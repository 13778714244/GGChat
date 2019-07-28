using Common;
using Common.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FrmServer.Utils
{

    public class OnlineUserUtils
    {
        private static Dictionary<string, GGUserInfo> onlineUserListDir = new Dictionary<string, GGUserInfo>();
         
        /// <summary>
        /// 得到所有在线客户端信息
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, GGUserInfo> GetAllOnlineClients()
        {
            return OnlineUserUtils.onlineUserListDir;
        }

        /// <summary>
        /// 添加客户端到在线列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static void AddOnlineClient(string userId, GGUserInfo user)
        {
            OnlineUserUtils.onlineUserListDir.Add(userId, user);

        }

        /// <summary>
        /// 将客户端移除在线列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        public static void RemoveOnlineClient(string userId)
        {
            OnlineUserUtils.onlineUserListDir.Remove(userId);

        }

        /// <summary>
        /// 得到单个在线客户端
        /// </summary>
        /// <param name="userId"></param>
        public static GGUserInfo GetSingleOnlineClient(string userId)
        {
            GGUserInfo user = OnlineUserUtils.onlineUserListDir[userId];
            return user;

        }


        /// <summary>
        /// 判断客户端是否在线
        /// </summary>
        /// <param name="userId"></param>
        public static bool CheckClientIsOnline(string userId)
        {
            if (OnlineUserUtils.onlineUserListDir.ContainsKey(userId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 获取在线用户ids
        /// </summary>
        public static string GetOnlineUserStr()
        {
            string userIds = "";
            foreach (KeyValuePair<string, GGUserInfo> user in OnlineUserUtils.onlineUserListDir)
            {
                userIds += "," + user.Value.userId;
            }
            return userIds;

        }

        /// <summary>
        /// 获取在线用户的 Socket
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static Socket GetSocketByUserId(string userId)
        {
            GGUserInfo user = OnlineUserUtils.GetSingleOnlineClient(userId);
            return user.socket;
        }
    }
}
