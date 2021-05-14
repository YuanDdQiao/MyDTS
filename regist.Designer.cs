
namespace MyDTS
{
    partial class Regist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Regist));
            this.button_regist_cancel = new System.Windows.Forms.Button();
            this.button_regist_click = new System.Windows.Forms.Button();
            this.text_regist_phone = new System.Windows.Forms.TextBox();
            this.label_regist_phone = new System.Windows.Forms.Label();
            this.text_regist_mail = new System.Windows.Forms.TextBox();
            this.label_regist_mail = new System.Windows.Forms.Label();
            this.text_regist_ack_password = new System.Windows.Forms.TextBox();
            this.label_regist_ack_password = new System.Windows.Forms.Label();
            this.text_regist_password = new System.Windows.Forms.TextBox();
            this.text_regist_name = new System.Windows.Forms.TextBox();
            this.label_regist_password = new System.Windows.Forms.Label();
            this.label_regist_username = new System.Windows.Forms.Label();
            this.udpSocket1 = new ClassDDTS.UDPSocket(this.components);
            this.SuspendLayout();
            // 
            // button_regist_cancel
            // 
            this.button_regist_cancel.Font = new System.Drawing.Font("Adobe 楷体 Std R", 14.25F, System.Drawing.FontStyle.Bold);
            this.button_regist_cancel.Location = new System.Drawing.Point(237, 334);
            this.button_regist_cancel.Name = "button_regist_cancel";
            this.button_regist_cancel.Size = new System.Drawing.Size(75, 30);
            this.button_regist_cancel.TabIndex = 39;
            this.button_regist_cancel.Text = "取  消";
            this.button_regist_cancel.UseVisualStyleBackColor = true;
            this.button_regist_cancel.Click += new System.EventHandler(this.button_regist_cancel_Click);
            // 
            // button_regist_click
            // 
            this.button_regist_click.Font = new System.Drawing.Font("Adobe 楷体 Std R", 14.25F, System.Drawing.FontStyle.Bold);
            this.button_regist_click.Location = new System.Drawing.Point(72, 334);
            this.button_regist_click.Name = "button_regist_click";
            this.button_regist_click.Size = new System.Drawing.Size(75, 30);
            this.button_regist_click.TabIndex = 38;
            this.button_regist_click.Text = "注  册";
            this.button_regist_click.UseVisualStyleBackColor = true;
            this.button_regist_click.Click += new System.EventHandler(this.button_regist_click_Click);
            // 
            // text_regist_phone
            // 
            this.text_regist_phone.Font = new System.Drawing.Font("宋体", 9F);
            this.text_regist_phone.Location = new System.Drawing.Point(197, 272);
            this.text_regist_phone.Name = "text_regist_phone";
            this.text_regist_phone.Size = new System.Drawing.Size(119, 21);
            this.text_regist_phone.TabIndex = 37;
            this.text_regist_phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_regist_phone
            // 
            this.label_regist_phone.AutoSize = true;
            this.label_regist_phone.Font = new System.Drawing.Font("Adobe 楷体 Std R", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_regist_phone.Location = new System.Drawing.Point(60, 272);
            this.label_regist_phone.Name = "label_regist_phone";
            this.label_regist_phone.Size = new System.Drawing.Size(119, 24);
            this.label_regist_phone.TabIndex = 36;
            this.label_regist_phone.Text = "*手机号码：";
            this.label_regist_phone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_regist_mail
            // 
            this.text_regist_mail.Font = new System.Drawing.Font("宋体", 9F);
            this.text_regist_mail.Location = new System.Drawing.Point(197, 225);
            this.text_regist_mail.Name = "text_regist_mail";
            this.text_regist_mail.Size = new System.Drawing.Size(119, 21);
            this.text_regist_mail.TabIndex = 35;
            this.text_regist_mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_regist_mail
            // 
            this.label_regist_mail.AutoSize = true;
            this.label_regist_mail.Font = new System.Drawing.Font("Adobe 楷体 Std R", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_regist_mail.Location = new System.Drawing.Point(60, 222);
            this.label_regist_mail.Name = "label_regist_mail";
            this.label_regist_mail.Size = new System.Drawing.Size(119, 24);
            this.label_regist_mail.TabIndex = 34;
            this.label_regist_mail.Text = "*邮箱地址：";
            this.label_regist_mail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_regist_ack_password
            // 
            this.text_regist_ack_password.Location = new System.Drawing.Point(197, 171);
            this.text_regist_ack_password.Name = "text_regist_ack_password";
            this.text_regist_ack_password.PasswordChar = '*';
            this.text_regist_ack_password.Size = new System.Drawing.Size(119, 21);
            this.text_regist_ack_password.TabIndex = 33;
            this.text_regist_ack_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_regist_ack_password
            // 
            this.label_regist_ack_password.AutoSize = true;
            this.label_regist_ack_password.Font = new System.Drawing.Font("Adobe 楷体 Std R", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_regist_ack_password.Location = new System.Drawing.Point(60, 168);
            this.label_regist_ack_password.Name = "label_regist_ack_password";
            this.label_regist_ack_password.Size = new System.Drawing.Size(119, 24);
            this.label_regist_ack_password.TabIndex = 32;
            this.label_regist_ack_password.Text = "*密码确认：";
            this.label_regist_ack_password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_regist_password
            // 
            this.text_regist_password.Location = new System.Drawing.Point(197, 121);
            this.text_regist_password.Name = "text_regist_password";
            this.text_regist_password.PasswordChar = '*';
            this.text_regist_password.Size = new System.Drawing.Size(119, 21);
            this.text_regist_password.TabIndex = 31;
            this.text_regist_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_regist_name
            // 
            this.text_regist_name.Font = new System.Drawing.Font("宋体", 9F);
            this.text_regist_name.Location = new System.Drawing.Point(197, 78);
            this.text_regist_name.Name = "text_regist_name";
            this.text_regist_name.Size = new System.Drawing.Size(119, 21);
            this.text_regist_name.TabIndex = 30;
            this.text_regist_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_regist_password
            // 
            this.label_regist_password.AutoSize = true;
            this.label_regist_password.Font = new System.Drawing.Font("Adobe 楷体 Std R", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_regist_password.Location = new System.Drawing.Point(70, 121);
            this.label_regist_password.Name = "label_regist_password";
            this.label_regist_password.Size = new System.Drawing.Size(109, 24);
            this.label_regist_password.TabIndex = 29;
            this.label_regist_password.Text = "* 密    码：";
            this.label_regist_password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_regist_username
            // 
            this.label_regist_username.AutoSize = true;
            this.label_regist_username.Font = new System.Drawing.Font("Adobe 楷体 Std R", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_regist_username.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_regist_username.Location = new System.Drawing.Point(68, 75);
            this.label_regist_username.Name = "label_regist_username";
            this.label_regist_username.Size = new System.Drawing.Size(111, 24);
            this.label_regist_username.TabIndex = 28;
            this.label_regist_username.Text = "*用 户 名：";
            this.label_regist_username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // udpSocket1
            // 
            this.udpSocket1.Active = false;
            this.udpSocket1.LocalHost = "127.0.0.1";
            this.udpSocket1.LocalPort = 8225;
            this.udpSocket1.DataArrival += new ClassDDTS.UDPSocket.DataArrivalEventHandler(this.udpSocket1_DataArrival);
            // 
            // Regist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(205)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(394, 448);
            this.Controls.Add(this.button_regist_cancel);
            this.Controls.Add(this.button_regist_click);
            this.Controls.Add(this.text_regist_phone);
            this.Controls.Add(this.label_regist_phone);
            this.Controls.Add(this.text_regist_mail);
            this.Controls.Add(this.label_regist_mail);
            this.Controls.Add(this.text_regist_ack_password);
            this.Controls.Add(this.label_regist_ack_password);
            this.Controls.Add(this.text_regist_password);
            this.Controls.Add(this.text_regist_name);
            this.Controls.Add(this.label_regist_password);
            this.Controls.Add(this.label_regist_username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Regist";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "regist";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.regist_FormClosed);
            this.Load += new System.EventHandler(this.regist_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_regist_cancel;
        private System.Windows.Forms.Button button_regist_click;
        private System.Windows.Forms.TextBox text_regist_phone;
        private System.Windows.Forms.Label label_regist_phone;
        private System.Windows.Forms.TextBox text_regist_mail;
        private System.Windows.Forms.Label label_regist_mail;
        private System.Windows.Forms.TextBox text_regist_ack_password;
        private System.Windows.Forms.Label label_regist_ack_password;
        private System.Windows.Forms.TextBox text_regist_password;
        private System.Windows.Forms.TextBox text_regist_name;
        private System.Windows.Forms.Label label_regist_password;
        private System.Windows.Forms.Label label_regist_username;
        private ClassDDTS.UDPSocket udpSocket1;
    }
}