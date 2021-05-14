
namespace MyDTS
{
    partial class CControl
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControl));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.client_control_show = new System.Windows.Forms.ToolStripMenuItem();
            this.client_control_hide = new System.Windows.Forms.ToolStripMenuItem();
            this.client_control_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.暂停任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.开始任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.取消任务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.数据同步ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sQL语句发布ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.udpSocket1 = new ClassDDTS.UDPSocket(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel_gb = new System.Windows.Forms.GroupBox();
            this.panel_gb_process = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_gb_tuser = new System.Windows.Forms.Label();
            this.panel_gb_tport = new System.Windows.Forms.Label();
            this.panel_gb_tip = new System.Windows.Forms.Label();
            this.panel_gb_suser = new System.Windows.Forms.Label();
            this.panel_gb_sport = new System.Windows.Forms.Label();
            this.panel_gb_sip = new System.Windows.Forms.Label();
            this.panel_gb_taskname = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labels = new System.Windows.Forms.Label();
            this.labelt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.数据同步ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mySQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.oracleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sqlServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.mongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.sQL生产发布ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.提交DMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.提交DDLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "控制台-这里显示用户名称";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.client_control_show,
            this.client_control_hide,
            this.client_control_exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(137, 70);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            this.contextMenuStrip1.DoubleClick += new System.EventHandler(this.contextMenuStrip1_DoubleClick);
            // 
            // client_control_show
            // 
            this.client_control_show.Name = "client_control_show";
            this.client_control_show.Size = new System.Drawing.Size(136, 22);
            this.client_control_show.Text = "打开控制台";
            this.client_control_show.Click += new System.EventHandler(this.client_control_show_Click);
            // 
            // client_control_hide
            // 
            this.client_control_hide.Name = "client_control_hide";
            this.client_control_hide.Size = new System.Drawing.Size(136, 22);
            this.client_control_hide.Text = "隐藏控制台";
            this.client_control_hide.Click += new System.EventHandler(this.client_control_hide_Click);
            // 
            // client_control_exit
            // 
            this.client_control_exit.Name = "client_control_exit";
            this.client_control_exit.Size = new System.Drawing.Size(136, 22);
            this.client_control_exit.Text = "退出系统";
            this.client_control_exit.Click += new System.EventHandler(this.client_control_exit_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator7,
            this.暂停任务ToolStripMenuItem,
            this.toolStripSeparator8,
            this.开始任务ToolStripMenuItem,
            this.toolStripSeparator9,
            this.取消任务ToolStripMenuItem,
            this.toolStripSeparator10,
            this.刷新列表ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 116);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(121, 6);
            // 
            // 暂停任务ToolStripMenuItem
            // 
            this.暂停任务ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.暂停任务ToolStripMenuItem.Name = "暂停任务ToolStripMenuItem";
            this.暂停任务ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.暂停任务ToolStripMenuItem.Text = "暂停任务";
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(121, 6);
            // 
            // 开始任务ToolStripMenuItem
            // 
            this.开始任务ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.开始任务ToolStripMenuItem.Name = "开始任务ToolStripMenuItem";
            this.开始任务ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.开始任务ToolStripMenuItem.Text = "开始任务";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(121, 6);
            // 
            // 取消任务ToolStripMenuItem
            // 
            this.取消任务ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.取消任务ToolStripMenuItem.Name = "取消任务ToolStripMenuItem";
            this.取消任务ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.取消任务ToolStripMenuItem.Text = "取消任务";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(121, 6);
            // 
            // 刷新列表ToolStripMenuItem
            // 
            this.刷新列表ToolStripMenuItem.Name = "刷新列表ToolStripMenuItem";
            this.刷新列表ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.刷新列表ToolStripMenuItem.Text = "刷新列表";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(205)))), ((int)(((byte)(218)))));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel1.Text = "请先注册，获取更多好用的功能模块";
            this.toolStripStatusLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(205)))), ((int)(((byte)(218)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 546);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1110, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel3.Text = "状态跟进";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel2.Text = "https://...";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(182)))), ((int)(((byte)(193)))), ((int)(((byte)(210)))));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据同步ToolStripMenuItem1,
            this.sQL语句发布ToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1110, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据同步ToolStripMenuItem1
            // 
            this.数据同步ToolStripMenuItem1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.数据同步ToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("数据同步ToolStripMenuItem1.Image")));
            this.数据同步ToolStripMenuItem1.Name = "数据同步ToolStripMenuItem1";
            this.数据同步ToolStripMenuItem1.Size = new System.Drawing.Size(102, 26);
            this.数据同步ToolStripMenuItem1.Text = "数据同步";
            this.数据同步ToolStripMenuItem1.Click += new System.EventHandler(this.mySQLToolStripMenuItem_Click);
            this.数据同步ToolStripMenuItem1.MouseEnter += new System.EventHandler(this.数据同步ToolStripMenuItem_MouseEnter);
            this.数据同步ToolStripMenuItem1.MouseLeave += new System.EventHandler(this.数据同步ToolStripMenuItem_MouseLeave);
            this.数据同步ToolStripMenuItem1.MouseHover += new System.EventHandler(this.数据同步ToolStripMenuItem_MouseHover);
            // 
            // sQL语句发布ToolStripMenuItem
            // 
            this.sQL语句发布ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.sQL语句发布ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sQL语句发布ToolStripMenuItem.Image")));
            this.sQL语句发布ToolStripMenuItem.Name = "sQL语句发布ToolStripMenuItem";
            this.sQL语句发布ToolStripMenuItem.Size = new System.Drawing.Size(134, 26);
            this.sQL语句发布ToolStripMenuItem.Text = "SQL语句发布";
            this.sQL语句发布ToolStripMenuItem.Click += new System.EventHandler(this.sQL语句发布ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(205)))), ((int)(((byte)(218)))));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripLabel4,
            this.toolStripLabel5});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1110, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel3.Image")));
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(108, 22);
            this.toolStripLabel3.Text = "添加数据库资源";
            this.toolStripLabel3.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel4.Image")));
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(84, 22);
            this.toolStripLabel4.Text = "我的数据库";
            this.toolStripLabel4.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel5.Image")));
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(132, 22);
            this.toolStripLabel5.Text = "公司数据库资源列表";
            this.toolStripLabel5.Click += new System.EventHandler(this.toolStripLabel5_Click);
            // 
            // udpSocket1
            // 
            this.udpSocket1.Active = false;
            this.udpSocket1.LocalHost = "192.168.1.4";
            this.udpSocket1.LocalPort = 8225;
            this.udpSocket1.DataArrival += new ClassDDTS.UDPSocket.DataArrivalEventHandler(this.udpSocket1_DataArrival);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel_gb);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Size = new System.Drawing.Size(1110, 491);
            this.splitContainer1.SplitterDistance = 204;
            this.splitContainer1.TabIndex = 12;
            this.splitContainer1.Visible = false;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.ItemHeight = 50;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(204, 491);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel_gb
            // 
            this.panel_gb.Controls.Add(this.panel_gb_process);
            this.panel_gb.Controls.Add(this.label2);
            this.panel_gb.Controls.Add(this.panel_gb_tuser);
            this.panel_gb.Controls.Add(this.panel_gb_tport);
            this.panel_gb.Controls.Add(this.panel_gb_tip);
            this.panel_gb.Controls.Add(this.panel_gb_suser);
            this.panel_gb.Controls.Add(this.panel_gb_sport);
            this.panel_gb.Controls.Add(this.panel_gb_sip);
            this.panel_gb.Controls.Add(this.panel_gb_taskname);
            this.panel_gb.Controls.Add(this.label8);
            this.panel_gb.Controls.Add(this.label7);
            this.panel_gb.Controls.Add(this.label6);
            this.panel_gb.Controls.Add(this.label5);
            this.panel_gb.Controls.Add(this.label4);
            this.panel_gb.Controls.Add(this.labels);
            this.panel_gb.Controls.Add(this.labelt);
            this.panel_gb.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_gb.Location = new System.Drawing.Point(0, 0);
            this.panel_gb.Name = "panel_gb";
            this.panel_gb.Size = new System.Drawing.Size(902, 275);
            this.panel_gb.TabIndex = 1;
            this.panel_gb.TabStop = false;
            this.panel_gb.Visible = false;
            // 
            // panel_gb_process
            // 
            this.panel_gb_process.AutoSize = true;
            this.panel_gb_process.Location = new System.Drawing.Point(141, 244);
            this.panel_gb_process.Name = "panel_gb_process";
            this.panel_gb_process.Size = new System.Drawing.Size(11, 12);
            this.panel_gb_process.TabIndex = 15;
            this.panel_gb_process.Text = " ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "同步进度：";
            this.label2.Visible = false;
            // 
            // panel_gb_tuser
            // 
            this.panel_gb_tuser.AutoSize = true;
            this.panel_gb_tuser.Location = new System.Drawing.Point(141, 207);
            this.panel_gb_tuser.Name = "panel_gb_tuser";
            this.panel_gb_tuser.Size = new System.Drawing.Size(11, 12);
            this.panel_gb_tuser.TabIndex = 13;
            this.panel_gb_tuser.Text = " ";
            // 
            // panel_gb_tport
            // 
            this.panel_gb_tport.AutoSize = true;
            this.panel_gb_tport.Location = new System.Drawing.Point(141, 179);
            this.panel_gb_tport.Name = "panel_gb_tport";
            this.panel_gb_tport.Size = new System.Drawing.Size(11, 12);
            this.panel_gb_tport.TabIndex = 12;
            this.panel_gb_tport.Text = " ";
            // 
            // panel_gb_tip
            // 
            this.panel_gb_tip.AutoSize = true;
            this.panel_gb_tip.Location = new System.Drawing.Point(141, 149);
            this.panel_gb_tip.Name = "panel_gb_tip";
            this.panel_gb_tip.Size = new System.Drawing.Size(11, 12);
            this.panel_gb_tip.TabIndex = 11;
            this.panel_gb_tip.Text = " ";
            // 
            // panel_gb_suser
            // 
            this.panel_gb_suser.AutoSize = true;
            this.panel_gb_suser.Location = new System.Drawing.Point(141, 118);
            this.panel_gb_suser.Name = "panel_gb_suser";
            this.panel_gb_suser.Size = new System.Drawing.Size(11, 12);
            this.panel_gb_suser.TabIndex = 10;
            this.panel_gb_suser.Text = " ";
            // 
            // panel_gb_sport
            // 
            this.panel_gb_sport.AutoSize = true;
            this.panel_gb_sport.Location = new System.Drawing.Point(141, 89);
            this.panel_gb_sport.Name = "panel_gb_sport";
            this.panel_gb_sport.Size = new System.Drawing.Size(11, 12);
            this.panel_gb_sport.TabIndex = 9;
            this.panel_gb_sport.Text = " ";
            // 
            // panel_gb_sip
            // 
            this.panel_gb_sip.AutoSize = true;
            this.panel_gb_sip.Location = new System.Drawing.Point(141, 54);
            this.panel_gb_sip.Name = "panel_gb_sip";
            this.panel_gb_sip.Size = new System.Drawing.Size(11, 12);
            this.panel_gb_sip.TabIndex = 8;
            this.panel_gb_sip.Text = " ";
            // 
            // panel_gb_taskname
            // 
            this.panel_gb_taskname.AutoSize = true;
            this.panel_gb_taskname.Location = new System.Drawing.Point(141, 24);
            this.panel_gb_taskname.Name = "panel_gb_taskname";
            this.panel_gb_taskname.Size = new System.Drawing.Size(11, 12);
            this.panel_gb_taskname.TabIndex = 7;
            this.panel_gb_taskname.Text = " ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "目标用户名称：";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "目标端口：";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "目标库IP：";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "数据源用户名称：";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "数据源端口：";
            this.label4.Visible = false;
            // 
            // labels
            // 
            this.labels.AutoSize = true;
            this.labels.Location = new System.Drawing.Point(20, 54);
            this.labels.Name = "labels";
            this.labels.Size = new System.Drawing.Size(65, 12);
            this.labels.TabIndex = 1;
            this.labels.Text = "数据源IP：";
            this.labels.Visible = false;
            // 
            // labelt
            // 
            this.labelt.AutoSize = true;
            this.labelt.Location = new System.Drawing.Point(20, 21);
            this.labelt.Name = "labelt";
            this.labelt.Size = new System.Drawing.Size(65, 12);
            this.labelt.TabIndex = 0;
            this.labelt.Text = "任务名称：";
            this.labelt.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 0;
            // 
            // 数据同步ToolStripMenuItem
            // 
            this.数据同步ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.mySQLToolStripMenuItem,
            this.toolStripSeparator2,
            this.oracleToolStripMenuItem,
            this.toolStripSeparator3,
            this.sqlServerToolStripMenuItem,
            this.toolStripSeparator11,
            this.mongoDBToolStripMenuItem,
            this.toolStripSeparator12});
            this.数据同步ToolStripMenuItem.Font = new System.Drawing.Font("Adobe 楷体 Std R", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.数据同步ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("数据同步ToolStripMenuItem.Image")));
            this.数据同步ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.数据同步ToolStripMenuItem.Name = "数据同步ToolStripMenuItem";
            this.数据同步ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 10, 4, 0);
            this.数据同步ToolStripMenuItem.Size = new System.Drawing.Size(92, 32);
            this.数据同步ToolStripMenuItem.Text = "数据同步";
            this.数据同步ToolStripMenuItem.MouseLeave += new System.EventHandler(this.数据同步ToolStripMenuItem_MouseLeave);
            this.数据同步ToolStripMenuItem.MouseHover += new System.EventHandler(this.数据同步ToolStripMenuItem_MouseHover);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // mySQLToolStripMenuItem
            // 
            this.mySQLToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.mySQLToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mySQLToolStripMenuItem.Image")));
            this.mySQLToolStripMenuItem.Name = "mySQLToolStripMenuItem";
            this.mySQLToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.mySQLToolStripMenuItem.Text = "MySQL";
            this.mySQLToolStripMenuItem.Click += new System.EventHandler(this.mySQLToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // oracleToolStripMenuItem
            // 
            this.oracleToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.oracleToolStripMenuItem.Enabled = false;
            this.oracleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("oracleToolStripMenuItem.Image")));
            this.oracleToolStripMenuItem.Name = "oracleToolStripMenuItem";
            this.oracleToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.oracleToolStripMenuItem.Text = "Oracle";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // sqlServerToolStripMenuItem
            // 
            this.sqlServerToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.sqlServerToolStripMenuItem.Enabled = false;
            this.sqlServerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sqlServerToolStripMenuItem.Image")));
            this.sqlServerToolStripMenuItem.Name = "sqlServerToolStripMenuItem";
            this.sqlServerToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.sqlServerToolStripMenuItem.Text = "SqlServer";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(141, 6);
            // 
            // mongoDBToolStripMenuItem
            // 
            this.mongoDBToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.mongoDBToolStripMenuItem.Enabled = false;
            this.mongoDBToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("mongoDBToolStripMenuItem.Image")));
            this.mongoDBToolStripMenuItem.Name = "mongoDBToolStripMenuItem";
            this.mongoDBToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.mongoDBToolStripMenuItem.Text = "MongoDB";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(141, 6);
            // 
            // sQL生产发布ToolStripMenuItem
            // 
            this.sQL生产发布ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.提交DMLToolStripMenuItem,
            this.toolStripSeparator5,
            this.提交DDLToolStripMenuItem,
            this.toolStripSeparator6});
            this.sQL生产发布ToolStripMenuItem.Enabled = false;
            this.sQL生产发布ToolStripMenuItem.Font = new System.Drawing.Font("Adobe 楷体 Std R", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sQL生产发布ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("sQL生产发布ToolStripMenuItem.Image")));
            this.sQL生产发布ToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sQL生产发布ToolStripMenuItem.Name = "sQL生产发布ToolStripMenuItem";
            this.sQL生产发布ToolStripMenuItem.Padding = new System.Windows.Forms.Padding(4, 10, 4, 0);
            this.sQL生产发布ToolStripMenuItem.Size = new System.Drawing.Size(118, 32);
            this.sQL生产发布ToolStripMenuItem.Text = "SQL生产发布";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(136, 6);
            // 
            // 提交DMLToolStripMenuItem
            // 
            this.提交DMLToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.提交DMLToolStripMenuItem.Name = "提交DMLToolStripMenuItem";
            this.提交DMLToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.提交DMLToolStripMenuItem.Text = "提交DML";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(136, 6);
            // 
            // 提交DDLToolStripMenuItem
            // 
            this.提交DDLToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(238)))));
            this.提交DDLToolStripMenuItem.Name = "提交DDLToolStripMenuItem";
            this.提交DDLToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.提交DDLToolStripMenuItem.Text = "提交DDL";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(136, 6);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(108, 22);
            this.toolStripLabel1.Text = "添加数据库资源";
            this.toolStripLabel1.Click += new System.EventHandler(this.toolStripLabel1_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel2.Image")));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(84, 22);
            this.toolStripLabel2.Text = "我的数据库";
            this.toolStripLabel2.Click += new System.EventHandler(this.toolStripLabel2_Click);
            // 
            // CControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(73)))), ((int)(((byte)(106)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1110, 568);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "SQL名字待定";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Control_FormClosing);
            this.Load += new System.EventHandler(this.CControl_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel_gb.ResumeLayout(false);
            this.panel_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem client_control_show;
        private System.Windows.Forms.ToolStripMenuItem client_control_hide;
        private System.Windows.Forms.ToolStripMenuItem client_control_exit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem 暂停任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem 开始任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem 取消任务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem 刷新列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据同步ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mySQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem oracleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem sqlServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem mongoDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem sQL生产发布ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem 提交DMLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem 提交DDLToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem 数据同步ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sQL语句发布ToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private ClassDDTS.UDPSocket udpSocket1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox panel_gb;
        private System.Windows.Forms.Label panel_gb_tuser;
        private System.Windows.Forms.Label panel_gb_tport;
        private System.Windows.Forms.Label panel_gb_tip;
        private System.Windows.Forms.Label panel_gb_suser;
        private System.Windows.Forms.Label panel_gb_sport;
        private System.Windows.Forms.Label panel_gb_sip;
        private System.Windows.Forms.Label panel_gb_taskname;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labels;
        private System.Windows.Forms.Label labelt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label panel_gb_process;
    }
}

