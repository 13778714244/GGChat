namespace FrmClient
{
    partial class MainForm
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
            CCWin.SkinControl.ChatListItem chatListItem4 = new CCWin.SkinControl.ChatListItem();
            CCWin.SkinControl.ChatListSubItem chatListSubItem3 = new CCWin.SkinControl.ChatListSubItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            CCWin.SkinControl.ChatListSubItem chatListSubItem4 = new CCWin.SkinControl.ChatListSubItem();
            CCWin.SkinControl.ChatListItem chatListItem5 = new CCWin.SkinControl.ChatListItem();
            CCWin.SkinControl.ChatListItem chatListItem6 = new CCWin.SkinControl.ChatListItem();
            this.friendsList = new CCWin.SkinControl.ChatListBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.skinContextMenuStrip_main = new CCWin.SkinControl.SkinContextMenuStrip();
            this.创建群ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.加入群ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.添加好友toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查找好友ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.头像显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大头像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.小头像ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人资料ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinToolTip1 = new CCWin.SkinToolTip(this.components);
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.toolstripButton_mainMenu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.pnlTx = new CCWin.SkinControl.SkinPanel();
            this.userImg = new CCWin.SkinControl.SkinButton();
            this.QQSign = new CCWin.SkinControl.SkinLabel();
            this.skinButton_State = new CCWin.SkinControl.SkinButton();
            this.skinToolStrip3 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripSplitButton_Friends = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSplitButton3 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSplitButton2 = new System.Windows.Forms.ToolStripSplitButton();
            this.清空会话列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nickName = new CCWin.SkinControl.SkinLabel();
            this.iconHitTimer = new System.Windows.Forms.Timer(this.components);
            this.showmsgWinTimer = new System.Windows.Forms.Timer(this.components);
            this.skinContextMenuStrip_main.SuspendLayout();
            this.skinToolStrip1.SuspendLayout();
            this.pnlTx.SuspendLayout();
            this.skinToolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // friendsList
            // 
            this.friendsList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.friendsList.DrawContentType = CCWin.SkinControl.DrawContentType.None;
            this.friendsList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.friendsList.ForeColor = System.Drawing.Color.Black;
            this.friendsList.FriendsMobile = true;
            chatListItem4.Bounds = new System.Drawing.Rectangle(0, 1, 321, 133);
            chatListItem4.IsOpen = true;
            chatListItem4.IsTwinkleHide = false;
            chatListItem4.OwnerChatListBox = this.friendsList;
            chatListSubItem3.Bounds = new System.Drawing.Rectangle(0, 27, 321, 53);
            chatListSubItem3.DisplayName = "幻影追风";
            chatListSubItem3.HeadImage = ((System.Drawing.Image)(resources.GetObject("chatListSubItem3.HeadImage")));
            chatListSubItem3.HeadRect = new System.Drawing.Rectangle(5, 33, 40, 40);
            chatListSubItem3.ID = null;
            chatListSubItem3.IpAddress = null;
            chatListSubItem3.IsTwinkle = false;
            chatListSubItem3.IsTwinkleHide = false;
            chatListSubItem3.IsVip = false;
            chatListSubItem3.LastWords = "";
            chatListSubItem3.NicName = "李四";
            chatListSubItem3.OwnerListItem = chatListItem4;
            chatListSubItem3.PersonalMsg = "Personal Message ...";
            chatListSubItem3.PlatformTypes = CCWin.SkinControl.PlatformType.PC;
            chatListSubItem3.Status = CCWin.SkinControl.ChatListSubItem.UserStatus.Online;
            chatListSubItem3.Tag = null;
            chatListSubItem3.TcpPort = 0;
            chatListSubItem3.UpdPort = 0;
            chatListSubItem4.Bounds = new System.Drawing.Rectangle(0, 81, 321, 53);
            chatListSubItem4.DisplayName = "云晟睿";
            chatListSubItem4.HeadImage = ((System.Drawing.Image)(resources.GetObject("chatListSubItem4.HeadImage")));
            chatListSubItem4.HeadRect = new System.Drawing.Rectangle(5, 87, 40, 40);
            chatListSubItem4.ID = null;
            chatListSubItem4.IpAddress = null;
            chatListSubItem4.IsTwinkle = false;
            chatListSubItem4.IsTwinkleHide = false;
            chatListSubItem4.IsVip = false;
            chatListSubItem4.LastWords = "";
            chatListSubItem4.NicName = "nicName";
            chatListSubItem4.OwnerListItem = chatListItem4;
            chatListSubItem4.PersonalMsg = "Personal Message ...";
            chatListSubItem4.PlatformTypes = CCWin.SkinControl.PlatformType.PC;
            chatListSubItem4.Status = CCWin.SkinControl.ChatListSubItem.UserStatus.Online;
            chatListSubItem4.Tag = null;
            chatListSubItem4.TcpPort = 0;
            chatListSubItem4.UpdPort = 0;
            chatListItem4.SubItems.AddRange(new CCWin.SkinControl.ChatListSubItem[] {
            chatListSubItem3,
            chatListSubItem4});
            chatListItem4.Text = "我的好友";
            chatListItem4.TwinkleSubItemNumber = 0;
            chatListItem5.Bounds = new System.Drawing.Rectangle(0, 135, 321, 25);
            chatListItem5.IsTwinkleHide = false;
            chatListItem5.OwnerChatListBox = this.friendsList;
            chatListItem5.Text = "家人";
            chatListItem5.TwinkleSubItemNumber = 0;
            chatListItem6.Bounds = new System.Drawing.Rectangle(0, 161, 321, 25);
            chatListItem6.IsTwinkleHide = false;
            chatListItem6.OwnerChatListBox = this.friendsList;
            chatListItem6.Text = "同学";
            chatListItem6.TwinkleSubItemNumber = 0;
            this.friendsList.Items.AddRange(new CCWin.SkinControl.ChatListItem[] {
            chatListItem4,
            chatListItem5,
            chatListItem6});
            this.friendsList.ListHadOpenGroup = null;
            this.friendsList.ListSubItemMenu = null;
            this.friendsList.Location = new System.Drawing.Point(2, 155);
            this.friendsList.Name = "friendsList";
            this.friendsList.SelectSubItem = null;
            this.friendsList.ShowNicName = false;
            this.friendsList.Size = new System.Drawing.Size(321, 455);
            this.friendsList.SubItemMenu = null;
            this.friendsList.TabIndex = 140;
            this.friendsList.Text = "chatListBox1";
            this.friendsList.DoubleClickSubItem += new CCWin.SkinControl.ChatListBox.ChatListEventHandler(this.friendsList_DoubleClickSubItem);
            this.friendsList.MouseEnterHead += new CCWin.SkinControl.ChatListBox.ChatListEventHandler(this.friendsList_MouseEnterHead);
            this.friendsList.MouseLeaveHead += new CCWin.SkinControl.ChatListBox.ChatListEventHandler(this.friendsList_MouseLeaveHead);
            this.friendsList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.friendsList_MouseMove);
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
            this.notifyIcon1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseMove);
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
            this.加入群ToolStripMenuItem1,
            this.添加好友toolStripMenuItem,
            this.查找好友ToolStripMenuItem,
            this.toolStripSeparator5,
            this.头像显示ToolStripMenuItem,
            this.修改密码ToolStripMenuItem,
            this.个人资料ToolStripMenuItem,
            this.toolStripMenuItem9,
            this.toolStripSeparator1,
            this.退出ToolStripMenuItem});
            this.skinContextMenuStrip_main.ItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinContextMenuStrip_main.Name = "MenuState";
            this.skinContextMenuStrip_main.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinContextMenuStrip_main.Size = new System.Drawing.Size(143, 250);
            this.skinContextMenuStrip_main.SkinAllColor = true;
            this.skinContextMenuStrip_main.TitleAnamorphosis = false;
            this.skinContextMenuStrip_main.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinContextMenuStrip_main.TitleRadius = 4;
            this.skinContextMenuStrip_main.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // 创建群ToolStripMenuItem1
            // 
            this.创建群ToolStripMenuItem1.Name = "创建群ToolStripMenuItem1";
            this.创建群ToolStripMenuItem1.Size = new System.Drawing.Size(156, 26);
            this.创建群ToolStripMenuItem1.Text = "创建群";
            // 
            // 加入群ToolStripMenuItem1
            // 
            this.加入群ToolStripMenuItem1.Name = "加入群ToolStripMenuItem1";
            this.加入群ToolStripMenuItem1.Size = new System.Drawing.Size(156, 26);
            this.加入群ToolStripMenuItem1.Text = "加入群";
            // 
            // 添加好友toolStripMenuItem
            // 
            this.添加好友toolStripMenuItem.Name = "添加好友toolStripMenuItem";
            this.添加好友toolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.添加好友toolStripMenuItem.Text = "添加好友";
            this.添加好友toolStripMenuItem.Visible = false;
            // 
            // 查找好友ToolStripMenuItem
            // 
            this.查找好友ToolStripMenuItem.Name = "查找好友ToolStripMenuItem";
            this.查找好友ToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.查找好友ToolStripMenuItem.Text = "查找好友";
            this.查找好友ToolStripMenuItem.Visible = false;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(153, 6);
            // 
            // 头像显示ToolStripMenuItem
            // 
            this.头像显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.大头像ToolStripMenuItem,
            this.小头像ToolStripMenuItem});
            this.头像显示ToolStripMenuItem.Name = "头像显示ToolStripMenuItem";
            this.头像显示ToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.头像显示ToolStripMenuItem.Text = "头像显示";
            this.头像显示ToolStripMenuItem.Visible = false;
            // 
            // 大头像ToolStripMenuItem
            // 
            this.大头像ToolStripMenuItem.Checked = true;
            this.大头像ToolStripMenuItem.CheckOnClick = true;
            this.大头像ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.大头像ToolStripMenuItem.Name = "大头像ToolStripMenuItem";
            this.大头像ToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.大头像ToolStripMenuItem.Text = "大头像";
            // 
            // 小头像ToolStripMenuItem
            // 
            this.小头像ToolStripMenuItem.CheckOnClick = true;
            this.小头像ToolStripMenuItem.Name = "小头像ToolStripMenuItem";
            this.小头像ToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.小头像ToolStripMenuItem.Text = "小头像";
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            // 
            // 个人资料ToolStripMenuItem
            // 
            this.个人资料ToolStripMenuItem.Name = "个人资料ToolStripMenuItem";
            this.个人资料ToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.个人资料ToolStripMenuItem.Text = "个人资料";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem9.Image")));
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(156, 26);
            this.toolStripMenuItem9.Text = "系统设置";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // skinToolTip1
            // 
            this.skinToolTip1.AutoPopDelay = 5000;
            this.skinToolTip1.ImageSize = new System.Drawing.Size(20, 20);
            this.skinToolTip1.InitialDelay = 500;
            this.skinToolTip1.OwnerDraw = true;
            this.skinToolTip1.ReshowDelay = 800;
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
            this.toolStripButton3,
            this.toolStripButton4});
            this.skinToolStrip1.Location = new System.Drawing.Point(4, 623);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(319, 24);
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
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 21);
            this.toolStripButton3.Text = "我的网盘";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(63, 21);
            this.toolStripButton4.Text = "查找";
            // 
            // pnlTx
            // 
            this.pnlTx.BackColor = System.Drawing.Color.Transparent;
            this.pnlTx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTx.Controls.Add(this.userImg);
            this.pnlTx.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pnlTx.DownBack = null;
            this.pnlTx.Location = new System.Drawing.Point(13, 37);
            this.pnlTx.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTx.MouseBack = null;
            this.pnlTx.Name = "pnlTx";
            this.pnlTx.NormlBack = null;
            this.pnlTx.Radius = 4;
            this.pnlTx.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.pnlTx.Size = new System.Drawing.Size(72, 72);
            this.pnlTx.TabIndex = 137;
            // 
            // userImg
            // 
            this.userImg.BackColor = System.Drawing.Color.Transparent;
            this.userImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userImg.BackgroundImage")));
            this.userImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.userImg.BackRectangle = new System.Drawing.Rectangle(4, 4, 4, 4);
            this.userImg.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.userImg.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.userImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userImg.DownBack = null;
            this.userImg.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.userImg.ImageSize = new System.Drawing.Size(64, 64);
            this.userImg.Location = new System.Drawing.Point(5, 3);
            this.userImg.Margin = new System.Windows.Forms.Padding(0);
            this.userImg.MouseBack = null;
            this.userImg.Name = "userImg";
            this.userImg.NormlBack = null;
            this.userImg.Radius = 4;
            this.userImg.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.userImg.Size = new System.Drawing.Size(64, 64);
            this.userImg.TabIndex = 128;
            this.userImg.Tag = "1";
            this.userImg.UseVisualStyleBackColor = false;
            // 
            // QQSign
            // 
            this.QQSign.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.QQSign.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.QQSign.BackColor = System.Drawing.Color.Transparent;
            this.QQSign.BorderColor = System.Drawing.Color.White;
            this.QQSign.BorderSize = 4;
            this.QQSign.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.QQSign.ForeColor = System.Drawing.Color.Black;
            this.QQSign.Location = new System.Drawing.Point(94, 64);
            this.QQSign.Name = "QQSign";
            this.QQSign.Size = new System.Drawing.Size(193, 20);
            this.QQSign.TabIndex = 134;
            this.QQSign.Text = "退一步海阔天空！";
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
            this.skinButton_State.Location = new System.Drawing.Point(90, 37);
            this.skinButton_State.Margin = new System.Windows.Forms.Padding(0);
            this.skinButton_State.MouseBack = null;
            this.skinButton_State.Name = "skinButton_State";
            this.skinButton_State.NormlBack = null;
            this.skinButton_State.Palace = true;
            this.skinButton_State.Size = new System.Drawing.Size(23, 23);
            this.skinButton_State.TabIndex = 136;
            this.skinButton_State.Tag = "1";
            this.skinButton_State.UseVisualStyleBackColor = false;
            // 
            // skinToolStrip3
            // 
            this.skinToolStrip3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.skinToolStrip3.Arrow = System.Drawing.Color.White;
            this.skinToolStrip3.AutoSize = false;
            this.skinToolStrip3.Back = System.Drawing.Color.White;
            this.skinToolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.skinToolStrip3.BackRadius = 4;
            this.skinToolStrip3.BackRectangle = new System.Drawing.Rectangle(2, 2, 2, 2);
            this.skinToolStrip3.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip3.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip3.BaseForeAnamorphosis = false;
            this.skinToolStrip3.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip3.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip3.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.skinToolStrip3.BaseHoverFore = System.Drawing.Color.Black;
            this.skinToolStrip3.BaseItemAnamorphosis = true;
            this.skinToolStrip3.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.skinToolStrip3.BaseItemBorderShow = false;
            this.skinToolStrip3.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip3.BaseItemDown")));
            this.skinToolStrip3.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skinToolStrip3.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip3.BaseItemMouse")));
            this.skinToolStrip3.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skinToolStrip3.BaseItemRadius = 2;
            this.skinToolStrip3.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip3.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skinToolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.skinToolStrip3.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip3.Fore = System.Drawing.Color.Black;
            this.skinToolStrip3.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip3.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinToolStrip3.ItemAnamorphosis = false;
            this.skinToolStrip3.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemBorderShow = false;
            this.skinToolStrip3.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip3.ItemRadius = 3;
            this.skinToolStrip3.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skinToolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButton_Friends,
            this.toolStripSplitButton3,
            this.toolStripSplitButton2});
            this.skinToolStrip3.Location = new System.Drawing.Point(6, 117);
            this.skinToolStrip3.Name = "skinToolStrip3";
            this.skinToolStrip3.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip3.Size = new System.Drawing.Size(319, 34);
            this.skinToolStrip3.SkinAllColor = true;
            this.skinToolStrip3.TabIndex = 135;
            this.skinToolStrip3.Text = "skinToolStrip3";
            this.skinToolStrip3.TitleAnamorphosis = false;
            this.skinToolStrip3.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip3.TitleRadius = 4;
            this.skinToolStrip3.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripSplitButton_Friends
            // 
            this.toolStripSplitButton_Friends.AutoSize = false;
            this.toolStripSplitButton_Friends.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton_Friends.DropDownButtonWidth = 20;
            this.toolStripSplitButton_Friends.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton_Friends.Image")));
            this.toolStripSplitButton_Friends.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripSplitButton_Friends.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton_Friends.Name = "toolStripSplitButton_Friends";
            this.toolStripSplitButton_Friends.Size = new System.Drawing.Size(60, 35);
            this.toolStripSplitButton_Friends.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripSplitButton_Friends.ToolTipText = "联系人";
            // 
            // toolStripSplitButton3
            // 
            this.toolStripSplitButton3.AutoSize = false;
            this.toolStripSplitButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton3.DropDownButtonWidth = 20;
            this.toolStripSplitButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton3.Image")));
            this.toolStripSplitButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton3.Name = "toolStripSplitButton3";
            this.toolStripSplitButton3.Size = new System.Drawing.Size(60, 35);
            this.toolStripSplitButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripSplitButton3.ToolTipText = "群";
            // 
            // toolStripSplitButton2
            // 
            this.toolStripSplitButton2.AutoSize = false;
            this.toolStripSplitButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton2.DropDownButtonWidth = 20;
            this.toolStripSplitButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空会话列表ToolStripMenuItem});
            this.toolStripSplitButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton2.Image")));
            this.toolStripSplitButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton2.Name = "toolStripSplitButton2";
            this.toolStripSplitButton2.Size = new System.Drawing.Size(60, 35);
            this.toolStripSplitButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripSplitButton2.ToolTipText = "最近联系人";
            // 
            // 清空会话列表ToolStripMenuItem
            // 
            this.清空会话列表ToolStripMenuItem.Name = "清空会话列表ToolStripMenuItem";
            this.清空会话列表ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.清空会话列表ToolStripMenuItem.Text = "清空会话列表";
            // 
            // nickName
            // 
            this.nickName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nickName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.nickName.BackColor = System.Drawing.Color.Transparent;
            this.nickName.BorderColor = System.Drawing.Color.White;
            this.nickName.BorderSize = 4;
            this.nickName.Cursor = System.Windows.Forms.Cursors.Default;
            this.nickName.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.nickName.ForeColor = System.Drawing.Color.Black;
            this.nickName.Location = new System.Drawing.Point(109, 37);
            this.nickName.Name = "nickName";
            this.nickName.Size = new System.Drawing.Size(131, 23);
            this.nickName.TabIndex = 133;
            this.nickName.Text = "David";
            // 
            // iconHitTimer
            // 
            this.iconHitTimer.Enabled = true;
            this.iconHitTimer.Interval = 1000;
            this.iconHitTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // showmsgWinTimer
            // 
            this.showmsgWinTimer.Enabled = true;
            this.showmsgWinTimer.Tick += new System.EventHandler(this.showmsgWinTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(327, 651);
            this.ContextMenuStrip = this.skinContextMenuStrip_main;
            this.Controls.Add(this.friendsList);
            this.Controls.Add(this.skinToolStrip1);
            this.Controls.Add(this.pnlTx);
            this.Controls.Add(this.QQSign);
            this.Controls.Add(this.skinButton_State);
            this.Controls.Add(this.skinToolStrip3);
            this.Controls.Add(this.nickName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimizeBox = true;
            this.Name = "MainForm";
            this.Text = "";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.skinContextMenuStrip_main.ResumeLayout(false);
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.pnlTx.ResumeLayout(false);
            this.skinToolStrip3.ResumeLayout(false);
            this.skinToolStrip3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinPanel pnlTx;
        private CCWin.SkinControl.SkinButton userImg;
        private CCWin.SkinControl.SkinLabel QQSign;
        private CCWin.SkinControl.SkinButton skinButton_State;
        private CCWin.SkinControl.SkinLabel nickName;
        private JustLib.UnitViews.UserListBox friendListBox1;
        private CCWin.SkinControl.SkinContextMenuStrip skinContextMenuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem 创建群ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 加入群ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 添加好友toolStripMenuItem;
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
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton_Friends;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton3;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton2;
        private System.Windows.Forms.ToolStripMenuItem 清空会话列表ToolStripMenuItem;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip3;
        private System.Windows.Forms.ToolStripButton toolstripButton_mainMenu;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private CCWin.SkinControl.ChatListBox friendsList;
        private CCWin.SkinToolTip skinToolTip1;
        public System.Windows.Forms.Timer iconHitTimer;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer showmsgWinTimer;
    }
}