using ClassDDTS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MyDTS
{
    public partial class CControl : Form
    {
        public Publec_Class PubClass = new Publec_Class();
        public MyDictioinary<string, DB_Task> mytasks;
        public static MyDictioinary<string, DB_Map> mydics;
        //MySqlConnection conn = null;
        //MySqlDataReader dr = null;
        ClassOptionDataMysql url_mysql = new ClassOptionDataMysql();

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        //读写Server.ini文件
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public CControl()
        {
            InitializeComponent();
            //浮游圆形小窗口
            //sync.Float f = new sync.Float();
            //f.Show();
        }

        //窗体关闭前发生事件  
        private void Control_FormClosing(object sender, FormClosingEventArgs e)
        {
            //窗体关闭原因为单击"关闭"按钮或Alt+F4  
            if (e.CloseReason == CloseReason.UserClosing)
            {
                //取消关闭操作 表现为不关闭窗体  
                e.Cancel = true;
                //隐藏窗体  
                this.Hide();
            }
            if (this.WindowState.ToString() == "Maximized") {
                //如果Windows目录中有Server.ini文件
                if (System.IO.File.Exists(PubClass.Get_windows() + "\\Server.ini") == true)
                {
                    WritePrivateProfileString("MyDTS-Client", "WindowState", "Maximized", PubClass.Get_windows() + "\\Server.ini");
                }
            }
            else {
                //如果Windows目录中有Server.ini文件
                if (System.IO.File.Exists(PubClass.Get_windows() + "\\Server.ini") == true)
                {
                    WritePrivateProfileString("MyDTS-Client", "WindowState", this.WindowState.ToString(), PubClass.Get_windows() + "\\Server.ini");
                }

            }
            if (udpSocket1.Active) { udpSocket1.Active = false; }
        }

        //"显示窗体"单击事件  
        private void client_control_show_Click(object sender, EventArgs e)
        {
            //窗体显示  
            this.Show();
            //窗体状态默认大小  
            StringBuilder temp = new StringBuilder(255);
            //如果Windows目录中有Server.ini文件
            if (System.IO.File.Exists(PubClass.Get_windows() + "\\Server.ini") == true)
            {
                GetPrivateProfileString("MyDTS-Client", "WindowState", "服务器地址读取错误。", temp, 255, PubClass.Get_windows() + "\\Server.ini");
                if (temp.ToString() == "Maximized")
                {
                    this.WindowState = FormWindowState.Maximized;
                }
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
            //激活窗体给予焦点  
            this.Activate();
        }

        //"隐藏窗体"单击事件  
        private void client_control_hide_Click(object sender, EventArgs e)
        {
            //隐藏窗体  
            this.Hide();
        }

        //"退出"单击事件  
        private void client_control_exit_Click(object sender, EventArgs e)
        {
            //点击"是(YES)"退出程序  
            if (MessageBox.Show("_确定要退出程序?", "安全提示",
                        System.Windows.Forms.MessageBoxButtons.YesNo,
                        System.Windows.Forms.MessageBoxIcon.Warning)
                == System.Windows.Forms.DialogResult.Yes)
            {
                //设置图标不可见  
                notifyIcon1.Visible = false;
                //关闭窗体  
                this.Close();
                //释放资源  
                this.Dispose();
                //关闭应用程序窗体  
                //Application.Exit();
                Process.GetCurrentProcess().Kill();
            }

        }
        //双击图标之后显示窗体
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            //激活窗体给予焦点  
            this.Activate();
        }
        private void CControl_Load(object sender, EventArgs e)
        {
            StringBuilder temp = new StringBuilder(255);
            //Console.WriteLine("当前路径:"+ System.Environment.CurrentDirectory);
            try
            {   //如果Windows目录中有Server.ini文件
                if (System.IO.File.Exists(PubClass.Get_windows() + "\\Server.ini") == true)
                {
                    GetPrivateProfileString("MyDTS-Client", "WindowState", "服务器地址读取错误。", temp, 255, PubClass.Get_windows() + "\\Server.ini");
                    if(temp.ToString() == "Maximized")
                    {
                        this.WindowState = FormWindowState.Maximized;
                    }
                }
                Login FrmLogon = new Login();   //创建并引用登录窗体
                if (FrmLogon.ShowDialog(this) == DialogResult.OK)   //当登窗体的对话框的返回值为OK时
                {
                    FrmLogon.Dispose();
                    FrmLogon.Close();
                    //udpSocket1.Active = true;
                    this.Text = "SQL-当前用户[" + Publec_Class.UserName + "]";
                    cctl_init_dblist();
                    cctl_init_tasklist();
                }
                else
                {
                    if (udpSocket1.Active) { udpSocket1.Active = false; }
                    FrmLogon.Dispose();
                    Close();
                    //关闭 CControl
                    //Application.Exit();
                    Process.GetCurrentProcess().Kill();
                }
                //启动并清理后台同步exe线程
                Process[] processes = Process.GetProcessesByName("slave");
                foreach (Process p in processes)
                {
                    p.Kill();
                }

                }catch (Exception ex)
            {
                Console.WriteLine("这里异常-：" + ex.Message);
            }
        }
        private void cctl_init_tasklist()
        {
            Publec_Class pc = new Publec_Class();
            ClassMsg msg = new ClassMsg();
            msg.sendKind = SendKind.SendCommand;
            msg.msgCommand = MsgCommand.TaskList;
            msg.SIP = pc.getMacAddr_Local(0);
            msg.SPort = this.udpSocket1.LocalPort.ToString();
            msg.Suser = Publec_Class.UserName;
            //打开socket，后台通信
            if (!udpSocket1.Active) { udpSocket1.Active = true; }
            udpSocket1.Send(IPAddress.Parse(Publec_Class.ServerIP), Convert.ToInt32(Publec_Class.ServerPort), new ClassSerializers().SerializeBinary(msg).ToArray());

        }
        private void cctl_init_dblist()
        {
            Publec_Class pc = new Publec_Class();
            ClassMsg msg = new ClassMsg();
            msg.sendKind = SendKind.SendCommand;
            msg.msgCommand = MsgCommand.DBList;
            msg.SIP = pc.getMacAddr_Local(0);
            msg.SPort = this.udpSocket1.LocalPort.ToString();
            msg.Suser = Publec_Class.UserName;

            //打开socket，后台通信
            if (!udpSocket1.Active) { udpSocket1.Active = true; }

            udpSocket1.Send(IPAddress.Parse(Publec_Class.ServerIP), Convert.ToInt32(Publec_Class.ServerPort), new ClassSerializers().SerializeBinary(msg).ToArray());

        }

        private void 数据同步ToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            this.数据同步ToolStripMenuItem.BackColor = Color.FromArgb(255, 241, 203);
        }
        private void 数据同步ToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            this.数据同步ToolStripMenuItem.BackColor = Color.FromArgb(196, 205, 218);
        }
        private void 数据同步ToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            this.数据同步ToolStripMenuItem.BackColor = Color.FromArgb(255, 241, 203);

        }

        /// <summary>
        /// 添加自定义数据库资源
        /// </summary>
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            if (this.udpSocket1.Active) this.udpSocket1.Active = false;
            dbconn.dbconn cnn = new dbconn.dbconn();
            if (cnn.ShowDialog(this) == DialogResult.OK)   //当登窗体的对话框的返回值为OK时
            {
                cnn.Dispose();
                cnn.Close();
            }
        }
        /// <summary>
        /// 我的数据库
        /// </summary>
        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            SuperMessage.dbtype = 0;
            if (udpSocket1.Active) { udpSocket1.Active = false; }
            dbconn.DBHouse dbh = new dbconn.DBHouse();
            if (dbh.ShowDialog(this) == DialogResult.OK)   //当登窗体的对话框的返回值为OK时
            {
                dbh.Dispose();
                dbh.Close();
                toolStripStatusLabel3.Text = "关闭了数据库列表.";

            }
        }
        /// <summary>
        /// 公司数据库资源列表
        /// </summary>
        private void toolStripLabel5_Click(object sender, EventArgs e)
        {
            //展示公司提供的数据库资源列表
            SuperMessage.dbtype = 1;
            dbconn.DBHouse dbh = new dbconn.DBHouse();
            if (dbh.ShowDialog(this) == DialogResult.OK)   //当登窗体的对话框的返回值为OK时
            {
                dbh.Dispose();
                dbh.Close();
                toolStripStatusLabel3.Text = "关闭了数据库列表.";
            }
        }
        /// <summary>
        /// 数据同步
        /// </summary>
        private void mySQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.udpSocket1.Active) this.udpSocket1.Active = false;
            sync.SyncOptions syncop = new sync.SyncOptions();
            //窗体的对话框返回值为OK时
            if(syncop.ShowDialog(this) == DialogResult.OK)
            {
                toolStripStatusLabel3.Text = "成功添加同步.";
                syncop.Dispose();
                //cctl_init_dblist();
                cctl_init_tasklist();
            }
            else
            {
                toolStripStatusLabel3.Text = "取消同步.";
                syncop.Dispose();
            }

        }

        private void contextMenuStrip1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {

        }

        private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port);

        private void udpSocket1_DataArrival(byte[] Data, IPAddress Ip, int Port)
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival);
            this.BeginInvoke(outdelegate, new object[] { Data, Ip, Port });
        }
        private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port) //当有数据到达后的处理进程
        {
            try
            {
                ClassMsg msg = new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as ClassMsg;
                switch (msg.msgCommand)
                {
                    case MsgCommand.TaskList:
                        //DialogResult = DialogResult.OK;
                        mytasks = (MyDictioinary<string, DB_Task>)new ClassSerializers().DeSerializeBinary(new MemoryStream(msg.Data));
                        //渲染数据
                        SuperMessage.mytasks = mytasks;
                        //数据库任务列表
                        this.splitContainer1.Visible = true;
                        this.treeView1.Nodes.Clear();
                        TreeNode datasync = new TreeNode("数据同步");//mytask.Value.TaskName
                        
                        foreach (KeyValuePair<string, DB_Task> mytask in mytasks.llDictionary)
                        {
                            //var synctask = datasync.Nodes.Add(mytask.Value.TaskName);
                            //如果还有子任务则：参考：https://blog.csdn.net/laoyezha/article/details/79302679
                            //    pointer = synctask.Nodes.Add("一人之下");
                            datasync.Nodes.Add(mytask.Value.TaskName);
                        }
                        this.treeView1.Nodes.Add(datasync);

                        break;
                    case MsgCommand.DBTaskCount://数据库资源为0
                        //0任务列表,不做显示
                        //初始化界面为0应该的样子
                        this.splitContainer1.Visible = false;

                        break;
                    case MsgCommand.DBList:
                        //DialogResult = DialogResult.OK;
                        mydics = (MyDictioinary<string, DB_Map>)new ClassSerializers().DeSerializeBinary(new MemoryStream(msg.Data));
                        //渲染数据库资源下拉按钮之前，保存列表字典到全局区
                        //全局变量重构//
                        //PublicValue.mydics = mydics;
                        SuperMessage.mydics = mydics;

                        break;
                    case MsgCommand.DBCount://数据库资源为0

                        break;

                }
            }
            catch { }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //只处理鼠标点击引起的状态变化
            if (e.Action == TreeViewAction.ByMouse)
            {
                toolStripStatusLabel3.Text = this.treeView1.SelectedNode.Text;
                this.panel_gb.BackColor = Color.White;
                this.panel_gb.Visible = true;
                foreach (KeyValuePair<string, DB_Task> mytask in mytasks.llDictionary)
                {
                    if(mytask.Value.TaskName == this.treeView1.SelectedNode.Text)
                    {
                        this.panel_gb_taskname.Text = this.treeView1.SelectedNode.Text;
                        this.panel_gb_sip.Text = mytask.Value.SIp;
                        this.panel_gb_sport.Text = mytask.Value.SPort.ToString() ;
                        this.panel_gb_suser.Text = mytask.Value.SUser;
                        this.panel_gb_tip.Text = mytask.Value.TIp;
                        this.panel_gb_tport.Text = mytask.Value.TPort.ToString();
                        this.panel_gb_tuser.Text = mytask.Value.TUser;
                        this.panel_gb_process.Text = mytask.Value.TaskProcess.ToString();
                        this.labelt.Visible = true;
                        this.labels.Visible = true;
                        this.label4.Visible = true;
                        this.label5.Visible = true;
                        this.label6.Visible = true;
                        this.label7.Visible = true;
                        this.label8.Visible = true;
                        this.label2.Visible = true;
                    }
                }
                

            }
            else
            {
                this.splitContainer1.Panel2.BackColor = Color.FromArgb(53, 73, 106);
                this.panel_gb.Visible = false;
                this.labelt.Visible = false;
                this.labels.Visible = false;
                this.label4.Visible = false;
                this.label5.Visible = false;
                this.label6.Visible = false;
                this.label7.Visible = false;
                this.label8.Visible = false;
                this.label2.Visible = false;
            }
        }

        private void sQL语句发布ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.udpSocket1.Active) this.udpSocket1.Active = false;
            sync.SqlReport sqlRep = new sync.SqlReport();
            //窗体的对话框返回值为OK时
            if (sqlRep.ShowDialog(this) == DialogResult.OK)
            {
                toolStripStatusLabel3.Text = "sql发布成功.";
                sqlRep.Dispose();
                cctl_init_dblist();

            }
            else
            {
                toolStripStatusLabel3.Text = "取消sql发布.";
                sqlRep.Dispose();
            }
        }
    }

    public class SuperMessage
    {
        //搜索：//全局变量重构// 就可以再所有客户端代码中获取修改前后的对比
        public static int dbtype;
        public static MyDictioinary<string, DB_Task> mytasks;
        public static MyDictioinary<string, DB_Map> mydics;
        public static string curr_username;
    }
}
