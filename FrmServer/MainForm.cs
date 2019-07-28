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
using Common;

namespace FrmServer
{
    public partial class MainForm : CCSkinMain
    {
        private Socket serverSocket = null;
        private delegate void ServerDelegate(object str);
        private Tools Tools = new Tools();
        public static List<GGUserInfo> user_list = new List<GGUserInfo>();
        public MainForm()
        {
            InitializeComponent();
        }
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

                serverSocket.Bind(serverPoint);
                serverSocket.Listen(0);

                AppendMsgToServerChatList(serverPoint + "服务已启动\r\n");

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

        #region 服务端接受连接的客户端
        public void GetClientConnection()
        {
            try
            {
                while (true)
                {
                    //接收客户端发来的身份信息
                    Socket clientSocket = serverSocket.Accept();
                    object obj = clientSocket.RemoteEndPoint;
                    string nameAndPwd = Tools.GetString(clientSocket);
                    string[] arr = nameAndPwd.Split('|');
                    string sql = string.Format("select*from GGUser where userId='{0}' and userPwd='{1}'", arr[0], arr[1]);
                    DataTable dt = DBHelper.Select(sql);
                    GGUserInfo user = new GGUserInfo();
                    if (dt.Rows.Count == 1)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            user.createTime = Convert.ToDateTime(item["createTime"]);
                            user.qqSign = item["qqSign"].ToString();
                            user.userAutoid = Convert.ToInt32(item["userAutoid"]);
                            user.userImg = item["userImg"].ToString();
                            user.userNickName = item["userNickName"].ToString();
                            user.userId = item["userId"].ToString();
                            user.isOnLine = Convert.ToBoolean(item["isOnLine"]);
                        }
                        IPEndPoint clientIPEndPoint = new IPEndPoint(IPAddress.Parse(arr[2]), Convert.ToInt32(arr[3]));
                        Socket tempClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    }
                    else
                    {

                    }


                    return;
                    user_list.Add(user);//保存用户信息
                    RefreshOnLineUser();//刷新用户                 
                    ServerDelegate temp = msg =>
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes(arr[0]);
                        AppendMsgToServerChatList(msg + "进入了聊天室" + Environment.NewLine + clientSocket.RemoteEndPoint + "连接到服务器", null, false);
                    };
                    serverChatRecords.Invoke(temp, arr[0]);
                    ServerThread myThread = new ServerThread(user, serverChatRecords, cmbUserList, label6);
                    foreach (GGUserInfo item in user_list)
                    {
                        if (item.userNickName != arr[0])
                        {
                            Tools.ServerSendMsgToClient(item.UserSocket, Convert.ToByte(MsgType.刷新在线用户), "【" + arr[0] + "】进入了聊天室");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务端接受连接的客户端:" + ex.Message);
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
        }
        #endregion

        #region 发布系统公告
        private void button2_Click(object sender, EventArgs e)
        {
            string msg = serverMsgContent.Rtf;
            if (msg != "")
            {
                AppendMsgToServerChatList("系统公告|" + msg + "");
                foreach (GGUserInfo item in FrmServer.MainForm.user_list)
                {
                    Tools.ServerSendMsgToClient(item.UserSocket, Convert.ToByte(MsgType.系统信息), "系统公告|" + msg + "");
                }
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
                if (user_list.Count > 0)
                {
                    int index = cmbUserList.SelectedIndex;
                    GGUserInfo GGUserInfo = user_list[index];

                    AppendMsgToServerChatList("【" + GGUserInfo.userNickName + "】被踢出聊天室");
                    //通知其他人
                    foreach (GGUserInfo item in user_list)
                    {
                        if (item.userNickName != GGUserInfo.userNickName)
                        {
                            Tools.ServerSendMsgToClient(item.UserSocket, Convert.ToByte(MsgType.踢出聊天室));
                        }
                    }
                    //通知用户本人
                    foreach (GGUserInfo item in user_list)
                    {
                        if (item.userNickName == GGUserInfo.userNickName)
                        {
                            Tools.ServerSendMsgToClient(item.UserSocket, Convert.ToByte(MsgType.踢出聊天室), "你已被踢出聊天室");
                            break;
                        }
                    }
                    user_list.Remove(user_list[index]);
                    RefreshOnLineUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(name + "已下线");
                RefreshOnLineUser();
            }
        }
        #endregion

        #region 手动刷新在线用户
        private void button6_Click(object sender, EventArgs e)
        {
            notifyIcon1.Text = string.Format("服务器IP:{0}\r\n端口号:{1}\r\n在线人数:{2}", txtIP.Text, txtPoint.Text, user_list.Count);
            RefreshOnLineUser();
        }
        #endregion

        #region 刷新用户的方法
        public void RefreshOnLineUser()
        {
            ServerDelegate temp = str =>
            {
                cmbUserList.Items.Clear();
                foreach (GGUserInfo user in user_list)
                {
                    cmbUserList.Items.Add(user.userNickName);
                }
                if (cmbUserList.Items.Count > 0)
                {
                    cmbUserList.SelectedIndex = 0;
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
            notifyIcon1.Text = string.Format("服务器IP:{0}\r\n端口号:{1}\r\n在线人数:{2}", txtIP.Text, txtPoint.Text, user_list.Count);
        }
        #endregion

        #region 禁言
        private void button8_Click(object sender, EventArgs e)
        {
            foreach (GGUserInfo item in user_list)
            {
                int index = cmbUserList.SelectedIndex;
                GGUserInfo GGUserInfo = user_list[index];
                if (item.userNickName == GGUserInfo.userNickName)
                {
                    if (GGUserInfo.canSpeak)
                    {
                        AppendMsgToServerChatList(GGUserInfo.userNickName + "已被禁言");
                    }
                    Tools.ServerSendMsgToClient(GGUserInfo.UserSocket, Convert.ToByte(MsgType.开启禁言), "系统:你已被禁言");
                    RefreshCanSpeak();
                    break;
                }
            }
        }
        #endregion

        #region 解除禁言
        private void button9_Click(object sender, EventArgs e)
        {
            foreach (GGUserInfo item in MainForm.user_list)
            {
                int index = cmbUserList.SelectedIndex;
                GGUserInfo GGUserInfo = MainForm.user_list[index];
                if (item.userNickName == GGUserInfo.userNickName)
                {
                    if (!GGUserInfo.canSpeak)
                    {
                        AppendMsgToServerChatList(GGUserInfo.userNickName + "可以发言了");
                    }
                    Tools.ServerSendMsgToClient(GGUserInfo.UserSocket, Convert.ToByte(MsgType.解除禁言), "系统:你可以发言了");
                    RefreshCanSpeak();
                    break;
                }
            }
        }
        #endregion

        #region 服务器私聊
        private void button10_Click(object sender, EventArgs e)
        {
            string name = cmbUserList.Text;
            try
            {
                foreach (GGUserInfo item in MainForm.user_list)
                {
                    int index = cmbUserList.SelectedIndex;
                    if (index < 0)
                    {
                        MessageBox.Show("请选择用户");
                        return;
                    }
                    GGUserInfo GGUserInfo = MainForm.user_list[index];
                    if (item.userNickName == GGUserInfo.userNickName)
                    {
                        string msg = serverMsgContent.Rtf;
                        if (msg == "")
                        {
                            return;
                        }

                        AppendMsgToServerChatList("系统给" + GGUserInfo.userNickName + "发送了消息|" + msg);
                        Tools.ServerSendMsgToClient(GGUserInfo.UserSocket, Convert.ToByte(MsgType.普通信息), "系统|" + msg);
                        break;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(name + "已下线");
                RefreshOnLineUser();
            }
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
            int index = cmbUserList.SelectedIndex;
            if (index < 0)
            {
                MessageBox.Show("请选择用户");
                return;
            }
            string path = textBox2.Text;
            string extendName = Path.GetExtension(path);
            FileType fileType = GetFileExtendName(extendName);

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                foreach (GGUserInfo item in user_list)
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];
                    int fileLength = fs.Read(buffer, 0, buffer.Length);
                    GGUserInfo GGUserInfo = user_list[index];
                    if (item.userNickName == GGUserInfo.userNickName)
                    {
                        AppendMsgToServerChatList("系统给" + GGUserInfo.userNickName + "发送了文件");
                        Tools.ServerSendMsgToClient(GGUserInfo.UserSocket, Convert.ToByte(MsgType.私发文件), "", Convert.ToByte(fileType), buffer, fileLength);
                        break;

                    }
                }
            }
        }
        #endregion

        #region 得到文件的拓展名的方法
        private FileType GetFileExtendName(string extendName)
        {
            FileType fileType = FileType.jpg;
            switch (extendName.ToLower())
            {
                case ".png":
                    fileType = FileType.png;
                    break;
                case ".gif":
                    fileType = FileType.gif;
                    break;
                case ".xls":
                    fileType = FileType.xls;
                    break;
                case ".xlsx":
                    fileType = FileType.xlsx;
                    break;
                case ".doc":
                    fileType = FileType.doc;
                    break;
                case ".docx":
                    fileType = FileType.docx;
                    break;
                case ".txt":
                    fileType = FileType.txt;
                    break;
                case ".mp3":
                    fileType = FileType.mp3;
                    break;
                case ".mp4":
                    fileType = FileType.mp4;
                    break;
            }
            return fileType;
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
                AppendMsgToServerChatList("系统给所有人发送了文件");
                foreach (GGUserInfo item in MainForm.user_list)
                {
                    Tools.ServerSendMsgToClient(item.UserSocket, Convert.ToByte(MsgType.群发文件));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("群发文件" + ex.Message);
            }
        }
        #endregion

        #region 服务器把信息转发给用户
        public void MessageToClient(byte msgType, string msgContent, bool isContainSelf = false, string userNickName = null)
        {
            if (userNickName != null)
            {
                foreach (GGUserInfo item in MainForm.user_list)
                {
                    if (item.userNickName == userNickName)
                    {
                        List<byte> list = new List<byte>();
                        byte[] byteMsg = Tools.StrToByte(msgContent);
                        list.Add(msgType);
                        list.AddRange(byteMsg);
                        byte[] sendMsg = list.ToArray();
                        item.UserSocket.Send(sendMsg);
                        break;
                    }
                }
                return;
            }
            if (isContainSelf)//同时转发给自己
            {
                foreach (GGUserInfo item in MainForm.user_list)
                {
                    List<byte> list = new List<byte>();
                    byte[] byteMsg = Tools.StrToByte(msgContent);
                    list.Add(msgType);
                    list.AddRange(byteMsg);
                    byte[] sendMsg = list.ToArray();
                    item.UserSocket.Send(sendMsg);
                }
            }
            else//不转发给自己
            {
                foreach (GGUserInfo item in MainForm.user_list)
                {
                    if (item.userNickName != userNickName)
                    {
                        List<byte> list = new List<byte>();
                        byte[] byteMsg = Tools.StrToByte(msgContent);
                        list.Add(msgType);
                        list.AddRange(byteMsg);
                        byte[] sendMsg = list.ToArray();
                        item.UserSocket.Send(sendMsg);
                    }
                }
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
                foreach (GGUserInfo item in MainForm.user_list)
                {
                    Tools.ServerSendMsgToClient(item.UserSocket, Convert.ToByte(MsgType.关闭服务器), "服务器已关闭");
                }
                notifyIcon1.Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region 判断选中的用户禁言状态
        private void cmbUserList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbUserList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            GGUserInfo GGUserInfo = user_list[index];
            button8.Enabled = !GGUserInfo.canSpeak;
            button9.Enabled = !button8.Enabled;
        }
        #endregion

        #region  刷新发言状态的方法
        private void RefreshCanSpeak()
        {
            int index = cmbUserList.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            GGUserInfo GGUserInfo = user_list[index];
            GGUserInfo.canSpeak = !GGUserInfo.canSpeak;
            button8.Enabled = !GGUserInfo.canSpeak;
            button9.Enabled = !button8.Enabled;
        }
        #endregion

        #region 自动启动服务器
        private void MainForm_Load(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(1, "提示", "服务已启动", ToolTipIcon.None);
            notifyIcon1.Text = string.Format("服务器IP:{0}\r\n端口号:{1}\r\n在线人数:{2}", txtIP.Text, txtPoint.Text, user_list.Count);
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
                AppendMsgToServerChatList(serverPoint + "服务已启动\r\n", null, false);

                Thread listenThread = new Thread(GetClientConnection) { IsBackground = true };
                listenThread.Start();
                button1.Text = "重新启动";
                user_list = new List<GGUserInfo>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region 将信息追加到服务端信息栏中
        private void AppendMsgToServerChatList(string msgContent, string userName = null, bool isRtf = true, RtfRichTextBox.RtfColor color = RtfRichTextBox.RtfColor.Green)
        {
            string newSendName = "";
            string newMsgContent = "";
            string[] arr = msgContent.Split('|');
            if (arr.Length > 1)
            {
                newSendName = arr[0];
                newMsgContent = arr[1].Replace("\0", "");
            }
            else
            {
                newSendName = "";
                newMsgContent = msgContent;
            }
            this.serverChatRecords.AppendTextAsRtf(string.Format("{0}  {1}", newSendName, DateTime.Now), new Font(this.Font, FontStyle.Regular), color);
            this.serverChatRecords.AppendTextAsRtf(Environment.NewLine);
            if (isRtf)
            {
                try
                {
                    this.serverChatRecords.AppendRtf(newMsgContent);
                }
                catch (Exception ex)
                {
                    newMsgContent = newMsgContent.Replace("\0", "");
                    this.serverChatRecords.AppendText(newMsgContent);
                    this.serverChatRecords.AppendTextAsRtf(Environment.NewLine);
                }
            }
            else
            {
                newMsgContent = newMsgContent.Replace("\0", "");
                this.serverChatRecords.AppendText(newMsgContent);
                this.serverChatRecords.AppendTextAsRtf(Environment.NewLine);
            }
            serverChatRecords.ScrollToCaret();
        }
        #endregion

        #region 点击气泡还原服务器状态
        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        #endregion

        #region 设置为最顶层
        private void MainForm_Click(object sender, EventArgs e)
        {
            this.TopLevel = true;
        }
        #endregion

    }
}
