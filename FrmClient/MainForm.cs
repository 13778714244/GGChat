using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using CCWin.SkinControl;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net;
using FrmClient.Properties;

namespace FrmClient
{
    //定义委托
    public delegate void GetServerMsgDel(MsgType msgType, string serverMsg, RtfRichTextBox.RtfColor color, bool isRtf);
    public partial class MainForm : BaseForm
    {
        public GetServerMsgDel GetServerMsgDel;
        private Form frmLogin;
        private GGUserInfo user;
        private Tools tools = new Tools();
        private Thread getMsgThread;
        public bool isExistsChatForm = true;
        public bool isShowPanel = false;
        public Dictionary<GGUserInfo, string> notReadMsg_list = new Dictionary<GGUserInfo, string>();
        public List<ChatForm> chatForm_list = new List<ChatForm>();
        private string content;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(Form frmLogin, GGUserInfo user)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            Control.CheckForIllegalCrossThreadCalls = false;
            this.user = user;
            //this.Text = "欢迎您【" + user.userNickName + "】，连接到" + user.serverIP + "的" + user.point + "端口";
            this.Text = user.serverIP + "  " + user.serverPoint;
            user.UserSocket.Connect(user.iPEndPoint);
            user.UserSocket.Send(tools.StrToByte(user.userNickName));
            getMsgThread = new Thread(GetServerMsg);
            getMsgThread.IsBackground = true;
            getMsgThread.Start();
        }


        #region 客服端接收接受消息
        public void GetServerMsg()
        {
            while (true)
            {
                try
                {
                    if (!user.UserSocket.Connected)
                    {
                        MessageBox.Show(user.userNickName + "链接断了，被迫强制关闭程序");
                        Application.Exit();
                        break;
                    }
                    int length;
                    byte[] obj = tools.GetSocketMsg(user.UserSocket, out length);
                    MsgType msgType = tools.GetMsgType(obj);
                    byte[] contentBytes = tools.GetMsgContent(obj);
                    string msgContent = tools.ByteToStr(contentBytes);
                    content = msgContent;

                    if (msgType == MsgType.群发抖动)
                    {
                        ServerMsgToChatRecords(msgType, msgContent);
                    }
                    else
                    {
                        #region 播放声音
                        if (msgType != MsgType.系统信息)
                        {
                            tools.playWmv(false);
                        }
                        else
                        {
                            tools.playWmv(true);
                        }
                        #endregion
                        ServerMsgToChatRecords(msgType, msgContent);
                    }
                }
                catch (Exception ex)
                {
                    iconHitTimer.Enabled = true;
                    iconHitTimer.Start();
                    MessageBox.Show("[" + user.userNickName + "]在首页客服端接收消息时报错:" + ex.Message);
                    break;
                }
            }
        }
        #endregion

        #region 将服务器发来的信息追加到ChatForm聊天记录里面
        public void ServerMsgToChatRecords(MsgType msgType, string msgContent, RtfRichTextBox.RtfColor color = RtfRichTextBox.RtfColor.SeaGreen, bool isRtf = true)
        {
            if (GetServerMsgDel == null)
            {
                isExistsChatForm = false;
                isShowPanel = true;
                //将信息添加到集合里面
                notReadMsg_list.Add(new GGUserInfo() { userNickName = user.userNickName, userImg = "1.png" }, msgContent);
            }
            else
            {
                GetServerMsgDel(msgType, msgContent, color, isRtf);
            }
        }
        #endregion

        public void ShowPanel()
        {

            foreach (GGUserInfo user in notReadMsg_list.Keys)
            {
                ChatListItem cItem = new ChatListItem(user.userNickName);

                ChatListSubItem.UserStatus state = ChatListSubItem.UserStatus.DontDisturb;
                Image img = Image.FromFile(tools.substringFromLast(Application.StartupPath, @"\", 2, @"\Images\userImg\") + user.userImg);
                ChatListSubItem csItem = new ChatListSubItem("", "", user.userNickName, "", state, img);
                cItem.SubItems.Add(csItem);
                friendsList.Items.Add(cItem);
            }
        }


        /// <summary>
        /// 加载好友信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            notifyIcon1.Text = string.Format("QQ:{0}({1})\r\n声音:{2}\r\n消息提示:{3}\r\n会话消息:{4}", user.userNickName, user.userId, "未开启", "开启", "头像闪烁");
            this.Location = frmLogin.Location;
            user = this.Tag as GGUserInfo;
            userImg.BackgroundImage = Image.FromFile(tools.substringFromLast(Application.StartupPath, @"\", 2, @"\Images\userImg\") + user.userImg);
            nickName.Text = user.userNickName;
            QQSign.Text = user.qqSign;

            //得到分组
            string sql = string.Format("select groupName, members from GGGroup where createId='{0}'", user.userId);
            DataTable dt = DBHelper.Select(sql);
            friendsList.Items.Clear();
            foreach (DataRow group in dt.Rows)
            {
                ChatListItem cItem = new ChatListItem(group["groupName"].ToString());
                if (!string.IsNullOrEmpty(group["members"].ToString()))
                {
                    sql = string.Format("select userId,userNickName,qqSign,userImg from GGUser where userAutoid in({0})", group["members"]);
                    dt = DBHelper.Select(sql);
                    foreach (DataRow friend in dt.Rows)
                    {
                        ChatListSubItem.UserStatus state = ChatListSubItem.UserStatus.DontDisturb;
                        Image img = Image.FromFile(tools.substringFromLast(Application.StartupPath, @"\", 2, @"\Images\userImg\") + friend["userImg"]);
                        ChatListSubItem csItem = new ChatListSubItem(friend["userId"].ToString(), "00", friend["userNickName"].ToString(), friend["qqSign"].ToString(), state, img);
                        cItem.SubItems.Add(csItem);
                        friendsList.Items.Add(cItem);
                    }
                }
            }
        }


        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
            tools.ClientendMsgToServer(user.UserSocket, Convert.ToByte(MsgType.下线), user.userNickName + "|" + user.userNickName + "下线了");
            Application.Exit();
        }



        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 私聊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void friendsList_DoubleClickSubItem(object sender, ChatListEventArgs e)
        {
            ChatListSubItem item = e.SelectSubItem;
            item.IsTwinkle = false;
            string name = item.DisplayName;
            GGUserInfo receiveUser = new GGUserInfo() { userNickName = name, iPEndPoint = new IPEndPoint(IPAddress.Parse("10.10.19.5"), new Random().Next(1000, 9999)) };
            ChatForm f = new ChatForm(user, receiveUser, this);
            f.Show();
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!isExistsChatForm)
            {
                Thread t = new Thread(IconHit);
                t.IsBackground = true;
                t.Start();
            }
        }
        /// <summary>
        /// 托盘闪烁
        /// </summary>
        private void IconHit()
        {
            try
            {
                notifyIcon1.Icon = new Icon(tools.GetRootPath(@"\Images\Icon\None64.ico"));
                System.Threading.Thread.Sleep(500);
                notifyIcon1.Icon = new Icon(tools.GetRootPath(@"\Images\Icon\qq.ico"));
                System.Threading.Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Application.Exit();
            }

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
        UserInfoForm userInformationForm = new UserInfoForm();

        /// <summary>
        /// 显示基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void friendsList_MouseEnterHead(object sender, ChatListEventArgs e)
        {
            int top = this.Top + this.friendsList.Top + (e.MouseOnSubItem.HeadRect.Y - this.friendsList.chatVScroll.Value);
            int left = this.Left - 279 - 5;
            int ph = Screen.GetWorkingArea(this).Height;

            if (top + 181 > ph)
            {
                top = ph - 181 - 5;
            }

            if (left < 0)
            {
                left = this.Right + 5;
            }
            if (userInformationForm != null)
            {
                this.userInformationForm.Location = new Point(left, top);
                this.userInformationForm.Tag = new GGUserInfo() { userNickName = "匿名", qqSign = "我的世界自己主宰！！！", userImg = "3.png" };
                this.userInformationForm.Show();
            }
        }
        //隐藏基本信息
        private void friendsList_MouseLeaveHead(object sender, ChatListEventArgs e)
        {
            userInformationForm.Hide();
        }
        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void friendsList_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private System.Threading.Timer formClose;

        private void showmsgWinTimer_Tick(object sender, EventArgs e)
        {
            if (isShowPanel)
            {

                int x = Screen.PrimaryScreen.WorkingArea.Width;
                int y = Screen.PrimaryScreen.WorkingArea.Height;
                NotReadMsgForm f = new NotReadMsgForm(content);
                f.Text = "x=" + x + "  y=" + y;
                f.Show();
                formClose = new System.Threading.Timer(new TimerCallback(timerCall), f, 3000, 0);
                f.Location = new Point(x - f.Width, y - f.Height);
                isShowPanel = false;
            }
        }
        private void timerCall(object obj)
        {
            formClose.Dispose();
            //(obj as Form).Close();
        }


        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }


    }
}
