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
using Common.model;
using Common.Utils;
using Common.enums;
using FrmClient.Utils;
using FrmClient.Forms;
using Common.Services;


namespace FrmClient
{
    //定义委托
    public delegate void ShowMsgDel(MessageInfo info);


    public partial class MainClientForm : BaseForm
    {
        private Form frmLogin;
        private Thread getMsgThread;
        private GGUserInfo fromUser = new GGUserInfo();
        private GGUserInfo toUser = new GGUserInfo();
        private UserInfoForm userInformationForm = new UserInfoForm();
        private MessageInfo toInfo = new MessageInfo() { socket = SingleUtils.LOGINER.socket, fromUser = SingleUtils.LOGINER, fromId = SingleUtils.LOGINER.userId };

        public MainClientForm(Form frmLogin)
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            Control.CheckForIllegalCrossThreadCalls = false;

            this.frmLogin = frmLogin;

            this.getMsgThread = new Thread(this.GetServerMsg) { IsBackground = true };
            this.getMsgThread.Start();
        }



        /// <summary>
        ///  客户端接收服务器发来的消息
        /// </summary>
        public void GetServerMsg()
        {
            while (true)
            {
                try
                {
                    string json = ToolUtils.GetString(SingleUtils.LOGINER.socket);
                    MessageInfo fromInfo = SerializerUtil.JsonToObject<MessageInfo>(json);
                    if (fromInfo.msgType == MsgType.创建分组 || fromInfo.msgType == MsgType.移动好友 || fromInfo.msgType == MsgType.删除好友 || fromInfo.msgType == MsgType.添加好友)
                    {
                        MessageBox.Show(fromInfo.content);
                        toInfo.msgType = MsgType.获取好友信息;
                        SocketUtils.SendToSingleClient(toInfo);
                    }
                    else if (fromInfo.msgType == MsgType.获取好友信息)
                    {
                        List<GGGroupInfo> group = SerializerUtil.JsonToObject<List<GGGroupInfo>>(fromInfo.content);
                        this.LoadFriends(group);
                    }
                    else if (fromInfo.msgType == MsgType.上线 || fromInfo.msgType == MsgType.下线)
                    {
                        if (fromInfo.msgType == MsgType.上线 && fromInfo.fromId != SingleUtils.LOGINER.userId)
                        {
                            SoundUtils.SystemSound();
                        }
                        // 1.客户端收到 有人上线 指令
                        // 2.向服务器发送[ 获取好友信息 ] 的请求
                        // 3.服务器向客户端反馈[ 获取好友信息 ] 的响应后，调用 this.LoadFriends(group);方法刷新好友数据
                        toInfo.msgType = MsgType.获取好友信息;
                        SocketUtils.SendToSingleClient(toInfo);
                    }
                    else if (fromInfo.msgType == MsgType.私聊)
                    {
                        SoundUtils.NewestInfoCome();
                    }

                    //将信息展现到 聊天面板
                    if (fromInfo.msgType == MsgType.私聊 || fromInfo.msgType == MsgType.私发抖动)
                    {
                        GGUserInfo fromUser = fromInfo.fromUser;
                        GGUserInfo toUser = fromInfo.toUser;

                        //发送者和接收者反转显示
                        string chatFormKey = GGUserUtils.GetChatFormKey(toUser, fromUser);

                        //存在聊天窗口 
                        if (SingleUtils.chatForm.ContainsKey(chatFormKey))
                        {
                            ChatForm chatFrom = SingleUtils.chatForm[chatFormKey] as ChatForm;
                            chatFrom.WindowState = FormWindowState.Normal;
                            SingleUtils.showMsgDelMethod(fromInfo);
                        }
                        //不存在聊天窗口 
                        else
                        {
                            //将信息添加到集合里面 
                            fromInfo.msgStateType = msgStateType.未读消息;
                            SingleUtils.noReadDic.Add(fromUser, fromInfo);
                            if (fromInfo.msgType == MsgType.私发抖动)
                            {
                                Thread openChatWinThread = new Thread(OpenChatWinThread) { IsBackground = false };
                                openChatWinThread.Start(fromInfo);
                            }
                            else
                            {
                                SingleUtils.isIconTD = true;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageInfo toInfo = new MessageInfo();
                    toInfo.msgType = MsgType.异常报告;
                    toInfo.content = "客户端接收服务器发来的消息报错   ex=" + ex.Message;
                    //this.showMsgDelMethod(toInfo);
                    iconHitTimer.Enabled = true;
                    iconHitTimer.Start();
                    //MessageBox.Show("[" + SingleUtils.LOGINER.userNickName + "]在首页客户端 [ " + this.GetType() + this.Name + " ] 接收消息时报错:" + ex.Message);
                    SoundUtils.playSound(toInfo.msgType + toInfo.content, EndPointEnum.PC端);
                    break;
                }

            }
        }

        /// <summary>
        /// 打开新的聊天窗口
        /// </summary>
        /// <param name="obj"></param>
        private void OpenChatWinThread(object obj)
        {
            MessageInfo fromInfo = obj as MessageInfo;
            ChatForm chatForm = new ChatForm(fromInfo.toUser, fromInfo.fromUser);
            Application.Run(chatForm);

        }


        /// <summary>
        /// 加载好友信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFriends(List<GGGroupInfo> groupList)
        {
            string friendsStr = "";
            List<GGGroupInfo> friendsGroupList = new List<GGGroupInfo>();
            friendsList.Items.Clear();
            friendsList.Groups.Clear();
            friendsList.Columns.Clear();
            friendsList.Clear();

            friendsList.Columns.Add(null, friendsList.Width - 10);

            notifyIcon1.Text = string.Format("QQ:{0}({1})\r\n声音:{2}\r\n消息提示:{3}\r\n会话消息:{4}", SingleUtils.LOGINER.userNickName, SingleUtils.LOGINER.userId, "未开启", "开启", "头像闪烁");

            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(40, 40);
            if (groupList.Count > 0)
            {
                foreach (GGGroupInfo group in groupList)
                {
                    friendsGroupList.Add(group);

                    ListViewGroup groupItem = new ListViewGroup(group.groupName);
                    friendsList.Groups.Add(groupItem);
                    if (string.IsNullOrEmpty(group.members) || group.memberList.Count <= 0)
                    {
                        ListViewItem friendItem = new ListViewItem(groupItem);
                        friendsList.Items.Add(friendItem);
                    }
                    else if (!string.IsNullOrEmpty(group.members) && group.memberList.Count > 0)
                    {

                        List<GGUserInfo> userList = group.memberList;
                        foreach (GGUserInfo user in userList)
                        {
                            user.groupAutoId = group.groupAutoId;
                            friendsStr += user.userId + ",";
                            Image img = Image.FromFile(SingleUtils.userImgPath + user.userImg);
                            if (user.isOnLine)
                            {
                                imgList.Images.Add(user.userId, img);
                            }
                            else
                            {
                                imgList.Images.Add(user.userId, ImageUtils.GetGrayImg(img));
                            }

                            friendsList.LargeImageList = friendsList.SmallImageList = imgList; // ImageList 属性 

                            ListViewItem friendItem = new ListViewItem(groupItem);
                            friendItem.Tag = user;
                            friendItem.Name = user.userId;
                            friendItem.Font = new Font(friendItem.Font.FontFamily, 10, FontStyle.Regular);
                            friendItem.ForeColor = Color.Black;
                            friendItem.Text = "[" + (user.isOnLine ? "在线" : "离线") + "]" + user.userNickName + "(" + user.userId + ")" + Environment.NewLine + user.qqSign;
                            friendItem.SubItems.Add(user.userNickName);
                            friendItem.SubItems.Add(user.userId);
                            friendItem.ImageKey = user.userId;//设置头像 

                            friendsList.Items.Add(friendItem);

                        }
                    }
                }
            }

            SingleUtils.FriendsStr = friendsStr;
            SingleUtils.FriendsGroupList = friendsGroupList;


            this.InitMoveGroup(SingleUtils.FriendsGroupList);

        }

        /// <summary>
        /// 初始化分组选项
        /// </summary>
        private void InitMoveGroup(List<GGGroupInfo> groupList)
        {
            this.moveToGroup.DropDownItems.Clear();
            foreach (GGGroupInfo group in groupList)
            {
                ToolStripItem item = this.moveToGroup.DropDownItems.Add(group.groupName);
                item.Tag = group.groupAutoId;
                item.Click += MainClientForm_Click;
            }
        }

        /// <summary>
        /// 移动好友
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainClientForm_Click(object sender, EventArgs e)
        {


            ToolStripItem toolStripItem = sender as ToolStripItem;
            string newGroupAutoId = toolStripItem.Tag.ToString();

            DialogResult dr = MessageBox.Show("确定将该好友移动到[" + toolStripItem.Text + newGroupAutoId + "]", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                ListViewItem lvi = this.friendsList.SelectedItems[0] as ListViewItem;
                GGUserInfo user = lvi.Tag as GGUserInfo;

                toInfo.msgType = MsgType.移动好友;
                toInfo.oldGroupAutoId = user.groupAutoId.ToString();
                toInfo.newGroupAutoId = newGroupAutoId;
                toInfo.toId = user.userAutoid.ToString();
                SocketUtils.SendToSingleClient(toInfo);
            }



        }

        /// <summary>
        /// 初始化个人信息
        /// </summary>
        private void InitPerInfo()
        {
            this.picHeadImg.Image = Image.FromFile(SingleUtils.userImgPath + SingleUtils.LOGINER.userImg);
            this.lblNickName.Text = GGUserUtils.GetNickAndId(SingleUtils.LOGINER);
            this.lblQQSign.Text = SingleUtils.LOGINER.qqSign;
            this.Text = SingleUtils.LOGINER.socket.RemoteEndPoint + "";
        }


        /// <summary>
        /// 下线
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.notifyIcon1.Dispose();
            toInfo.msgType = MsgType.下线;
            SocketUtils.SendToSingleClient(toInfo);
            //Application.Exit();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }


        private void MainForm_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (SingleUtils.isIconTD)
            {
                Thread t = new Thread(IconHit) { IsBackground = true };
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
                notifyIcon1.Icon = new Icon(ToolUtils.GetRootPath(@"\Images\Icon\None64.ico"));
                System.Threading.Thread.Sleep(500);
                notifyIcon1.Icon = new Icon(ToolUtils.GetRootPath(@"\Images\Icon\qq.ico"));
                System.Threading.Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                toInfo.msgType = MsgType.异常报告;
                toInfo.content = "托盘膳闪烁的线程报错：" + ex.Message;
                SoundUtils.playSound("", EndPointEnum.PC端);
                // Application.Exit();
            }

        }

        /// <summary>
        /// 显示基本信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void friendsList_MouseEnterHead(object sender, ChatListEventArgs e)
        {
            int top = 0;// this.Top + this.friendsList.Top + (e.MouseOnSubItem.HeadRect.Y - this.friendsList.chatVScroll.Value);
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


        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// 选择好友私聊
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void friendsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = friendsList.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                GGUserInfo receiveUser = (info.Item as ListViewItem).Tag as GGUserInfo;
                string chatFormKey = GGUserUtils.GetChatFormKey(SingleUtils.LOGINER, receiveUser);
                if (SingleUtils.chatForm.ContainsKey(chatFormKey))
                {
                    ChatForm cf = SingleUtils.chatForm[chatFormKey] as ChatForm;
                    cf.WindowState = FormWindowState.Normal;
                }
                else
                {
                    new ChatForm(SingleUtils.LOGINER, receiveUser).Show();
                }
            }
        }

        private void MainClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            toInfo.msgType = MsgType.下线;
            SocketUtils.SendToSingleClient(toInfo);
            //Application.Exit();
        }

        /// <summary>
        /// 弹窗显示好好友信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void friendsList_MouseEnter(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = friendsList.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
            }
        }



        /// <summary>
        /// 切换账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin.Show();
        }

        /// <summary>
        /// 双击notifyIcon显示聊天面板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SingleUtils.isIconTD = false;
            try
            {
                Dictionary<GGUserInfo, MessageInfo> tmpNoReadDic = new Dictionary<GGUserInfo, MessageInfo>(SingleUtils.noReadDic);

                foreach (KeyValuePair<GGUserInfo, MessageInfo> item in tmpNoReadDic)
                {
                    GGUserInfo fromUser = item.Key;
                    MessageInfo fromInfo = item.Value;
                    string chatFormKey = GGUserUtils.GetChatFormKey(SingleUtils.LOGINER, fromUser);

                    if (SingleUtils.chatForm.ContainsKey(chatFormKey))
                    {
                        ChatForm chatFrom = SingleUtils.chatForm[chatFormKey] as ChatForm;
                        chatFrom.WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        new ChatForm(SingleUtils.LOGINER, fromUser).Show();
                    }
                    SingleUtils.showMsgDelMethod(fromInfo);
                }
                SingleUtils.noReadDic.Clear();
            }
            catch (Exception ex)
            {
                SoundUtils.playSound("notifyIcon1_MouseDoubleClick [ 异常：" + ex.Message + " ]", EndPointEnum.PC端);
                //MessageBox.Show("notifyIcon1_MouseDoubleClick [ 异常：" + ex.Message + " ]");
            }

        }

        /// <summary>
        /// 选择tab显示相关信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = tabControl1.SelectedIndex;
            //选择tab显示已经打开的聊天窗口
            if (selectedIndex == 1)
            {
                this.chatFromList.Items.Clear();
                foreach (string user in SingleUtils.chatForm.Keys)
                {
                    ListViewItem item = new ListViewItem(user);
                    this.chatFromList.Items.Add(item);
                }
            }
            else if (selectedIndex == 2)
            {
                this.noReadMsgList.Items.Clear();
                foreach (KeyValuePair<GGUserInfo, MessageInfo> user in SingleUtils.noReadDic)
                {
                    GGUserInfo tmpUser = user.Key;
                    MessageInfo tmpMsg = user.Value;
                    string msg = tmpUser.userNickName + ":[" + tmpMsg.msgType + "]" + tmpMsg.content;
                    ListViewItem item = new ListViewItem(msg);
                    this.noReadMsgList.Items.Add(item);
                }
            }
        }

        private void MainClientForm_Load(object sender, EventArgs e)
        {
            this.GetNoReadMsg();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.InitPerInfo();
        }
        /// <summary>
        /// 获取未读信息
        /// </summary>
        private void GetNoReadMsg()
        {
            string sql = "SELECT * FROM [dbo].[ChatMessageRecord] where receiveId='" + SingleUtils.LOGINER.userId + "' and isRead=0 ";

            List<ChatMessageRecord> list = DBHelper.ConvertToModel<ChatMessageRecord>(sql);
            if (list.Count > 0)
            {
                SoundUtils.NewestInfoCome();
                SingleUtils.isIconTD = true;
            }
            foreach (ChatMessageRecord msg in list)
            {
                GGUserInfo fromUser = ChatDBUtils.GetPerInfoByUserId(msg.sendId);
                MessageInfo fromInfo = new MessageInfo();
                fromInfo.fromId = msg.sendId;
                fromInfo.toId = msg.receiveId;
                fromInfo.content = msg.content;
                fromInfo.msgType = msg.msgType;
                fromInfo.dateTime = msg.datetime;
                SingleUtils.noReadDic.Add(fromUser, fromInfo);
            }
        }




        /// <summary>
        /// 查找好友并添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }


        private void 删除好友ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListViewItem item = this.friendsList.SelectedItems[0];
            GGUserInfo user = item.Tag as GGUserInfo;


            DialogResult dr = MessageBox.Show(user.groupAutoId + "确认删除" + GGUserUtils.ShowNickAndId(user) + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                toInfo.msgType = MsgType.删除好友;
                toInfo.toId = user.userId;
                toInfo.content = user.groupAutoId.ToString();
                SocketUtils.SendToSingleClient(toInfo);
            }
        }

        private void 查找好友ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingleUtils.OpenForm("查找好友ToolStripMenuItem_Click", new AddFriendFrm());
        }

        private void 创建群ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new CreateGroupFrm().Show();

        }

        /// <summary>
        /// 不显示当前所在分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveToGroup_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                ListViewItem lvi = this.friendsList.SelectedItems[0] as ListViewItem;
                GGUserInfo user = lvi.Tag as GGUserInfo;
                List<GGGroupInfo> groupList = SingleUtils.FriendsGroupList.Where(i => i.groupAutoId != user.groupAutoId).ToList();
                this.InitMoveGroup(groupList);
            }
            catch (Exception ex)
            {
            }

        }

    }
}
