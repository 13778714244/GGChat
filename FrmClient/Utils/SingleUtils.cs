using Common.model;
using Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;
using FrmClient.Forms;
using System.Drawing;

namespace FrmClient.Utils
{
    public class SingleUtils
    {
        public static frmFileList frmFileList = new frmFileList();
        public static List<MessageInfo> fileByteList = new List<MessageInfo>(); 
        private static Dictionary<string, Form> openFormDict = new Dictionary<string, Form>();
        public static List<GGGroup> FriendsGroupList = null;
        public static string FriendsStr = "";
        public static string userImgPath = string.Format(Application.StartupPath + "" + ConfigurationManager.AppSettings["userImgPath"]);// ToolUtils.substringFromLast(Application.StartupPath, @"\", 2, ConfigurationManager.AppSettings["userImgPath"].ToString());
        public static EmojiForm emojiForm = new EmojiForm();
        public static RedIn redForm = null;
        public static IPAddress address;
        public static int port;
        public static Socket serverSocket;
        public static IPEndPoint serverIPEndPoint;
        public static GGUserInfo LOGINER;
        public static GGUserInfo fromUser;
        public static GGUserInfo toUser;
        public static ChatForm MainChatForm = null;
        public static Dictionary<string, Form> chatForm = new Dictionary<string, Form>();
        public static Dictionary<GGUserInfo, MessageInfo> noReadDic = new Dictionary<GGUserInfo, MessageInfo>();


        public static bool isQQTD = false; 
        public static bool isWPTD = false;
        public static System.Drawing.Color Color;
        public static System.Drawing.Font Font;

        public static void AddChatForm(string key, Form chatForm)
        {
            if (!SingleUtils.chatForm.ContainsKey(key))
            {
                SingleUtils.chatForm.Add(key, chatForm);
            }
        }

        /// <summary>
        /// 检测是否在线
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="millisecondsTimeout"></param>
        /// <returns></returns>
        public static bool IsConnection(int millisecondsTimeout)
        {
            int millisecondsTimeout0 = 5;//等待时间
            TcpClient client = new TcpClient();
            try
            {
                var ar = client.BeginConnect(SingleUtils.address, SingleUtils.port, null, null);
                ar.AsyncWaitHandle.WaitOne(millisecondsTimeout0);
                return client.Connected;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                client.Close();
            }
        }

        /// <summary>
        /// 重连服务器
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="millisecondsTimeout"></param>
        /// <returns></returns>
        public static bool ReConnection(int millisecondsTimeout)
        {
            int millisecondsTimeout0 = 5;//等待时间
            TcpClient client = new TcpClient();
            try
            {
                var ar = client.BeginConnect(SingleUtils.address, SingleUtils.port, null, null);
                ar.AsyncWaitHandle.WaitOne(millisecondsTimeout0);
                return client.Connected;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                client.Close();
            }
        }


    }
}
