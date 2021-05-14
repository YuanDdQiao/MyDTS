
namespace MyDTS.dbconn
{
    partial class create_conn
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_crenn_name = new System.Windows.Forms.TextBox();
            this.bt_crenn_name_cancel = new System.Windows.Forms.Button();
            this.bt_crenn_name_ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            // 
            // tb_crenn_name
            // 
            this.tb_crenn_name.Location = new System.Drawing.Point(6, 31);
            this.tb_crenn_name.Name = "tb_crenn_name";
            this.tb_crenn_name.Size = new System.Drawing.Size(258, 21);
            this.tb_crenn_name.TabIndex = 1;
            // 
            // bt_crenn_name_cancel
            // 
            this.bt_crenn_name_cancel.Location = new System.Drawing.Point(189, 60);
            this.bt_crenn_name_cancel.Name = "bt_crenn_name_cancel";
            this.bt_crenn_name_cancel.Size = new System.Drawing.Size(75, 23);
            this.bt_crenn_name_cancel.TabIndex = 2;
            this.bt_crenn_name_cancel.Text = "取消";
            this.bt_crenn_name_cancel.UseVisualStyleBackColor = true;
            // 
            // bt_crenn_name_ok
            // 
            this.bt_crenn_name_ok.Location = new System.Drawing.Point(104, 60);
            this.bt_crenn_name_ok.Name = "bt_crenn_name_ok";
            this.bt_crenn_name_ok.Size = new System.Drawing.Size(75, 23);
            this.bt_crenn_name_ok.TabIndex = 3;
            this.bt_crenn_name_ok.Text = "确定";
            this.bt_crenn_name_ok.UseVisualStyleBackColor = true;
            this.bt_crenn_name_ok.Click += new System.EventHandler(this.bt_crenn_name_ok_Click);
            // 
            // create_conn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 91);
            this.Controls.Add(this.bt_crenn_name_ok);
            this.Controls.Add(this.bt_crenn_name_cancel);
            this.Controls.Add(this.tb_crenn_name);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "create_conn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Connection";
            this.Load += new System.EventHandler(this.create_conn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_crenn_name;
        private System.Windows.Forms.Button bt_crenn_name_cancel;
        private System.Windows.Forms.Button bt_crenn_name_ok;
    }
}