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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmClient.Forms
{
    public partial class frmFileList : Form
    {
         
        public frmFileList()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }
         
        public void ShowFileList()
        { 
            this.groupBox1.Controls.Clear();
            SingleUtils.isWPTD = false;
            foreach (MessageInfo item in SingleUtils.fileByteList)
            {
                TextBox txt = new TextBox();
                txt.Enabled = false;
                txt.Text = Path.GetFileName(item.content);
                txt.Width = 200;
                txt.Location = new Point(50, (txt.Height + 1) * this.groupBox1.Controls.Count);

                Button btn = new Button();
                btn.Tag = item;
                btn.Location = new Point(txt.Location.X + txt.Width, txt.Location.Y);
                btn.Text = "接收";
                btn.Click += btn_Click;

                this.groupBox1.Controls.Add(txt);
                this.groupBox1.Controls.Add(btn);

            }
            this.Text = "共" + SingleUtils.fileByteList.Count + "个文件";
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            MessageInfo info = btn.Tag as MessageInfo;
            using (FileStream fsWrite = new FileStream(info.content, FileMode.Append))
            {
                fsWrite.Write(info.buffer, 2, info.fileLength - 2);
            }
            SingleUtils.fileByteList.Remove(info);
            this.ShowFileList();
            this.Text = "共" + SingleUtils.fileByteList.Count + "个文件";
            if (MessageBox.Show(string.Format("成功接收文件：{0}  ，是否查看 ", Path.GetFileName(info.content)), "下载成功", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = ToolUtils.GetFilePath();
                ofd.FileName = Path.GetFileName(info.content);
                ofd.ShowDialog();
            }
        }
    }
}
