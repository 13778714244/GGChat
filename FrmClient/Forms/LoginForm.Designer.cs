namespace FrmClient
{
    partial class LoginForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.menuStripState = new CCWin.SkinControl.SkinContextMenuStrip();
            this.ItemImonline = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemAway = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemBusy = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemMute = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemInVisble = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_state = new System.Windows.Forms.ImageList(this.components);
            this.menuStripId = new CCWin.SkinControl.SkinContextMenuStrip();
            this.toolShow = new System.Windows.Forms.ToolTip(this.components);
            this.buttonLogin = new CCWin.SkinControl.SkinButton();
            this.skinButton3 = new CCWin.SkinControl.SkinButton();
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.panelHeadImage = new CCWin.SkinControl.SkinPanel();
            this.skinButton_State = new CCWin.SkinControl.SkinButton();
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.textBoxPwd = new CCWin.SkinControl.SkinTextBox();
            this.textBoxId = new CCWin.SkinControl.SkinTextBox();
            this.imgLoadding = new System.Windows.Forms.PictureBox();
            this.checkBoxRememberPwd = new CCWin.SkinControl.SkinCheckBox();
            this.checkBoxAutoLogin = new CCWin.SkinControl.SkinCheckBox();
            this.skinLabel_SoftName = new CCWin.SkinControl.SkinLabel();
            this.btnRegister = new CCWin.SkinControl.SkinButton();
            this.skinButtom1 = new CCWin.SkinControl.SkinButton();
            this.process1 = new System.Diagnostics.Process();
            this.menuStripState.SuspendLayout();
            this.panelHeadImage.SuspendLayout();
            this.textBoxPwd.SuspendLayout();
            this.textBoxId.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripState
            // 
            this.menuStripState.Arrow = System.Drawing.Color.Black;
            this.menuStripState.Back = System.Drawing.Color.White;
            this.menuStripState.BackRadius = 4;
            this.menuStripState.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.menuStripState.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuStripState.Fore = System.Drawing.Color.Black;
            this.menuStripState.HoverFore = System.Drawing.Color.White;
            this.menuStripState.ImageScalingSize = new System.Drawing.Size(11, 11);
            this.menuStripState.ItemAnamorphosis = false;
            this.menuStripState.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripState.ItemBorderShow = false;
            this.menuStripState.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripState.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripState.ItemRadius = 4;
            this.menuStripState.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuStripState.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ItemImonline,
            this.ItemAway,
            this.ItemBusy,
            this.ItemMute,
            this.ItemInVisble});
            this.menuStripState.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuStripState.Name = "MenuState";
            this.menuStripState.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.menuStripState.Size = new System.Drawing.Size(139, 114);
            this.menuStripState.SkinAllColor = true;
            this.menuStripState.TitleAnamorphosis = false;
            this.menuStripState.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.menuStripState.TitleRadius = 4;
            this.menuStripState.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // ItemImonline
            // 
            this.ItemImonline.AutoSize = false;
            this.ItemImonline.Name = "ItemImonline";
            this.ItemImonline.Size = new System.Drawing.Size(105, 22);
            this.ItemImonline.Tag = "2";
            this.ItemImonline.Text = "我在线上";
            this.ItemImonline.ToolTipText = "表示希望好友看到您在线。\r\n声音：开启\r\n消息提醒框：开启\r\n会话消息：任务栏头像闪动\r\n";
            // 
            // ItemAway
            // 
            this.ItemAway.AutoSize = false;
            this.ItemAway.Name = "ItemAway";
            this.ItemAway.Size = new System.Drawing.Size(105, 22);
            this.ItemAway.Tag = "3";
            this.ItemAway.Text = "离开";
            this.ItemAway.ToolTipText = "表示离开，暂无法处理消息。\r\n声音：开启\r\n消息提醒框：开启\r\n会话消息：任务栏头像闪动\r\n";
            // 
            // ItemBusy
            // 
            this.ItemBusy.AutoSize = false;
            this.ItemBusy.Name = "ItemBusy";
            this.ItemBusy.Size = new System.Drawing.Size(105, 22);
            this.ItemBusy.Tag = "4";
            this.ItemBusy.Text = "忙碌";
            this.ItemBusy.ToolTipText = "表示忙碌，不会及时处理消息。\r\n声音：开启\r\n消息提醒框：开启\r\n会话消息：任务栏显示气泡\r\n";
            // 
            // ItemMute
            // 
            this.ItemMute.AutoSize = false;
            this.ItemMute.Name = "ItemMute";
            this.ItemMute.Size = new System.Drawing.Size(105, 22);
            this.ItemMute.Tag = "5";
            this.ItemMute.Text = "请勿打扰";
            this.ItemMute.ToolTipText = "表示不想被打扰。\r\n声音：关闭\r\n消息提醒框：关闭\r\n会话消息：任务栏显示气泡\r\n\r\n";
            // 
            // ItemInVisble
            // 
            this.ItemInVisble.AutoSize = false;
            this.ItemInVisble.Name = "ItemInVisble";
            this.ItemInVisble.Size = new System.Drawing.Size(105, 22);
            this.ItemInVisble.Tag = "6";
            this.ItemInVisble.Text = "隐身";
            this.ItemInVisble.ToolTipText = "表示好友看到您是离线的。\r\n声音：开启\r\n消息提醒框：开启\r\n会话消息：任务栏头像闪动\r\n";
            // 
            // imageList_state
            // 
            this.imageList_state.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_state.ImageStream")));
            this.imageList_state.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_state.Images.SetKeyName(0, "0.png");
            this.imageList_state.Images.SetKeyName(1, "1.png");
            this.imageList_state.Images.SetKeyName(2, "2.png");
            this.imageList_state.Images.SetKeyName(3, "3.png");
            this.imageList_state.Images.SetKeyName(4, "4.png");
            this.imageList_state.Images.SetKeyName(5, "5.png");
            // 
            // menuStripId
            // 
            this.menuStripId.Arrow = System.Drawing.Color.Black;
            this.menuStripId.AutoSize = false;
            this.menuStripId.Back = System.Drawing.Color.White;
            this.menuStripId.BackColor = System.Drawing.Color.White;
            this.menuStripId.BackRadius = 4;
            this.menuStripId.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.menuStripId.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(147)))), ((int)(((byte)(209)))));
            this.menuStripId.Fore = System.Drawing.Color.Black;
            this.menuStripId.HoverFore = System.Drawing.Color.White;
            this.menuStripId.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStripId.ItemAnamorphosis = false;
            this.menuStripId.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemBorderShow = false;
            this.menuStripId.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.menuStripId.ItemRadius = 4;
            this.menuStripId.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuStripId.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.menuStripId.Name = "MenuId";
            this.menuStripId.RadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuStripId.Size = new System.Drawing.Size(183, 4);
            this.menuStripId.SkinAllColor = true;
            this.menuStripId.TitleAnamorphosis = false;
            this.menuStripId.TitleColor = System.Drawing.Color.White;
            this.menuStripId.TitleRadius = 4;
            this.menuStripId.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.menuStripId.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.menuStripId_Closing);
            // 
            // toolShow
            // 
            this.toolShow.IsBalloon = true;
            // 
            // buttonLogin
            // 
            this.buttonLogin.BackColor = System.Drawing.Color.Transparent;
            this.buttonLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonLogin.BackRectangle = new System.Drawing.Rectangle(50, 23, 50, 23);
            this.buttonLogin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(118)))), ((int)(((byte)(156)))));
            this.buttonLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.buttonLogin.Create = true;
            this.buttonLogin.DownBack = global::FrmClient.Properties.Resources.button_login_down;
            this.buttonLogin.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.buttonLogin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.buttonLogin.ForeColor = System.Drawing.Color.Black;
            this.buttonLogin.Location = new System.Drawing.Point(144, 300);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLogin.MouseBack = global::FrmClient.Properties.Resources.button_login_hover;
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.NormlBack = global::FrmClient.Properties.Resources.button_login_normal;
            this.buttonLogin.Palace = true;
            this.buttonLogin.Size = new System.Drawing.Size(247, 61);
            this.buttonLogin.TabIndex = 131;
            this.buttonLogin.Text = "登        录";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // skinButton3
            // 
            this.skinButton3.BackColor = System.Drawing.Color.White;
            this.skinButton3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton3.DownBack = null;
            this.skinButton3.Location = new System.Drawing.Point(7, 316);
            this.skinButton3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinButton3.MouseBack = null;
            this.skinButton3.Name = "skinButton3";
            this.skinButton3.NormlBack = null;
            this.skinButton3.Size = new System.Drawing.Size(128, 45);
            this.skinButton3.TabIndex = 142;
            this.skinButton3.Text = "再开一个";
            this.skinButton3.UseVisualStyleBackColor = false;
            this.skinButton3.Click += new System.EventHandler(this.skinButton3_Click);
            // 
            // skinButton2
            // 
            this.skinButton2.BackColor = System.Drawing.Color.White;
            this.skinButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.skinButton2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(118)))), ((int)(((byte)(156)))));
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton2.DownBack")));
            this.skinButton2.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton2.Location = new System.Drawing.Point(444, 128);
            this.skinButton2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinButton2.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton2.MouseBack")));
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton2.NormlBack")));
            this.skinButton2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton2.Size = new System.Drawing.Size(31, 35);
            this.skinButton2.TabIndex = 141;
            this.skinButton2.UseVisualStyleBackColor = false;
            this.skinButton2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.skinButton2_MouseClick);
            // 
            // panelHeadImage
            // 
            this.panelHeadImage.BackColor = System.Drawing.Color.Transparent;
            this.panelHeadImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelHeadImage.BackgroundImage")));
            this.panelHeadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelHeadImage.Controls.Add(this.skinButton_State);
            this.panelHeadImage.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panelHeadImage.DownBack = null;
            this.panelHeadImage.Location = new System.Drawing.Point(17, 122);
            this.panelHeadImage.Margin = new System.Windows.Forms.Padding(0);
            this.panelHeadImage.MouseBack = null;
            this.panelHeadImage.Name = "panelHeadImage";
            this.panelHeadImage.NormlBack = null;
            this.panelHeadImage.Radius = 4;
            this.panelHeadImage.Size = new System.Drawing.Size(113, 106);
            this.panelHeadImage.TabIndex = 11;
            // 
            // skinButton_State
            // 
            this.skinButton_State.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_State.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("skinButton_State.BackgroundImage")));
            this.skinButton_State.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.skinButton_State.BackRectangle = new System.Drawing.Rectangle(4, 4, 4, 4);
            this.skinButton_State.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(118)))), ((int)(((byte)(156)))));
            this.skinButton_State.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_State.DownBack = null;
            this.skinButton_State.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton_State.ImageSize = new System.Drawing.Size(11, 11);
            this.skinButton_State.Location = new System.Drawing.Point(89, 84);
            this.skinButton_State.Margin = new System.Windows.Forms.Padding(0);
            this.skinButton_State.MouseBack = null;
            this.skinButton_State.Name = "skinButton_State";
            this.skinButton_State.NormlBack = null;
            this.skinButton_State.Size = new System.Drawing.Size(24, 22);
            this.skinButton_State.TabIndex = 10;
            this.skinButton_State.Tag = "2";
            this.skinButton_State.UseVisualStyleBackColor = false;
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.BackgroundImage = global::FrmClient.Properties.Resources.zhuce;
            this.skinButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.skinButton1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(118)))), ((int)(((byte)(156)))));
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.Create = true;
            this.skinButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skinButton1.DownBack = null;
            this.skinButton1.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton1.Location = new System.Drawing.Point(408, 214);
            this.skinButton1.Margin = new System.Windows.Forms.Padding(0);
            this.skinButton1.MouseBack = global::FrmClient.Properties.Resources.zhuce_hover;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = global::FrmClient.Properties.Resources.zhuce;
            this.skinButton1.Size = new System.Drawing.Size(63, 22);
            this.skinButton1.TabIndex = 140;
            this.skinButton1.UseVisualStyleBackColor = false;
            // 
            // textBoxPwd
            // 
            this.textBoxPwd.BackColor = System.Drawing.Color.Transparent;
            this.textBoxPwd.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textBoxPwd.Icon = ((System.Drawing.Image)(resources.GetObject("textBoxPwd.Icon")));
            this.textBoxPwd.IconIsButton = true;
            this.textBoxPwd.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxPwd.Location = new System.Drawing.Point(141, 175);
            this.textBoxPwd.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxPwd.MinimumSize = new System.Drawing.Size(0, 35);
            this.textBoxPwd.MouseBack = null;
            this.textBoxPwd.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxPwd.Name = "textBoxPwd";
            this.textBoxPwd.NormlBack = null;
            this.textBoxPwd.Padding = new System.Windows.Forms.Padding(7, 6, 80, 6);
            this.textBoxPwd.Size = new System.Drawing.Size(333, 35);
            // 
            // textBoxPwd.BaseText
            // 
            this.textBoxPwd.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPwd.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPwd.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textBoxPwd.SkinTxt.Location = new System.Drawing.Point(7, 6);
            this.textBoxPwd.SkinTxt.Name = "BaseText";
            this.textBoxPwd.SkinTxt.PasswordChar = '●';
            this.textBoxPwd.SkinTxt.Size = new System.Drawing.Size(246, 22);
            this.textBoxPwd.SkinTxt.TabIndex = 0;
            this.textBoxPwd.SkinTxt.Text = "000";
            this.textBoxPwd.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textBoxPwd.SkinTxt.WaterText = "密码";
            this.textBoxPwd.TabIndex = 138;
            this.textBoxPwd.IconClick += new System.EventHandler(this.textBoxPwd_IconClick);
            // 
            // textBoxId
            // 
            this.textBoxId.BackColor = System.Drawing.Color.Transparent;
            this.textBoxId.Icon = null;
            this.textBoxId.IconIsButton = false;
            this.textBoxId.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxId.Location = new System.Drawing.Point(141, 128);
            this.textBoxId.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxId.MinimumSize = new System.Drawing.Size(37, 35);
            this.textBoxId.MouseBack = null;
            this.textBoxId.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.NormlBack = null;
            this.textBoxId.Padding = new System.Windows.Forms.Padding(7, 6, 37, 6);
            this.textBoxId.Size = new System.Drawing.Size(333, 35);
            // 
            // textBoxId.BaseText
            // 
            this.textBoxId.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxId.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxId.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.textBoxId.SkinTxt.Location = new System.Drawing.Point(7, 6);
            this.textBoxId.SkinTxt.Name = "BaseText";
            this.textBoxId.SkinTxt.Size = new System.Drawing.Size(289, 22);
            this.textBoxId.SkinTxt.TabIndex = 0;
            this.textBoxId.SkinTxt.Text = "617828826";
            this.textBoxId.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.textBoxId.SkinTxt.WaterText = "帐号";
            this.textBoxId.TabIndex = 137;
            // 
            // imgLoadding
            // 
            this.imgLoadding.Image = ((System.Drawing.Image)(resources.GetObject("imgLoadding.Image")));
            this.imgLoadding.Location = new System.Drawing.Point(-5, 269);
            this.imgLoadding.Margin = new System.Windows.Forms.Padding(0);
            this.imgLoadding.Name = "imgLoadding";
            this.imgLoadding.Size = new System.Drawing.Size(503, 2);
            this.imgLoadding.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgLoadding.TabIndex = 134;
            this.imgLoadding.TabStop = false;
            this.imgLoadding.Visible = false;
            // 
            // checkBoxRememberPwd
            // 
            this.checkBoxRememberPwd.AutoSize = true;
            this.checkBoxRememberPwd.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxRememberPwd.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkBoxRememberPwd.DefaultCheckButtonWidth = 15;
            this.checkBoxRememberPwd.DownBack = null;
            this.checkBoxRememberPwd.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBoxRememberPwd.ForeColor = System.Drawing.Color.Black;
            this.checkBoxRememberPwd.LightEffect = false;
            this.checkBoxRememberPwd.Location = new System.Drawing.Point(144, 214);
            this.checkBoxRememberPwd.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxRememberPwd.MouseBack = null;
            this.checkBoxRememberPwd.Name = "checkBoxRememberPwd";
            this.checkBoxRememberPwd.NormlBack = ((System.Drawing.Image)(resources.GetObject("checkBoxRememberPwd.NormlBack")));
            this.checkBoxRememberPwd.SelectedDownBack = null;
            this.checkBoxRememberPwd.SelectedMouseBack = null;
            this.checkBoxRememberPwd.SelectedNormlBack = null;
            this.checkBoxRememberPwd.Size = new System.Drawing.Size(91, 24);
            this.checkBoxRememberPwd.TabIndex = 129;
            this.checkBoxRememberPwd.Text = "记住密码";
            this.checkBoxRememberPwd.UseVisualStyleBackColor = false;
            // 
            // checkBoxAutoLogin
            // 
            this.checkBoxAutoLogin.AutoSize = true;
            this.checkBoxAutoLogin.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxAutoLogin.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.checkBoxAutoLogin.DefaultCheckButtonWidth = 15;
            this.checkBoxAutoLogin.DownBack = null;
            this.checkBoxAutoLogin.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.checkBoxAutoLogin.ForeColor = System.Drawing.Color.Black;
            this.checkBoxAutoLogin.LightEffect = false;
            this.checkBoxAutoLogin.Location = new System.Drawing.Point(252, 214);
            this.checkBoxAutoLogin.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxAutoLogin.MouseBack = null;
            this.checkBoxAutoLogin.Name = "checkBoxAutoLogin";
            this.checkBoxAutoLogin.NormlBack = ((System.Drawing.Image)(resources.GetObject("checkBoxAutoLogin.NormlBack")));
            this.checkBoxAutoLogin.SelectedDownBack = null;
            this.checkBoxAutoLogin.SelectedMouseBack = null;
            this.checkBoxAutoLogin.SelectedNormlBack = null;
            this.checkBoxAutoLogin.Size = new System.Drawing.Size(91, 24);
            this.checkBoxAutoLogin.TabIndex = 130;
            this.checkBoxAutoLogin.Text = "自动登录";
            this.checkBoxAutoLogin.UseVisualStyleBackColor = false;
            this.checkBoxAutoLogin.CheckedChanged += new System.EventHandler(this.checkBoxAutoLogin_CheckedChanged);
            // 
            // skinLabel_SoftName
            // 
            this.skinLabel_SoftName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel_SoftName.AutoSize = true;
            this.skinLabel_SoftName.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_SoftName.BorderColor = System.Drawing.Color.White;
            this.skinLabel_SoftName.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_SoftName.ForeColor = System.Drawing.Color.Black;
            this.skinLabel_SoftName.Location = new System.Drawing.Point(3, 2);
            this.skinLabel_SoftName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.skinLabel_SoftName.Name = "skinLabel_SoftName";
            this.skinLabel_SoftName.Size = new System.Drawing.Size(0, 24);
            this.skinLabel_SoftName.TabIndex = 136;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnRegister.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(118)))), ((int)(((byte)(156)))));
            this.btnRegister.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnRegister.Create = true;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.DownBack = null;
            this.btnRegister.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnRegister.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRegister.Location = new System.Drawing.Point(408, 208);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegister.MouseBack = null;
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.NormlBack = null;
            this.btnRegister.Size = new System.Drawing.Size(68, 20);
            this.btnRegister.TabIndex = 132;
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // skinButtom1
            // 
            this.skinButtom1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.skinButtom1.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButtom1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButtom1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.skinButtom1.DownBack = null;
            this.skinButtom1.DrawType = CCWin.SkinControl.DrawStyle.None;
            this.skinButtom1.Image = ((System.Drawing.Image)(resources.GetObject("skinButtom1.Image")));
            this.skinButtom1.Location = new System.Drawing.Point(331, 332);
            this.skinButtom1.Margin = new System.Windows.Forms.Padding(0);
            this.skinButtom1.MouseBack = null;
            this.skinButtom1.Name = "skinButtom1";
            this.skinButtom1.NormlBack = null;
            this.skinButtom1.Size = new System.Drawing.Size(21, 20);
            this.skinButtom1.TabIndex = 139;
            this.skinButtom1.UseVisualStyleBackColor = false;
            // 
            // process1
            // 
            this.process1.StartInfo.Domain = "";
            this.process1.StartInfo.LoadUserProfile = false;
            this.process1.StartInfo.Password = null;
            this.process1.StartInfo.StandardErrorEncoding = null;
            this.process1.StartInfo.StandardOutputEncoding = null;
            this.process1.StartInfo.UserName = "";
            this.process1.SynchronizingObject = this;
            // 
            // LoginForm
            // 
            this.AcceptButton = this.buttonLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackPalace = global::FrmClient.Properties.Resources.texture;
            this.BackToColor = false;
            this.BorderPalace = global::FrmClient.Properties.Resources.BackPalace1;
            this.ClientSize = new System.Drawing.Size(495, 378);
            this.Controls.Add(this.skinButton3);
            this.Controls.Add(this.skinButton2);
            this.Controls.Add(this.panelHeadImage);
            this.Controls.Add(this.skinButton1);
            this.Controls.Add(this.textBoxPwd);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.imgLoadding);
            this.Controls.Add(this.checkBoxRememberPwd);
            this.Controls.Add(this.checkBoxAutoLogin);
            this.Controls.Add(this.skinLabel_SoftName);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.skinButtom1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.menuStripState.ResumeLayout(false);
            this.panelHeadImage.ResumeLayout(false);
            this.textBoxPwd.ResumeLayout(false);
            this.textBoxPwd.PerformLayout();
            this.textBoxId.ResumeLayout(false);
            this.textBoxId.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgLoadding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinContextMenuStrip menuStripState;
        private System.Windows.Forms.ToolStripMenuItem ItemImonline;
        private System.Windows.Forms.ToolStripMenuItem ItemAway;
        private System.Windows.Forms.ToolStripMenuItem ItemBusy;
        private System.Windows.Forms.ToolStripMenuItem ItemMute;
        private System.Windows.Forms.ToolStripMenuItem ItemInVisble;
        private System.Windows.Forms.ImageList imageList_state;
        private CCWin.SkinControl.SkinTextBox textBoxPwd;
        private CCWin.SkinControl.SkinButton skinButton_State;
        private CCWin.SkinControl.SkinPanel panelHeadImage;
        private CCWin.SkinControl.SkinTextBox textBoxId;
        private System.Windows.Forms.PictureBox imgLoadding;
        private CCWin.SkinControl.SkinCheckBox checkBoxRememberPwd;
        private CCWin.SkinControl.SkinCheckBox checkBoxAutoLogin;
        private CCWin.SkinControl.SkinLabel skinLabel_SoftName;
        private CCWin.SkinControl.SkinButton btnRegister;
        private CCWin.SkinControl.SkinButton buttonLogin;
        private CCWin.SkinControl.SkinContextMenuStrip menuStripId;
        private CCWin.SkinControl.SkinButton skinButtom1;
        private System.Windows.Forms.ToolTip toolShow;
        private CCWin.SkinControl.SkinButton skinButton1;
        private CCWin.SkinControl.SkinButton skinButton2;
        private CCWin.SkinControl.SkinButton skinButton3;
        private System.Diagnostics.Process process1;

    }
}