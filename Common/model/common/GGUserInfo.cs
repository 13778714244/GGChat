using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common.model
{
    /// <summary>
    /// 用户扩展类
    /// </summary>
    [Serializable]
    public class GGUserInfo : GGUser
    {

        public string serverIP { get; set; }
        public int serverPoint { get; set; }
        public string localIP { get; set; }
        public int localPoint { get; set; }
        public int groupAutoId { get; set; }

        [NonSerialized]
        private Image _headImg;
        public Image headImg
        {
            get { return _headImg; }
            set { _headImg = value; }
        }


        [NonSerialized]
        private Socket userSocket;
        public Socket socket
        {
            get { return userSocket; }
            set { userSocket = value; }
        }

        public bool canSpeak { get; set; }
        public IPEndPoint iPEndPoint { get; set; }
        public bool isOnLine { get; set; }

    }
}
