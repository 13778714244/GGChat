using Common.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.model
{
    [Serializable]
    public class NoReadMsg
    { 
        public int chatRecordAutoId { get; set; }
        public string chatRecordId { get; set; }
        public string sendId { get; set; }
        public string receiveId { get; set; }
        public string content { get; set; }
        public MsgType msgType { get; set; }
        public DateTime datetime { get; set; }
        public bool isRead { get; set; }
    }
}
