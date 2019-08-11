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
    public partial class RedIn : Form
    {
        public RedIn( )
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            Control.CheckForIllegalCrossThreadCalls = false;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.TopMost = true;   
        }
         
    }
}
