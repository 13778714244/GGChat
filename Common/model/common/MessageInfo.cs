using Common.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Common.model
{
    [Serializable]
    public class MessageInfo
    {
        public string fromId { get; set; }
        public string fromPwd { get; set; }
        public string toId { get; set; }
        public GGUserInfo fromUser { get; set; }
        public GGUserInfo toUser { get; set; }
        public string content { get; set; }
        public MsgType msgType { get; set; }
        public FileType fileType { get; set; }
        public DateTime dateTime { get; set; }

        [NonSerialized]
        private Socket _socket;

        public Socket socket
        {
            get { return _socket; }
            set { _socket = value; }
        }
        public string excludeUserIds { get; set; }
        public byte[] buffer { get; set; }
        public int fileLength { get; set; }
         
        public string oldGroupAutoId { get; set; }
        public string newGroupAutoId { get; set; }
        public int fromNoRead { get; set; }

    }
}
