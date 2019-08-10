using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.model
{
    [Serializable]
    public class GGGroup
    {
        public int groupAutoId { get; set; }

        public string groupId { get; set; }

        public string groupName { get; set; }

        public string createId { get; set; }

        public string members { get; set; }

        public DateTime createTime { get; set; }


        private List<GGUserInfo> _memberList;

        public List<GGUserInfo> memberList
        {
            get
            {
                if (_memberList == null)
                {
                    return new List<GGUserInfo>();
                }
                else
                {
                    return _memberList;
                }
            }
            set
            {
                if (value == null)
                {
                    _memberList = new List<GGUserInfo>();
                }
                else
                {
                    _memberList = value;
                }
            }
        }

        public bool isDefault { get; set; }

    }
}
