using Common;
using Common.model;
using Common.Utils;
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

namespace FrmClient
{
    public partial class UserInfoForm : Form
    {
        public UserInfoForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void UserInfoForm_VisibleChanged(object sender, EventArgs e)
        {
            GGUserInfo user = this.Tag as GGUserInfo;
            userHeadImg.Image = HeadImgUtils.ShowHeadImg(user);
            userName.Text = user.userNickName;
            userQm.Text = user.qqSign;
        }
    }
}
