using Common;
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
    public partial class NoRead : Form
    {
        string msg;

        public NoRead(string msg)
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.msg = msg;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height;
            this.Location = new Point(x, y);
            string sendName = "";
            string msgContent = "";
            string[] arr = msg.Split('|');
            if (arr.Length > 1)
            {
                sendName = arr[0];
                msgContent = arr[1];
            }
            try
            {
                rtfRichTextBox1.Rtf = msgContent;
            }
            catch (Exception)
            {
                rtfRichTextBox1.Text = msgContent;
            }
            this.TopMost = true;
        }
    }
}
