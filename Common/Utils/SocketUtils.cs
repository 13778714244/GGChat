using Common.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Utils
{
    public class SocketUtils
    {

        /// <summary>
        /// 服务端将字节发送信息给单个客户端
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static void SendToSingleClient(MessageInfo messageInfo)
        {
            try
            {
                messageInfo.dateTime = DateTime.Now;
                string info = SerializerUtil.ObjectToJson<MessageInfo>(messageInfo);
                byte[] bytes = Encoding.UTF8.GetBytes(info);
                messageInfo.socket.Send(bytes);
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务端将字节发送信息给客户端," + ex.Message);
            }
        }


        /// <summary>
        /// 服务端将字节发送信息给好友客户端
        /// </summary>
        /// <param name="onLineUser"></param>
        /// <param name="messageInfo"></param>
        public static void SendToOnlineFriendClients(Dictionary<string, GGUserInfo> onLineUser, List<GGUserInfo> friendList, MessageInfo messageInfo)
        {
            try
            {
                List<GGUserInfo> onlineList = onLineUser.Values.ToList<GGUserInfo>();

                List<GGUserInfo> clientList = new List<GGUserInfo>();
                foreach (GGUserInfo item in onlineList)
                {
                    GGUserInfo tmpUser = friendList.Where(i => i.userId == item.userId).SingleOrDefault();
                    if (tmpUser != null)
                    {
                        clientList.Add(item);
                    }
                }

                string info = SerializerUtil.ObjectToJson<MessageInfo>(messageInfo);
                byte[] bytes = Encoding.UTF8.GetBytes(info);
                foreach (GGUserInfo user in clientList)
                {
                    user.socket.Send(bytes);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务端将字节发送信息给客户端," + ex.Message);
            }
        }

        /// <summary>
        /// 服务端将字节发送信息给客户端
        /// </summary>
        /// <param name="onLineUser"></param>
        /// <param name="messageInfo"></param>
        public static void SendToMultiClients(Dictionary<string, GGUserInfo> onLineUser, MessageInfo messageInfo)
        {
            try
            {
                string info = SerializerUtil.ObjectToJson<MessageInfo>(messageInfo);
                byte[] bytes = Encoding.UTF8.GetBytes(info);
                if (messageInfo.excludeUserIds == null)
                {
                    foreach (GGUserInfo user in onLineUser.Values)
                    {
                        user.socket.Send(bytes);
                    }
                }
                else
                {
                    List<string> excludeUserList = messageInfo.excludeUserIds.Split('|').ToList<string>();
                    foreach (GGUserInfo user in onLineUser.Values)
                    {
                        if (excludeUserList.Contains(user.userId)) continue;

                        user.socket.Send(bytes);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("服务端将字节发送信息给客户端," + ex.Message);
            }
        }

        /// <summary>
        /// 给单个客户端发送文件
        /// </summary>
        /// <param name="messageInfo"></param>
        public static void SendFileToSingleClient(MessageInfo messageInfo)
        {

            List<byte> list = new List<byte>();
            byte[] byteMsg = ToolUtils.StrToByte(messageInfo.content);

            list.Add(Convert.ToByte(messageInfo.msgType));//标记为:信息类型
            if (messageInfo.fileType != 0)
            {
                list.Add(Convert.ToByte(messageInfo.fileType));//标记位:文件类型
            }
            if (messageInfo.buffer != null)
            {
                list.AddRange(messageInfo.buffer);//发送的是字节
            }
            else
            {
                list.AddRange(byteMsg);//发送的是字符串
            }
            byte[] sendMsg = list.ToArray();

            //发送方式
            if (messageInfo.buffer != null)//发送文件
            {
                messageInfo.socket.Send(sendMsg, 0, messageInfo.fileLength + 2, SocketFlags.None);
            }
        }


        /// <summary>
        /// 给多个客户端发送文件
        /// </summary>
        /// <param name="messageInfo"></param>
        public static void SendFileToMutilClient(Dictionary<string, GGUserInfo> onLineUser, MessageInfo messageInfo)
        {

            List<byte> list = new List<byte>();
            byte[] byteMsg = ToolUtils.StrToByte(messageInfo.content);

            list.Add(Convert.ToByte(messageInfo.msgType));//标记为:信息类型
            if (messageInfo.fileType != 0)
            {
                list.Add(Convert.ToByte(messageInfo.fileType));//标记位:文件类型
            }
            if (messageInfo.buffer != null)
            {
                list.AddRange(messageInfo.buffer);//发送的是字节
            }
            else
            {
                list.AddRange(byteMsg);//发送的是字符串
            }
            byte[] sendMsg = list.ToArray();

            //发送方式
            if (messageInfo.buffer != null)//发送文件
            {
                foreach (GGUserInfo user in onLineUser.Values)
                {
                    user.socket.Send(sendMsg, 0, messageInfo.fileLength + 2, SocketFlags.None);
                }
            }
        }
    }
}
