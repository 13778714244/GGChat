using CCWin.SkinControl;
using Common.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmServer.Utils
{
    public class ChatUtils
    {
        private static object obj = new object();
        private static bool isRtf = true;
        private static string fontFamliy = "宋体";
        private static int fontSize = 10;
        private static CCWin.SkinControl.RtfRichTextBox.RtfColor color = RtfRichTextBox.RtfColor.Green;


        /// <summary>
        /// 将信息追加到服务端信息栏中
        /// </summary>
        /// <param name="msgContent"></param>
        /// <param name="userName"></param>
        /// <param name="isRtf"></param>
        /// <param name="color"></param>
        public static void AppendMsgToServerChatList(CCWin.SkinControl.RtfRichTextBox serverChatRecords, MessageInfo messageInfo)
        {
            lock (obj)
            {
                //serverChatRecords.AppendTextAsRtf(string.Format("{0}  {1}", messageInfo.fromId, DateTime.Now), new Font(fontFamliy, fontSize), color);
                serverChatRecords.AppendTextAsRtf(string.Format("{0}", messageInfo.dateTime), new Font(fontFamliy, fontSize), color);
                serverChatRecords.AppendTextAsRtf(Environment.NewLine);
                serverChatRecords.AppendText("[ " + messageInfo.msgType + " ]");
                if (isRtf)
                {
                    try
                    {
                        serverChatRecords.AppendRtf(messageInfo.content);
                    }
                    catch (Exception ex)
                    {
                        serverChatRecords.AppendText(messageInfo.content);
                    }
                }
                else
                {
                    serverChatRecords.AppendText(messageInfo.content);
                }
                serverChatRecords.AppendTextAsRtf(Environment.NewLine);
                serverChatRecords.AppendTextAsRtf(Environment.NewLine);
                serverChatRecords.ScrollToCaret();
            }
        }
    }
}
