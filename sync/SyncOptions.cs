using ClassDDTS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDTS.sync
{
    public partial class SyncOptions : Form
    {
        //上/下一步，操作初始索引的状态
        public int sindex = 0;
        //数据库连接
        MySqlConnection conn = null;
        MyDictioinary<string, DB_Map> mydics;
        ClassOptionDataMysql url_source_mysql = new ClassOptionDataMysql();
        ClassOptionDataMysql url_target_mysql = new ClassOptionDataMysql();
        MySqlDataReader dr = null;
        string sync_type = "";

        public SyncOptions()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = sindex;
            button1_up.Enabled = false;
        }

        [DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);

        private void SyncOptions_Load(object sender, EventArgs e)
        {
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.ItemSize = new Size(0, 1);
            button2_next.Focus();

        }
        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SyncOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (udpSocket1.Active)
                udpSocket1.Active = false;

        }

        private void button1_sqlview_Click(object sender, EventArgs e)
        {
            sync.SQLResult sqlrel = new sync.SQLResult();
            if (sqlrel.ShowDialog(this) == DialogResult.OK)   //当登窗体的对话框的返回值为OK时
            {
                sqlrel.Dispose();
                sqlrel.Close();
            }

        }

        private void button1_up_Click(object sender, EventArgs e)
        {
            sindex -= 1;
            //（1）
            //当选择的“通过SQL语句一次性同步”为真，则在处理上一步操作的时候需要过滤掉第四步界面
            switch (sindex)
            {
                case 3:
                    if (sync_type == "sql") { sindex -= 1; }
                    break;
                case 4:
                    if (sync_type == "all" || sync_type == "once") { sindex -= 1; }
                    break;
                default:
                    break;
            }


            //上一步 导航按钮控制上下限

            if (sindex >= 0)
            {
                //导航栏按钮处理
                button2_next.Text = "下一步 >";
                tabControl1.SelectedIndex = sindex;
            }
            if (sindex < 5)
            {
                button2_next.Enabled = true;
            }
            if (sindex <= 0)
            {
                button1_up.Enabled = false;
                button2_next.Enabled = true;

            }
            //Console.WriteLine("sindex =" + sindex);
        }
        private void button2_next_Click(object sender, EventArgs e)
        {
            sindex += 1;
            //（1）
            //进入下一个不步骤窗体之前，要做基本的条件处理
            //同步数据类型一定要选择
            bool type_1 = t_ypen();
            //同步数据库资源一定要选择
            switch (sindex)
            {
                case 1:
                    if (!type_1) { MessageBox.Show("       请选择同步数据类型！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); sindex = 0; return; } //sindex = 0; 用作还原当前按钮所在状态的正确步骤
                    //Console.WriteLine("sindex =" + sindex);
                    //初始化下拉菜单列表
                    init_dblist();

                    break;
                case 2:
                    button2_next.Focus();
                    if (!type_b_data_source_is_ok(0)) { MessageBox.Show("       请选择源数据库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); sindex = 1; return; } //sindex = 1; 用作还原当前按钮所在状态的正确步骤
                    if (this.dbsource.Dbname.Length == 0)
                    {
                        MessageBox.Show("       请选择源数据库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); sindex = 1; return;
                    }

                    if (!type_b_data_source_is_ok(1)) { MessageBox.Show("       请选择目标数据库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); sindex = 1; return; }
                    if (this.dbtarget.Dbname.Length == 0)
                    {
                        MessageBox.Show("       请选择目标数据库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); sindex = 1; return;
                    }
                    //Console.WriteLine("sindex =" + sindex);
                    if (this.dbname_left.Text.Trim() == "")
                    {
                        MessageBox.Show("       源数据库名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); sindex = 1; return;
                    }
                    if (this.dbname_right.Text.Trim() == "")
                    {
                        MessageBox.Show("       目标数据库名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); sindex = 1; return;
                    }
                    break;
                case 3:
                    //只显示"再数据库中同步所有表"单选按钮
                    if(sync_type == "all")
                    {
                        radioButton6_part.Enabled = false;
                        radioButton5_all.Enabled = true;
                        radioButton5_all.Checked = true;
                        treeView1.Enabled = false;
                        CreateTree();

                    }
                    //只显示"全量数据一次性同步"单选按钮
                    if (sync_type == "once")
                    {
                        radioButton6_part.Enabled = true;
                        radioButton5_all.Enabled = false;
                        radioButton6_part.Checked = true;
                        treeView1.Enabled = true;

                        CreateTree();
                    }
                    button2_next.Focus();
                    //如果选则的是“通过SQL语句一次性同步”则导航使用到的索引  sindex  需要跳过第四步
                    if (sync_type == "sql")
                    {
                        sindex += 1;
                    }

                    //Console.WriteLine("sindex =" + sindex);
                    break;
                case 4:
                    button2_next.Focus();
                    //如果选则的是“通过SQL语句一次性同步”则导航使用到的索引  sindex  不在增加处理逻辑
                    if (sync_type != "sql")
                    {
                        sindex += 1;
                    }
                    //Console.WriteLine("sindex =" + sindex);
                    break;
                case 5:
                    button2_next.Focus();
                    //Console.WriteLine("sindex =" + sindex);
                    break;
                default:
                    if(this.tb_taskname.Text.Trim() == "")
                    {
                        MessageBox.Show("       *同步的任务命名,不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                    if (MessageBox.Show("   您确定立即开始执行任务吗?", "提示",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Question)
            == System.Windows.Forms.DialogResult.Yes)
                    {
                        start_task();
                    }
                    break;
            }
            //（2）
            //下一步 导航按钮控制上下限
            if (sindex >= 5)
            {
                if(checkBox4_imi.Checked == true)
                {
                    button2_next.Text = "立即执行";
                }
                else
                {
                    button2_next.Enabled = false;

                }
                if (sindex > 5)
                {
                    sindex = 5;
                }
            }
            else
            {
                button2_next.Text = "下一步 >";
                button2_next.Enabled = true;
                button1_up.Enabled = true;
            }

            //（3）
            //导航栏按钮处理
            tabControl1.SelectedIndex = sindex;
            //Console.WriteLine("下一步按钮.." + sindex);

        }
        private bool t_ypen()
        {
            //三个单选按钮必须有一个选择，否则不能得知数据传输的方式
            if (radioButton1_all.Checked == true)
            {
                sync_type = "all";
                return true;
            }
            else if (radioButton2_once.Checked == true)
            {
                sync_type = "once";
                return true;
            }
            else if (radioButton3_sql.Checked == true)
            {
                sync_type = "sql";
                return true;
            }
            else
            {
                return false;
            }
        }
        //初始化数据库实例的数据源信息和 目标数据库配置信息
        private bool db_info_set_source()
        {
            if (this.tb_left_ipaddr.Text.Trim() == "" || this.tb_left_username.Text.Trim() == "" || this.tb_left_password.Text.Trim() == "" || this.tb_left_port.Text.Trim() == "")
            {
                //MessageBox.Show("       数据源连接信息错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (!Publec_Class.IsNumberic(this.tb_left_port.Text.Trim())) { MessageBox.Show("端口只能为正整数！");return false; }
            // 数据源信息
            this.dbsource.DbHost = this.tb_left_ipaddr.Text.Trim();
            this.dbsource.DbUser = this.tb_left_username.Text.Trim();
            this.dbsource.DbPassword = this.tb_left_password.Text.Trim();
            this.dbsource.DbPort = Convert.ToInt32(this.tb_left_port.Text.Trim());
            //this.dbsource.Dbname = this.dbname_left.Text.Trim();
            //
            url_source_mysql.DbHost = this.dbsource.DbHost;
            url_source_mysql.DbUser = this.dbsource.DbUser;
            url_source_mysql.DbPassword = this.dbsource.DbPassword;
            url_source_mysql.DbPort = this.dbsource.DbPort;
            //url_source_mysql.Dbname = this.dbsource.Dbname;
            return true;
        }
        private bool db_info_set_target()
        {
            if (this.tb_right_ipaddr.Text.Trim() == "" || this.tb_right_username.Text.Trim() == "" || this.tb_right_password.Text.Trim() == "" ||  this.tb_right_port.Text.Trim() == "")
            {
                //MessageBox.Show("       目标数据库连接信息错误！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (!Publec_Class.IsNumberic(this.tb_right_port.Text.Trim())) { MessageBox.Show("端口只能为正整数！"); return false; }
            // 数据源信息
            this.dbtarget.DbHost = this.tb_right_ipaddr.Text.Trim();
            this.dbtarget.DbUser = this.tb_right_username.Text.Trim();
            this.dbtarget.DbPassword = this.tb_right_password.Text.Trim();
            this.dbtarget.DbPort = Convert.ToInt32(this.tb_right_port.Text.Trim());
            //this.dbtarget.Dbname = this.dbname_right.Text.Trim();
            //
            // 目标数据库信息
            url_target_mysql.DbHost = this.dbtarget.DbHost;
            url_target_mysql.DbUser = this.dbtarget.DbUser;
            url_target_mysql.DbPassword = this.dbtarget.DbPassword;
            url_target_mysql.DbPort = this.dbtarget.DbPort;
            //url_target_mysql.Dbname = this.dbtarget.Dbname;
            return true;
        }

        //数据源实例
        private bool source_connect()
        {
            //数据库配置信息初始化
            if (!db_info_set_source()) { return false; }

            //获取连接
            url_source_mysql.SetConnectStr("server="+this.dbsource.DbHost+";User ID="+ this.dbsource.DbUser+ ";Password="+ this.dbsource.DbPassword+ ";port="+ this.dbsource.DbPort+ ";");
            conn = url_source_mysql.getConnection();
            if(conn == null)
            {
                MessageBox.Show("       数据库连接错误：" + url_source_mysql.ErrValue, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;

        }
        //目标实例
        private bool taget_connect()
        {
            //数据库配置信息初始化
            if (!db_info_set_target()) { return false; }

            url_target_mysql.SetConnectStr("server=" + this.dbtarget.DbHost + ";User ID=" + this.dbtarget.DbUser + ";Password=" + this.dbtarget.DbPassword + ";port=" + this.dbtarget.DbPort + ";");
            //获取连接

            conn = url_target_mysql.getConnection();

            if (conn == null)
            {
                MessageBox.Show("       数据库连接错误：" + url_target_mysql.ErrValue, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        //同步数据资源可用性测试（参数 0:数据源，1:数据目标库）
        private bool type_b_data_source_is_ok(int t)
        {
            if(t == 0)
            {
                if (!source_connect())//测试连接失败
                {
                    return false;
                }
                return true;//测试连接成功
            }
            else { 
                if(t != 1){
                    MessageBox.Show("       程序内部错误，参数只能为0或1 。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (!taget_connect())//测试连接失败
                {
                    return false;
                }
                if (this.dbtarget.Dbname.Length == 0)
                {
                    return false;
                }
                return true;//测试连接成功
            }
        }

        private void dbname_left_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("       数据库选择了："+this.dbname_left.Text.Trim(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.dbsource.Dbname = this.dbname_left.Text.Trim();
            //
            // 源数据库信息
            url_source_mysql.Dbname = this.dbsource.Dbname;

        }

        private void dbname_left_Click(object sender, EventArgs e)
        {
            if (!source_connect()) { MessageBox.Show("       请选择源数据库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            dbname_left.Items.Clear();
            string sql = "SELECT schema_name FROM information_schema.schemata";
            dr = url_source_mysql.selectDatabase(sql, conn);
            if (!dr.HasRows)
            {
                dr.Close();
                Console.WriteLine("拉取数据库列表失败！");
                return;
            }

            while (dr.Read())
            {
                dbname_left.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void dbname_right_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dbtarget.Dbname = this.dbname_right.Text.Trim();
            //
            // 目标数据库信息
            url_target_mysql.Dbname = this.dbtarget.Dbname;
        }

        private void dbname_right_Click(object sender, EventArgs e)
        {
            if (!(taget_connect())) { MessageBox.Show("       请选择目标数据库！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            dbname_right.Items.Clear();
            string sql = "SELECT schema_name FROM information_schema.schemata";
            dr = url_target_mysql.selectDatabase(sql, conn);
            if (!dr.HasRows)
            {
                dr.Close();
                Console.WriteLine("拉取数据库列表失败！");
                return;
            }

            while (dr.Read())
            {
                dbname_right.Items.Add(dr.GetString(0));
            }
            dr.Close();
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void groupBox6_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

        }

        private void groupBox7_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void tabPage1_type_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

        }

        private void dblist_left_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("当前选择了。。" + this.dbconn_comb.Text);
            foreach (KeyValuePair<string, DB_Map> mydic in mydics.llDictionary)
            {
                if (mydic.Key == this.dblist_left.Text.Trim().ToString())
                {
                    //left
                    tb_left_ipaddr.Text = mydic.Value.ipaddr;
                    tb_left_username.Text = mydic.Value.username;
                    tb_left_password.Text = mydic.Value.password;
                    tb_left_port.Text = mydic.Value.port.ToString();
                    break;
                }
            }

        }
        private void dblist_right_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, DB_Map> mydic in mydics.llDictionary)
            {
                if (mydic.Key == this.dblist_right.Text.Trim().ToString())
                {
                    //right
                    tb_right_ipaddr.Text = mydic.Value.ipaddr;
                    tb_right_username.Text = mydic.Value.username;
                    tb_right_password.Text = mydic.Value.password;
                    tb_right_port.Text = mydic.Value.port.ToString();
                    break;
                }
            }

        }

        private void init_dblist()
        {
            Publec_Class pc = new Publec_Class();
            RegisterMsg registermsg = new RegisterMsg();
            registermsg.name = this.dblist_left.Text.Trim();
            byte[] registerData = new ClassSerializers().SerializeBinary(registermsg).ToArray();
            ClassMsg msg = new ClassMsg();
            msg.sendKind = SendKind.SendCommand;
            msg.msgCommand = MsgCommand.DBList;
            msg.SIP = pc.getMacAddr_Local(0);
            msg.SPort = this.udpSocket1.LocalPort.ToString();
            msg.Data = registerData;
            msg.Suser = Publec_Class.UserName;
            //打开socket，后台通信
            udpSocket1.Active = true;

            udpSocket1.Send(IPAddress.Parse(Publec_Class.ServerIP), Convert.ToInt32(Publec_Class.ServerPort), new ClassSerializers().SerializeBinary(msg).ToArray());

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
                    case MsgCommand.DBList:
                        //DialogResult = DialogResult.OK;
                        mydics = (MyDictioinary<string, DB_Map>)new ClassSerializers().DeSerializeBinary(new MemoryStream(msg.Data));
                        //渲染数据库资源下拉按钮之前，保存列表字典到全局区
                        //全局变量重构//
                        //PublicValue.mydics = mydics;
                        SuperMessage.mydics = mydics;
                        //数据库列表展开
                        dblist_left.Items.Clear();
                        dblist_right.Items.Clear();
                        foreach (KeyValuePair<string, DB_Map> mydic in mydics.llDictionary)
                        {
                            if(Publec_Class.UserName == mydic.Value.rguser) { continue; }
                            //left
                            if (dblist_left.Text.Trim().Length > 0)
                            {
                                dblist_left.Items.Add(mydic.Key);
                            }
                            else
                            {
                                dblist_left.Items.Add(mydic.Key);
                                dblist_left.Text = mydic.Key;
                                tb_left_ipaddr.Text = mydic.Value.ipaddr;
                                tb_left_username.Text = mydic.Value.username;
                                tb_left_password.Text = mydic.Value.password;
                                tb_left_port.Text = mydic.Value.port.ToString();
                            }
                            //right
                            if (dblist_right.Text.Trim().Length > 0)
                            {
                                dblist_right.Items.Add(mydic.Key);
                            }
                            else
                            {
                                dblist_right.Items.Add(mydic.Key);
                                dblist_right.Text = mydic.Key;
                                tb_right_ipaddr.Text = mydic.Value.ipaddr;
                                tb_right_username.Text = mydic.Value.username;
                                tb_right_password.Text = mydic.Value.password;
                                tb_right_port.Text = mydic.Value.port.ToString();
                            }
                            //Console.WriteLine("数据库列表测试："+ mydic.Key.ToString() + "\t:" + mydic.Value.ToString());
                        }
                        //PublicValue.dbname = dblist_left.Items[0].ToString();
                        
                        break;
                    case MsgCommand.DBCount://数据库资源为0
                        //没有数据库资源,不做显示
                        //Console.WriteLine("没有数据库资源列表哦。。");
                        //初始化界面为0应该的样子
                        this.tb_left_ipaddr.Text = "localhost";
                        this.tb_left_username.Text = "root";
                        this.tb_left_password.Text = "";
                        this.tb_left_port.Text = "3306";
                        //
                        this.tb_right_ipaddr.Text = "localhost";
                        this.tb_right_username.Text = "root";
                        this.tb_right_password.Text = "";
                        this.tb_right_port.Text = "3306";

                        break;

                }
            }
            catch { }
        }

        private void checkBox4_imi_CheckedChanged(object sender, EventArgs e)
        {
            if(this.checkBox4_imi.Checked == false)
            {
                button2_next.Enabled = false;
            }
            else
            {
                button2_next.Enabled = true;
            }

        }

        private void start_task()
        {
            //判断任务列表是否重复
            foreach (KeyValuePair<string, DB_Task> mytask in SuperMessage.mytasks.llDictionary)
            {
                if(mytask.Value.TaskName == this.tb_taskname.Text.Trim())
                {
                    MessageBox.Show("       "+this.tb_taskname.Text.Trim() +" 任务名称重复，请重新输入！" , "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Publec_Class pc = new Publec_Class();
            ClassMsg msg = new ClassMsg();
            msg.sendKind = SendKind.SendCommand;
            msg.msgCommand = MsgCommand.DBPStart;
            msg.SIP = pc.getMacAddr_Local(0);
            msg.SPort = this.udpSocket1.LocalPort.ToString();
            //        public DB_Task(string TaskName, string SIp, int SPort, string SUser, string TIp, int TPort,string TUser, int TaskProcess)
            DB_Task task = new DB_Task(
                this.tb_taskname.Text.Trim(),
                this.tb_left_ipaddr.Text.Trim(), 
                Convert.ToInt32(this.tb_left_port.Text.Trim()),
                this.tb_left_username.Text.Trim(),
                this.tb_right_ipaddr.Text.Trim(),
                Convert.ToInt32(this.tb_right_port.Text.Trim()),
                this.tb_right_username.Text.Trim(),
                Convert.ToInt32((int)MsgCommand.DBPStart));
            byte[] taskData = new ClassSerializers().SerializeBinary(task).ToArray();
            msg.Data = taskData;
            //打开socket，后台通信
            if (!udpSocket1.Active) { udpSocket1.Active = true; }
            udpSocket1.Send(IPAddress.Parse(Publec_Class.ServerIP), Convert.ToInt32(Publec_Class.ServerPort), new ClassSerializers().SerializeBinary(msg).ToArray());
            //SuperMessage.mytasks.Add(this.tb_taskname.Text.Trim(), task);
            string list_tables = tableFunction();
            if (list_tables == "")
            {
                MessageBox.Show("       数据源没有表需要同步！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Hide();
            if (sync_type == "all")
            {

                WinExec(System.Environment.CurrentDirectory + "\\" + "slave.exe" +
                    " --my_addr " + task.SIp + ":" + task.SPort +
                    " --my_user " + task.SUser +
                    " --my_password " + this.tb_left_password.Text.Trim() +
                    " --my_database " + this.dbname_left.Text.Trim() +
                    " --my_taddr " + task.TIp + ":" + task.TPort+
                    " --my_tuser " + task.TUser +
                    " --my_tpassword " + this.tb_right_password.Text.Trim() +
                    " --my_tdatabase " + this.dbname_right.Text.Trim() + " "+
                    list_tables
                    , 0);
                /*
                string ProcessName = "explorer";//这里换成你需要删除的进程名称
                Process[] MyProcess1 = Process.
GetProcessesByName(ProcessName);
                Process MyProcess = new Process();
                //设定程序名
                MyProcess.StartInfo.FileName = "cmd.exe";
                //关闭Shell的使用
                MyProcess.StartInfo.UseShellExecute = false;
                //重定向标准输入
                MyProcess.StartInfo.RedirectStandardInput = true;
                //重定向标准输出
                MyProcess.StartInfo.RedirectStandardOutput = true;
                //重定向错误输出
                MyProcess.StartInfo.RedirectStandardError = true;
                //设置不显示窗口
                MyProcess.StartInfo.CreateNoWindow = true;
                //执行强制结束命令
                MyProcess.Start();
                MyProcess.StandardInput.WriteLine("ntsd -c q -p "
                + (MyProcess1[0].Id).ToString());//直接结束进程ID
                MyProcess.StandardInput.WriteLine("Exit");
                第二种，通过强大的进程类进行标准关闭。
string ProcessName = "explorer";//换成想要结束的进程名字
                Process[] MyProcess = Process.
GetProcessesByName(ProcessName);
                MyProcess[0].Kill();
                */


            }
            if (sync_type == "once")
            {

            }
            if(sync_type == "sql")
            {
                if (!Sql_tableFunction())
                {
                    MessageBox.Show("       同步失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            DialogResult = DialogResult.OK;
        }
        private string tableFunction()
        {
            string sql = "SELECT table_name FROM information_schema.tables WHERE table_schema='" + this.dbname_left.Text.Trim() + "'";
            dr = url_source_mysql.selectDatabase(sql, conn);
            if (!dr.HasRows)
            {
                dr.Close();
                Console.WriteLine("数据源拉取列表失败！");
                return "";
            }
            string tables_list = "";
            while (dr.Read())
            {
                tables_list += "--table " + dr.GetString(0) + " ";
            }
            dr.Close();

            return tables_list;
        }

        private bool Sql_tableFunction()
        {
            string sql = this.richTextBox1.Text.Trim();
            //开始字符串 
            string s1 = "select";
            //结束字符串 
            string s2 = "from";
            Regex rg = new Regex("(?<=(" + s1 + "))[.\\s\\S]*?(?=(" + s2 + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            string str = rg.Match(sql.ToLower()).Value;
            int colnum=str.Split(',').Length;
            string[] colnames = str.Split(',');
            string isql = "use " + this.dbname_right.Text.Trim() + ";" + "insert ignore into " + this.target_comboBox1.Text.Trim() + "(";
            int f_count = 0;

            for (int i = 0; i < colnum; i++)
            {
                isql += colnames[i] + ",";
            }
            isql = isql.Substring(0, isql.Length - 1) + ") values";
            dr = url_source_mysql.selectDatabase("use "+this.dbname_left.Text.Trim() + ";" + sql, conn);
            //dr.Close();
            if(dr == null && url_source_mysql.ErrValue != null)
            {
                MessageBox.Show("       同步失败！数据库访问异常："+ url_source_mysql.ErrValue, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!dr.HasRows)
            {
                dr.Close();
                Console.WriteLine("数据源拉取列表失败！");
                return false;
            }
            this.Hide();
            bool comp = false;
            string tmp = "";
            while (dr.Read())
            {
                for (int j = 0; j < colnum; j++)
                {
                    //拼一条完整的记录（，，）,
                    if (j == 0)
                    {
                        tmp += "('" + dr.GetString(j) + "',";
                    }
                    else if (j == colnum - 1)
                    {
                        tmp += "'" + dr.GetString(j) + "'),";
                    }
                    else
                    {
                        tmp += "'" + dr.GetString(j) + "',";
                    }
                }
                f_count += 1;
                //每1000次做一次入库
                if (f_count == 1000)
                {
                    tmp = tmp.Substring(0, tmp.Length - 1);
                    conn.Close();
                    conn = url_target_mysql.getConnection();
                    var err = url_target_mysql.insertDatabase(isql+ tmp, conn);
                    if (err == 0)
                    {
                        MessageBox.Show("       同步失败！数据库访问异常：" + url_target_mysql.ErrInsertValue, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    //Console.WriteLine("isql+ tmp=====" + isql + tmp);

                    f_count = 0;
                    comp = false;
                    tmp = "";
                }
                else
                {
                    //不满1000条但是数据存在时
                    comp = true;
                    //Console.WriteLine("f_count="+ f_count);

                }
                //循环处理初始化变量
            }
            if (comp) {
                tmp = tmp.Substring(0, tmp.Length - 1);
                conn.Close();
                conn= url_target_mysql.getConnection();
                //isql= "use test;insert ignore into login) values username,password,macaddr,ipaddr,port,state ,"
                var err = url_target_mysql.insertDatabase(isql + tmp, conn);
                if (err == 0)
                {
                    MessageBox.Show("       同步失败！数据库访问异常：" + url_target_mysql.ErrInsertValue, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                //Console.WriteLine("不足1000条，isql+ tmp=====" + isql + tmp);

            }
            Console.WriteLine("目标写入成功！");
            dr.Close();
            DialogResult = DialogResult.OK;
            return true;
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //只处理鼠标点击引起的状态变化
            if (e.Action == TreeViewAction.ByMouse)
            {
                //默认全选
                //e.Node.Checked = true;
                //更新子节点状态
                UpdateChildNodes(e.Node);
                //更新父节点状态
                UpdateParents(e.Node);
            }

        }
        private void UpdateChildNodes(TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
            {
                //child.Checked = node.Checked;
                child.Checked = node.Checked;
                child.ForeColor = Color.Black;
                UpdateChildNodes(child);

            }
        }
        private void UpdateParents(TreeNode node)
        {
            var parent = node.Parent;
            while (parent != null)
            {
                //设置父节点状态
                SetNodeState(parent);
                parent = parent.Parent;
            }
        }

        private void SetNodeState(TreeNode parent)
        {
            if (parent.Nodes.IsAllChecked())
            {
                //子节点全选中
                parent.Checked = true;
                parent.ForeColor = Color.Black;
            }
            else if (parent.Nodes.IsAllUnChecked())
            {
                //子节点全未选中
                parent.Checked = false;
                parent.ForeColor = Color.Black;
                //还要判断子节点中是否有半选中状态
                foreach (TreeNode child in parent.Nodes)
                {
                    if (child.ForeColor == Color.Blue)
                    {
                        //用蓝色标记半选中状态
                        parent.ForeColor = Color.Blue;
                        break;
                    }
                }
            }
            else
            {
                //子节点有的选中有的未选中
                parent.Checked = false;
                parent.ForeColor = Color.Blue;
            }
        }
        private void CreateTree()
        {
            if (mydics.llDictionary.Count <= 0)
            {
                MessageBox.Show("       数据库资源列表为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.treeView1.Nodes.Clear();
            foreach (KeyValuePair<string, DB_Map> mydic in mydics.llDictionary)
            {
                if (this.dblist_left.Text.Trim() == mydic.Value.name)
                {
                    TreeNode dataname = new TreeNode(mydic.Value.name);
                    string sql = "SELECT schema_name FROM information_schema.schemata WHERE schema_name NOT IN ('information_schema','mysql','performance_schema','sys')";
                    dr = url_source_mysql.selectDatabase(sql, conn);
                    if (!dr.HasRows)
                    {
                        dr.Close();
                        Console.WriteLine("拉取数据库列表失败！");
                        return;
                    }
                    this.treeView1.Nodes.Add(dataname);
                    while (dr.Read())
                    {
                        dataname.Nodes.Add(dr.GetString(0));
                        /* var china = anime.Nodes.Add("国创");
                         pointer = china.Nodes.Add("一人之下");

                         var nihonn = anime.Nodes.Add("日本");
                         pointer = nihonn.Nodes.Add("OVERLORD");
                         this.LaoYeZha_TreeView.Nodes.Add(anime);*/

                        //dbname_left.Items.Add(dr.GetString(0));
                    }
                    dr.Close();
                    break;
                }
            }
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            var treeview = sender as TreeView;
            var brush = Brushes.Black;
            if (e.Node.ForeColor == Color.Blue)
            {
                var location = e.Node.Bounds.Location;
                location.Offset(-11, 2);
                var size = new Size(9, 9);
                brush = Brushes.Blue;
                e.Graphics.FillRectangle(brush, new Rectangle(location, size));
            }
            //绘制文本
            e.Graphics.DrawString(e.Node.Text, treeview.Font, brush, e.Bounds.Left, e.Bounds.Top);
        }

        private void target_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void target_comboBox1_Click(object sender, EventArgs e)
        {
            this.target_comboBox1.Items.Clear();
            string sql = "SELECT table_name FROM information_schema.tables WHERE table_schema='" + this.dbname_right.Text.Trim() + "'"; 
            dr = url_target_mysql.selectDatabase(sql, conn);
            if (!dr.HasRows)
            {
                dr.Close();
                Console.WriteLine("拉取数据库列表失败！");
                return;
            }

            while (dr.Read())
            {
                this.target_comboBox1.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }
    }
    //全局变量
    public class PublicValue
    {
        public static string dbname;
        public static string old_dbname;
        //public static MyDictioinary<string, DB_Map> mydics;
        //public static int[] aa;
    }
    static class TreeNodeCollectionExtern
    {
        public static bool IsAllChecked(this TreeNodeCollection treeNodeCollection)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                if (node.Checked == false)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsAllUnChecked(this TreeNodeCollection treeNodeCollection)
        {
            foreach (TreeNode node in treeNodeCollection)
            {
                if (node.Checked == true)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
