using Common;
using Common.enums;
using Common.model;
using FrmClient.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmClient.Forms
{
    public partial class RecordFrm : Form
    {
        public RecordFrm()
        {
            InitializeComponent();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string start = this.start.Value.ToString("yyyy-MM-dd");
            string end = this.end.Value.AddDays(1).ToString("yyyy-MM-dd");
            string sql = string.Format(@"SELECT [recordAutoId]
      ,[sendId]
      ,[receiveId]
      ,[msgType]
      ,[content]
      ,[datetime]
  FROM [GGChatDB].[dbo].[Records]
  where [datetime] between '{0}' and '{1}' and ([sendId]='{2}' or [receiveId]='{2}') ", start, end, SingleUtils.LOGINER.userId);
            List<Records> recordsList = DBHelper.ConvertToExtModel<Records>(sql);
            foreach (Records item in recordsList)
            {
                MessageInfo toInfo = new MessageInfo() { content = item.content, dateTime = item.datetime, fromId = item.sendId, msgType = (MsgType)item.msgType, toId = item.receiveId };
                ChatRecordUtils.AppendMsgToClient(this.list, toInfo);
            }
            this.Text = string.Format("找到{0}至{1}范围内{2}条记录", start, end, recordsList.Count);
        }
    }
}
