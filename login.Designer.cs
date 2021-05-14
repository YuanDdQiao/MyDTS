
namespace MyDTS
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.button_login_cancel = new System.Windows.Forms.Button();
            this.button_login_click = new System.Windows.Forms.Button();
            this.text_login_passwd = new System.Windows.Forms.TextBox();
            this.text_login_name = new System.Windows.Forms.TextBox();
            this.label_login_password = new System.Windows.Forms.Label();
            this.label_login_username = new System.Windows.Forms.Label();
            this.udpSocket1 = new ClassDDTS.UDPSocket(this.components);
            this.SuspendLayout();
            // 
            // button_login_cancel
            // 
            this.button_login_cancel.Font = new System.Drawing.Font("Adobe 楷体 Std R", 14.25F, System.Drawing.FontStyle.Bold);
            this.button_login_cancel.Location = new System.Drawing.Point(194, 140);
            this.button_login_cancel.Name = "button_login_cancel";
            this.button_login_cancel.Size = new System.Drawing.Size(75, 30);
            this.button_login_cancel.TabIndex = 15;
            this.button_login_cancel.Text = "取  消";
            this.button_login_cancel.UseVisualStyleBackColor = true;
            // 
            // button_login_click
            // 
            this.button_login_click.Font = new System.Drawing.Font("Adobe 楷体 Std R", 14.25F, System.Drawing.FontStyle.Bold);
            this.button_login_click.Location = new System.Drawing.Point(80, 140);
            this.button_login_click.Name = "button_login_click";
            this.button_login_click.Size = new System.Drawing.Size(75, 30);
            this.button_login_click.TabIndex = 16;
            this.button_login_click.Text = "登  录";
            this.button_login_click.UseVisualStyleBackColor = true;
            this.button_login_click.Click += new System.EventHandler(this.button_login_click_Click);
            // 
            // text_login_passwd
            // 
            this.text_login_passwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_login_passwd.Location = new System.Drawing.Point(180, 101);
            this.text_login_passwd.Name = "text_login_passwd";
            this.text_login_passwd.PasswordChar = '*';
            this.text_login_passwd.Size = new System.Drawing.Size(119, 21);
            this.text_login_passwd.TabIndex = 14;
            this.text_login_passwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // text_login_name
            // 
            this.text_login_name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.text_login_name.Font = new System.Drawing.Font("宋体", 9F);
            this.text_login_name.Location = new System.Drawing.Point(180, 57);
            this.text_login_name.Name = "text_login_name";
            this.text_login_name.Size = new System.Drawing.Size(119, 21);
            this.text_login_name.TabIndex = 13;
            this.text_login_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_login_password
            // 
            this.label_login_password.AutoSize = true;
            this.label_login_password.Font = new System.Drawing.Font("Adobe 楷体 Std R", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_login_password.Location = new System.Drawing.Point(65, 98);
            this.label_login_password.Name = "label_login_password";
            this.label_login_password.Size = new System.Drawing.Size(103, 24);
            this.label_login_password.TabIndex = 12;
            this.label_login_password.Text = "*密    码：";
            this.label_login_password.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_login_username
            // 
            this.label_login_username.AutoSize = true;
            this.label_login_username.Font = new System.Drawing.Font("Adobe 楷体 Std R", 14.25F, System.Drawing.FontStyle.Bold);
            this.label_login_username.Location = new System.Drawing.Point(65, 54);
            this.label_login_username.Name = "label_login_username";
            this.label_login_username.Size = new System.Drawing.Size(102, 24);
            this.label_login_username.TabIndex = 11;
            this.label_login_username.Text = "用 户 名：";
            this.label_login_username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // udpSocket1
            // 
            this.udpSocket1.Active = false;
            this.udpSocket1.LocalHost = "127.0.0.1";
            this.udpSocket1.LocalPort = 8225;
            this.udpSocket1.DataArrival += new ClassDDTS.UDPSocket.DataArrivalEventHandler(this.udpSocket1_DataArrival);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(205)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(372, 218);
            this.Controls.Add(this.button_login_cancel);
            this.Controls.Add(this.button_login_click);
            this.Controls.Add(this.text_login_passwd);
            this.Controls.Add(this.text_login_name);
            this.Controls.Add(this.label_login_password);
            this.Controls.Add(this.label_login_username);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_login_cancel;
        private System.Windows.Forms.Button button_login_click;
        private System.Windows.Forms.TextBox text_login_passwd;
        private System.Windows.Forms.TextBox text_login_name;
        private System.Windows.Forms.Label label_login_password;
        private System.Windows.Forms.Label label_login_username;
        private ClassDDTS.UDPSocket udpSocket1;
    }
}