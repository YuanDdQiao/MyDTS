using ClassDDTS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace MyDTS.sync
{
    public partial class SqlReport : Form
    {
        MySqlConnection conn = null;
        ClassOptionDataMysql mysql_report = new ClassOptionDataMysql();
        MySqlDataReader dr = null;
        string t_Tag;
        string t_Sql;
        string t_DBname;
        DateTime ts;
        public SqlReport()
        {
            InitializeComponent();
        }

        private void SqlReport_Load(object sender, EventArgs e)
        {
            //cbb_sqlreport
            this.cbb_sqlreport.Items.Clear();
            if(SuperMessage.mydics == null)
            {
                MessageBox.Show("       sql-发布找不到数据库资源！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            foreach (KeyValuePair<string, DB_Map> mydic in SuperMessage.mydics.llDictionary)
            {
                if (mydic.Value.rguser == Publec_Class.UserName) { continue; }
                string sql = "SELECT schema_name FROM information_schema.schemata WHERE schema_name NOT IN ('information_schema','mysql','performance_schema','sys')";
                string dburl = "server = " + mydic.Value.ipaddr + "; User ID = " + mydic.Value.username + "; Password = " + mydic.Value.password + ";port = "+ mydic.Value.port+ ";";
                mysql_report.SetConnectStr(dburl);
                conn = mysql_report.getConnection();
                if (conn == null)
                {
                    //MessageBox.Show("       数据库连接错误：" + mysql_report.ErrValue, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue ;
                }

                dr = mysql_report.selectDatabase(sql, conn);
                if (!dr.HasRows)
                {
                    dr.Close();
                    Console.WriteLine("拉取数据库列表失败！");
                    continue;
                }
                while (dr.Read())
                {
                    this.cbb_sqlreport.Items.Add(mydic.Key + ":" + dr.GetString(0));
                }
                dr.Close();
            }
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);

        }

        private void sql_report_bt_Click(object sender, EventArgs e)
        {
            /*
            DateTime now = DateTime.Now;
            int msUntilFour = (int)((ts - now).TotalMilliseconds);

            var t = new System.Threading.Timer(doAt1AM);
            t.Change(msUntilFour, Timeout.Infinite);
            Console.WriteLine("创建时间为：" + now);

             */
            //判断数据库资源名称是否存在；
            //判断输入的SQL语句是否合法；
            if (!isExistsInDBLists(this.cbb_sqlreport.Text.Split(':')[0].ToString()))
            {MessageBox.Show("       选择数据库实例：" + this.cbb_sqlreport.Text.Trim() + " -不合法！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            //double ts = Publec_Class.ConvertToUnixOfTime(this.dateTimePicker1_sql.Value);
            Console.WriteLine("-- - 约定发布的时间为:" + ts.ToString());
            if (this.cb_timer.Checked)
            {
                //时间获取测试
                //MessageBox.Show("       开始执行时间为：" + d1 + " ！" +"时间戳为："+ ts + "通过时间戳又转成时间格式：" + Publec_Class.StampToDateTime(ts.ToString()),"提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                DateTime now = DateTime.Now;
                int msUntilFour = (int)((ts - now).TotalMilliseconds);
                if(msUntilFour < 0)
                {
                    MessageBox.Show("       请设置“启用开始执行的时间”的时间值", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                }
                else
                {
                    var thd = new System.Threading.Timer(sqlReport_Elapsed);
                    //thd.Change(msUntilFour, Timeout.Infinite);
                    thd.Change(msUntilFour, 0);
                    //thd.Change(msUntilFour, 0);
                    this.Hide();

                }
            }
            else
            {
                //立即执行
                var thd = new System.Threading.Timer(sqlReport_Elapsed);
                thd.Change(0,0);
                this.Hide();
            }
        }
        private void sqlReport_Elapsed(object sende)
        {
            string dburl = "";
            //初始化数据库连接
            foreach (KeyValuePair<string, DB_Map> mydic in SuperMessage.mydics.llDictionary)
            {
                if (mydic.Key == t_Tag.ToString())
                {
                    dburl = "server = " + mydic.Value.ipaddr + "; User ID = " + mydic.Value.username + "; Password = " + mydic.Value.password + ";port = 3306;";
                    break;
                }
            }
            try
            {
                //"server=localhost;User ID=root;Password=ydq713611;database=ddts;port=3306;";
                mysql_report.SetConnectStr(dburl);
                //获取连接
                conn = mysql_report.getConnection();
                if (conn == null)
                {
                    MessageBox.Show("       数据库连接错误：" + mysql_report.ErrValue, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //查询用户数据
                string sql = t_Sql.ToString();
                //保存数据库资源
                //Console.WriteLine("准备发布----"+ DateTime.Now.ToString());
                DateTime aa = DateTime.Now;
                int x = mysql_report.updateDatabase("use " + t_DBname + ";" + sql, conn);
                if (x > 0)
                {
                    Console.WriteLine("SQL发布成功！发布时间为："+ aa.ToString());
                }
                //MessageBox.Show("       SQL发布成功!" , "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                DialogResult = DialogResult.OK;
            }
            catch (Exception exx)
            {
                MessageBox.Show("       发布异常：" + exx.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port);

        private void udpSocket1_DataArrival(byte[] Data, IPAddress Ip, int Port)
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival);
            this.BeginInvoke(outdelegate, new object[] { Data, Ip, Port });
        }
        private void DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port) //当有数据到达后的处理进程
        {
            /*try
            {
                //RegisterMsg registermsg = (RegisterMsg)new ClassSerializers().DeSerializeBinary(new MemoryStream(msg.Data));

                ClassMsg msg = new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as ClassMsg;
                switch (msg.msgCommand)
                {
                    case MsgCommand.DBList:
                        //DialogResult = DialogResult.OK;
                        mydics = (MyDictioinary<string, DB_Map>)new ClassSerializers().DeSerializeBinary(new MemoryStream(msg.Data));
                        //渲染数据库资源下拉按钮之前，保存列表字典到全局区PublicValue.mydics
                        PublicValue.mydics = mydics;
                        //数据库列表展开
                        init2_views();
                        dbconn_comb.Items.Clear();
                        foreach (KeyValuePair<string, DB_Map> mydic in mydics.llDictionary)
                        {
                            if (dbconn_comb.Text.Trim().Length > 0)
                            {
                                dbconn_comb.Items.Add(mydic.Key);
                            }
                            else
                            {
                                dbconn_comb.Items.Add(mydic.Key);
                                dbconn_comb.Text = mydic.Key;
                                dbconn_ipaddr.Text = mydic.Value.ipaddr;
                                dbconn_username.Text = mydic.Value.username;
                                dbconn_password.Text = mydic.Value.password;
                                dbconn_port.Text = mydic.Value.port.ToString();
                            }
                            //Console.WriteLine("数据库列表测试："+ mydic.Key.ToString() + "\t:" + mydic.Value.ToString());
                        }
                        PublicValue.dbname = dbconn_comb.Items[0].ToString();
                        init4_views();
                        break;
                    case MsgCommand.DBCount://数据库资源为0
                        //没有数据库资源
                        //Console.WriteLine("没有数据库资源列表哦。。");
                        //初始化界面为0应该的样子
                        init_views();
                        break;

                }
            }
            catch { }*/
        }

        private void cb_timer_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cb_timer.Checked)
            {
                this.dateTimePicker1_sql.Enabled = true;
            }
            else { this.dateTimePicker1_sql.Enabled = false; }
        }

        private void cbb_sqlreport_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("       SQL发布成功!this.cbb_sqlreport.Text.Trim()="+this.cbb_sqlreport.Text.Trim(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            if (this.cbb_sqlreport.Text.Trim() != "")
            {
                if (this.rtb_sql_report.Text.Trim() != "") { this.sql_report_bt.Enabled = true; } else { this.sql_report_bt.Enabled = false; }
                t_Tag = this.cbb_sqlreport.Text.Split(':')[0].ToString();
                t_Sql = this.rtb_sql_report.Text.Trim();
                t_DBname = this.cbb_sqlreport.Text.Split(':')[1].ToString();

            }
            else
            {
                this.sql_report_bt.Enabled=false;
            }

        }

        private void rtb_sql_report_TextChanged(object sender, EventArgs e)
        {
            if (this.rtb_sql_report.Text.Trim() != "") {
                if (this.cbb_sqlreport.Text.Trim() != "") { this.sql_report_bt.Enabled = true; } else { this.sql_report_bt.Enabled = false; }
            } else { this.sql_report_bt.Enabled = false; }
            if (this.rtb_sql_report.Text.Trim().Contains("drop database")|| this.rtb_sql_report.Text.Trim().Contains("drop table")) {
                MessageBox.Show("       危险操作请联系管理员确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool isExistsInDBLists(string dbname)
        {
            foreach (KeyValuePair<string, DB_Map> mydic in SuperMessage.mydics.llDictionary)
            {
                if (mydic.Key == dbname) { return true; }
            }
            return false;
        }

        private void dateTimePicker1_sql_ValueChanged(object sender, EventArgs e)
        {
            ts = this.dateTimePicker1_sql.Value;
        }
    }
}
