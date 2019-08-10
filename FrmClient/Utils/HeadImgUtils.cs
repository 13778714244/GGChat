using Common.model;
using Common.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrmClient.Utils
{
    public class HeadImgUtils
    {
        private static string ONLINE = "online";
        private static string OFFLINE = "offline";

        /// <summary>
        /// 保存在线头像
        /// </summary>
        /// <param name="heaImg"></param>
        /// <param name="userImg"></param>
        /// <returns></returns>
        private static void SaveOnlineHeadImg(Image image, GGUserInfo user)
        {
            user.isOnLine = true;
            HeadImgUtils.SaveHeadImg(image, user);
        }

        /// <summary>
        /// 保存离线头像
        /// </summary>
        /// <param name="heaImg"></param>
        /// <param name="userImg"></param>
        /// <returns></returns>
        private static void SaveOfflineHeadImg(Image image, GGUserInfo user)
        {
            user.isOnLine = false;
            HeadImgUtils.SaveHeadImg(image, user);
        }

        /// <summary>
        /// 保存用户注册时候的图片
        /// </summary>
        /// <param name="userImg"></param>
        public static void SaveRegisterUserHeadImg(Image image, GGUserInfo user)
        {
            HeadImgUtils.SaveOfflineHeadImg(image, user);//添离线图片
            HeadImgUtils.SaveOnlineHeadImg(image, user);//添加在线图片
        }


        /// <summary>
        /// 设置头像
        /// </summary>
        /// <param name="heaImg"></param>
        /// <param name="userImg"></param>
        /// <returns></returns>
        private static void SaveHeadImg(Image image, GGUserInfo user)
        {
            string name = user.userId;
            string extend = Path.GetExtension(user.userImg);
            string path = SingleUtils.userImgPath + name + "_" + (user.isOnLine ? HeadImgUtils.ONLINE : HeadImgUtils.OFFLINE) + extend;
            Image newHeadImg = null;
            if (user.isOnLine)
            {
                newHeadImg = image;
            }
            else
            {
                newHeadImg = ImageUtils.GetGrayImg(image);
            }
            newHeadImg = ImageUtils.GetReducedImage(newHeadImg, 50, 50);//压缩图片
            newHeadImg.Save(path);
        }

        /// <summary>
        /// 显示状态头像
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static Image ShowHeadImg(GGUserInfo user)
        {
            string name = user.userId;
            string extend = Path.GetExtension(user.userImg);
            string path = null;
            if (user.isOnLine)
            {
                path = SingleUtils.userImgPath + name + "_" + HeadImgUtils.ONLINE + extend;
            }
            else
            {
                path = SingleUtils.userImgPath + name + "_" + HeadImgUtils.OFFLINE + extend;
            }
            return Image.FromFile(path);
        }
    }
}
