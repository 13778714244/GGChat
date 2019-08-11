using CCWin;
using Common;
using Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmClient
{
    public partial class EmojiForm : Form
    {
        public EmojiForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
            Control.CheckForIllegalCrossThreadCalls = false;
            Update();

            this.Width = cols * (padding + penWeight);
            this.Height = rows * (padding + penWeight * 4);
            this.BackColor = Color.White;
            this.bigPic.Visible = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.bigPic.SizeMode = PictureBoxSizeMode.StretchImage;
            this.bigPic.Size = new Size((imgSize + penWeight * 4) * 2, (imgSize + penWeight * 4) * 2);

            this.emoji.SizeMode = PictureBoxSizeMode.StretchImage;
            this.emoji.Size = new Size(imgSize, imgSize);
            this.emoji.BackColor = Color.LightGray;

        }
        int penWeight = 1;
        int cols = 15;
        int rows = 9;
        int index = 0;
        int padding = 35;
        int imgSize = 32;
        int selecIndex = 1;
        bool isShowBig = true;
        bool isLoad = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            if (isLoad)
            {
                index = 0;
                for (int i = 0; i < cols; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        index++;
                        Image img = ToolUtils.GetEmotion(index + ".gif");
                        //g.DrawImage(img, i * padding, j * padding, imgSize, imgSize);
                        //复制图片副本
                        Bitmap bmp = new Bitmap(img.Width, img.Height, PixelFormat.Format32bppArgb);
                        using (Graphics gg = Graphics.FromImage(bmp))
                        {
                            using (Pen pen = new Pen(Color.Gray, penWeight))
                            {
                                //  gg.DrawRectangle(pen, new Rectangle(0, 0, Math.Abs(bit.Width), Math.Abs(bit.Height)));//加边框
                                gg.DrawRectangle(pen, new Rectangle(0, 0, Math.Abs(bmp.Width), Math.Abs(bmp.Height)));//加椭圆边框
                                PictureBox picBox = new PictureBox();
                                picBox.Click += SelectedEmoj;
                                picBox.BackgroundImageLayout = ImageLayout.Stretch;
                                picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                                picBox.Location = new Point(i * padding, j * padding);
                                picBox.Size = new Size(32, 32);
                                picBox.BorderStyle = BorderStyle.FixedSingle;
                                //picBox.Image = img;
                                picBox.BackgroundImage = img;
                                this.Controls.Add(picBox);
                                this.bigPic.Image = bmp;
                            }
                        }
                    }
                }
            }

        }


        /// <summary>
        /// 选中emoji表情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedEmoj(object sender, EventArgs e)
        {
            Image emojiIcon = ToolUtils.GetEmotion(selecIndex + ".gif");
            this.Tag = emojiIcon;
            this.Text = this.Tag.ToString();
            this.Visible = false;
        }




        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            PictureBox pb = sender as PictureBox;

            this.bigPic.Visible = true;
            try
            {
                int x = e.Location.X;
                int y = e.Location.Y;

                if (x % padding > 0)
                {
                    x = padding * (x / padding);
                }
                if (y % padding > 0)
                {
                    y = padding * (y / padding);
                }
                Point curRectangle = new Point(x, y);
                int curRow = y / padding + 1;
                int curCol = x / padding + 1;

                selecIndex = (curCol - 1) * rows + curRow;

                Image bigImg = ToolUtils.GetEmotion(selecIndex + ".gif");

                if (curCol >= 9)
                {

                    this.bigPic.Location = new Point(0, 0);
                }
                else
                {
                    this.bigPic.Location = new Point(this.Width - this.bigPic.Width - 15, 0);
                }
                if (isShowBig)
                {
                    this.bigPic.Image = bigImg;

                    this.emoji.Image = bigImg;
                    this.emoji.Location = new Point(x, y);
                }
                this.Text = "   第" + selecIndex + "个,X=" + curRectangle.X + "  Y=" + curRectangle.Y + "  行:" + curRow + "  列:" + curCol;
            }
            catch (Exception)
            {
            }
        }

        private void EmojiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void emoji_Click(object sender, EventArgs e)
        {
            Image emojiIcon = ToolUtils.GetEmotion( selecIndex + ".gif");
            this.Tag = emojiIcon;
            this.Text = this.Tag.ToString();
            this.Visible = false;
        }

    }
}
