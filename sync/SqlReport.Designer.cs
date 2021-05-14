
namespace MyDTS.sync
{
    partial class SqlReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlReport));
            this.udpSocket1 = new ClassDDTS.UDPSocket(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_timer = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1_sql = new System.Windows.Forms.DateTimePicker();
            this.cbb_sqlreport = new System.Windows.Forms.ComboBox();
            this.sql_report_bt = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtb_sql_report = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // udpSocket1
            // 
            this.udpSocket1.Active = false;
            this.udpSocket1.LocalHost = "127.0.0.1";
            this.udpSocket1.LocalPort = 8225;
            this.udpSocket1.DataArrival += new ClassDDTS.UDPSocket.DataArrivalEventHandler(this.udpSocket1_DataArrival);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cb_timer);
            this.groupBox1.Controls.Add(this.dateTimePicker1_sql);
            this.groupBox1.Controls.Add(this.cbb_sqlreport);
            this.groupBox1.Controls.Add(this.sql_report_bt);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 470);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 69);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "选择数据库实例：";
            // 
            // cb_timer
            // 
            this.cb_timer.AutoSize = true;
            this.cb_timer.Location = new System.Drawing.Point(8, 45);
            this.cb_timer.Name = "cb_timer";
            this.cb_timer.Size = new System.Drawing.Size(144, 16);
            this.cb_timer.TabIndex = 4;
            this.cb_timer.Text = "启用开始执行的时间：";
            this.cb_timer.UseVisualStyleBackColor = true;
            this.cb_timer.CheckedChanged += new System.EventHandler(this.cb_timer_CheckedChanged);
            // 
            // dateTimePicker1_sql
            // 
            this.dateTimePicker1_sql.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePicker1_sql.Enabled = false;
            this.dateTimePicker1_sql.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1_sql.Location = new System.Drawing.Point(156, 42);
            this.dateTimePicker1_sql.Name = "dateTimePicker1_sql";
            this.dateTimePicker1_sql.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1_sql.TabIndex = 3;
            this.dateTimePicker1_sql.ValueChanged += new System.EventHandler(this.dateTimePicker1_sql_ValueChanged);
            // 
            // cbb_sqlreport
            // 
            this.cbb_sqlreport.BackColor = System.Drawing.Color.White;
            this.cbb_sqlreport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_sqlreport.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.cbb_sqlreport.FormattingEnabled = true;
            this.cbb_sqlreport.Location = new System.Drawing.Point(156, 16);
            this.cbb_sqlreport.Name = "cbb_sqlreport";
            this.cbb_sqlreport.Size = new System.Drawing.Size(200, 20);
            this.cbb_sqlreport.TabIndex = 1;
            this.cbb_sqlreport.SelectedIndexChanged += new System.EventHandler(this.cbb_sqlreport_SelectedIndexChanged);
            // 
            // sql_report_bt
            // 
            this.sql_report_bt.Dock = System.Windows.Forms.DockStyle.Right;
            this.sql_report_bt.Enabled = false;
            this.sql_report_bt.Location = new System.Drawing.Point(652, 17);
            this.sql_report_bt.Name = "sql_report_bt";
            this.sql_report_bt.Size = new System.Drawing.Size(98, 49);
            this.sql_report_bt.TabIndex = 0;
            this.sql_report_bt.Text = "提 交/立即执行";
            this.sql_report_bt.UseVisualStyleBackColor = true;
            this.sql_report_bt.Click += new System.EventHandler(this.sql_report_bt_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtb_sql_report);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(753, 470);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // rtb_sql_report
            // 
            this.rtb_sql_report.BackColor = System.Drawing.Color.Lavender;
            this.rtb_sql_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_sql_report.Location = new System.Drawing.Point(3, 17);
            this.rtb_sql_report.Name = "rtb_sql_report";
            this.rtb_sql_report.Size = new System.Drawing.Size(747, 450);
            this.rtb_sql_report.TabIndex = 0;
            this.rtb_sql_report.Text = "";
            this.rtb_sql_report.TextChanged += new System.EventHandler(this.rtb_sql_report_TextChanged);
            // 
            // SqlReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 539);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SqlReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL发布";
            this.Load += new System.EventHandler(this.SqlReport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private ClassDDTS.UDPSocket udpSocket1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button sql_report_bt;
        private System.Windows.Forms.RichTextBox rtb_sql_report;
        private System.Windows.Forms.ComboBox cbb_sqlreport;
        private System.Windows.Forms.CheckBox cb_timer;
        private System.Windows.Forms.DateTimePicker dateTimePicker1_sql;
        private System.Windows.Forms.Label label1;
    }
}