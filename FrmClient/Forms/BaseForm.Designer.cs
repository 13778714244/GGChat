namespace FrmClient
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BorderPalace = ((System.Drawing.Image)(resources.GetObject("$this.BorderPalace")));
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.ClientSize = new System.Drawing.Size(428, 231);
            this.CloseBoxSize = new System.Drawing.Size(39, 20);
            this.CloseDownBack = global::FrmClient.Properties.Resources.btn_close_down;
            this.CloseMouseBack = global::FrmClient.Properties.Resources.btn_close_highlight;
            this.CloseNormlBack = global::FrmClient.Properties.Resources.btn_close_disable;
            this.ControlBoxOffset = new System.Drawing.Point(0, 0);
            this.EffectWidth = 0;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaxDownBack = global::FrmClient.Properties.Resources.btn_max_down;
            this.MaxMouseBack = global::FrmClient.Properties.Resources.btn_max_highlight;
            this.MaxNormlBack = global::FrmClient.Properties.Resources.btn_max_normal;
            this.MaxSize = new System.Drawing.Size(28, 20);
            this.MiniDownBack = global::FrmClient.Properties.Resources.btn_mini_down;
            this.MinimizeBox = false;
            this.MiniMouseBack = global::FrmClient.Properties.Resources.btn_mini_highlight;
            this.MiniNormlBack = global::FrmClient.Properties.Resources.btn_mini_normal;
            this.MiniSize = new System.Drawing.Size(28, 28);
            this.Name = "BaseForm";
            this.RestoreDownBack = global::FrmClient.Properties.Resources.btn_restore_down;
            this.RestoreMouseBack = global::FrmClient.Properties.Resources.btn_restore_highlight;
            this.RestoreNormlBack = global::FrmClient.Properties.Resources.btn_restore_normal;
            this.Text = " ";
            this.ResumeLayout(false);

        }

        #endregion

    }
}