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

namespace FrmClient.Utils
{
    public class SingleUtils
    {
        private static Dictionary<string, Form> openFormDict = new Dictionary<string, Form>();
        public static List<GGGroup> FriendsGroupList { get; set; }
        public static string FriendsStr = "";
        public static string userImgPath = ToolUtils.substringFromLast(Application.StartupPath, @"\", 2, ConfigurationManager.AppSettings["userImgPath"].ToString());
        public static EmojiForm emojiForm = new EmojiForm();
        public static RedPacketForm redForm = new RedPacketForm();
        public static IPAddress address;
        public static int port;
        public static Socket serverSocket;
        public static IPEndPoint serverIPEndPoint;
        public static GGUserInfo LOGINER;
        public static GGUserInfo fromUser;
        public static GGUserInfo toUser;
        //public static ShowMsgDel showMsgDelMethod;
        public static Dictionary<string, Form> chatForm = new Dictionary<string, Form>();
        public static Dictionary<GGUserInfo, MessageInfo> noReadDic = new Dictionary<GGUserInfo, MessageInfo>();
        

        public static bool isIconTD = false;
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
        /// 打开窗口
        /// </summary>
        /// <param name="key"></param>
        /// <param name="form"></param>
        /// <param name="action"></param>
        public static void OpenForm(string key, Form pForm)
        {
            if (SingleUtils.openFormDict.ContainsKey(key))
            {
                Form form = SingleUtils.openFormDict[key];
                form.Show();
            }
            else
            {
                SingleUtils.openFormDict.Add(key, pForm);
                pForm.Show();
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="key"></param>
        /// <param name="form"></param>
        public static void CloseForm(string key, Form pForm)
        {
            if (SingleUtils.openFormDict.ContainsKey(key))
            {
                Form form = SingleUtils.openFormDict[key];
                SingleUtils.openFormDict.Remove(key);
                form.Close();
            }
            else
            {
                pForm.Close();
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
