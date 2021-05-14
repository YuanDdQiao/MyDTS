using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDTS.sync
{
    public partial class Float : Form
    {
        private Point _frmPoint;
        public Float()
        {
            InitializeComponent();
            //无边框
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //不出现在任务栏
            this.ShowInTaskbar = false;

            this.TopMost = true;
            _frmPoint = new Point();

        }

        private void Float_Load(object sender, EventArgs e)
        {
            this.MouseDown += Float_MouseDown;
            this.MouseMove += Float_MouseMove;

        }

        private void Float_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-_frmPoint.X, -_frmPoint.Y);
                Location = myPosittion;
            }
            //鼠标划过时候的背景色
            this.BackColor = System.Drawing.Color.White;
            //鼠标划过时候的提示信息
            ToolTip p = new ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(this, "创建新连接");

        }

        private void Float_MouseDown(object sender, MouseEventArgs e)
        {
            _frmPoint.X = e.X;
            _frmPoint.Y = e.Y;

        }
        
        //配置位圆形窗体
        private void Float_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath mypath = new System.Drawing.Drawing2D.GraphicsPath();
            //mypath.AddEllipse(10, 10, this.Width - 30, this.Height - 20);
            mypath.AddEllipse(100, 5, this.ClientSize.Width-100, this.ClientSize.Height-15);
            this.Region = new Region(mypath);
        }
        
        private void Float_MouseLeave(object sender, EventArgs e)
        {
        //鼠标离开后时候的背景色恢复到默认
        this.BackColor = System.Drawing.Color.Lavender;
        this.BackColor = System.Drawing.Color.SkyBlue;
        }

        private void Float_MouseUp(object sender, MouseEventArgs e)
        {
            this.BackColor = System.Drawing.Color.SkyBlue;

        }

        private void Float_Click(object sender, EventArgs e)
        {
        this.BackColor = System.Drawing.Color.White;

        }
    }
}
