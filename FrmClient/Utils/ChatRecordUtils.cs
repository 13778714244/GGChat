using CCWin.SkinControl;
using Common.enums;
using Common.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmClient.Utils
{
    public class ChatRecordUtils
    {
        private static bool isRtf = true;
        private static Font[] fontArr = { new Font("宋体", 10), new Font("宋体", 10) };
        private static RtfRichTextBox.RtfColor[] colorArr = { RtfRichTextBox.RtfColor.Red, RtfRichTextBox.RtfColor.Green };


        /// <summary>
        /// 追加聊天信息
        /// </summary>
        /// <param name="chatRecords"></param>
        /// <param name="getNameAndMsg"></param>
        /// <param name="isRtf"></param>
        public static void AppendMsgToClient(RtfRichTextBox chatRecords, MessageInfo fromInfo)
        {
            int index = fromInfo.fromId == SingleUtils.LOGINER.userId ? 0 : 1; 
            chatRecords.AppendTextAsRtf(string.Format("{0}", fromInfo.dateTime), ChatRecordUtils.GetFont(index), ChatRecordUtils.GetColor(index));
            chatRecords.AppendText(Environment.NewLine);
            if (isRtf)
            {
                try
                {
                    chatRecords.AppendRtf(fromInfo.content);
                }
                catch (Exception ex)
                {
                    chatRecords.AppendText(fromInfo.content);
                    chatRecords.AppendText(Environment.NewLine);
                }
            }
            else
            {
                chatRecords.AppendText(fromInfo.content);
            }
            chatRecords.AppendText(Environment.NewLine);
            chatRecords.ScrollToCaret();
        }


        /// <summary>
        /// 设置字体
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Font GetFont(int index)
        {
            Font font = fontArr[index];
            return font;
        }

        /// <summary>
        /// 设置颜色
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static RtfRichTextBox.RtfColor GetColor(int index)
        {
            RtfRichTextBox.RtfColor color = colorArr[index];
            return color;
        }

    }
}
