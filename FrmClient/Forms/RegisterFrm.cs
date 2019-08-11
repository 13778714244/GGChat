using Common;
using Common.enums;
using Common.model;
using Common.Services;
using Common.Utils;
using FrmClient.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmClient.Forms
{
    public partial class RegisterFrm : BaseForm
    {
        private string fullFileName;
        private Image headImg = null;
        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string userId = NickUtils.GetUserId();
                string nick = this.nick.Text;
                string pwd = this.pwd.Text;
                string relPwd = this.relPwd.Text;
                string qqSign = this.qqSign.Text;

                string name = userId;
                string extend = Path.GetExtension(fullFileName);
                GGUserInfo user = new GGUserInfo() { createTime = DateTime.Now, qqSign = qqSign, userId = userId, userImg = (headImg == null ? "" : name + extend), userNickName = nick, userPwd = pwd };

                if (ChatDBUtils.RegisterUser(user))
                {
                    HeadImgUtils.SaveRegisterUserHeadImg(this.headImg, user);
                    MessageBox.Show(GGUserUtils.ShowNickAndId(user) + "注册成功");
                }
                else
                {
                    MessageBox.Show(GGUserUtils.ShowNickAndId(user) + "注册失败");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                fullFileName = ofd.FileName;
                headImg = Image.FromFile(fullFileName);
                this.head.Image = headImg;
                //MessageBox.Show(fullFileName + "    " + System.IO.Path.GetExtension(fullFileName));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(NickUtils.GetUserId());
            this.Close();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.nick.Text = NickUtils.GetNickName();
        }


    }
}
