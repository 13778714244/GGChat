namespace FrmClient
{
    partial class ChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.mainLeftPanel = new CCWin.SkinControl.SkinPanel();
            this.LeftAndrightSplit = new System.Windows.Forms.SplitContainer();
            this.recordAndSendMsgSplit = new System.Windows.Forms.SplitContainer();
            this.chatRecords = new CCWin.SkinControl.RtfRichTextBox();
            this.skToolMenu = new CCWin.SkinControl.SkinToolStrip();
            this.toolFont = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton8 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEmotion = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton7 = new System.Windows.Forms.ToolStripButton();
            this.msgContent = new CCWin.SkinControl.RtfRichTextBox();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.skinPanel2 = new CCWin.SkinControl.SkinPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.gifBox_wait = new JustLib.Controls.GifBox();
            this.btnClose = new CCWin.SkinControl.SkinButton();
            this.skinButton_send = new CCWin.SkinControl.SkinButton();
            this.pictureBox_state = new System.Windows.Forms.PictureBox();
            this.skinLabel_p2PState = new CCWin.SkinControl.SkinLabel();
            this.righPanel = new CCWin.SkinControl.SkinPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.skinLabel_FriendName = new CCWin.SkinControl.SkinLabel();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel_FriendID = new CCWin.SkinControl.SkinLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.memberList = new System.Windows.Forms.ListView();
            this.skinLabel_depTitle = new CCWin.SkinControl.SkinLabel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.friendNickName = new System.Windows.Forms.Label();
            this.friendQQSign = new CCWin.SkinControl.SkinLabel();
            this.userHeadImg = new System.Windows.Forms.PictureBox();
            this.skinToolStrip1 = new CCWin.SkinControl.SkinToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftAndrightSplit)).BeginInit();
            this.LeftAndrightSplit.Panel1.SuspendLayout();
            this.LeftAndrightSplit.Panel2.SuspendLayout();
            this.LeftAndrightSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordAndSendMsgSplit)).BeginInit();
            this.recordAndSendMsgSplit.Panel1.SuspendLayout();
            this.recordAndSendMsgSplit.Panel2.SuspendLayout();
            this.recordAndSendMsgSplit.SuspendLayout();
            this.skToolMenu.SuspendLayout();
            this.bottomPanel.SuspendLayout();
            this.skinPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state)).BeginInit();
            this.righPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.topPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userHeadImg)).BeginInit();
            this.skinToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "text";
            this.notifyIcon1.BalloonTipTitle = "title";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "QQ图标";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.gif");
            this.imageList1.Images.SetKeyName(1, "2.gif");
            this.imageList1.Images.SetKeyName(2, "3.gif");
            this.imageList1.Images.SetKeyName(3, "4.gif");
            this.imageList1.Images.SetKeyName(4, "5.gif");
            this.imageList1.Images.SetKeyName(5, "6.gif");
            this.imageList1.Images.SetKeyName(6, "7.gif");
            this.imageList1.Images.SetKeyName(7, "8.gif");
            this.imageList1.Images.SetKeyName(8, "9.gif");
            this.imageList1.Images.SetKeyName(9, "10.gif");
            this.imageList1.Images.SetKeyName(10, "11.gif");
            this.imageList1.Images.SetKeyName(11, "12.gif");
            this.imageList1.Images.SetKeyName(12, "13.gif");
            this.imageList1.Images.SetKeyName(13, "14.gif");
            this.imageList1.Images.SetKeyName(14, "15.gif");
            this.imageList1.Images.SetKeyName(15, "16.gif");
            this.imageList1.Images.SetKeyName(16, "17.gif");
            this.imageList1.Images.SetKeyName(17, "18.gif");
            this.imageList1.Images.SetKeyName(18, "19.gif");
            this.imageList1.Images.SetKeyName(19, "20.gif");
            this.imageList1.Images.SetKeyName(20, "21.gif");
            this.imageList1.Images.SetKeyName(21, "22.gif");
            this.imageList1.Images.SetKeyName(22, "23.gif");
            this.imageList1.Images.SetKeyName(23, "24.gif");
            this.imageList1.Images.SetKeyName(24, "25.gif");
            this.imageList1.Images.SetKeyName(25, "26.gif");
            this.imageList1.Images.SetKeyName(26, "27.gif");
            this.imageList1.Images.SetKeyName(27, "28.gif");
            this.imageList1.Images.SetKeyName(28, "29.gif");
            this.imageList1.Images.SetKeyName(29, "30.gif");
            this.imageList1.Images.SetKeyName(30, "31.gif");
            this.imageList1.Images.SetKeyName(31, "32.gif");
            this.imageList1.Images.SetKeyName(32, "33.gif");
            this.imageList1.Images.SetKeyName(33, "34.gif");
            this.imageList1.Images.SetKeyName(34, "35.gif");
            this.imageList1.Images.SetKeyName(35, "36.gif");
            this.imageList1.Images.SetKeyName(36, "37.gif");
            this.imageList1.Images.SetKeyName(37, "38.gif");
            this.imageList1.Images.SetKeyName(38, "39.gif");
            this.imageList1.Images.SetKeyName(39, "40.gif");
            this.imageList1.Images.SetKeyName(40, "41.gif");
            this.imageList1.Images.SetKeyName(41, "42.gif");
            this.imageList1.Images.SetKeyName(42, "43.gif");
            this.imageList1.Images.SetKeyName(43, "44.gif");
            this.imageList1.Images.SetKeyName(44, "45.gif");
            this.imageList1.Images.SetKeyName(45, "46.gif");
            this.imageList1.Images.SetKeyName(46, "47.gif");
            this.imageList1.Images.SetKeyName(47, "48.gif");
            this.imageList1.Images.SetKeyName(48, "49.gif");
            this.imageList1.Images.SetKeyName(49, "50.gif");
            this.imageList1.Images.SetKeyName(50, "51.gif");
            this.imageList1.Images.SetKeyName(51, "52.gif");
            this.imageList1.Images.SetKeyName(52, "53.gif");
            this.imageList1.Images.SetKeyName(53, "54.gif");
            this.imageList1.Images.SetKeyName(54, "55.gif");
            this.imageList1.Images.SetKeyName(55, "56.gif");
            this.imageList1.Images.SetKeyName(56, "57.gif");
            this.imageList1.Images.SetKeyName(57, "58.gif");
            this.imageList1.Images.SetKeyName(58, "59.gif");
            this.imageList1.Images.SetKeyName(59, "60.gif");
            this.imageList1.Images.SetKeyName(60, "61.gif");
            this.imageList1.Images.SetKeyName(61, "62.gif");
            this.imageList1.Images.SetKeyName(62, "63.gif");
            this.imageList1.Images.SetKeyName(63, "64.gif");
            this.imageList1.Images.SetKeyName(64, "65.gif");
            this.imageList1.Images.SetKeyName(65, "66.gif");
            this.imageList1.Images.SetKeyName(66, "67.gif");
            this.imageList1.Images.SetKeyName(67, "68.gif");
            this.imageList1.Images.SetKeyName(68, "69.gif");
            this.imageList1.Images.SetKeyName(69, "70.gif");
            this.imageList1.Images.SetKeyName(70, "71.gif");
            this.imageList1.Images.SetKeyName(71, "72.gif");
            this.imageList1.Images.SetKeyName(72, "73.gif");
            this.imageList1.Images.SetKeyName(73, "74.gif");
            this.imageList1.Images.SetKeyName(74, "75.gif");
            this.imageList1.Images.SetKeyName(75, "76.gif");
            this.imageList1.Images.SetKeyName(76, "77.gif");
            this.imageList1.Images.SetKeyName(77, "78.gif");
            this.imageList1.Images.SetKeyName(78, "79.gif");
            this.imageList1.Images.SetKeyName(79, "80.gif");
            this.imageList1.Images.SetKeyName(80, "81.gif");
            this.imageList1.Images.SetKeyName(81, "82.gif");
            this.imageList1.Images.SetKeyName(82, "83.gif");
            this.imageList1.Images.SetKeyName(83, "84.gif");
            this.imageList1.Images.SetKeyName(84, "85.gif");
            this.imageList1.Images.SetKeyName(85, "86.gif");
            this.imageList1.Images.SetKeyName(86, "87.gif");
            this.imageList1.Images.SetKeyName(87, "88.gif");
            this.imageList1.Images.SetKeyName(88, "89.gif");
            this.imageList1.Images.SetKeyName(89, "90.gif");
            this.imageList1.Images.SetKeyName(90, "91.gif");
            this.imageList1.Images.SetKeyName(91, "92.gif");
            this.imageList1.Images.SetKeyName(92, "93.gif");
            this.imageList1.Images.SetKeyName(93, "94.gif");
            this.imageList1.Images.SetKeyName(94, "95.gif");
            this.imageList1.Images.SetKeyName(95, "96.gif");
            this.imageList1.Images.SetKeyName(96, "97.gif");
            this.imageList1.Images.SetKeyName(97, "98.gif");
            this.imageList1.Images.SetKeyName(98, "99.gif");
            this.imageList1.Images.SetKeyName(99, "100.gif");
            this.imageList1.Images.SetKeyName(100, "101.gif");
            this.imageList1.Images.SetKeyName(101, "102.gif");
            this.imageList1.Images.SetKeyName(102, "103.gif");
            this.imageList1.Images.SetKeyName(103, "104.gif");
            this.imageList1.Images.SetKeyName(104, "105.gif");
            this.imageList1.Images.SetKeyName(105, "106.gif");
            this.imageList1.Images.SetKeyName(106, "107.gif");
            this.imageList1.Images.SetKeyName(107, "108.gif");
            this.imageList1.Images.SetKeyName(108, "109.gif");
            this.imageList1.Images.SetKeyName(109, "110.gif");
            this.imageList1.Images.SetKeyName(110, "111.gif");
            this.imageList1.Images.SetKeyName(111, "112.gif");
            this.imageList1.Images.SetKeyName(112, "113.gif");
            this.imageList1.Images.SetKeyName(113, "114.gif");
            this.imageList1.Images.SetKeyName(114, "115.gif");
            this.imageList1.Images.SetKeyName(115, "116.gif");
            this.imageList1.Images.SetKeyName(116, "117.gif");
            this.imageList1.Images.SetKeyName(117, "118.gif");
            this.imageList1.Images.SetKeyName(118, "119.gif");
            this.imageList1.Images.SetKeyName(119, "120.gif");
            this.imageList1.Images.SetKeyName(120, "121.gif");
            this.imageList1.Images.SetKeyName(121, "122.gif");
            this.imageList1.Images.SetKeyName(122, "123.gif");
            this.imageList1.Images.SetKeyName(123, "124.gif");
            this.imageList1.Images.SetKeyName(124, "125.gif");
            this.imageList1.Images.SetKeyName(125, "126.gif");
            this.imageList1.Images.SetKeyName(126, "127.gif");
            this.imageList1.Images.SetKeyName(127, "128.gif");
            this.imageList1.Images.SetKeyName(128, "129.gif");
            this.imageList1.Images.SetKeyName(129, "130.gif");
            this.imageList1.Images.SetKeyName(130, "131.gif");
            this.imageList1.Images.SetKeyName(131, "132.gif");
            this.imageList1.Images.SetKeyName(132, "133.gif");
            this.imageList1.Images.SetKeyName(133, "134.gif");
            this.imageList1.Images.SetKeyName(134, "135.gif");
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.mainSplit.IsSplitterFixed = true;
            this.mainSplit.Location = new System.Drawing.Point(4, 28);
            this.mainSplit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.BackColor = System.Drawing.Color.White;
            this.mainSplit.Panel1.Controls.Add(this.mainLeftPanel);
            this.mainSplit.Panel1Collapsed = true;
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.LeftAndrightSplit);
            this.mainSplit.Panel2.Controls.Add(this.topPanel);
            this.mainSplit.Size = new System.Drawing.Size(792, 568);
            this.mainSplit.SplitterDistance = 80;
            this.mainSplit.TabIndex = 156;
            // 
            // mainLeftPanel
            // 
            this.mainLeftPanel.BackColor = System.Drawing.Color.Transparent;
            this.mainLeftPanel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.mainLeftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLeftPanel.DownBack = null;
            this.mainLeftPanel.Location = new System.Drawing.Point(0, 0);
            this.mainLeftPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mainLeftPanel.MouseBack = null;
            this.mainLeftPanel.Name = "mainLeftPanel";
            this.mainLeftPanel.NormlBack = null;
            this.mainLeftPanel.Size = new System.Drawing.Size(80, 100);
            this.mainLeftPanel.TabIndex = 0;
            // 
            // LeftAndrightSplit
            // 
            this.LeftAndrightSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftAndrightSplit.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.LeftAndrightSplit.IsSplitterFixed = true;
            this.LeftAndrightSplit.Location = new System.Drawing.Point(0, 112);
            this.LeftAndrightSplit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LeftAndrightSplit.Name = "LeftAndrightSplit";
            // 
            // LeftAndrightSplit.Panel1
            // 
            this.LeftAndrightSplit.Panel1.Controls.Add(this.recordAndSendMsgSplit);
            this.LeftAndrightSplit.Panel1MinSize = 0;
            // 
            // LeftAndrightSplit.Panel2
            // 
            this.LeftAndrightSplit.Panel2.Controls.Add(this.righPanel);
            this.LeftAndrightSplit.Panel2MinSize = 0;
            this.LeftAndrightSplit.Size = new System.Drawing.Size(792, 456);
            this.LeftAndrightSplit.SplitterDistance = 618;
            this.LeftAndrightSplit.TabIndex = 155;
            // 
            // recordAndSendMsgSplit
            // 
            this.recordAndSendMsgSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.recordAndSendMsgSplit.Location = new System.Drawing.Point(0, 0);
            this.recordAndSendMsgSplit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.recordAndSendMsgSplit.Name = "recordAndSendMsgSplit";
            this.recordAndSendMsgSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // recordAndSendMsgSplit.Panel1
            // 
            this.recordAndSendMsgSplit.Panel1.Controls.Add(this.chatRecords);
            this.recordAndSendMsgSplit.Panel1.Controls.Add(this.skToolMenu);
            // 
            // recordAndSendMsgSplit.Panel2
            // 
            this.recordAndSendMsgSplit.Panel2.Controls.Add(this.msgContent);
            this.recordAndSendMsgSplit.Panel2.Controls.Add(this.bottomPanel);
            this.recordAndSendMsgSplit.Size = new System.Drawing.Size(618, 456);
            this.recordAndSendMsgSplit.SplitterDistance = 146;
            this.recordAndSendMsgSplit.TabIndex = 155;
            // 
            // chatRecords
            // 
            this.chatRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chatRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chatRecords.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.chatRecords.Location = new System.Drawing.Point(0, 0);
            this.chatRecords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chatRecords.Name = "chatRecords";
            this.chatRecords.Size = new System.Drawing.Size(618, 106);
            this.chatRecords.TabIndex = 149;
            this.chatRecords.Text = "";
            this.chatRecords.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // skToolMenu
            // 
            this.skToolMenu.Arrow = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.skToolMenu.AutoSize = false;
            this.skToolMenu.Back = System.Drawing.Color.White;
            this.skToolMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skToolMenu.BackRadius = 4;
            this.skToolMenu.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skToolMenu.Base = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skToolMenu.BaseFore = System.Drawing.Color.Black;
            this.skToolMenu.BaseForeAnamorphosis = false;
            this.skToolMenu.BaseForeAnamorphosisBorder = 4;
            this.skToolMenu.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skToolMenu.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.skToolMenu.BaseHoverFore = System.Drawing.Color.Black;
            this.skToolMenu.BaseItemAnamorphosis = true;
            this.skToolMenu.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(123)))), ((int)(((byte)(123)))));
            this.skToolMenu.BaseItemBorderShow = true;
            this.skToolMenu.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skToolMenu.BaseItemDown")));
            this.skToolMenu.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.skToolMenu.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skToolMenu.BaseItemMouse")));
            this.skToolMenu.BaseItemPressed = System.Drawing.Color.Transparent;
            this.skToolMenu.BaseItemRadius = 2;
            this.skToolMenu.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenu.BaseItemSplitter = System.Drawing.Color.Transparent;
            this.skToolMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skToolMenu.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skToolMenu.Fore = System.Drawing.Color.Black;
            this.skToolMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skToolMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skToolMenu.HoverFore = System.Drawing.Color.White;
            this.skToolMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skToolMenu.ItemAnamorphosis = false;
            this.skToolMenu.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.ItemBorderShow = false;
            this.skToolMenu.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skToolMenu.ItemRadius = 3;
            this.skToolMenu.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.None;
            this.skToolMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolFont,
            this.toolStripButton8,
            this.toolStripButtonEmotion,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripButton6,
            this.toolStripButton7});
            this.skToolMenu.Location = new System.Drawing.Point(0, 106);
            this.skToolMenu.Name = "skToolMenu";
            this.skToolMenu.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skToolMenu.Size = new System.Drawing.Size(618, 40);
            this.skToolMenu.SkinAllColor = true;
            this.skToolMenu.TabIndex = 133;
            this.skToolMenu.Text = "skinToolStrip1";
            this.skToolMenu.TitleAnamorphosis = false;
            this.skToolMenu.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skToolMenu.TitleRadius = 4;
            this.skToolMenu.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolFont
            // 
            this.toolFont.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolFont.Image = ((System.Drawing.Image)(resources.GetObject("toolFont.Image")));
            this.toolFont.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFont.Margin = new System.Windows.Forms.Padding(4, 1, 0, 2);
            this.toolFont.Name = "toolFont";
            this.toolFont.Size = new System.Drawing.Size(24, 37);
            this.toolFont.Text = "toolStripButton1";
            this.toolFont.ToolTipText = "字体";
            this.toolFont.Click += new System.EventHandler(this.toolFont_Click);
            // 
            // toolStripButton8
            // 
            this.toolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton8.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton8.Image")));
            this.toolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton8.Name = "toolStripButton8";
            this.toolStripButton8.Size = new System.Drawing.Size(24, 37);
            this.toolStripButton8.Text = "窗口震动";
            this.toolStripButton8.Click += new System.EventHandler(this.toolStripButton8_Click);
            // 
            // toolStripButtonEmotion
            // 
            this.toolStripButtonEmotion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEmotion.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonEmotion.Image")));
            this.toolStripButtonEmotion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEmotion.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.toolStripButtonEmotion.Name = "toolStripButtonEmotion";
            this.toolStripButtonEmotion.Size = new System.Drawing.Size(24, 37);
            this.toolStripButtonEmotion.Text = "toolStripButton2";
            this.toolStripButtonEmotion.ToolTipText = "表情";
            this.toolStripButtonEmotion.Click += new System.EventHandler(this.toolStripButtonEmotion_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 37);
            this.toolStripButton4.Text = "手写板";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 37);
            this.toolStripButton5.Text = "屏幕截图";
            this.toolStripButton5.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(73, 37);
            this.toolStripButton6.Text = "消息记录";
            // 
            // toolStripButton7
            // 
            this.toolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton7.Image")));
            this.toolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton7.Name = "toolStripButton7";
            this.toolStripButton7.Size = new System.Drawing.Size(24, 37);
            this.toolStripButton7.Text = "发送图片（支持Gif）";
            this.toolStripButton7.Click += new System.EventHandler(this.toolStripButton7_Click);
            // 
            // msgContent
            // 
            this.msgContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.msgContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgContent.EnableAutoDragDrop = true;
            this.msgContent.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.msgContent.Location = new System.Drawing.Point(0, 0);
            this.msgContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.msgContent.Name = "msgContent";
            this.msgContent.Size = new System.Drawing.Size(618, 252);
            this.msgContent.TabIndex = 150;
            this.msgContent.Text = "";
            this.msgContent.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.Color.Transparent;
            this.bottomPanel.Controls.Add(this.skinPanel2);
            this.bottomPanel.Controls.Add(this.pictureBox_state);
            this.bottomPanel.Controls.Add(this.skinLabel_p2PState);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 252);
            this.bottomPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(618, 54);
            this.bottomPanel.TabIndex = 154;
            // 
            // skinPanel2
            // 
            this.skinPanel2.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel2.Controls.Add(this.button1);
            this.skinPanel2.Controls.Add(this.gifBox_wait);
            this.skinPanel2.Controls.Add(this.btnClose);
            this.skinPanel2.Controls.Add(this.skinButton_send);
            this.skinPanel2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.skinPanel2.DownBack = null;
            this.skinPanel2.Location = new System.Drawing.Point(162, 0);
            this.skinPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.skinPanel2.MouseBack = null;
            this.skinPanel2.Name = "skinPanel2";
            this.skinPanel2.NormlBack = null;
            this.skinPanel2.Size = new System.Drawing.Size(456, 54);
            this.skinPanel2.TabIndex = 150;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(356, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 146;
            this.button1.Text = "刷新";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gifBox_wait
            // 
            this.gifBox_wait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gifBox_wait.BackColor = System.Drawing.Color.Transparent;
            this.gifBox_wait.BorderColor = System.Drawing.Color.Transparent;
            this.gifBox_wait.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gifBox_wait.Image = ((System.Drawing.Image)(resources.GetObject("gifBox_wait.Image")));
            this.gifBox_wait.Location = new System.Drawing.Point(42, 15);
            this.gifBox_wait.Margin = new System.Windows.Forms.Padding(4);
            this.gifBox_wait.Name = "gifBox_wait";
            this.gifBox_wait.Size = new System.Drawing.Size(29, 30);
            this.gifBox_wait.TabIndex = 145;
            this.gifBox_wait.Text = "gifBox1";
            this.gifBox_wait.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.btnClose.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.DownBack = ((System.Drawing.Image)(resources.GetObject("btnClose.DownBack")));
            this.btnClose.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.btnClose.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Location = new System.Drawing.Point(135, 15);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.MouseBack = ((System.Drawing.Image)(resources.GetObject("btnClose.MouseBack")));
            this.btnClose.Name = "btnClose";
            this.btnClose.NormlBack = ((System.Drawing.Image)(resources.GetObject("btnClose.NormlBack")));
            this.btnClose.Size = new System.Drawing.Size(92, 30);
            this.btnClose.TabIndex = 144;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // skinButton_send
            // 
            this.skinButton_send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.skinButton_send.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_send.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.skinButton_send.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_send.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.skinButton_send.DownBack = ((System.Drawing.Image)(resources.GetObject("skinButton_send.DownBack")));
            this.skinButton_send.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.skinButton_send.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinButton_send.Location = new System.Drawing.Point(235, 15);
            this.skinButton_send.Margin = new System.Windows.Forms.Padding(4);
            this.skinButton_send.MouseBack = ((System.Drawing.Image)(resources.GetObject("skinButton_send.MouseBack")));
            this.skinButton_send.Name = "skinButton_send";
            this.skinButton_send.NormlBack = ((System.Drawing.Image)(resources.GetObject("skinButton_send.NormlBack")));
            this.skinButton_send.Size = new System.Drawing.Size(92, 30);
            this.skinButton_send.TabIndex = 143;
            this.skinButton_send.Text = "发送";
            this.skinButton_send.UseVisualStyleBackColor = false;
            this.skinButton_send.Click += new System.EventHandler(this.skinButton_send_Click);
            // 
            // pictureBox_state
            // 
            this.pictureBox_state.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_state.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_state.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_state.BackgroundImage")));
            this.pictureBox_state.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_state.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox_state.Location = new System.Drawing.Point(31, 20);
            this.pictureBox_state.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox_state.Name = "pictureBox_state";
            this.pictureBox_state.Size = new System.Drawing.Size(21, 20);
            this.pictureBox_state.TabIndex = 142;
            this.pictureBox_state.TabStop = false;
            // 
            // skinLabel_p2PState
            // 
            this.skinLabel_p2PState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.skinLabel_p2PState.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel_p2PState.AutoSize = true;
            this.skinLabel_p2PState.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_p2PState.BorderColor = System.Drawing.Color.White;
            this.skinLabel_p2PState.BorderSize = 4;
            this.skinLabel_p2PState.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.skinLabel_p2PState.ForeColor = System.Drawing.Color.IndianRed;
            this.skinLabel_p2PState.Location = new System.Drawing.Point(52, 20);
            this.skinLabel_p2PState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.skinLabel_p2PState.Name = "skinLabel_p2PState";
            this.skinLabel_p2PState.Size = new System.Drawing.Size(66, 20);
            this.skinLabel_p2PState.TabIndex = 141;
            this.skinLabel_p2PState.Text = "P2P直连";
            // 
            // righPanel
            // 
            this.righPanel.BackColor = System.Drawing.Color.White;
            this.righPanel.Controls.Add(this.groupBox1);
            this.righPanel.Controls.Add(this.pictureBox1);
            this.righPanel.Controls.Add(this.memberList);
            this.righPanel.Controls.Add(this.skinLabel_depTitle);
            this.righPanel.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.righPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.righPanel.DownBack = null;
            this.righPanel.Location = new System.Drawing.Point(0, 0);
            this.righPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.righPanel.MouseBack = null;
            this.righPanel.Name = "righPanel";
            this.righPanel.NormlBack = null;
            this.righPanel.Size = new System.Drawing.Size(170, 456);
            this.righPanel.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.skinLabel_FriendName);
            this.groupBox1.Controls.Add(this.skinLabel5);
            this.groupBox1.Controls.Add(this.skinLabel4);
            this.groupBox1.Controls.Add(this.skinLabel_FriendID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 205);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(170, 72);
            this.groupBox1.TabIndex = 146;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // skinLabel_FriendName
            // 
            this.skinLabel_FriendName.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel_FriendName.AutoSize = true;
            this.skinLabel_FriendName.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_FriendName.BorderColor = System.Drawing.Color.White;
            this.skinLabel_FriendName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_FriendName.Location = new System.Drawing.Point(73, 48);
            this.skinLabel_FriendName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.skinLabel_FriendName.Name = "skinLabel_FriendName";
            this.skinLabel_FriendName.Size = new System.Drawing.Size(39, 20);
            this.skinLabel_FriendName.TabIndex = 139;
            this.skinLabel_FriendName.Text = "刘海";
            // 
            // skinLabel5
            // 
            this.skinLabel5.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.Location = new System.Drawing.Point(21, 21);
            this.skinLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(54, 20);
            this.skinLabel5.TabIndex = 142;
            this.skinLabel5.Text = "帐号：";
            // 
            // skinLabel4
            // 
            this.skinLabel4.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(21, 48);
            this.skinLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(54, 20);
            this.skinLabel4.TabIndex = 141;
            this.skinLabel4.Text = "名称：";
            // 
            // skinLabel_FriendID
            // 
            this.skinLabel_FriendID.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel_FriendID.AutoSize = true;
            this.skinLabel_FriendID.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_FriendID.BorderColor = System.Drawing.Color.White;
            this.skinLabel_FriendID.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_FriendID.Location = new System.Drawing.Point(73, 21);
            this.skinLabel_FriendID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.skinLabel_FriendID.Name = "skinLabel_FriendID";
            this.skinLabel_FriendID.Size = new System.Drawing.Size(54, 20);
            this.skinLabel_FriendID.TabIndex = 137;
            this.skinLabel_FriendID.Text = "10003";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(170, 180);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 145;
            this.pictureBox1.TabStop = false;
            // 
            // memberList
            // 
            this.memberList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.memberList.GridLines = true;
            this.memberList.Location = new System.Drawing.Point(0, 277);
            this.memberList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.memberList.Name = "memberList";
            this.memberList.Size = new System.Drawing.Size(170, 179);
            this.memberList.TabIndex = 144;
            this.memberList.UseCompatibleStateImageBehavior = false;
            // 
            // skinLabel_depTitle
            // 
            this.skinLabel_depTitle.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel_depTitle.AutoSize = true;
            this.skinLabel_depTitle.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel_depTitle.BorderColor = System.Drawing.Color.White;
            this.skinLabel_depTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel_depTitle.Location = new System.Drawing.Point(51, 266);
            this.skinLabel_depTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.skinLabel_depTitle.Name = "skinLabel_depTitle";
            this.skinLabel_depTitle.Size = new System.Drawing.Size(54, 20);
            this.skinLabel_depTitle.TabIndex = 140;
            this.skinLabel_depTitle.Text = "部门：";
            this.skinLabel_depTitle.Visible = false;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.skinLabel3);
            this.topPanel.Controls.Add(this.panel1);
            this.topPanel.Controls.Add(this.userHeadImg);
            this.topPanel.Controls.Add(this.skinToolStrip1);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 0);
            this.topPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(792, 112);
            this.topPanel.TabIndex = 153;
            // 
            // skinLabel3
            // 
            this.skinLabel3.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(391, 19);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(69, 20);
            this.skinLabel3.TabIndex = 3;
            this.skinLabel3.Text = "正在输入";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.friendNickName);
            this.panel1.Controls.Add(this.friendQQSign);
            this.panel1.Location = new System.Drawing.Point(85, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(299, 74);
            this.panel1.TabIndex = 6;
            // 
            // friendNickName
            // 
            this.friendNickName.AutoSize = true;
            this.friendNickName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.friendNickName.Location = new System.Drawing.Point(5, 15);
            this.friendNickName.Name = "friendNickName";
            this.friendNickName.Size = new System.Drawing.Size(51, 20);
            this.friendNickName.TabIndex = 5;
            this.friendNickName.Text = "昵称";
            // 
            // friendQQSign
            // 
            this.friendQQSign.ArtTextStyle = CCWin.SkinControl.ArtTextStyle.None;
            this.friendQQSign.AutoSize = true;
            this.friendQQSign.BackColor = System.Drawing.Color.Transparent;
            this.friendQQSign.BorderColor = System.Drawing.Color.White;
            this.friendQQSign.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.friendQQSign.Location = new System.Drawing.Point(3, 48);
            this.friendQQSign.Name = "friendQQSign";
            this.friendQQSign.Size = new System.Drawing.Size(69, 20);
            this.friendQQSign.TabIndex = 2;
            this.friendQQSign.Text = "个性签名";
            // 
            // userHeadImg
            // 
            this.userHeadImg.Dock = System.Windows.Forms.DockStyle.Left;
            this.userHeadImg.Image = ((System.Drawing.Image)(resources.GetObject("userHeadImg.Image")));
            this.userHeadImg.Location = new System.Drawing.Point(0, 0);
            this.userHeadImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userHeadImg.Name = "userHeadImg";
            this.userHeadImg.Size = new System.Drawing.Size(80, 78);
            this.userHeadImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.userHeadImg.TabIndex = 5;
            this.userHeadImg.TabStop = false;
            // 
            // skinToolStrip1
            // 
            this.skinToolStrip1.Arrow = System.Drawing.Color.Black;
            this.skinToolStrip1.AutoSize = false;
            this.skinToolStrip1.Back = System.Drawing.Color.White;
            this.skinToolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BackRadius = 4;
            this.skinToolStrip1.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 10);
            this.skinToolStrip1.Base = System.Drawing.Color.Transparent;
            this.skinToolStrip1.BaseFore = System.Drawing.Color.Black;
            this.skinToolStrip1.BaseForeAnamorphosis = false;
            this.skinToolStrip1.BaseForeAnamorphosisBorder = 4;
            this.skinToolStrip1.BaseForeAnamorphosisColor = System.Drawing.Color.White;
            this.skinToolStrip1.BaseForeOffset = new System.Drawing.Point(0, 0);
            this.skinToolStrip1.BaseHoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.BaseItemAnamorphosis = true;
            this.skinToolStrip1.BaseItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BaseItemBorderShow = true;
            this.skinToolStrip1.BaseItemDown = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemDown")));
            this.skinToolStrip1.BaseItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BaseItemMouse = ((System.Drawing.Image)(resources.GetObject("skinToolStrip1.BaseItemMouse")));
            this.skinToolStrip1.BaseItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.BaseItemRadius = 4;
            this.skinToolStrip1.BaseItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.BaseItemSplitter = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinToolStrip1.DropDownImageSeparator = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.skinToolStrip1.Fore = System.Drawing.Color.Black;
            this.skinToolStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 4, 2);
            this.skinToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.skinToolStrip1.HoverFore = System.Drawing.Color.White;
            this.skinToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.skinToolStrip1.ItemAnamorphosis = true;
            this.skinToolStrip1.ItemBorder = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemBorderShow = true;
            this.skinToolStrip1.ItemHover = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemPressed = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(148)))), ((int)(((byte)(212)))));
            this.skinToolStrip1.ItemRadius = 4;
            this.skinToolStrip1.ItemRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSplitButton1,
            this.toolStripButton3});
            this.skinToolStrip1.Location = new System.Drawing.Point(0, 78);
            this.skinToolStrip1.Name = "skinToolStrip1";
            this.skinToolStrip1.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinToolStrip1.Size = new System.Drawing.Size(792, 34);
            this.skinToolStrip1.SkinAllColor = true;
            this.skinToolStrip1.TabIndex = 4;
            this.skinToolStrip1.Text = "skinToolStrip1";
            this.skinToolStrip1.TitleAnamorphosis = true;
            this.skinToolStrip1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(236)))));
            this.skinToolStrip1.TitleRadius = 4;
            this.skinToolStrip1.TitleRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(24, 31);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 31);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(39, 31);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 31);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(159)))), ((int)(((byte)(215)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.mainSplit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChatForm_FormClosing);
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.Shown += new System.EventHandler(this.ChatForm_Shown);
            this.Click += new System.EventHandler(this.ChatForm_Click);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
            this.mainSplit.ResumeLayout(false);
            this.LeftAndrightSplit.Panel1.ResumeLayout(false);
            this.LeftAndrightSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftAndrightSplit)).EndInit();
            this.LeftAndrightSplit.ResumeLayout(false);
            this.recordAndSendMsgSplit.Panel1.ResumeLayout(false);
            this.recordAndSendMsgSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.recordAndSendMsgSplit)).EndInit();
            this.recordAndSendMsgSplit.ResumeLayout(false);
            this.skToolMenu.ResumeLayout(false);
            this.skToolMenu.PerformLayout();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.skinPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_state)).EndInit();
            this.righPanel.ResumeLayout(false);
            this.righPanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userHeadImg)).EndInit();
            this.skinToolStrip1.ResumeLayout(false);
            this.skinToolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private CCWin.SkinControl.SkinToolStrip skinToolStrip1;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel friendQQSign;
        private CCWin.SkinControl.SkinPanel righPanel;
        private CCWin.SkinControl.SkinToolStrip skToolMenu;
        private System.Windows.Forms.ToolStripButton toolFont;
        private System.Windows.Forms.ToolStripButton toolStripButtonEmotion;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripButton toolStripButton7;
        private JustLib.Controls.GifBox gifBox_wait;
        private CCWin.SkinControl.SkinButton skinButton_send;
        private CCWin.SkinControl.SkinButton btnClose;
        private CCWin.SkinControl.SkinLabel skinLabel_p2PState;
        private System.Windows.Forms.PictureBox pictureBox_state;
        private CCWin.SkinControl.SkinLabel skinLabel_FriendID;
        private CCWin.SkinControl.SkinLabel skinLabel_FriendName;
        private CCWin.SkinControl.SkinLabel skinLabel_depTitle;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ListView memberList;
        private CCWin.SkinControl.RtfRichTextBox msgContent;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripButton toolStripButton8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.SplitContainer LeftAndrightSplit;
        private System.Windows.Forms.SplitContainer recordAndSendMsgSplit;
        private System.Windows.Forms.SplitContainer mainSplit;
        private CCWin.SkinControl.SkinPanel skinPanel2;
        private CCWin.SkinControl.SkinPanel mainLeftPanel;
        private System.Windows.Forms.PictureBox userHeadImg;
        public CCWin.SkinControl.RtfRichTextBox chatRecords;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label friendNickName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Button button1;


    }
}