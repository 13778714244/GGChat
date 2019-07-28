using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.model;
using Common.Utils;

namespace Controls
{
    public partial class WinUserInfo : UserControl
    {
        private GGUserInfo user;
        public WinUserInfo(GGUserInfo user)
        {
            InitializeComponent();
            this.user = user;
        }

        [Browsable(true)]
        [Description("控件的宽度"), Category("自定义属性"), DefaultValue(180)]
        public int width { get; set; }


        [Browsable(true)]
        [Description("控件的高度"), Category("自定义属性"), DefaultValue(70)]
        public int height { get; set; }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            this.width = 180;
            this.height = 70;
            this.Size = new Size(this.width, this.height);

            this.head.Image = this.user.headImg;
            this.nick.Text = GGUserUtils.GetNickAndId(this.user);
            this.btnAdd.Tag = this.user;
        }
        //定义委托
        public delegate void BtnClickHandle(object sender, EventArgs e);
        //定义事件
        public event BtnClickHandle UserControlBtnAddClicked;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (UserControlBtnAddClicked != null)
            {
                UserControlBtnAddClicked(sender, new EventArgs());//把按钮自身作为参数传递
            }
        }
    }
}
