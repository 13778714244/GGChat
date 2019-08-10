using Common;
using Common.enums;
using Common.model;
using Common.Utils;
using Controls;
using FrmClient.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmClient.Forms
{
    public partial class AddFriendFrm : Form
    {

        private int wuInfo_width = 180;
        private int wuInfo_height = 70;
        private int rowCount = 5;//一行显示多少个
        private int colCount = 4;//一行显示多少个
        private int span = 10;//每个的间隔
        private int cols = 1;//第几列
        private int rows = 1;//第几行

        private MessageInfo toInfo = new MessageInfo() { msgType = MsgType.添加好友, socket = SingleUtils.LOGINER.socket, fromId = SingleUtils.LOGINER.userId, fromUser = SingleUtils.LOGINER };

        public AddFriendFrm()
        {
            InitializeComponent();
            this.Size = new Size((wuInfo_width + span) * colCount + span, wuInfo_height * rowCount);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        /// <summary>
        /// 发送添加好友信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wuInfo_UserControlBtnAddClicked(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GGUserInfo user = btn.Tag as GGUserInfo;
            if (SingleUtils.LOGINER.userId == user.userId)
            {
                MessageBox.Show("不能添加自己为好友");
                return;
            }
            if (SingleUtils.FriendsStr.Contains(user.userId))
            {
                MessageBox.Show(GGUserUtils.ShowNickAndId(user) + "已经是你的好友了");
                return;
            }
            toInfo.toId = user.userId;
            toInfo.toUser = user;
            SocketUtils.SendToSingleClient(toInfo);
        }

        private void btnQuery_BtnClick(object sender, EventArgs e)
        {
            Init();
            string nickorid = this.nickorid.Text.Trim();
            string sql = @"SELECT [userAutoid]
      ,[userId]
      ,[userPwd]
      ,[userNickName]
      ,[qqSign]
      ,[userImg]
      ,[createTime]
  FROM [dbo].[GGUser]
  where (userid like '%" + nickorid + "%' or userNickName like '%" + nickorid + "%')  ";

            List<GGUserInfo> userList = DBHelper.ConvertToExtModel<GGUserInfo>(sql);
            foreach (GGUserInfo user in userList)
            {
                user.isOnLine = true;
                user.headImg = HeadImgUtils.ShowHeadImg(user);
                if (cols > colCount)
                {
                    cols = 1;
                    ++rows;
                }
                if (user.userId == SingleUtils.LOGINER.userId)
                {
                    user.userNickName = "[自己]" + user.userNickName;
                }
                else if (SingleUtils.FriendsStr.Contains(user.userId))
                {
                    user.userNickName = "[好友]" + user.userNickName;
                }

                WinUserInfo wuInfo = new WinUserInfo(user);
                wuInfo.width = wuInfo_width;
                wuInfo.height = wuInfo_height;

                int x = (wuInfo.width + span) * (cols - 1);
                int y = (wuInfo.height + span) * (rows - 1) + span * 3;

                wuInfo.Location = new Point(x, y);
                wuInfo.UserControlBtnAddClicked += wuInfo_UserControlBtnAddClicked;
                this.groupBox1.Controls.Add(wuInfo);

                ++cols;
            }
        }

        private void Init()
        {
            cols = 1;//第几列
            rows = 1;//第几行
            this.groupBox1.Controls.Clear();
        }

        private void AddFriendFrm_Load(object sender, EventArgs e)
        {
            this.btnQuery_BtnClick(null, null);
            this.StartPosition = FormStartPosition.CenterScreen;
        }


    }
}
