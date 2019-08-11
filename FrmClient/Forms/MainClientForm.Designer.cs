namespace FrmClient
{
    partial class MainClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainClientForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.skinContextMenuStrip_main = new CCWin.SkinControl.SkinContextMenuStrip();
            this.创建群ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.删除好友ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.查找好友ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.头像显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大头像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小头像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.toolstripButton_mainMenu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.wp = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.skinButton_State = new CCWin.SkinControl.SkinButton();
            this.iconHitTimer = new System.Windows.Forms.Timer(this.components);
            this.friendsList = new System.Windows.Forms.ListView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chatFromList = new System.Windows.Forms.ListView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.noReadMsgList = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picHeadImg = new System.Windows.Forms.PictureBox();
            this.lblQQSign = new System.Windows.Forms.Label();
            this.lblNickName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.skinContextMenuStrip_main.SuspendLayout();
            this.skinToolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeadImg)).BeginInit();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.skinContextMenuStrip_main;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "图标";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // skinContextMenuStrip_main
            // 
            this.skinContextMenuStrip_main.Arrow = System.Drawing.Color.Black;
            this.skinContextMenuStrip_main.Back = System.Drawing.Color.White;
            this.skinContextMenuStrip_main.BackRadius = 4;
            this.skinContextMenuStrip_main.Base = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.skinContextMenuStrip_main.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip_main.Fore = System.Drawing.Color.Black;
            this.skinContextMenuStrip_main.HoverFore = System.Drawing.Color.White;
            this.skinContextMenuStrip_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinContextMenuStrip_main.ItemAnamorphosis = false;
            this.skinContextMenuStrip_main.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_main.ItemBorderShow = false;
            this.skinContextMenuStrip_main.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_main.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinContextMenuStrip_main.ItemRadius = 4;
            this.skinContextMenuStrip_main.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinContextMenuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建群ToolStripMenuItem1,
            this.moveToGroup,
            this.删除好友ToolStripMenuItem1,
            this.查找好友ToolStripMenuItem,
            this.toolStripSeparator5,
            this.头像显示ToolStripMenuItem,
            this.修改密码ToolStripMenuItem,
            this.个人资料ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripMenuItem9,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.skinContextMenuStrip_main.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip_main.Name = "MenuState";
            this.skinContextMenuStrip_main.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_main.Size = new System.Drawing.Size(158, 276);
            this.skinContextMenuStrip_main.SkinAllColor = true;
            this.skinContextMenuStrip_main.TitleAnamorphosis = false;
            this.skinContextMenuStrip_main.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStrip_main.TitleRadius = 4;
            this.skinContextMenuStrip_main.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // 创建群ToolStripMenuItem1
            // 
            this.创建群ToolStripMenuItem1.Name = "创建群ToolStripMenuItem1";
            this.创建群ToolStripMenuItem1.Size = new System.Drawing.Size(157, 26);
            this.创建群ToolStripMenuItem1.Text = "创建分组";
            this.创建群ToolStripMenuItem1.Click += new System.EventHandler(this.创建群ToolStripMenuItem1_Click);
            // 
            // moveToGroup
            // 
            this.moveToGroup.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.moveToGroup.Name = "moveToGroup";
            this.moveToGroup.Size = new System.Drawing.Size(157, 26);
            this.moveToGroup.Text = "移动好友至";
            this.moveToGroup.MouseEnter += new System.EventHandler(this.moveToGroup_MouseEnter);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(233, 26);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(233, 26);
            this.toolStripMenuItem3.Text = "toolStripMenuItem3";
            // 
            // 删除好友ToolStripMenuItem1
            // 
            this.删除好友ToolStripMenuItem1.Name = "删除好友ToolStripMenuItem1";
            this.删除好友ToolStripMenuItem1.Size = new System.Drawing.Size(157, 26);
            this.删除好友ToolStripMenuItem1.Text = "删除好友";
            this.删除好友ToolStripMenuItem1.Click += new System.EventHandler(this.删除好友ToolStripMenuItem1_Click);
            // 
            // 查找好友ToolStripMenuItem
            // 
            this.查找好友ToolStripMenuItem.Name = "查找好友ToolStripMenuItem";
            this.查找好友ToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.查找好友ToolStripMenuItem.Text = "查找好友";
            this.查找好友ToolStripMenuItem.Click += new System.EventHandler(this.查找好友ToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(154, 6);
            // 
            // 头像显示ToolStripMenuItem
            // 
            this.头像显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.大头像ToolStripMenuItem,
            this.小头像ToolStripMenuItem});
            this.头像显示ToolStripMenuItem.Name = "头像显示ToolStripMenuItem";
            this.头像显示ToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.头像显示ToolStripMenuItem.Text = "头像显示";
            // 
            // 大头像ToolStripMenuItem
            // 
            this.大头像ToolStripMenuItem.Checked = true;
            this.大头像ToolStripMenuItem.CheckOnClick = true;
            this.大头像ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.大头像ToolStripMenuItem.Name = "大头像ToolStripMenuItem";
            this.大头像ToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.大头像ToolStripMenuItem.Text = "大头像";
            // 
            // 小头像ToolStripMenuItem
            // 
            this.小头像ToolStripMenuItem.CheckOnClick = true;
            this.小头像ToolStripMenuItem.Name = "小头像ToolStripMenuItem";
            this.小头像ToolStripMenuItem.Size = new System.Drawing.Size(129, 26);
            this.小头像ToolStripMenuItem.Text = "小头像";
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            // 
            // 个人资料ToolStripMenuItem
            // 
            this.个人资料ToolStripMenuItem.Name = "个人资料ToolStripMenuItem";
            this.个人资料ToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.个人资料ToolStripMenuItem.Text = "个人资料";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(157, 26);
            this.toolStripMenuItem1.Text = "切换账号";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem9.Image")));
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(157, 26);
            this.toolStripMenuItem9.Text = "系统设置";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // skinToolStrip1
            // 
            this.skinToolStrip1.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skinToolStrip1.AutoSize = false;
            this.skinToolStrip1.Back = System.Drawing.Color.White;
            this.skinToolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BackRadius = 4;
            this.skinToolStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip1.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip1.BaseForeAnamorphosis = true;
            this.skinToolStrip1.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip1.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.skinToolStrip1.BaseHoverFore = System.Drawing.Color.Black;
            this.skinToolStrip1.BaseItemAnamorphosis = true;
            this.skinToolStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.skinToolStrip1.BaseItemBorderShow = true;
            this.skinToolStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemDown")));
            this.skinToolStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemMouse")));
            this.skinToolStrip1.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BaseItemRadius = 2;
            this.skinToolStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinToolStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip1.Fore = System.Drawing.Color.Black;
            this.skinToolStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip1.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinToolStrip1.ItemAnamorphosis = false;
            this.skinToolStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemBorderShow = false;
            this.skinToolStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemRadius = 3;
            this.skinToolStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolstripButton_mainMenu,
            this.toolStripButton1,
            this.wp,
            this.toolStripButton4});
            this.skinToolStrip1.Location = new System.Drawing.Point(4, 622);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(325, 24);
            this.skinToolStrip1.SkinAllColor = true;
            this.skinToolStrip1.TabIndex = 139;
            this.skinToolStrip1.Text = "skinToolStrip2";
            this.skinToolStrip1.TitleAnamorphosis = false;
            this.skinToolStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip1.TitleRadius = 4;
            this.skinToolStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolstripButton_mainMenu
            // 
            this.toolstripButton_mainMenu.AutoSize = false;
            this.toolstripButton_mainMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolstripButton_mainMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolstripButton_mainMenu.Image")));
            this.toolstripButton_mainMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolstripButton_mainMenu.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolstripButton_mainMenu.Name = "toolstripButton_mainMenu";
            this.toolstripButton_mainMenu.Size = new System.Drawing.Size(24, 24);
            this.toolstripButton_mainMenu.Text = "toolStripButton4";
            this.toolstripButton_mainMenu.ToolTipText = "主菜单";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton1.Text = "toolStripButton2";
            this.toolStripButton1.ToolTipText = "打开系统设置";
            // 
            // wp
            // 
            this.wp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wp.Image = ((System.Drawing.Image)(resources.GetObject("wp.Image")));
            this.wp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.wp.Name = "wp";
            this.wp.Size = new System.Drawing.Size(24, 21);
            this.wp.Text = "我的网盘";
            this.wp.Click += new System.EventHandler(this.wp_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(63, 21);
            this.toolStripButton4.Text = "查找";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // skinButton_State
            // 
            this.skinButton_State.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_State.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.skinButton_State.BackRectangle = new System.Drawing.Rectangle(4, 4, 4, 4);
            this.skinButton_State.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton_State.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_State.DownBack = null;
            this.skinButton_State.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton_State.Image = ((System.Drawing.Image)(resources.GetObject("skinButton_State.Image")));
            this.skinButton_State.ImageSize = new System.Drawing.Size(11, 11);
            this.skinButton_State.Location = new System.Drawing.Point(91, 21);
            this.skinButton_State.Margin = new System.Windows.Forms.Padding(0);
            this.skinButton_State.MouseBack = null;
            this.skinButton_State.Name = "skinButton_State";
            this.skinButton_State.NormlBack = null;
            this.skinButton_State.Palace = true;
            this.skinButton_State.Size = new System.Drawing.Size(23, 22);
            this.skinButton_State.TabIndex = 136;
            this.skinButton_State.Tag = "1";
            this.skinButton_State.UseVisualStyleBackColor = false;
            // 
            // iconHitTimer
            // 
            this.iconHitTimer.Enabled = true;
            this.iconHitTimer.Interval = 1000;
            this.iconHitTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // friendsList
            // 
            this.friendsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendsList.Location = new System.Drawing.Point(3, 2);
            this.friendsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.friendsList.Name = "friendsList";
            this.friendsList.Size = new System.Drawing.Size(311, 452);
            this.friendsList.TabIndex = 140;
            this.friendsList.UseCompatibleStateImageBehavior = false;
            this.friendsList.View = System.Windows.Forms.View.Details;
            this.friendsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.friendsList_MouseDoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(4, 137);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(325, 485);
            this.tabControl1.TabIndex = 141;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.friendsList);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(317, 456);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "好友";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chatFromList);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(317, 456);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "组";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chatFromList
            // 
            this.chatFromList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatFromList.Location = new System.Drawing.Point(3, 2);
            this.chatFromList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatFromList.Name = "chatFromList";
            this.chatFromList.Size = new System.Drawing.Size(311, 452);
            this.chatFromList.TabIndex = 0;
            this.chatFromList.UseCompatibleStateImageBehavior = false;
            this.chatFromList.View = System.Windows.Forms.View.List;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.noReadMsgList);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(317, 456);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "未读信息";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // noReadMsgList
            // 
            this.noReadMsgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noReadMsgList.Location = new System.Drawing.Point(0, 0);
            this.noReadMsgList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.noReadMsgList.Name = "noReadMsgList";
            this.noReadMsgList.Size = new System.Drawing.Size(317, 456);
            this.noReadMsgList.TabIndex = 1;
            this.noReadMsgList.UseCompatibleStateImageBehavior = false;
            this.noReadMsgList.View = System.Windows.Forms.View.List;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picHeadImg);
            this.groupBox1.Controls.Add(this.lblQQSign);
            this.groupBox1.Controls.Add(this.lblNickName);
            this.groupBox1.Controls.Add(this.skinButton_State);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(4, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(325, 104);
            this.groupBox1.TabIndex = 142;
            this.groupBox1.TabStop = false;
            // 
            // picHeadImg
            // 
            this.picHeadImg.BackColor = System.Drawing.Color.Transparent;
            this.picHeadImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picHeadImg.Location = new System.Drawing.Point(16, 19);
            this.picHeadImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picHeadImg.Name = "picHeadImg";
            this.picHeadImg.Size = new System.Drawing.Size(70, 70);
            this.picHeadImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHeadImg.TabIndex = 139;
            this.picHeadImg.TabStop = false;
            // 
            // lblQQSign
            // 
            this.lblQQSign.AutoSize = true;
            this.lblQQSign.Location = new System.Drawing.Point(103, 56);
            this.lblQQSign.Name = "lblQQSign";
            this.lblQQSign.Size = new System.Drawing.Size(37, 15);
            this.lblQQSign.TabIndex = 138;
            this.lblQQSign.Text = "签名";
            // 
            // lblNickName
            // 
            this.lblNickName.AutoSize = true;
            this.lblNickName.Location = new System.Drawing.Point(117, 25);
            this.lblNickName.Name = "lblNickName";
            this.lblNickName.Size = new System.Drawing.Size(37, 15);
            this.lblNickName.TabIndex = 137;
            this.lblNickName.Text = "昵称";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // MainClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(333, 650);
            this.ContextMenuStrip = this.skinContextMenuStrip_main;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.skinToolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(333, 650);
            this.Name = "MainClientForm";
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainClientForm_FormClosing);
            this.Load += new System.EventHandler(this.MainClientForm_Load);
            this.skinContextMenuStrip_main.ResumeLayout(false);
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHeadImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton skinButton_State;
        private JustLib.UnitViews.UserListBox friendListBox1;
        private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem 创建群ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem moveToGroup;
        private System.Windows.Forms.ToolStripMenuItem 查找好友ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 头像显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 大头像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 小头像ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人资料ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolstripButton_mainMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton wp;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListView friendsList;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picHeadImg;
        private System.Windows.Forms.Label lblQQSign;
        private System.Windows.Forms.Label lblNickName;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ListView chatFromList;
        public System.Windows.Forms.Timer iconHitTimer;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView noReadMsgList;
        private System.Windows.Forms.ToolStripMenuItem 删除好友ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Timer timer1;
    }
}