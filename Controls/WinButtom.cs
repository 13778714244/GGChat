using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
    public partial class WinButtom : UserControl
    {
        public WinButtom()
        {
            InitializeComponent();
        }

        //定义委托
        public delegate void BtnClickEvent(object sender, EventArgs e);
        //定义事件
        [Description("自定义按钮点击事件")]
        public event BtnClickEvent BtnClick;
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.BtnClick != null)
            {
                this.BtnClick(sender, e);
            }
        }

        private void WinButtom_Load(object sender, EventArgs e)
        {
            this.Size = this.button1.Size;
            this.button1.Dock = DockStyle.Fill;
        }
    }
}
