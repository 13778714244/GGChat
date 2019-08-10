using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public class ImageUtils
    {


        /// <summary>
        /// 将彩色图片转化为灰色
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap GetGrayImg(Image img)
        {
            int Height = img.Height;
            int Width = img.Width;
            Bitmap bitmap = new Bitmap(Width, Height);
            Bitmap MyBitmap = (Bitmap)img;
            Color pixel;
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    pixel = MyBitmap.GetPixel(x, y);
                    int r, g, b, Result = 0;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    //实例程序以加权平均值法产生黑白图像  
                    int iType = 2;
                    switch (iType)
                    {
                        case 0://平均值法  
                            Result = ((r + g + b) / 3);
                            break;
                        case 1://最大值法  
                            Result = r > g ? r : g;
                            Result = Result > b ? Result : b;
                            break;
                        case 2://加权平均值法  
                            Result = ((int)(0.7 * r) + (int)(0.2 * g) + (int)(0.1 * b));
                            break;
                    }
                    bitmap.SetPixel(x, y, Color.FromArgb(Result, Result, Result));
                }
            return bitmap;
        }


        /// <summary>
        /// 生成缩略图重载方法1，返回缩略图的Image对象
        /// </summary>
        /// <param name="Width">缩略图的宽度</param>
        /// <param name="Height">缩略图的高度</param>
        /// <returns>缩略图的Image对象</returns>
        public static Image GetReducedImage(Image ResourceImage, int Width = 100, int Height = 100)
        {
            try
            {

                //用指定的大小和格式初始化Bitmap类的新实例
                Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format32bppArgb);
                //从指定的Image对象创建新Graphics对象
                Graphics graphics = Graphics.FromImage(bitmap);
                //清除整个绘图面并以透明背景色填充
                graphics.Clear(Color.Transparent);
                //在指定位置并且按指定大小绘制原图片对象
                graphics.DrawImage(ResourceImage, new Rectangle(0, 0, Width, Height));
                return bitmap;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary> 
        /// 按照比例缩小图片 
        /// </summary> 
        /// <param name="srcImage">要缩小的图片</param> 
        /// <param name="percent">缩小比例</param> 
        /// <returns>缩小后的结果</returns> 
        public static Bitmap PercentImage(Image srcImage, double percent = 0.5)
        {
            // 缩小后的高度 
            int newH = int.Parse(Math.Round(srcImage.Height * percent).ToString());
            // 缩小后的宽度 
            int newW = int.Parse(Math.Round(srcImage.Width * percent).ToString());
            try
            {
                // 要保存到的图片 
                Bitmap b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);
                // 插值算法的质量 
                g.InterpolationMode = InterpolationMode.Default;
                g.DrawImage(srcImage, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, srcImage.Width, srcImage.Height), GraphicsUnit.Pixel);
                g.Dispose();
                return b;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
