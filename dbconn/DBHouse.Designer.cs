
namespace MyDTS.dbconn
{
    partial class DBHouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DBHouse));
            this.dataGridView1_house = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.getprivileges = new System.Windows.Forms.ToolStripMenuItem();
            this.udpSocket1 = new ClassDDTS.UDPSocket(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.申请用户密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查看申请的用户密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_house)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1_house
            // 
            this.dataGridView1_house.AllowUserToOrderColumns = true;
            this.dataGridView1_house.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1_house.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1_house.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1_house.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1_house.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.username,
            this.password,
            this.hostname,
            this.port});
            this.dataGridView1_house.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView1_house.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1_house.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1_house.Name = "dataGridView1_house";
            this.dataGridView1_house.RowTemplate.Height = 23;
            this.dataGridView1_house.Size = new System.Drawing.Size(835, 352);
            this.dataGridView1_house.TabIndex = 0;
            this.dataGridView1_house.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1_house.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            this.dataGridView1_house.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // name
            // 
            this.name.HeaderText = "名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // username
            // 
            this.username.HeaderText = "用户名";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // password
            // 
            this.password.HeaderText = "密码";
            this.password.Name = "password";
            this.password.ReadOnly = true;
            // 
            // hostname
            // 
            this.hostname.HeaderText = "主机地址";
            this.hostname.Name = "hostname";
            this.hostname.ReadOnly = true;
            // 
            // port
            // 
            this.port.HeaderText = "端口";
            this.port.Name = "port";
            this.port.ReadOnly = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getprivileges});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(143, 30);
            // 
            // getprivileges
            // 
            this.getprivileges.Enabled = false;
            this.getprivileges.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.getprivileges.Name = "getprivileges";
            this.getprivileges.Size = new System.Drawing.Size(142, 26);
            this.getprivileges.Text = "申请访问";
            this.getprivileges.Click += new System.EventHandler(this.getprivileges_Click);
            // 
            // udpSocket1
            // 
            this.udpSocket1.Active = false;
            this.udpSocket1.LocalHost = "127.0.0.1";
            this.udpSocket1.LocalPort = 8226;
            this.udpSocket1.DataArrival += new ClassDDTS.UDPSocket.DataArrivalEventHandler(this.udpSocket1_DataArrival);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.申请用户密码ToolStripMenuItem,
            this.查看申请的用户密码ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(223, 56);
            // 
            // 申请用户密码ToolStripMenuItem
            // 
            this.申请用户密码ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.申请用户密码ToolStripMenuItem.Name = "申请用户密码ToolStripMenuItem";
            this.申请用户密码ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.申请用户密码ToolStripMenuItem.Text = "申请用户密码";
            // 
            // 查看申请的用户密码ToolStripMenuItem
            // 
            this.查看申请的用户密码ToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.查看申请的用户密码ToolStripMenuItem.Name = "查看申请的用户密码ToolStripMenuItem";
            this.查看申请的用户密码ToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.查看申请的用户密码ToolStripMenuItem.Text = "查看申请的用户密码";
            // 
            // DBHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 352);
            this.Controls.Add(this.dataGridView1_house);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DBHouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "我的数据库";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DBHouse_FormClosing);
            this.Load += new System.EventHandler(this.DBHouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1_house)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1_house;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn port;
        private ClassDDTS.UDPSocket udpSocket1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 申请用户密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查看申请的用户密码ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem getprivileges;
    }
}