using Common.enums;
using System;
using System.Collections.Generic;
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
            }
            return fileType;
        }
    }
}
