using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.model
{
    [Serializable]
    public class Records
    {
        public int recordAutoId { get; set; }
        public string sendId { get; set; }
        public string receiveId { get; set; }
        public int msgType { get; set; }
        public string content { get; set; }
        public DateTime datetime { get; set; }
    }
}
