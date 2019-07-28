using Common.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Utils
{
    public class GGUserUtils
    {

        /// <summary>
        /// 得到昵称和ID
        /// </summary>
        public static string GetNickAndId(GGUserInfo user)
        {
            return user.userNickName + "(" + user.userId + ")";
        }


        public static string ShowNickAndId(GGUserInfo user)
        {
            return " [ "+user.userNickName + "(" + user.userId + ") ] ";
        }

        /// <summary>
        /// 得到聊天窗口的 key
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
          public static string GetChatFormKey(GGUserInfo fromUser,GGUserInfo toUser)
        {
            return fromUser.userId + ":" + toUser.userId;
        }

    }
}
