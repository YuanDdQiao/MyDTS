
namespace MyDTS.dbconn
{
    partial class dbconn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dbconn));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dbconn_cnn = new System.Windows.Forms.Button();
            this.dbconn_testcnn = new System.Windows.Forms.Button();
            this.dbconn_cancel = new System.Windows.Forms.Button();
            this.dbconn_new = new System.Windows.Forms.Button();
            this.dbconn_clone = new System.Windows.Forms.Button();
            this.dbconn_save = new System.Windows.Forms.Button();
            this.dbconn_rename = new System.Windows.Forms.Button();
            this.dbconn_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dbconn_comb = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dbconn_db = new System.Windows.Forms.TextBox();
            this.dbconn_port = new System.Windows.Forms.TextBox();
            this.dbconn_password = new System.Windows.Forms.TextBox();
            this.dbconn_username = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dbconn_ipaddr = new System.Windows.Forms.TextBox();
            this.lb_left_port = new System.Windows.Forms.Label();
            this.lb_left_password = new System.Windows.Forms.Label();
            this.lb_left_username = new System.Windows.Forms.Label();
            this.lb_left_ipaddr = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.udpSocket1 = new ClassDDTS.UDPSocket(this.components);
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dbconn_cnn);
            this.groupBox1.Controls.Add(this.dbconn_testcnn);
            this.groupBox1.Controls.Add(this.dbconn_cancel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 361);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(544, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dbconn_cnn
            // 
            this.dbconn_cnn.Enabled = false;
            this.dbconn_cnn.Location = new System.Drawing.Point(169, 18);
            this.dbconn_cnn.Name = "dbconn_cnn";
            this.dbconn_cnn.Size = new System.Drawing.Size(111, 20);
            this.dbconn_cnn.TabIndex = 9;
            this.dbconn_cnn.Text = "连接";
            this.dbconn_cnn.UseVisualStyleBackColor = true;
            this.dbconn_cnn.Click += new System.EventHandler(this.dbconn_cnn_Click);
            // 
            // dbconn_testcnn
            // 
            this.dbconn_testcnn.Enabled = false;
            this.dbconn_testcnn.Location = new System.Drawing.Point(418, 18);
            this.dbconn_testcnn.Name = "dbconn_testcnn";
            this.dbconn_testcnn.Size = new System.Drawing.Size(111, 20);
            this.dbconn_testcnn.TabIndex = 8;
            this.dbconn_testcnn.Text = "测试连接";
            this.dbconn_testcnn.UseVisualStyleBackColor = true;
            this.dbconn_testcnn.Click += new System.EventHandler(this.dbconn_testcnn_Click);
            // 
            // dbconn_cancel
            // 
            this.dbconn_cancel.Location = new System.Drawing.Point(292, 18);
            this.dbconn_cancel.Name = "dbconn_cancel";
            this.dbconn_cancel.Size = new System.Drawing.Size(111, 20);
            this.dbconn_cancel.TabIndex = 7;
            this.dbconn_cancel.Text = "取消";
            this.dbconn_cancel.UseVisualStyleBackColor = true;
            this.dbconn_cancel.Click += new System.EventHandler(this.dbconn_cancel_Click);
            // 
            // dbconn_new
            // 
            this.dbconn_new.Location = new System.Drawing.Point(167, 12);
            this.dbconn_new.Name = "dbconn_new";
            this.dbconn_new.Size = new System.Drawing.Size(64, 23);
            this.dbconn_new.TabIndex = 2;
            this.dbconn_new.Text = "新建";
            this.dbconn_new.UseVisualStyleBackColor = true;
            this.dbconn_new.Click += new System.EventHandler(this.dbconn_new_Click);
            // 
            // dbconn_clone
            // 
            this.dbconn_clone.Enabled = false;
            this.dbconn_clone.Location = new System.Drawing.Point(243, 12);
            this.dbconn_clone.Name = "dbconn_clone";
            this.dbconn_clone.Size = new System.Drawing.Size(64, 23);
            this.dbconn_clone.TabIndex = 2;
            this.dbconn_clone.Text = "克隆";
            this.dbconn_clone.UseVisualStyleBackColor = true;
            this.dbconn_clone.Click += new System.EventHandler(this.dbconn_clone_Click);
            // 
            // dbconn_save
            // 
            this.dbconn_save.Enabled = false;
            this.dbconn_save.Location = new System.Drawing.Point(318, 11);
            this.dbconn_save.Name = "dbconn_save";
            this.dbconn_save.Size = new System.Drawing.Size(64, 23);
            this.dbconn_save.TabIndex = 2;
            this.dbconn_save.Text = "保存";
            this.dbconn_save.UseVisualStyleBackColor = true;
            this.dbconn_save.Click += new System.EventHandler(this.dbconn_save_Click);
            // 
            // dbconn_rename
            // 
            this.dbconn_rename.Enabled = false;
            this.dbconn_rename.Location = new System.Drawing.Point(393, 11);
            this.dbconn_rename.Name = "dbconn_rename";
            this.dbconn_rename.Size = new System.Drawing.Size(64, 23);
            this.dbconn_rename.TabIndex = 2;
            this.dbconn_rename.Text = "重命名";
            this.dbconn_rename.UseVisualStyleBackColor = true;
            this.dbconn_rename.Click += new System.EventHandler(this.dbconn_rename_Click);
            // 
            // dbconn_delete
            // 
            this.dbconn_delete.Enabled = false;
            this.dbconn_delete.Location = new System.Drawing.Point(468, 11);
            this.dbconn_delete.Name = "dbconn_delete";
            this.dbconn_delete.Size = new System.Drawing.Size(64, 23);
            this.dbconn_delete.TabIndex = 2;
            this.dbconn_delete.Text = "删除";
            this.dbconn_delete.UseVisualStyleBackColor = true;
            this.dbconn_delete.Click += new System.EventHandler(this.dbconn_delete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(167, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "保/存的连接";
            // 
            // dbconn_comb
            // 
            this.dbconn_comb.FormattingEnabled = true;
            this.dbconn_comb.Location = new System.Drawing.Point(256, 48);
            this.dbconn_comb.Name = "dbconn_comb";
            this.dbconn_comb.Size = new System.Drawing.Size(276, 20);
            this.dbconn_comb.TabIndex = 4;
            this.dbconn_comb.SelectedIndexChanged += new System.EventHandler(this.dbconn_comb_SelectedIndexChanged);
            this.dbconn_comb.Click += new System.EventHandler(this.dbconn_comb_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(169, 79);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(363, 276);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.dbconn_db);
            this.tabPage1.Controls.Add(this.dbconn_port);
            this.tabPage1.Controls.Add(this.dbconn_password);
            this.tabPage1.Controls.Add(this.dbconn_username);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.dbconn_ipaddr);
            this.tabPage1.Controls.Add(this.lb_left_port);
            this.tabPage1.Controls.Add(this.lb_left_password);
            this.tabPage1.Controls.Add(this.lb_left_username);
            this.tabPage1.Controls.Add(this.lb_left_ipaddr);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(355, 250);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MYSQL";
            // 
            // dbconn_db
            // 
            this.dbconn_db.Enabled = false;
            this.dbconn_db.Location = new System.Drawing.Point(86, 128);
            this.dbconn_db.Name = "dbconn_db";
            this.dbconn_db.Size = new System.Drawing.Size(250, 21);
            this.dbconn_db.TabIndex = 6;
            // 
            // dbconn_port
            // 
            this.dbconn_port.Location = new System.Drawing.Point(86, 101);
            this.dbconn_port.Name = "dbconn_port";
            this.dbconn_port.Size = new System.Drawing.Size(250, 21);
            this.dbconn_port.TabIndex = 6;
            this.dbconn_port.TextChanged += new System.EventHandler(this.dbconn_port_TextChanged);
            // 
            // dbconn_password
            // 
            this.dbconn_password.Location = new System.Drawing.Point(86, 74);
            this.dbconn_password.Name = "dbconn_password";
            this.dbconn_password.PasswordChar = '*';
            this.dbconn_password.Size = new System.Drawing.Size(250, 21);
            this.dbconn_password.TabIndex = 7;
            this.dbconn_password.TextChanged += new System.EventHandler(this.dbconn_password_TextChanged);
            // 
            // dbconn_username
            // 
            this.dbconn_username.Location = new System.Drawing.Point(86, 47);
            this.dbconn_username.Name = "dbconn_username";
            this.dbconn_username.Size = new System.Drawing.Size(250, 21);
            this.dbconn_username.TabIndex = 8;
            this.dbconn_username.TextChanged += new System.EventHandler(this.dbconn_username_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(6, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据/库";
            // 
            // dbconn_ipaddr
            // 
            this.dbconn_ipaddr.Location = new System.Drawing.Point(86, 19);
            this.dbconn_ipaddr.Name = "dbconn_ipaddr";
            this.dbconn_ipaddr.Size = new System.Drawing.Size(250, 21);
            this.dbconn_ipaddr.TabIndex = 9;
            this.dbconn_ipaddr.TextChanged += new System.EventHandler(this.dbconn_ipaddr_TextChanged);
            // 
            // lb_left_port
            // 
            this.lb_left_port.AutoSize = true;
            this.lb_left_port.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_left_port.Location = new System.Drawing.Point(6, 104);
            this.lb_left_port.Name = "lb_left_port";
            this.lb_left_port.Size = new System.Drawing.Size(29, 12);
            this.lb_left_port.TabIndex = 2;
            this.lb_left_port.Text = "端口";
            // 
            // lb_left_password
            // 
            this.lb_left_password.AutoSize = true;
            this.lb_left_password.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_left_password.Location = new System.Drawing.Point(6, 77);
            this.lb_left_password.Name = "lb_left_password";
            this.lb_left_password.Size = new System.Drawing.Size(29, 12);
            this.lb_left_password.TabIndex = 3;
            this.lb_left_password.Text = "密码";
            // 
            // lb_left_username
            // 
            this.lb_left_username.AutoSize = true;
            this.lb_left_username.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_left_username.Location = new System.Drawing.Point(6, 50);
            this.lb_left_username.Name = "lb_left_username";
            this.lb_left_username.Size = new System.Drawing.Size(41, 12);
            this.lb_left_username.TabIndex = 4;
            this.lb_left_username.Text = "用户名";
            // 
            // lb_left_ipaddr
            // 
            this.lb_left_ipaddr.AutoSize = true;
            this.lb_left_ipaddr.Font = new System.Drawing.Font("宋体", 9F);
            this.lb_left_ipaddr.Location = new System.Drawing.Point(6, 22);
            this.lb_left_ipaddr.Name = "lb_left_ipaddr";
            this.lb_left_ipaddr.Size = new System.Drawing.Size(71, 12);
            this.lb_left_ipaddr.TabIndex = 5;
            this.lb_left_ipaddr.Text = "SQL主机地址";
            // 
            // groupBox2
            // 
            this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
            this.groupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.groupBox2.Location = new System.Drawing.Point(11, -3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(150, 358);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // udpSocket1
            // 
            this.udpSocket1.Active = false;
            this.udpSocket1.LocalHost = "127.0.0.1";
            this.udpSocket1.LocalPort = 8225;
            this.udpSocket1.DataArrival += new ClassDDTS.UDPSocket.DataArrivalEventHandler(this.udpSocket1_DataArrival);
            // 
            // dbconn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 411);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.dbconn_comb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dbconn_delete);
            this.Controls.Add(this.dbconn_rename);
            this.Controls.Add(this.dbconn_save);
            this.Controls.Add(this.dbconn_clone);
            this.Controls.Add(this.dbconn_new);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "dbconn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "连接到我的SQL主机";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.dbconn_FormClosed);
            this.Load += new System.EventHandler(this.dbconn_Load);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button dbconn_testcnn;
        private System.Windows.Forms.Button dbconn_cancel;
        private System.Windows.Forms.Button dbconn_new;
        private System.Windows.Forms.Button dbconn_clone;
        private System.Windows.Forms.Button dbconn_save;
        private System.Windows.Forms.Button dbconn_rename;
        private System.Windows.Forms.Button dbconn_delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox dbconn_comb;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox dbconn_port;
        private System.Windows.Forms.TextBox dbconn_password;
        private System.Windows.Forms.TextBox dbconn_username;
        private System.Windows.Forms.TextBox dbconn_ipaddr;
        private System.Windows.Forms.Label lb_left_port;
        private System.Windows.Forms.Label lb_left_password;
        private System.Windows.Forms.Label lb_left_username;
        private System.Windows.Forms.Label lb_left_ipaddr;
        private System.Windows.Forms.TextBox dbconn_db;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button dbconn_cnn;
        private System.Windows.Forms.GroupBox groupBox2;
        private ClassDDTS.UDPSocket udpSocket1;
    }
}