using Common;
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
    public partial class RegisterFrm : BaseForm
    {
        public RegisterFrm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string userId = this.GetUserId();
            string nick = this.nick.Text;
            string pwd = this.pwd.Text;
            string relPwd = this.relPwd.Text;
            string qqSign = this.qqSign.Text;

            string sql = @"INSERT INTO [dbo].[GGUser]
           ([userId]
           ,[userPwd]
           ,[userNickName]
           ,[qqSign]
           ,[userImg]
           ,[createTime])
     VALUES
           (@userId,  
           @userPwd,  
           @userNickName,  
           @qqSign, 
           @userImg,  
           @createTime)";

            string fileName = userId + System.IO.Path.GetExtension(fullFileName);
            object[] valArr = { userId, pwd, nick, qqSign, headImg == null ? "" : fileName, DateTime.Now };
            if (DBHelper.Excute(sql, valArr) > 0)
            {
                MessageBox.Show("注册成功[" + userId + "]");
                if (headImg != null)
                {
                    this.headImg.Save(SingleUtils.userImgPath + fileName);
                }
            }
            else
            {
                MessageBox.Show("注册失败");
            }

        }

        /// <summary>
        /// 得到QQ号码
        /// </summary>
        /// <returns></returns>
        public string GetUserId()
        {
            Random random = new Random();
            string userId = "";
            for (int i = 0; i < 10; i++)
            {
                int r = random.Next(0, 20);
                userId += r;
            }
            userId = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            return userId;
        }
        private string fullFileName;
        private Image headImg = null;
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
            MessageBox.Show(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        }
    }
}
