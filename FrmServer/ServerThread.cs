using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Net.Sockets;
using System.IO;
using Common;
using CCWin.SkinControl;
using Common.model;
using FrmServer.Utils;
using Common.enums;
using Common.Utils;
using Common.Services;

namespace FrmServer
{
    public class ServerThread
    {
        private GGUserInfo currentUser;
        private Thread userThread;
        private delegate void ServerDelegate(string msgContent, string sendUserName, RtfRichTextBox.RtfColor color = RtfRichTextBox.RtfColor.SeaGreen, bool isRtf = true);
        private RtfRichTextBox serverChatRecords;
        private ComboBox ComboBox;
        private Label label;
        private MessageInfo toInfo = new MessageInfo();

        public ServerThread(GGUserInfo userInfo, RtfRichTextBox serverChatRecords, ComboBox ComboBox, Label label)
        {
            this.currentUser = userInfo;
            this.serverChatRecords = serverChatRecords;
            this.ComboBox = ComboBox;
            this.label = label;
            this.userThread = new Thread(this.GetClientMsg) { IsBackground = true };
            this.userThread.Start();
            ChatDBUtils.onlineUserStr = OnlineUserUtils.GetOnlineUserStr();
        }


        /// <summary>
        /// 服务器获取客户端发来的信息
        /// </summary>
        public void GetClientMsg()
        {
            while (true)
            {
                try
                {

                    if (!this.currentUser.socket.Connected)
                    {
                        toInfo.msgType = MsgType.系统消息;
                        //信息显示到服务器
                        toInfo.content = GGUserUtils.ShowNickAndId(this.currentUser) + " 客户端失去连接";
                        ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                        SoundUtils.playSound(toInfo.content, EndPointEnum.服务器);
                        break;
                    }

                    string json = ToolUtils.GetString(this.currentUser.socket);
                    MessageInfo fromInfo = SerializerUtil.JsonToObject<MessageInfo>(json);

                    if (fromInfo == null)
                    {
                        //信息显示到服务器
                        MessageInfo tmpInfo = new MessageInfo();
                        tmpInfo.msgType = MsgType.异常报告;
                        tmpInfo.content = GGUserUtils.ShowNickAndId(this.currentUser) + " 未获取到信息";
                        ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, tmpInfo);
                        SoundUtils.playSound(toInfo.content, EndPointEnum.服务器);
                        break;
                    }

                    toInfo = new MessageInfo()
                  {
                      msgType = fromInfo.msgType,
                      socket = this.currentUser.socket,
                      content = fromInfo.content,
                      fromId = fromInfo.fromId,
                      toId = fromInfo.toId,
                      fromUser = fromInfo.fromUser,
                      toUser = fromInfo.toUser,
                      dateTime = DateTime.Now
                  };


                    if (!string.IsNullOrEmpty(fromInfo.toId) && OnlineUserUtils.CheckClientIsOnline(fromInfo.toId) && true)
                    {
                        toInfo.socket = OnlineUserUtils.GetSingleOnlineClient(fromInfo.toId).socket;
                    }
                    if (fromInfo.msgType == MsgType.移动好友)
                    {
                        int oldGroupAutoId = Convert.ToInt32(fromInfo.oldGroupAutoId);
                        int newGroupAutoId = Convert.ToInt32(fromInfo.newGroupAutoId);
                        int friendAutoId = Convert.ToInt32(fromInfo.toId);
                        GGGroup oldGroupInfo = ChatDBUtils.GetSingeGroupByAutoId(oldGroupAutoId);
                        GGGroup newGroupInfo = ChatDBUtils.GetSingeGroupByAutoId(newGroupAutoId);
                        GGUserInfo userInfo = ChatDBUtils.GetPerInfoByAutoId(friendAutoId);
                        ChatDBUtils.MoveGroup(oldGroupAutoId, newGroupAutoId, friendAutoId);
                        toInfo.content = "成功将好友" + GGUserUtils.ShowNickAndId(userInfo) + "从[ " + oldGroupInfo.groupName + " ] 移动到 [ " + newGroupInfo.groupName + " ]";
                        SocketUtils.SendToSingleClient(toInfo);
                    }
                    else if (fromInfo.msgType == MsgType.私发红包)
                    {
                        if (OnlineUserUtils.CheckClientIsOnline(fromInfo.toId))
                        {
                            SocketUtils.SendToSingleClient(toInfo);
                        }
                        toInfo.content = GGUserUtils.ShowNickAndId(fromInfo.fromUser) + "给" + GGUserUtils.ShowNickAndId(fromInfo.toUser) + "发了" + fromInfo.content + "元的红包";
                    }
                    else if (fromInfo.msgType == MsgType.私聊)
                    {
                        if (OnlineUserUtils.CheckClientIsOnline(fromInfo.toId))
                        {
                            //信息转发给指定客户端
                            SocketUtils.SendToSingleClient(toInfo);
                            //添加聊天记录
                            ChatDBUtils.AddRecords(fromInfo);
                        }
                        else
                        {
                            //添加离线信息到数据库
                            ChatDBUtils.AddOfflineMsgToClient(fromInfo);
                        }
                    }
                    else if (fromInfo.msgType == MsgType.用户注册)
                    {
                        GGUserInfo user = SerializerUtil.JsonToObject<GGUserInfo>(json);
                        bool isSuc = ChatDBUtils.RegisterUser(user);

                        if (isSuc)
                        {
                            toInfo.content = GGUserUtils.ShowNickAndId(user) + "注册成功";
                        }
                        else
                        {
                            toInfo.content = GGUserUtils.ShowNickAndId(user) + "注册失败";
                        }
                        SocketUtils.SendToSingleClient(toInfo);
                    }
                    else if (fromInfo.msgType == MsgType.创建分组)
                    {
                        GGGroup tmpGroup = ChatDBUtils.GetGroupByName(fromInfo.content);
                        if (tmpGroup != null)
                        {
                            toInfo.content = "分组[" + fromInfo.content + "]已存在，请重新命名";
                            SocketUtils.SendToSingleClient(toInfo);
                        }
                        else
                        {
                            ChatDBUtils.CreateGroup(fromInfo.fromUser, fromInfo.content);
                            toInfo.content = "分组[" + fromInfo.content + "]创建成功";
                            SocketUtils.SendToSingleClient(toInfo);
                        }
                    }
                    else if (fromInfo.msgType == MsgType.删除分组)
                    {
                        string groupAutoId = fromInfo.content;
                        ChatDBUtils.DelGroup(groupAutoId);
                        toInfo.content = "分组[" + fromInfo.content + "]删除成功";
                        SocketUtils.SendToSingleClient(toInfo);
                    }
                    else if (fromInfo.msgType == MsgType.修改分组)
                    {
                        string[] arr = fromInfo.content.Split('|');
                        string groupAutoId = arr[0];
                        string groupName = arr[1];
                        ChatDBUtils.UpdateGroup(groupAutoId, groupName);
                        toInfo.content = "分组[" + fromInfo.content + "]修改为[" + groupName + "]";
                        SocketUtils.SendToSingleClient(toInfo);
                    }
                    else if (fromInfo.msgType == MsgType.删除好友)
                    {
                        string friendAutoId = fromInfo.toId;
                        int groupAutoId = Convert.ToInt32(fromInfo.content);
                        GGGroup defaultGroup = ChatDBUtils.GetSingeGroupByAutoId(groupAutoId);
                        bool isSuc = ChatDBUtils.DelFriend(defaultGroup, friendAutoId);
                        //信息转发给指定客户端
                        toInfo.content = "成功删除好友" + GGUserUtils.ShowNickAndId(fromInfo.toUser);
                        SocketUtils.SendToSingleClient(toInfo);
                    }
                    else if (fromInfo.msgType == MsgType.添加好友)
                    {
                        //检查默认分组
                        CheckDefaultGroup(fromInfo);

                        GGUserInfo user = ChatDBUtils.GetPerInfoByUserId(fromInfo.toId);
                        GGGroup defaultGroup = ChatDBUtils.GetDefaultGroup(fromInfo.fromId);
                        bool isSuc = ChatDBUtils.AddFriend(defaultGroup, user.userAutoid);
                        //信息转发给指定客户端
                        toInfo.content = "成功添加" + GGUserUtils.ShowNickAndId(fromInfo.toUser) + "为好友";
                        SocketUtils.SendToSingleClient(toInfo);
                    }
                    else if (fromInfo.msgType == MsgType.获取好友信息)
                    {
                        List<GGGroup> groupList = ChatDBUtils.GetGroupFriendsInfo(fromInfo.fromId);
                        toInfo.content = SerializerUtil.ObjectToJson<List<GGGroup>>(groupList);
                        //将好友信息发送给制定客户端，刷新好友在线情况
                        SocketUtils.SendToSingleClient(toInfo);
                        toInfo.content = GGUserUtils.ShowNickAndId(fromInfo.fromUser) + "的好友情况如下：" + ChatDBUtils.GetPerOnlineGroupFriendsStr(fromInfo.fromId);
                    }
                    else if (fromInfo.msgType == MsgType.群发抖动)
                    {
                        //信息分发给其他客户端
                        SocketUtils.SendToMultiClients(OnlineUserUtils.GetAllOnlineClients(), fromInfo);
                    }
                    else if (fromInfo.msgType == MsgType.私发抖动)
                    {
                        toInfo.fromUser = OnlineUserUtils.GetSingleOnlineClient(fromInfo.fromId);
                        if (OnlineUserUtils.CheckClientIsOnline(fromInfo.toId))
                        {
                            toInfo.toUser = OnlineUserUtils.GetSingleOnlineClient(fromInfo.toId);
                            toInfo.content = GGUserUtils.ShowNickAndId(toInfo.fromUser) + " 给你发了一个抖动";
                            toInfo.socket = toInfo.toUser.socket;
                            SocketUtils.SendToSingleClient(toInfo);
                        }
                        toInfo.content = GGUserUtils.ShowNickAndId(fromInfo.fromUser) + " 给" + GGUserUtils.ShowNickAndId(fromInfo.toUser) + "发了一个抖动";
                    }
                    else if (fromInfo.msgType == MsgType.退出聊天室)
                    {
                        SocketUtils.SendToMultiClients(OnlineUserUtils.GetAllOnlineClients(), toInfo);
                    }
                    else if (fromInfo.msgType == MsgType.群发红包)
                    {
                        //信息分发给其他客户端
                        SocketUtils.SendToMultiClients(OnlineUserUtils.GetAllOnlineClients(), toInfo);
                    }
                    else if (fromInfo.msgType == MsgType.下线)
                    {
                        string userId = fromInfo.fromId;
                        GGUserInfo user = OnlineUserUtils.GetSingleOnlineClient(userId);
                        toInfo.content = GGUserUtils.ShowNickAndId(user) + " 下线了";
                        //user.socket.Close();
                        //下线客户端
                        OnlineUserUtils.RemoveOnlineClient(userId);
                    }
                    else if (fromInfo.msgType == MsgType.上线)
                    {
                        //信息分发给其他客户端
                        SocketUtils.SendToMultiClients(OnlineUserUtils.GetAllOnlineClients(), toInfo);
                    }
                    else if (fromInfo.msgType == MsgType.群聊)
                    {
                        //信息分发给其他客户端
                        SocketUtils.SendToMultiClients(OnlineUserUtils.GetAllOnlineClients(), toInfo);
                    }
                    else
                    {
                        toInfo.content = "未知信息：[ " + fromInfo.msgType + " ]  " + fromInfo.content;
                    }
                    //信息显示到服务器
                    ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                }
                catch (Exception ex)
                {
                    MessageInfo toInfo = new MessageInfo();
                    toInfo.msgType = MsgType.异常报告;
                    toInfo.content = GGUserUtils.ShowNickAndId(currentUser) + "被强制下线，服务器读取信息时异常：" + ex.Message;
                    //信息显示到服务器
                    ChatUtils.AppendMsgToServerChatList(this.serverChatRecords, toInfo);
                    //关闭连接并下线客户端
                    //userInfo.UserSocket1.Close();
                    OnlineUserUtils.RemoveOnlineClient(currentUser.userId);
                    //currentUser.socket.Close();
                    SoundUtils.playSound(toInfo.msgType + toInfo.content, EndPointEnum.服务器);
                }
            }
        }
        /// <summary>
        /// 检查是否存在默认分组，不存在则添加
        /// </summary>
        /// <param name="fromInfo"></param>
        private static void CheckDefaultGroup(MessageInfo fromInfo)
        {
            GGUserInfo tmpUser = ChatDBUtils.GetPerInfoByUserId(fromInfo.fromId);
            GGGroup defaultGroup = ChatDBUtils.GetDefaultGroup(tmpUser.userId);
            if (defaultGroup == null)
            {
                ChatDBUtils.CreateGroup(tmpUser, "我的好友", true);
            }
        }
    }

}