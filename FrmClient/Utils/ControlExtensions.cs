using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmClient.Utils
{
    /// <summary>
    /// 替代使用InvokeRequired
    /// </summary>
    public static class ControlExtensions
    { 
        /// <summary>
        /// 从worker thread 调用UI Thread的控件的方法
        /// </summary>
        /// <param name="control"></param>
        /// <param name="code"></param>
        public static void UIThread(this Control control, Action code)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(code);
                return;
            }
            code.Invoke();
        }
    }
}
