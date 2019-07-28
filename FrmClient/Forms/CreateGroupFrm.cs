using Common;
using Common.enums;
using Common.model;
using Common.Utils;
using Controls;
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
    public partial class CreateGroupFrm : Form
    {

        private MessageInfo toInfo = new MessageInfo() { msgType = MsgType.创建分组, socket = SingleUtils.LOGINER.socket, fromId = SingleUtils.LOGINER.userId, fromUser = SingleUtils.LOGINER };

        public CreateGroupFrm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            toInfo.content = this.groupName.Text.Trim();
            SocketUtils.SendToSingleClient(toInfo);
        }

        private void CreateGroupFrm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
