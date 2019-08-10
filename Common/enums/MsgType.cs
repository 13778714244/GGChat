using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.enums
{
    public enum MsgType
    {

        私发抖动 = 10,
        群发抖动,

        开启禁言,
        解除禁言,

        系统消息,
        异常报告,

        私聊,
        群聊,

        退出聊天室,
        踢出聊天室,

        私发红包,
        群发红包,

        私发文件,
        群发文件,

        下线,
        上线,

        登陆成功,
        登陆失败,

        获取好友信息,

        已登录,
        登录,

        私发离线信息,
        群发离线信息,
        系统离线信息,

        关闭服务器,

        添加好友,
        删除好友,
        创建分组,
        删除分组,
        修改分组,
        移动好友,
        用户注册,


    }
}
