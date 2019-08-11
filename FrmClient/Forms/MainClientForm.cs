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
    public delegate void ShowMsgDel(MessageInfo fromInfo);


    public partial class MainClientForm : BaseForm
    {
        private MessageInfo toInfo = new MessageInfo() { socket = SingleUtils.LOGINER.socket, fromUser = SingleUtils.LOGINER, fromId = SingleUtils.LOGINER.userId };
        private Form frmLogin;
        private Thread getMsgThread;
        private GGUserInfo fromUser = new GGUserInfo();
        private GGUserInfo toUser = new GGUserInfo();
        private UserInfoForm userInformationForm = new UserInfoForm();


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
                    int msgLength;
                    byte[] buffer = ToolUtils.GetByte(SingleUtils.LOGINER.socket, out msgLength);
                    string json = Encoding.UTF8.GetString(buffer, 0, msgLength);
                    MessageInfo fromInfo = null;
                    byte[] fileInfo = null;
                    try
                    {
                        fromInfo = SerializerUtil.JsonToObject<MessageInfo>(json);
                    }
                    catch (Exception ex)
                    {
                        fileInfo = Encoding.UTF8.GetBytes(json);
                    }
                    //接收文件
                    if (fileInfo != null)
                    {

                        MsgType msgType = (MsgType)fileInfo[0];
                        FileType fileType = (FileType)fileInfo[1];
                        SingleUtils.fileByteList.Add(new MessageInfo() { content = ToolUtils.GetFilePath() + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + fileType, fileLength = msgLength, msgType = msgType, fileType = fileType, buffer = fileInfo });
                        SingleUtils.isWPTD = true;
                    }
                    else
                    {

                        if (fromInfo.msgType == MsgType.创建分组 || fromInfo.msgType == MsgType.移动好友 || fromInfo.msgType == MsgType.删除好友 || fromInfo.msgType == MsgType.添加好友)
                        {
                            MessageBox.Show(fromInfo.content);
                            toInfo.msgType = MsgType.获取好友信息;
                            SocketUtils.SendToSingleClient(toInfo);
                        }
                        else if (fromInfo.msgType == MsgType.用户注册)
                        {
                            MessageBox.Show(fromInfo.content);
                        }
                        else if (fromInfo.msgType == MsgType.获取好友信息)
                        {
                            List<GGGroup> group = SerializerUtil.JsonToObject<List<GGGroup>>(fromInfo.content);
                            Thread loadFriendThread = new Thread(this.LoadFriends) { IsBackground = true };
                            loadFriendThread.Start(group);
                        }
                        else if (fromInfo.msgType == MsgType.上线 || fromInfo.msgType == MsgType.下线)
                        {
                            if (fromInfo.msgType == MsgType.上线 && fromInfo.fromId != SingleUtils.LOGINER.userId)
                            {
                                SoundUtils.SystemSound();
                            }
                            SingleUtils.FriendsStr = fromInfo.content;
                            // 1.客户端收到 有人上线 指令
                            // 2.向服务器发送[ 获取好友信息 ] 的请求
                            // 3.服务器向客户端反馈[ 获取好友信息 ] 的响应后，调用 this.LoadFriends(group);方法刷新好友数据
                            toInfo.msgType = MsgType.获取好友信息;
                            SocketUtils.SendToSingleClient(toInfo);
                        }
                        if (fromInfo.msgType == MsgType.私发文件 || fromInfo.msgType == MsgType.群发文件)
                        {
                            MessageBox.Show(fromInfo.msgType + "");
                        }
                        //将信息展现到 聊天面板
                        else if (fromInfo.msgType == MsgType.私聊 || fromInfo.msgType == MsgType.私发抖动 || fromInfo.msgType == MsgType.私发红包 || fromInfo.msgType == MsgType.系统消息)
                        {
                            GGUserInfo fromUser = fromInfo.fromUser;
                            GGUserInfo toUser = fromInfo.toUser;

                            //发送者和接收者反转显示
                            string chatFormKey = GGUserUtils.GetChatFormKey(toUser, fromUser);

                            //存在聊天窗口 
                            if (SingleUtils.chatForm.ContainsKey(chatFormKey))
                            {
                                ChatForm chatFrom = SingleUtils.chatForm[chatFormKey] as ChatForm;
                                if (chatFrom.showMsgDelMethod != null)
                                {
                                    chatFrom.WindowState = FormWindowState.Normal;
                                    chatFrom.showMsgDelMethod(fromInfo);
                                }
                            }
                            //不存在聊天窗口 
                            else
                            {
                                SoundUtils.NewestInfoCome();
                                //将信息添加到集合里面  
                                fromInfo.fromNoRead = 1;
                                SingleUtils.noReadDic.Add(fromUser, fromInfo);
                                if (fromInfo.msgType == MsgType.私发抖动 || fromInfo.msgType == MsgType.私发红包)
                                {
                                    Thread openChatWinThread = new Thread((obj) =>
                                    {
                                        MessageInfo tmpFromInfo = obj as MessageInfo;
                                        ChatForm chatForm = new ChatForm(tmpFromInfo.toUser, tmpFromInfo.fromUser);
                                        Application.Run(chatForm);
                                    }) { IsBackground = false };
                                    openChatWinThread.Start(fromInfo);
                                }
                                else
                                {
                                    SingleUtils.isQQTD = true;
                                }
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
                    MessageBox.Show("[" + SingleUtils.LOGINER.userNickName + "]在首页客户端 [ " + this.GetType() + this.Name + " ] 接收消息时报错:" + ex.Message);
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
        private void LoadFriends(object paramGroupList)
        {
            List<GGGroup> groupList = paramGroupList as List<GGGroup>;
            string friendsStr = "";
            List<GGGroup> friendsGroupList = new List<GGGroup>();
            friendsList.Items.Clear();
            friendsList.Groups.Clear();
            friendsList.Columns.Clear();
            friendsList.Clear();

            friendsList.Columns.Add(null, friendsList.Width - 10);

            notifyIcon1.Text = string.Format("QQ:{0}({1})\r\n声音:{2}\r\n消息提示:{3}\r\n会话消息:{4}", SingleUtils.LOGINER.userNickName, SingleUtils.LOGINER.userId, "未开启", "开启", "头像闪烁");

            ImageList imgList = new ImageList();
            this.friendsList.LargeImageList = this.friendsList.SmallImageList = imgList; // ImageList 属性 
            imgList.ImageSize = new Size(40, 40);
            if (groupList.Count > 0)
            {
                foreach (GGGroup group in groupList)
                {
                    friendsGroupList.Add(group);

                    ListViewGroup groupItem = new ListViewGroup(group.groupName + "(" + group.memberList.Count + ")");
                    this.friendsList.Groups.Add(groupItem);

                    if (!string.IsNullOrEmpty(group.members) && group.memberList.Count > 0)
                    {
                        foreach (GGUserInfo user in group.memberList)
                        {
                            ListViewItem friendItem = new ListViewItem(groupItem);
                            user.groupAutoId = group.groupAutoId;
                            //添加好友ID
                            friendsStr += user.userId + ",";
                            Image img = HeadImgUtils.ShowHeadImg(user);
                            imgList.Images.Add(user.userId, img);

                            friendItem.Tag = user;
                            friendItem.Name = user.userId;
                            friendItem.Font = new Font(friendItem.Font.FontFamily, 10, FontStyle.Regular);
                            friendItem.ForeColor = Color.Black;
                            friendItem.Text = "[" + (user.isOnLine ? "在线" : "离线") + "]" + user.userNickName + "(" + user.userId + ")" + Environment.NewLine + user.qqSign;
                            friendItem.SubItems.Add(user.userNickName);
                            friendItem.SubItems.Add(user.userId);
                            friendItem.ImageKey = user.userId;//设置头像  
                            this.friendsList.Items.Add(friendItem);
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
        private void InitMoveGroup(List<GGGroup> groupList)
        {
            this.moveToGroup.DropDownItems.Clear();
            foreach (GGGroup group in groupList)
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
            this.picHeadImg.Image = HeadImgUtils.ShowHeadImg(SingleUtils.LOGINER);
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



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (SingleUtils.isQQTD)
            {
                Thread t = new Thread(() =>
                {
                    notifyIcon1.Icon = ToolUtils.GetIcon("None64.ico");
                    System.Threading.Thread.Sleep(500);
                    notifyIcon1.Icon = ToolUtils.GetIcon("qq.ico");
                    System.Threading.Thread.Sleep(500);
                }) { IsBackground = true };
                t.Start();
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
            SingleUtils.isQQTD = false;
            try
            {
                Dictionary<GGUserInfo, MessageInfo> tmpNoReadDic = new Dictionary<GGUserInfo, MessageInfo>(SingleUtils.noReadDic);

                foreach (KeyValuePair<GGUserInfo, MessageInfo> item in tmpNoReadDic)
                {
                    GGUserInfo fromUser = item.Key;
                    MessageInfo fromInfo = item.Value;
                    string chatFormKey = GGUserUtils.GetChatFormKey(fromUser, SingleUtils.LOGINER);
                    ChatForm chatFrom = null;
                    if (SingleUtils.chatForm.ContainsKey(chatFormKey))
                    {
                        chatFrom = SingleUtils.chatForm[chatFormKey] as ChatForm;
                        chatFrom.WindowState = FormWindowState.Normal;

                    }
                    else
                    {
                        chatFrom = new ChatForm(SingleUtils.LOGINER, fromUser);
                        chatFrom.Show();
                    }
                    chatFrom.showMsgDelMethod(fromInfo);
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
            string sql = string.Format("SELECT * FROM [dbo].[{0}] where receiveId='{1}' and isRead=0 ", DBTUtils.DBT_NoReadMsg, SingleUtils.LOGINER.userId);
            DBHelper.Excute(string.Format("update [dbo].[{0}] set isRead=1 where receiveId='{1}' and isRead=0 ", DBTUtils.DBT_NoReadMsg, SingleUtils.LOGINER.userId));
            List<NoReadMsg> list = DBHelper.ConvertToModel<NoReadMsg>(sql);
            if (list.Count > 0)
            {
                SoundUtils.NewestInfoCome();
                SingleUtils.isQQTD = true;
            }
            foreach (NoReadMsg msg in list)
            {
                GGUserInfo fromUser = ChatDBUtils.GetPerInfoByUserId(msg.sendId);
                MessageInfo fromInfo = new MessageInfo();
                fromInfo.fromId = msg.sendId;
                fromInfo.toId = msg.receiveId;
                fromInfo.content = msg.content;
                fromInfo.msgType = msg.msgType;
                fromInfo.dateTime = msg.datetime;
                fromInfo.fromNoRead = 1;
                SingleUtils.noReadDic.Add(fromUser, fromInfo);

                //添加聊天记录
                ChatDBUtils.AddRecords(fromInfo);
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


            DialogResult dr = MessageBox.Show("确认删除" + GGUserUtils.ShowNickAndId(user) + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                toInfo.msgType = MsgType.删除好友;
                toInfo.toId = user.userAutoid.ToString();
                toInfo.toUser = user;
                toInfo.content = user.groupAutoId.ToString();
                SocketUtils.SendToSingleClient(toInfo);
            }
        }

        private void 查找好友ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddFriendFrm().Show();
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
                List<GGGroup> groupList = SingleUtils.FriendsGroupList.Where(i => i.groupAutoId != user.groupAutoId).ToList();
                this.InitMoveGroup(groupList);
            }
            catch (Exception ex)
            {
            }

        }
        Image im = null;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
            {
                im = this.wp.Image;
                if (SingleUtils.isWPTD)
                {
                    this.wp.Image = null;
                }
                Thread.Sleep(500);
                this.wp.Image = im;
                Thread.Sleep(500);
            }) { IsBackground = true };
            th.Start();
        }

        private void wp_Click(object sender, EventArgs e)
        {
            if (SingleUtils.frmFileList.IsDisposed)
            {
                SingleUtils.frmFileList = new frmFileList();
            }
            SingleUtils.frmFileList.Show();
            SingleUtils.frmFileList.ShowFileList();
        }

    }
}