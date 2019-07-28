using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;
using System.Net;
using Common.enums;
using Common.model;

using System.Configuration;

namespace Common.Utils
{
    public class ToolUtils
    {

        /// <summary>
        /// 得到配置文件的服务器地址
        /// </summary>
        /// <returns></returns>
        public static string GetServerIP()
        {
            bool IsLocalserverIP = Convert.ToBoolean(ConfigurationManager.AppSettings["IsLocalserverIP"]);
            if (IsLocalserverIP)
            {
                return ToolUtils.GetLocalIP();
            }
            string ip = ConfigurationManager.AppSettings["serverIP"].ToString();
            return ip;
        }

        /// <summary>
        /// 得到配置文件的服务器端口
        /// </summary>
        /// <returns></returns>
        public static int GetServerPort()
        {
            string port = ConfigurationManager.AppSettings["serverPort"].ToString();
            return Convert.ToInt32(port);
        }

        /// <summary>
        /// IP[本机充当服务器]
        /// </summary>
        /// <returns></returns>
        public static string GetLocalIP()
        {
            IPAddress[] addressArr = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress item in addressArr)
            {
                if (item.ToString().Contains("."))
                {
                    return item.ToString();
                }
            }
            return "";
        }


        /// <summary>
        /// 得到资源文件的路径
        /// </summary>
        /// <returns></returns>
        public static string GetResourcePath()
        {
            string newStr = substringFromLast(Application.StartupPath, @"\", 3, @"\Common\OnLineUsers.txt");
            return newStr;
        }

        /// <summary>
        /// 得到资源文件的路径
        /// </summary>
        /// <returns></returns>
        public static string GetResourcePath(string appendStr)
        {
            string newStr = substringFromLast(Application.StartupPath, @"\", 2, appendStr);
            return newStr;
        }

        /// <summary>
        /// 得到项目的根目录
        /// </summary>
        /// <returns></returns>
        public static string GetRootPath(string appendStr = "")
        {
            string newStr = substringFromLast(Application.StartupPath, @"\", 2, appendStr);
            return newStr;
        }

        /// <summary>
        /// 从后面截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="c"></param>
        /// <param name="howMuch"></param>
        /// <returns></returns>
        public static string substringFromLast(string str, string c, int howMuch, string appendStr = null)
        {
            for (int i = 0; i < howMuch; i++)
            {
                str = str.Substring(0, str.LastIndexOf(c));
            }
            if (!string.IsNullOrEmpty(appendStr))
            {
                str += appendStr;
            }
            return str;
        }

        /// <summary>
        /// 从前面截取字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="c"></param>
        /// <param name="howMuch"></param>
        /// <returns></returns>
        public static string substringFromIndex(string str, char c, int strIndex)
        {
            string[] strArr = str.Split(c);
            return strArr[strIndex];
        }

        /// <summary>
        /// 字符串转化为字节
        /// </summary>
        /// <param name="msg"></param>
        public static byte[] StrToByte(string msg)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(msg);
            return bytes;
        }

        /// <summary>
        /// 字节转化为字符串
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string ByteToStr(byte[] bytes)
        {
            string str = Encoding.UTF8.GetString(bytes);
            return str.Replace("\0", "");
        }

        /// <summary>
        /// 得到字符串
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string GetString(Socket clientSocket)
        {
            byte[] buffer = new byte[1024 * 1024 * 5];
            int msgLength = clientSocket.Receive(buffer);
            string msg = Encoding.UTF8.GetString(buffer, 0, msgLength);
            return msg;
        }


        /// <summary>
        /// 得到分割线
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string GetSPLine()
        {

            string msg = "";
            for (int i = 0; i < 100; i++)
            {
                msg += "-";
            }
            return msg;
        }

        /// <summary>
        /// 得到空格数
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string GetSpaces(int len = 3)
        {
            string msg = "";
            for (int i = 0; i < len; i++)
            {
                msg += " ";
            }
            return msg;
        }

        /// <summary>
        /// 得到分割线
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static string GetSpan(int howMuch = 100)
        {

            string msg = "";
            for (int i = 0; i < howMuch; i++)
            {
                msg += " ";
            }
            return msg;
        }

        /// <summary>
        /// 【解析】得到socket发送的字节信息
        /// </summary>
        /// <param name="clientSocket"></param>
        public static byte[] GetSocketMsg(Socket clientSocket, out int msgLength)
        {
            try
            {
                if (clientSocket.Connected)
                {
                    byte[] buffer = new byte[1024 * 1024 * 5];//1057369989   126MB   4092
                    int length = clientSocket.Receive(buffer);
                    msgLength = length;
                    return buffer;
                }
                else
                {
                    byte[] buffer = StrToByte(clientSocket.RemoteEndPoint + " 有人连接断了下线了");
                    msgLength = buffer.Length;
                    return buffer;
                }
            }
            catch (Exception ex)
            {
                //byte[] buffer = StrToByte("有人连接断了下线了，抛出了异常");
                byte[] buffer = StrToByte("");
                msgLength = buffer.Length;
                return buffer;
            }
        }


        /// <summary>
        /// 得到信息类型
        /// </summary>
        /// <param name="clientSocket"></param>
        public static MsgType GetMsgType(byte[] bytes)
        {
            try
            {
                if (bytes.Length > 0)
                {
                    return (MsgType)bytes[0];
                }
                else
                {
                    return MsgType.下线;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("得到信息类型:" + ex.Message);
                return MsgType.下线;
            }

        }


        /// <summary>
        /// 得到信息内容
        /// </summary>
        /// <param name="clientSocket"></param>
        public static byte[] GetMsgContent(byte[] bytes, bool isContainFile = false)
        {
            try
            {
                if (bytes.Length > 1)
                {
                    if (isContainFile)
                    {
                        List<byte> list = new List<byte>();
                        byte[] buffer = new byte[bytes.Length - 2];
                        for (int i = 0; i < bytes.Length - 2; i++)
                        {
                            buffer[i] = bytes[i + 2];
                        }
                        list.AddRange(buffer);
                        byte[] msgContent = list.ToArray();
                        return msgContent;
                    }
                    else
                    {
                        List<byte> list = new List<byte>();
                        byte[] buffer = new byte[bytes.Length - 1];
                        for (int i = 0; i < bytes.Length - 1; i++)
                        {
                            buffer[i] = bytes[i + 1];
                        }
                        list.AddRange(buffer);
                        byte[] msgContent = list.ToArray();
                        return msgContent;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("得到信息内容:" + ex.Message);
                return null;
            }
        }


        /// <summary>
        /// 服务端将字节发送信息给所有客户端
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static void ServerSendMsgToClients(Socket serverSoket, byte msgType, string msgContent = "", byte fileType = 0, byte[] bufferBytes = null, int fileLength = 0)
        {
            try
            {
                List<byte> list = new List<byte>();
                byte[] byteMsg = StrToByte(msgContent);

                list.Add(msgType);//标记为:信息类型
                if (fileType != 0)
                {
                    list.Add(fileType);//标记位:文件类型
                }
                if (bufferBytes != null)
                {
                    list.AddRange(bufferBytes);//发送的是字节
                }
                else
                {
                    list.AddRange(byteMsg);//发送的是字符串
                }
                byte[] sendMsg = list.ToArray();

                //发送方式
                if (bufferBytes != null)//发送文件
                {
                    serverSoket.Send(sendMsg, 0, fileLength + 2, SocketFlags.None);
                }
                else
                {
                    serverSoket.Send(sendMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务端将字节发送信息给客户端," + ex.Message);
            }
        }



        /// <summary>
        /// 服务端将字节发送信息给单个客户端
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static void ServerSendMsgToSingleClient(Socket serverSoket, byte msgType, string msgContent = "", byte fileType = 0, byte[] bufferBytes = null, int fileLength = 0)
        {
            try
            {
                List<byte> list = new List<byte>();
                byte[] byteMsg = StrToByte(msgContent);

                list.Add(msgType);//标记为:信息类型
                if (fileType != 0)
                {
                    list.Add(fileType);//标记位:文件类型
                }
                if (bufferBytes != null)
                {
                    list.AddRange(bufferBytes);//发送的是字节
                }
                else
                {
                    list.AddRange(byteMsg);//发送的是字符串
                }
                byte[] sendMsg = list.ToArray();

                //发送方式
                if (bufferBytes != null)//发送文件
                {
                    serverSoket.Send(sendMsg, 0, fileLength + 2, SocketFlags.None);
                }
                else
                {
                    serverSoket.Send(sendMsg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务端将字节发送信息给客户端," + ex.Message);
            }
        }




        /// <summary>
        /// 客户端将字节发送信息给服务端
        /// </summary>
        /// <param name="fileContent"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static void ClientToServer(Socket clientSoket, byte msgType, string msg = "")
        {
            try
            {
                List<byte> list = new List<byte>();
                byte[] byteMsg = StrToByte(msg);
                list.Add(msgType);
                list.AddRange(byteMsg);
                byte[] sendMsg = list.ToArray();
                clientSoket.Send(sendMsg);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("客户端将字节发送信息给服务端," + ex.Message);
            }
        }


    }
}
