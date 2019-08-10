using Common;
using Common.model;
using Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class ChatDBUtils
    {
        public static string onlineUserStr;
        /// <summary>
        /// 获取好友信息
        /// </summary>
        /// <param name="fromInfo"></param>
        /// <returns></returns>
        public static List<GGGroup> GetGroupFriendsInfo(string userId)
        {
            //得到分组
            string groupSql = string.Format("select * from {0} where createId='{1}'", DBTUtils.DBT_GGGroup, userId);
            List<GGGroup> groupList = DBHelper.ConvertToExtModel<GGGroup>(groupSql);

            foreach (GGGroup group in groupList)
            {
                if (!string.IsNullOrEmpty(group.members))
                {
                    string members = group.members;

                    if (!string.IsNullOrEmpty(members))
                    {
                        if (members.StartsWith(","))
                        {
                            members = members.Substring(1);
                        }
                        else if (members.EndsWith(","))
                        {
                            members = members.Substring(0, members.Length - 1);
                        }
                    }
                    string userSql = string.Format("select * from {1} where userAutoid in({0})", members, DBTUtils.DBT_GGUser);
                    List<GGUserInfo> userList = DBHelper.ConvertToExtModel<GGUserInfo>(userSql);
                    foreach (GGUserInfo user in userList)
                    {
                        if (onlineUserStr.Contains(user.userId))
                        {
                            user.isOnLine = true;
                        }
                        else
                        {
                            user.isOnLine = false;
                        }
                    }
                    group.memberList = userList;
                }
            }
            return groupList;
        }


        /// <summary>
        /// 获取好友信息
        /// </summary>
        /// <param name="fromInfo"></param>
        /// <returns></returns>
        public static List<GGUserInfo> GetFriendsInfo(string userId)
        {
            List<GGGroup> groupFriendList = ChatDBUtils.GetGroupFriendsInfo(userId);
            List<GGUserInfo> userList = new List<GGUserInfo>();
            foreach (GGGroup group in groupFriendList)
            {
                if (!string.IsNullOrEmpty(group.members) && group.memberList.Count > 0)
                {
                    userList.AddRange(group.memberList);
                }
            }
            return userList;
        }





        /// <summary>
        /// 获得好友分组
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetPerGroupsStr(string userId)
        {
            List<GGGroup> groupList = ChatDBUtils.GetGroupFriendsInfo(userId);
            string res = "";
            foreach (GGGroup group in groupList)
            {
                res += ToolUtils.GetSpaces() + group.groupName;
            }
            return res;
        }

        /// <summary>
        /// 获得好友列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetPerFriendsStr(string userId)
        {
            List<GGGroup> groupList = ChatDBUtils.GetGroupFriendsInfo(userId);
            string res = "";
            foreach (GGGroup group in groupList)
            {

                foreach (GGUserInfo user in group.memberList)
                {
                    res += GGUserUtils.GetNickAndId(user) + ToolUtils.GetSpaces();
                }
            }
            return res;
        }


        /// <summary>
        /// 获得好友列表，显示是否在线
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetPerOnlineFriendsStr(string userId)
        {
            List<GGGroup> groupList = ChatDBUtils.GetGroupFriendsInfo(userId);
            string res = "";
            foreach (GGGroup group in groupList)
            {

                foreach (GGUserInfo user in group.memberList)
                {
                    res += GGUserUtils.GetNickAndId(user);
                    if (onlineUserStr.Contains(user.userId))
                    {
                        res += "[在线]";
                    }
                    else
                    {
                        res += "[离线]";
                    }
                    res += ToolUtils.GetSpaces();
                }
            }
            return res;
        }

        /// <summary>
        /// 获得好友分组及列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetPerGroupFriendsStr(string userId)
        {
            List<GGGroup> groupList = ChatDBUtils.GetGroupFriendsInfo(userId);
            string res = "";
            foreach (GGGroup group in groupList)
            {
                res += group.groupName + "：[";
                foreach (GGUserInfo user in group.memberList)
                {
                    res += GGUserUtils.GetNickAndId(user) + ToolUtils.GetSpaces();
                }
                res += "]";
            }
            return res;
        }

        /// <summary>
        /// 获得好友分组及列表，显示是否在线
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string GetPerOnlineGroupFriendsStr(string userId)
        {
            List<GGGroup> groupList = ChatDBUtils.GetGroupFriendsInfo(userId);
            string res = "";
            foreach (GGGroup group in groupList)
            {
                res += group.groupName + "：[";
                foreach (GGUserInfo user in group.memberList)
                {
                    res += GGUserUtils.GetNickAndId(user);
                    if (onlineUserStr.Contains(user.userId))
                    {
                        res += "[在线]";
                    }
                    else
                    {
                        res += "[离线]";
                    }
                    res += ToolUtils.GetSpaces();
                }
                res += "]";
            }
            return res;
        }

        /// <summary>
        /// 获得单个数据库用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static GGUserInfo GetPerInfoByUserId(string userId)
        {
            string sql = string.Format("SELECT [userAutoid],[userId],[userPwd],[userNickName],[qqSign],[userImg],[createTime]FROM [dbo].[{0}]where userId='{1}'", DBTUtils.DBT_GGUser, userId);
            List<GGUserInfo> singleUser = DBHelper.ConvertToExtModel<GGUserInfo>(sql);
            return singleUser[0];
        }

        /// <summary>
        /// 获得单个数据库用户
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static GGUserInfo GetPerInfoByAutoId(int autoId)
        {
            string sql = string.Format("SELECT [userAutoid],[userId],[userPwd],[userNickName],[qqSign],[userImg],[createTime]FROM [dbo].[{0}]where userAutoid='{1}'", DBTUtils.DBT_GGUser, autoId);
            List<GGUserInfo> singleUser = DBHelper.ConvertToExtModel<GGUserInfo>(sql);
            return singleUser[0];
        }

        public static bool AddOfflineMsgToClient(MessageInfo fromInfo)
        {
            //私发离线信息                            
            string sql = "INSERT INTO [dbo].[" + DBTUtils.DBT_NoReadMsg + "]([chatRecordId],[sendId],[receiveId],[msgType],[content],[dateTime],isRead)VALUES(@@chatRecordId,@@sendId, @@receiveId,  @@msgType,@@content, @@dateTime,@@isRead)";
            object[] param = { 
                                Guid.NewGuid(),
                                fromInfo.fromId,
                                fromInfo.toId,
                                fromInfo.msgType,
                                fromInfo.content,
                                DateTime.Now,
                                0
                            };
            int row = DBHelper.Excute(sql, param);

            return row > 0 ? true : false;
        }


        /// <summary>
        /// 根据名称查询分组
        /// </summary>
        /// <param name="fromInfo"></param>
        /// <returns></returns>
        public static GGGroup GetGroupByName(string groupName)
        {
            //私发离线信息                            
            string sql = string.Format("SELECT [groupAutoId],[groupId],[groupName],[createId],[members],[createTime],[isDefault]FROM [dbo].[{0}] where groupName='{1}'", DBTUtils.DBT_GGGroup, groupName);

            List<GGGroup> defaultGroup = DBHelper.ConvertToExtModel<GGGroup>(sql);
            if (defaultGroup.Count > 0)
            {
                return defaultGroup[0];
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到默认的分组
        /// </summary>
        /// <param name="fromInfo"></param>
        /// <returns></returns>
        public static GGGroup GetDefaultGroup(string userId)
        {
            //私发离线信息                            
            string sql = string.Format("SELECT [groupAutoId],[groupId],[groupName],[createId],[members],[createTime],[isDefault]FROM [dbo].[{0}] where createId='{1}' and isDefault=1", DBTUtils.DBT_GGGroup, userId.Trim());

            List<GGGroup> defaultGroup = DBHelper.ConvertToExtModel<GGGroup>(sql);
            if (defaultGroup.Count > 0)
            {
                return defaultGroup[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查询单个分组
        /// </summary>
        /// <param name="fromInfo"></param>
        /// <returns></returns>
        public static GGGroup GetSingeGroupByAutoId(int autoId)
        {
            //私发离线信息                            
            string sql = string.Format("SELECT [groupAutoId],[groupId],[groupName],[createId],[members],[createTime],[isDefault]FROM [dbo].[{0}]where groupAutoId={1}", DBTUtils.DBT_GGGroup, autoId);

            List<GGGroup> defaultGroup = DBHelper.ConvertToExtModel<GGGroup>(sql);

            return defaultGroup[0];
        }


        /// <summary>
        /// 添加好友
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool AddFriend(GGGroup defaultGroup, int friendAutoId)
        {
            string members = defaultGroup.members + "," + friendAutoId;
            string sql = string.Format("UPDATE [dbo].[{0}] SET [members] = '{1}' WHERE groupAutoId={2}", DBTUtils.DBT_GGGroup, members, defaultGroup.groupAutoId);
            int row = DBHelper.Excute(sql);
            return row > 0 ? true : false;
        }

        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="group"></param>
        /// <param name="friendAutoId"></param>
        /// <returns></returns>
        public static bool DelFriend(GGGroup group, string friendAutoId)
        {
            string members = group.members.Replace("," + friendAutoId, "");
            string sql = string.Format("UPDATE [dbo].[{0}] SET [members] = '{1}' WHERE groupAutoId={2}", DBTUtils.DBT_GGGroup, members, group.groupAutoId);
            int row = DBHelper.Excute(sql);
            return row > 0 ? true : false;
        }



        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="gGUserInfo"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static bool CreateGroup(GGUserInfo gGUserInfo, string groupName, bool isDefault = false)
        {
            string sql = "INSERT INTO [dbo].[" + DBTUtils.DBT_GGGroup + "]([groupId],[groupName],[createId],[members],[createTime],[isDefault])VALUES(@@groupId, @@groupName, @@createId,  @@members,  @@createTime,  @@isDefault )";
            object[] valArr = { "group" + gGUserInfo.userId, groupName, gGUserInfo.userId, "", DateTime.Now, isDefault ? 1 : 0 };
            int row = DBHelper.Excute(sql, valArr);
            return row > 0 ? true : false;

        }

        /// <summary>
        /// 删除分组
        /// </summary>
        /// <param name="groupAutoId"></param>
        public static bool DelGroup(string groupAutoId)
        {
            string sql = string.Format("DELETE FROM [dbo].[{0}] WHERE groupAutoId={1}", DBTUtils.DBT_GGGroup, groupAutoId);
            int row = DBHelper.Excute(sql);
            return row > 0 ? true : false;
        }

        /// <summary>
        /// 修改分组名
        /// </summary>
        /// <param name="groupAutoId"></param>
        /// <param name="groupName"></param>
        public static bool UpdateGroup(string groupAutoId, string groupName)
        {
            string sql = string.Format("UPDATE [dbo].[{0}] SET [groupName] = '{1}' WHERE groupAutoId={2}", DBTUtils.DBT_GGGroup, groupName, groupAutoId);
            int row = DBHelper.Excute(sql);
            return row > 0 ? true : false;
        }

        /// <summary>
        /// 移动好友
        /// </summary>
        /// <param name="groupAutoId"></param>
        /// <param name="friendAutoId"></param>
        public static bool MoveGroup(int oldGroupAutoId, int newGroupAutoId, int friendAutoId)
        {
            string addSql = string.Format("UPDATE [dbo].[{0}] SET [members] =CAST([members] AS VARCHAR)+ ',{1}' WHERE groupAutoId={2}", DBTUtils.DBT_GGGroup, friendAutoId, newGroupAutoId);

            string delSql = string.Format("UPDATE [dbo].[{0}] SET [members] =replace(CAST( [members] as varchar),',{1}','') WHERE groupAutoId={2}", DBTUtils.DBT_GGGroup, friendAutoId, oldGroupAutoId);
            string[] sqlArr = { addSql, delSql };
            int row = DBHelper.Excute(sqlArr);
            return row > 0 ? true : false;
        }


        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool RegisterUser(GGUser user)
        {

            string sql = @"INSERT INTO [dbo].[GGUser]
           ([userId]
           ,[userPwd]
           ,[userNickName]
           ,[qqSign]
           ,[userImg]
           ,[createTime])
     VALUES
           (@userId,  
           @userPwd,  
           @userNickName,  
           @qqSign, 
           @userImg,  
           @createTime)";

            object[] valArr = { user.userId, user.userPwd, user.userNickName, user.qqSign, user.userImg, DateTime.Now };
            if (DBHelper.Excute(sql, valArr) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取所有用户信息
        /// </summary>
        /// <param name="fromInfo"></param>
        /// <returns></returns>
        public static List<GGUserInfo> GetAllUser()
        {

            List<GGUserInfo> userList = DBHelper.ConvertToExtModel<GGUserInfo>("select*from GGUser");

            return userList;
        }
    }
}
