using Common.enums;
using Common.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class FileUtils
    {
        public static FileType GetFileExtendName(string extendName)
        {
            FileType fileType = FileType.jpg;
            switch (extendName.ToLower())
            {
                case ".jpg":
                    fileType = FileType.jpg;
                    break;
                case ".png":
                    fileType = FileType.png;
                    break;
                case ".gif":
                    fileType = FileType.gif;
                    break;
                case ".xls":
                    fileType = FileType.xls;
                    break;
                case ".xlsx":
                    fileType = FileType.xlsx;
                    break;
                case ".doc":
                    fileType = FileType.doc;
                    break;
                case ".docx":
                    fileType = FileType.docx;
                    break;
                case ".txt":
                    fileType = FileType.txt;
                    break;
                case ".mp3":
                    fileType = FileType.mp3;
                    break;
                case ".mp4":
                    fileType = FileType.mp4;
                    break;
                case ".wmv":
                    fileType = FileType.wmv;
                    break;
                case ".rar":
                    fileType = FileType.rar;
                    break;
                case ".zip":
                    fileType = FileType.rar;
                    break;
                case ".exe":
                    fileType = FileType.rar;
                    break;
                case ".bat":
                    fileType = FileType.rar;
                    break;
                case ".js":
                    fileType = FileType.rar;
                    break;
                case ".css":
                    fileType = FileType.rar;
                    break;
                case ".html":
                    fileType = FileType.rar;
                    break;
                case ".htm":
                    fileType = FileType.rar;
                    break;
                default:
                    fileType = 0;
                    break;
            }

            return fileType;
        }

        /// <summary>
        /// 追加文本
        /// </summary>
        /// <param name="content"></param>
        private static void AppendTxt(string filePath, string content)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(content);
            }
        }

        /// <summary>
        /// 记住密码
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="content"></param>
        public static void RemeberPwd(GGUserInfo loginUser)
        {
            //541789021 000 遗忘成事 4.png
            string content = string.Format("{0} {1} {2} {3}", loginUser.userId, loginUser.userPwd, loginUser.userNickName, loginUser.userImg);
            FileUtils.AppendTxt(ToolUtils.GetRemPwdFile(), content);
        }

        /// <summary>
        /// 读取记住的登陆信息
        /// </summary>
        /// <param name="remPwdTxtPath"></param>
        /// <returns></returns>
        public static string[] ReadRemeberInfo(string remPwdTxtPath)
        {
            try
            {
                string[] remPwdArr = File.ReadAllLines(remPwdTxtPath, Encoding.UTF8);
                return remPwdArr;
            }
            catch (Exception ex)
            {
                return new string[0];
            }
        }
    }
}
