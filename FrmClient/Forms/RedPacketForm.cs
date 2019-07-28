using CCWin;
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
    public partial class RedPacketForm : Form
    {
        public RedPacketForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private Random r = new Random();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string str = string.Format("恭喜你，抢到了{0}元的红包", r.Next(1, 10) + Convert.ToDecimal(r.NextDouble().ToString().Substring(0, 4)));
            MessageBox.Show(str);
            this.Close();
        }
    }
}
