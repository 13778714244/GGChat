using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class DefaultUtils
    {
        public static string headImg = System.Configuration.ConfigurationManager.AppSettings["defaultHeadImg"].ToString();
    }
}
