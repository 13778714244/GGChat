using CCWin;
using CCWin.SkinControl;
using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.Serialization;
using FrmServer.Utils;
using Common.enums;
using Common.Utils;
using Common.Services;
using Common.model;



namespace FrmServer
{
    public partial class MainServerForm : CCSkinMain
    {
        private Socket serverSocket = null;
        private delegate void ServerDelegate(object str);
        private MessageInfo toInfo = new MessageInfo() { msgType = MsgType.系统消息, fromId = "服务器" };


        public MainServerForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            Control.CheckForIllegalCrossThreadCalls = false;
        }



        #region 服务端接受连接的客户端
        public void GetClientConnection()
        {
            try
            {
                while (true)
                {
                    //1. 服务器接收客户端发来的身份信息
                    //2. 根据发来的信息进行账号验证
                    //3. 反馈给客户端
                    Socket clientSocket = serverSocket.Accept();
                    string nameAndPwd = ToolUtils.GetString(clientSocket);
                    MessageInfo fromInfo = SerializerUtil.JsonToObject<MessageInfo>(nameAndPwd);
                    string sql = string.Format("select * from GGUser where userId='{0}' and userPwd='{1}'", fromInfo.fromId, fromInfo.fromPwd);
                    List<GGUserInfo> userList = DBHelper.ConvertToExtModel<GGUserInfo>(sql);

                    toInfo.socket = clientSocket;
                    toInfo.dateTime = DateTime.Now;
                    if (userList.Count == 1)
                    {
                        GGUserInfo user = userList[0];
                        if (OnlineUserUtils.GetAllOnlineClients().ContainsKey(user.userId))
                        {
                            toInfo.msgType = MsgType.已登录;
                            toInfo.content = GGUserUtils.ShowNickAndId(user) + "已登录";
                            SocketUtils.SendToSingleClient(toInfo);
                        }
                        else
                        {
                            user.socket = clientSocket;
                            //保存用户信息
                            OnlineUserUtils.AddOnlineClient(user.userId, user);
                            //保存在线客户端用户的ids
                            ChatDBUtils.onlineUserStr = OnlineUserUtils.GetOnlineUserStr();
                            //刷新用户    
                            RefreshOnLineUser();
                            //服务器反馈客户端                            
                            toInfo.msgType = MsgType.登陆成功;
                            toInfo.content = SerializerUtil.ObjectToJson<GGUserInfo>(user);
                            SocketUtils.SendToSingleClient(toInfo);
                            //在服务器面板显示记录
                            ServerDelegate temp = msg =>
                            {
                                toInfo.msgType = MsgType.系统消息;
                                toInfo.content = "[ " + msg + "连接到服务器 ]   <--->   " + GGUserUtils.ShowNickAndId(user) + "进入了聊天室";
                                //显示到服务器端
                                ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                            };
                            serverChatRecords.Invoke(temp, clientSocket.RemoteEndPoint);
                            //聊天线程
                            ServerThread myThread = new ServerThread(user, this.serverChatRecords, this.cmbUserList, this.label6);

                            //上线提醒其他客户端
                            toInfo.msgType = MsgType.上线;
                            toInfo.fromId = user.userId;
                            //获取好友列表
                            List<GGGroup> group = ChatDBUtils.GetGroupFriendsInfo(user.userId);
                            List<GGUserInfo> friendList = ChatDBUtils.GetFriendsInfo(user.userId);
                            //同时通知自己
                            friendList.Add(user);
                            toInfo.content = ChatDBUtils.GetPerFriendsStr(user.userId);
                            SocketUtils.SendToOnlineFriendClients(OnlineUserUtils.GetAllOnlineClients(), friendList, toInfo);
                            //SocketUtils.SendToMultiClients(OnlineUserUtils.GetAllOnlineClients(), toInfo);

                            toInfo.content = GGUserUtils.ShowNickAndId(user) + "上线，需通知其好友 " + ChatDBUtils.GetPerOnlineFriendsStr(user.userId) + " 刷新在线好友状态";
                            //显示到客户端
                            ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                        }
                    }
                    else if (userList.Count == 0)
                    {
                        toInfo.msgType = MsgType.登陆失败;
                        toInfo.content = "登陆失败，未找到账号";
                        SocketUtils.SendToSingleClient(toInfo);
                    }
                    else
                    {
                        toInfo.msgType = MsgType.登陆失败;
                        toInfo.content = "登陆失败，找到多个账号";
                        SocketUtils.SendToSingleClient(toInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageInfo toInfo = new MessageInfo();
                toInfo.msgType = MsgType.异常报告;
                toInfo.content = "服务端[" + this.GetType() + this.Name + "]接受连接的客户端:" + ex.Message;
                ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                //MessageBox.Show("服务端[" + this.GetType() + this.Name + "]接受连接的客户端:" + ex.Message);
            }
        }
        #endregion

        #region 获取本地IP
        private void button4_Click(object sender, EventArgs e)
        {
            cmbIPs.Items.Clear();
            IPAddress[] addressArr = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress item in addressArr)
            {
                if (item.ToString().Contains("."))
                {
                    cmbIPs.Items.Add(item);
                }
            }
            if (cmbIPs.Items.Count > 0)
            {
                cmbIPs.SelectedIndex = 0;
            }
        }
        #endregion

        #region 选择通信IP
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIPs.Items.Count > 0)
            {
                txtIP.Text = cmbIPs.SelectedItem.ToString();
            }
        }
        #endregion

        #region 启动服务器
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (serverSocket != null)
                {
                    serverSocket.Close();
                }

                string IP = txtIP.Text.Trim();
                string point = txtPoint.Text.Trim();
                IPAddress serverIP = IPAddress.Parse(IP);
                IPEndPoint serverPoint = new IPEndPoint(serverIP, Convert.ToInt32(point));
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                toInfo.socket = serverSocket;
                serverSocket.Bind(serverPoint);
                serverSocket.Listen(0);

                toInfo.content = serverPoint + "服务已启动";
                ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);

                Thread listenThread = new Thread(GetClientConnection);
                listenThread.IsBackground = true;
                listenThread.Start();
                button1.Text = "重新启动";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        #endregion



        #region  停止服务器
        private void button7_Click(object sender, EventArgs e)
        {
            if (serverSocket != null)
            {
                serverSocket.Close();
            }
            MessageInfo info = new MessageInfo() { content = "服务器已停止" };
            //显示到服务器端
            ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, info);
        }
        #endregion

        #region 发布系统公告
        private void button2_Click(object sender, EventArgs e)
        {
            string msg = serverMsgContent.Rtf;
            if (msg != "")
            {
                toInfo.content = msg;
                //显示到服务器端
                ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                //发送到客户端
                SocketUtils.SendToMultiClients(OnlineUserUtils.GetAllOnlineClients(), toInfo);
            }
            serverMsgContent.ResetText();
        }
        #endregion

        #region 踢人
        private void button5_Click(object sender, EventArgs e)
        {
            string name = cmbUserList.Text;
            try
            {
                if (OnlineUserUtils.GetAllOnlineClients().Count > 0)
                {
                    string userId = cmbUserList.SelectedText;
                    GGUserInfo user = OnlineUserUtils.GetSingleOnlineClient(userId);


                    toInfo.msgType = MsgType.踢出聊天室;
                    toInfo.content = GGUserUtils.ShowNickAndId(user) + "被踢出聊天室";
                    //显示到服务器端
                    ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                    //发送到客户端
                    SocketUtils.SendToMultiClients(OnlineUserUtils.GetAllOnlineClients(), toInfo);
                    //客户端下线
                    OnlineUserUtils.RemoveOnlineClient(user.userId);
                    //刷新客户端
                    this.RefreshOnLineUser();
                }
            }
            catch (Exception ex)
            {
                toInfo.msgType = MsgType.异常报告;
                toInfo.content = "踢人下线时抛出异常：" + ex.Message;
                //显示到服务器端
                ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                //刷新客户端
                this.RefreshOnLineUser();
            }
        }
        #endregion

        #region 手动刷新在线用户
        private void button6_Click(object sender, EventArgs e)
        {
            //刷新客户端
            this.RefreshOnLineUser();
        }
        #endregion

        #region 刷新用户的方法
        public void RefreshOnLineUser()
        {
            ServerDelegate temp = str =>
            {
                cmbUserList.Items.Clear();
                foreach (KeyValuePair<string, GGUserInfo> user in OnlineUserUtils.GetAllOnlineClients())
                {
                    cmbUserList.Items.Add(user.Key);
                }
                if (cmbUserList.Items.Count > 0)
                {
                    //cmbUserList.SelectedItem = UserUtils.onlineUserListDir.;
                }
                else if (cmbUserList.Items.Count == 0)
                {
                    cmbUserList.Text = string.Empty;
                }

            };
            cmbUserList.Invoke(temp, "");

            temp = count =>
            {
                label6.Text = "当前在线用户人数:" + count + "人";
            };
            label6.Invoke(temp, cmbUserList.Items.Count);
            notifyIcon1.Text = string.Format("服务器IP:{0}\r\n端口号:{1}\r\n在线人数:{2}", txtIP.Text, txtPoint.Text, OnlineUserUtils.GetAllOnlineClients().Count);
        }
        #endregion

        #region 禁言
        private void button8_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, GGUserInfo> item in OnlineUserUtils.GetAllOnlineClients())
            {
                string index = cmbUserList.SelectedText;
                GGUserInfo GGUserInfo = OnlineUserUtils.GetSingleOnlineClient(index);
                GGUserInfo user = item.Value;
                if (user.userId == GGUserInfo.userId)
                {
                    toInfo.msgType = MsgType.开启禁言;
                    toInfo.content = GGUserInfo.userNickName + "已被禁言";
                    //显示到服务器端
                    ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                    //发送给其他客户端
                    toInfo.content = "系统:你已被禁言";
                    SocketUtils.SendToMultiClients(OnlineUserUtils.GetAllOnlineClients(), toInfo);
                    this.RefreshCanSpeak();
                    break;
                }
            }
        }
        #endregion

        #region 解除禁言
        private void button9_Click(object sender, EventArgs e)
        {
            string index = this.cmbUserList.SelectedText;
            GGUserInfo GGUserInfo = OnlineUserUtils.GetSingleOnlineClient(index);
            toInfo.msgType = MsgType.解除禁言;
            toInfo.content = GGUserInfo.userNickName + "可以发言了";
            //显示到服务器端
            ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
            //发送给其他客户端
            toInfo.content = "系统:你可以发言了";
            SocketUtils.SendToSingleClient(toInfo);

        }
        #endregion

        #region 服务器私聊
        private void button10_Click(object sender, EventArgs e)
        {
            string content = this.serverMsgContent.Text;
            string name = cmbUserList.Text;
            GGUserInfo toUser = OnlineUserUtils.GetSingleOnlineClient(name);

            toInfo.content = content;
            toInfo.toId = toUser.userId;
            toInfo.toUser = toUser;
            //显示到服务器端
            ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
            //发送给其他客户端 
            SocketUtils.SendToSingleClient(toInfo);

        }
        #endregion

        #region 选择文件
        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择要发送的文件";
            ofd.Filter = "所有文件|*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;
            }
        }
        #endregion

        #region 私送文件
        private void button12_Click(object sender, EventArgs e)
        {
            string index = cmbUserList.SelectedText;
            if (string.IsNullOrEmpty(index))
            {
                MessageBox.Show("请选择用户");
                return;
            }
            string path = textBox2.Text;
            string extendName = Path.GetExtension(path);
            FileType fileType = FileUtils.GetFileExtendName(extendName);

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                foreach (KeyValuePair<string, GGUserInfo> item in OnlineUserUtils.GetAllOnlineClients())
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    int fileLength = fs.Read(buffer, 0, buffer.Length);
                    GGUserInfo user = OnlineUserUtils.GetSingleOnlineClient(index);

                    toInfo.msgType = MsgType.私发文件;
                    toInfo.content = "系统给" + GGUserUtils.ShowNickAndId(user) + "发送了文件";
                    toInfo.fileType = fileType;
                    toInfo.buffer = buffer;
                    toInfo.fileLength = fileLength;
                    toInfo.toId = user.userId;
                    toInfo.toUser = user;
                    //显示到服务器端
                    ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                    //发送给其他客户端 
                    SocketUtils.SendFileToSingleClient(toInfo);
                    //ToolUtils.ServerSendMsgToClients(GGUserInfo.UserSocket1, Convert.ToByte(MsgType.私发文件), "", Convert.ToByte(fileType), buffer, fileLength);
                }
            }
        }
        #endregion

        #region  群发文件
        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                string path = textBox2.Text;
                if (string.IsNullOrEmpty(path))
                {
                    return;
                }
                string fileContent = File.ReadAllText(path, Encoding.Default);
                string fileName = Path.GetFileName(path);

                toInfo.msgType = MsgType.群发文件;
                toInfo.content = "系统给所有人发送了文件 [ " + fileName + " ] ";
                //显示到服务器端
                ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                //发送给其他客户端 
                SocketUtils.SendFileToMutilClient(OnlineUserUtils.GetAllOnlineClients(), toInfo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("群发文件" + ex.Message);
            }
        }
        #endregion



        #region 选择通信IP地址
        private void cmbIPs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbIPs.Items.Count > 0)
            {
                txtIP.Text = cmbIPs.SelectedItem.ToString();
            }
        }
        #endregion

        #region 退出服务
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                foreach (KeyValuePair<string, GGUserInfo> item in OnlineUserUtils.GetAllOnlineClients())
                {
                    toInfo.msgType = MsgType.关闭服务器;
                    toInfo.content = "服务器已关闭 ";
                    //显示到服务器端
                    ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                    //发送个所有客户端
                    SocketUtils.SendToMultiClients(OnlineUserUtils.GetAllOnlineClients(), toInfo);
                }
                this.notifyIcon1.Visible = false;
                this.notifyIcon1.Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }


            string file = Application.StartupPath + @"\FrmClient.exe";
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                string name = p.ProcessName;

                if (name == (this.GetType().Namespace))
                {
                    p.Kill();
                }
            }
        }
        #endregion

        #region 判断选中的用户禁言状态
        private void cmbUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string index = cmbUserList.SelectedItem.ToString();
            if (string.IsNullOrEmpty(index))
            {
                return;
            }
            GGUserInfo GGUserInfo = OnlineUserUtils.GetSingleOnlineClient(index);
            button8.Enabled = !GGUserInfo.canSpeak;
            button9.Enabled = !button8.Enabled;
        }
        #endregion

        #region  刷新发言状态的方法
        private void RefreshCanSpeak()
        {
            string index = cmbUserList.SelectedItem.ToString();
            if (string.IsNullOrEmpty(index))
            {
                return;
            }
            GGUserInfo GGUserInfo = OnlineUserUtils.GetSingleOnlineClient(index);
            GGUserInfo.canSpeak = !GGUserInfo.canSpeak;
            button8.Enabled = !GGUserInfo.canSpeak;
            button9.Enabled = !button8.Enabled;
        }
        #endregion




        #region 自动启动服务器
        private void MainForm_Load(object sender, EventArgs e)
        {
            Dictionary<string, GGUserInfo> userList = OnlineUserUtils.GetAllOnlineClients();
            notifyIcon1.ShowBalloonTip(1, "提示", "服务已启动", ToolTipIcon.None);
            notifyIcon1.Text = string.Format("服务器IP:{0}\r\n端口号:{1}\r\n在线人数:{2}", txtIP.Text, txtPoint.Text, userList.Count);
            cmbIPs.Items.Clear();
            IPAddress[] addressArr = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress item in addressArr)
            {
                if (item.ToString().Contains("."))
                {
                    cmbIPs.Items.Add(item);
                }
            }
            if (cmbIPs.Items.Count > 0)
            {
                cmbIPs.SelectedIndex = 0;
            }

            try
            {
                if (serverSocket != null)
                {
                    serverSocket.Close();
                }

                string IP = txtIP.Text.Trim();
                string point = txtPoint.Text.Trim();
                IPAddress serverIP = IPAddress.Parse(IP);
                IPEndPoint serverPoint = new IPEndPoint(serverIP, Convert.ToInt32(point));
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                serverSocket.Bind(serverPoint);
                serverSocket.Listen(0);

                MessageInfo toInfo = new MessageInfo();
                toInfo.content = serverPoint + "服务已启动" + Environment.NewLine;
                ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);

                Thread listenThread = new Thread(this.GetClientConnection) { IsBackground = true };
                listenThread.Start();
                button1.Text = "重新启动";
            }
            catch (Exception ex)
            {
                MessageInfo toInfo = new MessageInfo();
                toInfo.content = "服务器异常：" + ex.Message + Environment.NewLine;
                ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                //MessageBox.Show(ex.Message);
            }
        }
        #endregion



        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        private void MainForm_Click(object sender, EventArgs e)
        {
            this.TopLevel = true;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
         
    }
}
