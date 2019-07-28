using CCWin.SkinControl;
using Common;
using Common.enums;
using Common.model;
using Common.Utils;
using FrmClient.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmClient
{
    public partial class LoginForm : BaseForm
    {

        private Image NomalBack;
        MessageInfo toInfo = new MessageInfo() { msgType = MsgType.登录 };

        public LoginForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            Control.CheckForIllegalCrossThreadCalls = false;
        }


        private void textBoxPwd_IconClick(object sender, EventArgs e)
        {
            PassKey pass = new PassKey(this.Left + this.textBoxPwd.Left - 25, this.Top + this.textBoxPwd.Bottom, this.textBoxPwd.SkinTxt);
            pass.Show(this);
        }

        /// <summary>
        /// 加载记住密码的账户信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginForm_Load(object sender, EventArgs e)
        {
            string remPwdTxtPath = ToolUtils.GetResourcePath(@"\Files\remPwd.txt");
            string[] remPwdArr = File.ReadAllLines(remPwdTxtPath, Encoding.Default);
            for (int i = 0; i < remPwdArr.Length; i++)
            {
                string[] userItem = remPwdArr[i].Split(' ');
                string userId = userItem[0];
                string userPwd = userItem[1];
                string userNickName = userItem[2];
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.AutoSize = false;
                item.Size = new System.Drawing.Size(182, 45);
                item.Text = userNickName + "\n" + userId;
                item.Tag = new string[] { userId, userNickName };  //Tag用于存储UserID 和 NickName
                item.Image = Image.FromFile(ToolUtils.GetResourcePath(@"\Images\userImg\") + userItem[3]); //根据ID获取头像
                item.Click += new EventHandler(toolStripMenuItemID_Click);
                menuStripId.Height += 45;
                menuStripId.Items.Add(item);
            }
        }


        //从帐号下拉列表中 选中某个登录帐号
        void toolStripMenuItemID_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string[] tag = (string[])item.Tag;
            textBoxId.SkinTxt.Text = tag[0];
            panelHeadImage.BackgroundImage = item.Image;
        }

        private void checkBoxAutoLogin_CheckedChanged(object sender, EventArgs e)
        {
            this.checkBoxRememberPwd.Checked = this.checkBoxAutoLogin.Checked ? true : this.checkBoxRememberPwd.Checked;
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userId = textBoxId.SkinTxt.Text.Trim();
                string userPwd = textBoxPwd.SkinTxt.Text.Trim();

                SingleUtils.address = IPAddress.Parse(ToolUtils.GetServerIP());
                SingleUtils.port = ToolUtils.GetServerPort();

                SingleUtils.serverIPEndPoint = new IPEndPoint(SingleUtils.address, SingleUtils.port);
                SingleUtils.serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                SingleUtils.serverSocket.Connect(SingleUtils.serverIPEndPoint);

                toInfo.fromId = userId;
                toInfo.fromPwd = userPwd;
                toInfo.socket = SingleUtils.serverSocket;
                toInfo.dateTime = DateTime.Now;
                //1. 将登陆信息发送给服务器
                //2. 服务器接收登陆信息判断账户是否可用
                //3. 客户端接收服务器发送的验证信息进行信息展示
                //4. 成功登陆获取在线客户端信息
                SocketUtils.SendToSingleClient(toInfo);

                string json = ToolUtils.GetString(SingleUtils.serverSocket);
                MessageInfo fromInfo = SerializerUtil.JsonToObject<MessageInfo>(json);
                if (fromInfo.msgType == MsgType.登陆成功)
                {
                    GGUserInfo loginUser = SerializerUtil.JsonToObject<GGUserInfo>(fromInfo.content);
                    loginUser.socket = SingleUtils.serverSocket;
                    loginUser.canSpeak = true;
                    SingleUtils.LOGINER = loginUser;
                    this.Hide();
                    new MainClientForm(this).Show();
                }
                else if (fromInfo.msgType == MsgType.已登录)
                {
                    MessageBox.Show(fromInfo.content);
                }
                else
                {
                    MessageBox.Show(fromInfo.content);
                }
            }
            catch (Exception ex)
            {
                SoundUtils.playSound("登陆客户端[ " + this.GetType() + this.Name + " ]错误:" + ex.Message, EndPointEnum.PC端);
            }
        }





        private void skinButton2_MouseClick(object sender, MouseEventArgs e)
        {
            this.menuStripId.Show(this.textBoxId, 1, this.textBoxId.Height + 1);
            NomalBack = this.skinButton2.NormlBack;
            this.skinButton2.NormlBack = this.skinButton2.DownBack;
            this.skinButton2.Enabled = false;
        }

        private void menuStripId_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            this.skinButton2.Enabled = true;
            this.skinButton2.NormlBack = NomalBack;
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            string file = Application.StartupPath + @"\" + this.GetType().Namespace + ".exe";
            System.Diagnostics.Process.Start(file);
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                string name = p.ProcessName;

                if (name == (this.GetType().Namespace))
                {
                    //   MessageBox.Show(name);
                    //if (MessageBox.Show("关闭吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    //{
                    //    p.Kill();

                    //}
                }
            }
        }


        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
