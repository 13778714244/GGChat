using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common.model
{
    [Serializable]
    public class GGUser
    {
        public int userAutoid { get; set; }
        public string userId { get; set; }
        public string userPwd { get; set; }
        public string userNickName { get; set; }
        public string qqSign { get; set; }
        public string userImg { get; set; }
        public DateTime createTime { get; set; }
    }
}
