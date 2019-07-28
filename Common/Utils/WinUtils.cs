using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace Common.Utils
{
    public class WinUtils
    {

        /// <summary>
        /// 窗体抖动的方法
        /// </summary>
        public static void WindowShake(Form frm)
        {
            frm.WindowState = FormWindowState.Normal;
            frm.TopMost = true;
            Point oldPoint = new Point(frm.Location.X, frm.Location.Y);
            Random r = new Random();
            for (int i = 0; i < 15; i++)
            {
                frm.Location = new Point(frm.Location.X + r.Next(8), frm.Location.Y + r.Next(8));
                System.Threading.Thread.Sleep(50);
                frm.Location = oldPoint;
            }
        }

    }
}
