namespace Controls
{
    partial class WinUserInfo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.head = new System.Windows.Forms.PictureBox();
            this.nick = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.head)).BeginInit();
            this.SuspendLayout();
            // 
            // head
            // 
            this.head.Dock = System.Windows.Forms.DockStyle.Left;
            this.head.Location = new System.Drawing.Point(0, 0);
            this.head.Name = "head";
            this.head.Size = new System.Drawing.Size(77, 83);
            this.head.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.head.TabIndex = 0;
            this.head.TabStop = false;
            // 
            // nick
            // 
            this.nick.AutoSize = true;
            this.nick.Dock = System.Windows.Forms.DockStyle.Top;
            this.nick.Location = new System.Drawing.Point(77, 0);
            this.nick.Name = "nick";
            this.nick.Size = new System.Drawing.Size(37, 15);
            this.nick.TabIndex = 1;
            this.nick.Text = "昵称";
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(77, 53);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(132, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "加好友";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // WinUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.nick);
            this.Controls.Add(this.head);
            this.Name = "WinUserInfo";
            this.Size = new System.Drawing.Size(209, 83);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.head)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox head;
        private System.Windows.Forms.Label nick;
        private System.Windows.Forms.Button btnAdd;

    }
}
