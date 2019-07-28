namespace FrmClient
{
    partial class UserInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInfoForm));
            this.userName = new CCWin.SkinControl.SkinLabel();
            this.userQm = new CCWin.SkinControl.SkinLabel();
            this.userHeadImg = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.userHeadImg)).BeginInit();
            this.SuspendLayout();
            // 
            // userName
            // 
            this.userName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.userName.BackColor = System.Drawing.Color.Transparent;
            this.userName.BorderColor = System.Drawing.Color.Black;
            this.userName.BorderSize = 4;
            this.userName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userName.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.userName.ForeColor = System.Drawing.Color.White;
            this.userName.Location = new System.Drawing.Point(177, 23);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(145, 34);
            this.userName.TabIndex = 104;
            this.userName.Text = "威廉乔克斯_汀";
            // 
            // userQm
            // 
            this.userQm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userQm.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.Anamorphosis;
            this.userQm.BackColor = System.Drawing.Color.Transparent;
            this.userQm.BorderColor = System.Drawing.Color.Black;
            this.userQm.BorderSize = 4;
            this.userQm.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.userQm.ForeColor = System.Drawing.Color.White;
            this.userQm.Location = new System.Drawing.Point(179, 89);
            this.userQm.Name = "userQm";
            this.userQm.Size = new System.Drawing.Size(176, 20);
            this.userQm.TabIndex = 105;
            this.userQm.Text = "退一步海阔天空！";
            // 
            // userHeadImg
            // 
            this.userHeadImg.BackColor = System.Drawing.Color.Transparent;
            this.userHeadImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.userHeadImg.Image = ((System.Drawing.Image)(resources.GetObject("userHeadImg.Image")));
            this.userHeadImg.Location = new System.Drawing.Point(0, 0);
            this.userHeadImg.Name = "userHeadImg";
            this.userHeadImg.Size = new System.Drawing.Size(153, 231);
            this.userHeadImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userHeadImg.TabIndex = 103;
            this.userHeadImg.TabStop = false;
            // 
            // UserInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(428, 231);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.userQm);
            this.Controls.Add(this.userHeadImg);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserInfoForm";
            this.VisibleChanged += new System.EventHandler(this.UserInfoForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.userHeadImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinLabel userName;
        private CCWin.SkinControl.SkinLabel userQm;
        private System.Windows.Forms.PictureBox userHeadImg;
    }
}