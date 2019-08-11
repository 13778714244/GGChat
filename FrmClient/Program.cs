using FrmClient.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form loginForm = new LoginForm();
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
            {
                string name = p.ProcessName;

                if (name == "FrmClient.exe")
                {
                    // p.Kill();
                }
            }

            Application.Run(loginForm);
        }
    }
}
