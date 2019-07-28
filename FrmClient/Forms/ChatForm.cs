using CCWin.SkinControl;
using Common;
using Common.enums;
using Common.model;
using Common.Utils;
using FrmClient.Utils;
using JustLib.Controls;
using OMCS.Passive;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmClient
{
    public partial class ChatForm : BaseForm
    {
        private Icon notifyIcon;
        private object selectedEmoji = 0;

        private MessageInfo toInfo = new MessageInfo() { socket = SingleUtils.LOGINER.socket, fromUser = SingleUtils.LOGINER, toUser = SingleUtils.toUser, fromId = SingleUtils.LOGINER.userId };

        public ChatForm(GGUserInfo fromUser, GGUserInfo toUser)
        {
            InitializeComponent();//选择好友私聊     
            Control.CheckForIllegalCrossThreadCalls = false;

            SingleUtils.showMsgDelMethod = this.ShowMsgDelMethodImpl;
            SingleUtils.fromUser = fromUser;
            SingleUtils.toUser = toUser;

            toInfo.toId = toUser.userId;
            toInfo.toUser = SingleUtils.toUser;

            string chatFormKey = GGUserUtils.GetChatFormKey(SingleUtils.fromUser, SingleUtils.toUser);
            SingleUtils.AddChatForm(chatFormKey, this);

            this.Size = new System.Drawing.Size(400, 400);
            this.Tag = chatFormKey;
            this.Text = "你" + GGUserUtils.ShowNickAndId(SingleUtils.fromUser) + "正在和" + GGUserUtils.ShowNickAndId(SingleUtils.toUser) + "聊天";

            //表情选择面板
            SingleUtils.emojiForm.VisibleChanged += new EventHandler(this.GetEmoji);
            SingleUtils.emojiForm.Show();
            SingleUtils.emojiForm.Visible = false;
        }




        /// <summary>
        /// 发送回信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skinButton_send_Click(object sender, EventArgs e)
        {

            if (!SingleUtils.LOGINER.canSpeak)
            {
                return;
            }
            string sendMsg = this.msgContent.Rtf;
            if (sendMsg.Length >= 10000000)//千万个字符
            {
                MessageBox.Show("内容太多或内容太大无法发送");
                return;
            }
            //发送至服务器
            toInfo.content = sendMsg;
            toInfo.msgType = MsgType.私聊;
            SocketUtils.SendToSingleClient(toInfo);

            ChatRecordUtils.AppendMsgToClient(this.chatRecords, toInfo);

        }

        /// <summary>
        /// 关闭聊天窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            string chatFormKey = this.Tag.ToString();
            SingleUtils.chatForm.Remove(chatFormKey);
            SingleUtils.showMsgDelMethod = null;
            this.Close();
        }

        /// <summary>
        /// 得到表情图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetEmoji(object sender, EventArgs e)
        {
            try
            {
                selectedEmoji = ((EmojiForm)sender).Tag;
                Image emoji = Image.FromFile(selectedEmoji.ToString());
                this.msgContent.InsertImage(emoji);
                SingleUtils.emojiForm.Tag = "";
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 加载在线成员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChatForm_Load(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(200, 200);
            this.userHeadImg.Image = Image.FromFile(SingleUtils.userImgPath + SingleUtils.toUser.userImg);
            this.friendNickName.Text = SingleUtils.toUser.userNickName + "(" + SingleUtils.toUser.userId + ")";
            this.friendQQSign.Text = SingleUtils.toUser.qqSign;
            this.pictureBox1.Image = this.userHeadImg.Image;

            SingleUtils.isIconTD = false;
            this.Width = this.MinimumSize.Width;
            this.Height = 700;
            this.msgContent.AppendText(SingleUtils.LOGINER.userNickName + "对" + SingleUtils.toUser.userNickName + "说：" + new Random().Next(1, 100));
            this.notifyIcon = this.notifyIcon1.Icon;
            this.notifyIcon1.Text = string.Format("QQ:{0}({1})\r\n声音:{2}", SingleUtils.LOGINER.userNickName, SingleUtils.LOGINER.userId, "未开启");

            ShowChatForm();
        }

        /// <summary>
        /// 显示聊天窗口
        /// </summary>
        private void ShowChatForm()
        {
            memberList.Items.Clear();
            memberList.View = View.List;
            foreach (string user in SingleUtils.chatForm.Keys)
            {
                ListViewItem item = new ListViewItem(user);
                memberList.Items.Add(item);
            }
        }

        /// <summary>
        /// 委托方法的实现
        /// </summary>
        /// <param name="serverMsg"></param>
        public void ShowMsgDelMethodImpl(MessageInfo fromInfo)
        {
            if (fromInfo.msgType == MsgType.私聊)
            {
                if (fromInfo.fromId != SingleUtils.LOGINER.userId)
                {
                    SoundUtils.NewestInfoCome();
                }
                ChatRecordUtils.AppendMsgToClient(this.chatRecords, fromInfo);
            }
            else if (fromInfo.msgType == MsgType.私发抖动)
            {
                ChatRecordUtils.AppendMsgToClient(this.chatRecords, fromInfo);
                WinUtils.WindowShake(this);
            }
        }



        /// <summary>
        /// 发送表情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(SingleUtils.emojiForm.Tag);
            if (count <= 0)
            {
                return;
            }
            int index = count;
            string img = ToolUtils.GetResourcePath(@"\Images\emotion\" + (index + 1) + ".gif");
            Image image = Image.FromFile(img);
            msgContent.InsertImage(image);

        }

        #region 显示/隐藏表情栏
        private void listView1_MouseLeave(object sender, EventArgs e)
        {
            SingleUtils.emojiForm.Visible = false;
        }

        private void toolStripButtonEmotion_MouseEnter(object sender, EventArgs e)
        {
            SingleUtils.emojiForm.Visible = true;
        }
        #endregion


        /// <summary>
        /// 选择图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            ofd.Filter = "所有图片|*.jpg;*.jpeg;*.png;*.gif";
            ofd.Title = "请选择图片文件";

            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                Image smallImg = ImageUtils.PercentImage(img, 0.1);
                this.msgContent.InsertImage(smallImg);
            }
        }


        private void ChatForm_Click(object sender, EventArgs e)
        {
            //this.TopMost = true;
        }

        private void ChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// 发起震动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            //发送至服务器
            toInfo.msgType = MsgType.私发抖动;
            SocketUtils.SendToSingleClient(toInfo);
            toInfo.content = "你给" + GGUserUtils.ShowNickAndId(SingleUtils.toUser) + "发了一个抖动";
            ChatRecordUtils.AppendMsgToClient(this.chatRecords, toInfo);
        }

        #region 显示/隐藏表情栏
        private void toolStripButtonEmotion_Click(object sender, EventArgs e)
        {
            int fTop = this.Top;
            int fLeft = this.Left;
            SingleUtils.emojiForm.Visible = !SingleUtils.emojiForm.Visible;
            SingleUtils.emojiForm.Location = new Point(fLeft, fTop);
        }
        #endregion




        #region 截屏
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            Bitmap bit = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bit))
            {
                g.CopyFromScreen(0, 0, 0, 0, new Size(width, height));
            }
            Image smallImg = ImageUtils.PercentImage(bit);
            this.msgContent.InsertImage(smallImg);
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsSocketConnected(SingleUtils.LOGINER.socket))
            {
                this.gifBox_wait.Visible = false;
            }
            else
            {
                this.gifBox_wait.Visible = true;

            }
        }


        private bool IsSocketConnected(Socket client)
        {
            bool blockingState = client.Blocking;
            try
            {
                byte[] tmp = new byte[1];
                client.Blocking = false;
                client.Send(tmp, 0, 0);
                return true;
            }
            catch (SocketException e)
            {
                // 产生 10035 == WSAEWOULDBLOCK 错误，说明被阻止了，但是还是连接的
                if (e.NativeErrorCode.Equals(10035))
                    return false;
                else
                    return true;
            }
            finally
            {
                client.Blocking = blockingState;    // 恢复状态
            }
        }

        private void ChatForm_Activated(object sender, EventArgs e)
        {

        }

        private void ChatForm_Shown(object sender, EventArgs e)
        {
            //读取 未读信息
            foreach (KeyValuePair<GGUserInfo, MessageInfo> item in SingleUtils.noReadDic)
            {
                MessageInfo fromInfo = item.Value;
                this.ShowMsgDelMethodImpl(fromInfo);
            }
            //清空 未读信息        
            SingleUtils.noReadDic.Clear();
        }

        private void toolFont_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            SingleUtils.Color = this.colorDialog1.Color;


            this.fontDialog1.ShowDialog();
            SingleUtils.Font = this.fontDialog1.Font;

            this.msgContent.SelectAll();
            this.msgContent.SelectionFont = SingleUtils.Font;
            this.msgContent.SelectionColor = (SingleUtils.Color);
            this.msgContent.Select(0, 0);
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowChatForm();
        }

    }
}
