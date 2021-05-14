using ClassDDTS;
using MyDTS.sync;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MyDTS.dbconn
{

    public partial class dbconn : Form
    {
        Publec_Class PubClass = new Publec_Class();
        MySqlConnection conn = null;
        ClassOptionDataMysql url_dbconn_mysql = new ClassOptionDataMysql();
        MyDictioinary<string, DB_Map> mydics;

        public dbconn()
        {
            InitializeComponent();
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }
        /// <summary>
        /// 新建
        /// </summary>
        private void dbconn_new_Click(object sender, EventArgs e)
        {
            create_conn ccn = new create_conn();
            if (ccn.ShowDialog(this) == DialogResult.OK)   //当登窗体的对话框的返回值为OK时
            {
                this.dbconn_comb.Text = PublicValue.dbname;
                this.dbconn_ipaddr.Text = "localhost";
                this.dbconn_username.Text = "root";
                this.dbconn_port.Text = "3306";
                init3_views();
            }

        }
        private void init_views() {
            //初始化界面功能
            this.dbconn_clone.Enabled = false;
            this.dbconn_save.Enabled = false;
            this.dbconn_delete.Enabled = false;
            this.dbconn_rename.Enabled = false;
            this.dbconn_delete.Enabled = false;
            this.dbconn_cnn.Enabled = false;
            this.dbconn_testcnn.Enabled = false;
            dbconn_new.Focus();

        }
        private void init2_views()
        {
            //初始化界面功能
            this.dbconn_clone.Enabled = true;
            this.dbconn_save.Enabled = false;
            this.dbconn_delete.Enabled = true;
            this.dbconn_rename.Enabled = true;
            this.dbconn_delete.Enabled = true;
            this.dbconn_cnn.Enabled = false;
            this.dbconn_testcnn.Enabled = true;
            dbconn_cnn.Focus();

        }
        private void init3_views()
        {
            //初始化界面功能
            this.dbconn_clone.Enabled = false;
            this.dbconn_save.Enabled = true;
            this.dbconn_delete.Enabled = false;
            this.dbconn_rename.Enabled = false;
            this.dbconn_delete.Enabled = false;
            this.dbconn_cnn.Enabled = false;
            this.dbconn_testcnn.Enabled = true;
            dbconn_cnn.Focus();
        }
        private void init4_views()
        {
            //初始化界面功能
            this.dbconn_clone.Enabled = true;
            this.dbconn_save.Enabled = false;
            this.dbconn_delete.Enabled = true;
            this.dbconn_rename.Enabled = true;
            this.dbconn_delete.Enabled = true;
            this.dbconn_cnn.Enabled = false;
            this.dbconn_testcnn.Enabled = true;
            dbconn_cnn.Focus();
        }
        private void init_dblist()
        {
            Publec_Class pc = new Publec_Class();
            RegisterMsg registermsg = new RegisterMsg();
            registermsg.name = this.dbconn_comb.Text.Trim();
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
        private void dbconn_Load(object sender, EventArgs e)
        {
            //初始化后台参数
            init_dblist();
        }

        private void dbconn_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (udpSocket1.Active)
                udpSocket1.Active = false;
        }

        private void dbconn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            if (udpSocket1.Active)
                udpSocket1.Active = false;
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
                //RegisterMsg registermsg = (RegisterMsg)new ClassSerializers().DeSerializeBinary(new MemoryStream(msg.Data));

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
                        init2_views();
                        dbconn_comb.Items.Clear();
                        foreach (KeyValuePair<string, DB_Map> mydic in mydics.llDictionary) {
                            if (mydic.Value.property == 0 && Publec_Class.UserName != mydic.Value.rguser) { continue; }
                            if (mydic.Value.property == 1 && mydic.Value.ack == "否") { continue; }
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
                                dbconn_port.Text = mydic.Value.port.ToString() ;
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
            catch { }
        }

        private void dbconn_comb_Click(object sender, EventArgs e)
        {
            //点击不应该进行一次数据库操作，会导致后台推送回来后，刷新屏幕。
            //init_dblist();
        }

        /// <summary>
        /// 保存
        /// </summary>
        private void dbconn_save_Click(object sender, EventArgs e)
        {
            Int32 pro_tmp = 1;
            DB_Map db_pro_tmp = null;
            //全局变量重构//
            //if (PublicValue.mydics.llDictionary.Count > 0)
            if (SuperMessage.mydics.llDictionary.Count > 0)
            {
                if (PublicValue.old_dbname  != null)
                {
                    db_pro_tmp = getKeyExistsDics(PublicValue.old_dbname);
                    PublicValue.old_dbname = "";
                }
                else
                {
                    db_pro_tmp = getKeyExistsDics(dbconn_comb.Text.Trim());
                }
                if (db_pro_tmp == null)
                {
                    pro_tmp = 0;
                }
                else
                {
                    pro_tmp = 0;
                    //bug  ing
                    //MessageBox.Show("       名字冲突，请重新填写一个连接名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
            }
            DB_Map dbconn_save = new DB_Map(dbconn_comb.Text.Trim(), dbconn_username.Text.Trim(),dbconn_password.Text.Trim(),
                dbconn_ipaddr.Text.Trim(),Convert.ToInt32(dbconn_port.Text.Trim()), pro_tmp,"否",Publec_Class.UserName);
            byte[] dbconn_saveData = new ClassSerializers().SerializeBinary(dbconn_save).ToArray();
            ClassMsg msg = new ClassMsg();
            msg.sendKind = SendKind.SendCommand;
            msg.msgCommand = MsgCommand.DBSave;
            msg.SPort = this.udpSocket1.LocalPort.ToString();
            msg.SIP = PubClass.getMacAddr_Local(0);
            msg.Data = dbconn_saveData;

            udpSocket1.Send(IPAddress.Parse(PubClass.GetServerIp().Trim()), Convert.ToInt32(PubClass.GetServerPort().Trim()), new ClassSerializers().SerializeBinary(msg).ToArray());

        }
        /// <summary>
        /// 保/存的连接
        /// </summary>
        private void dbconn_comb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine("当前选择了。。" + this.dbconn_comb.Text);
            foreach (KeyValuePair<string, DB_Map> mydic in mydics.llDictionary)
            {
                if(mydic.Key == this.dbconn_comb.Text.Trim().ToString())
                {
                    this.dbconn_ipaddr.Text = mydic.Value.ipaddr;
                    this.dbconn_username.Text = mydic.Value.username;
                    this.dbconn_password.Text = mydic.Value.password;
                    this.dbconn_port.Text = mydic.Value.port.ToString();
                    PublicValue.dbname = this.dbconn_comb.Text;
                    break;
                }
            }
            //Console.WriteLine("当前选择了。PublicValue.dbname==" + PublicValue.dbname);

        }
        /// <summary>
        /// 克隆
        /// </summary>
        private void dbconn_clone_Click(object sender, EventArgs e)
        {
            string tmp = this.dbconn_comb.Text.Trim();
            PublicValue.old_dbname = tmp;
            create_conn ccn = new create_conn();
            if (ccn.ShowDialog(this) == DialogResult.OK)   //当登窗体的对话框的返回值为OK时
            {

                this.dbconn_comb.Text = PublicValue.dbname;
                this.dbconn_ipaddr.Text = getKeyExistsDics(tmp).ipaddr;
                this.dbconn_username.Text = getKeyExistsDics(tmp).username;
                this.dbconn_port.Text = getKeyExistsDics(tmp).port.ToString();
                init3_views();
            }

        }

        private void dbconn_ipaddr_TextChanged(object sender, EventArgs e)
        {
            this.dbconn_save.Enabled = true;
        }

        private void dbconn_username_TextChanged(object sender, EventArgs e)
        {
            this.dbconn_save.Enabled = true;

        }

        private void dbconn_password_TextChanged(object sender, EventArgs e)
        {
            this.dbconn_save.Enabled = true;

        }

        private void dbconn_port_TextChanged(object sender, EventArgs e)
        {
            this.dbconn_save.Enabled = true;

        }
        /// <summary>
        /// 重命名
        /// </summary>
        private void dbconn_rename_Click(object sender, EventArgs e)
        {
            DB_Map tmp = new DB_Map(this.dbconn_comb.Text.Trim(), this.dbconn_username.Text.Trim(),
                this.dbconn_password.Text.Trim(), this.dbconn_ipaddr.Text.Trim(), Convert.ToInt32(this.dbconn_port.Text.Trim()),0, "否",Publec_Class.UserName);

            create_conn ccn = new create_conn();
            if (ccn.ShowDialog(this) == DialogResult.OK)   //当登窗体的对话框的返回值为OK时
            {
                this.dbconn_comb.Text = PublicValue.dbname;
                this.dbconn_ipaddr.Text = tmp.ipaddr;
                this.dbconn_username.Text = tmp.username;
                this.dbconn_password.Text = tmp.password;
                this.dbconn_port.Text = tmp.port.ToString();
                dbconn_replace_dbname(tmp, PublicValue.dbname);
                init4_views();
            }

        }
        private void dbconn_replace_dbname(DB_Map tmp,string dbname)
        {
            Publec_Class pc = new Publec_Class();
            DB_Map renamemsg = new DB_Map(dbname, tmp.username,tmp.password,tmp.ipaddr,tmp.port,tmp.property, "否",Publec_Class.UserName);
            byte[] renamemsgData = new ClassSerializers().SerializeBinary(renamemsg).ToArray();
            ClassMsg msg = new ClassMsg();
            msg.sendKind = SendKind.SendCommand;
            msg.msgCommand = MsgCommand.DBRename;
            msg.oldname = tmp.name;
            msg.SIP = pc.getMacAddr_Local(0);
            msg.SPort = this.udpSocket1.LocalPort.ToString();
            msg.Data = renamemsgData;

            //打开socket，后台通信
            if (!udpSocket1.Active)
                udpSocket1.Active = true;

            udpSocket1.Send(IPAddress.Parse(Publec_Class.ServerIP), Convert.ToInt32(Publec_Class.ServerPort), new ClassSerializers().SerializeBinary(msg).ToArray());

        }
        private DB_Map getKeyExistsDics(string name)
        {
            //全局变量重构//

            //foreach (KeyValuePair<string, DB_Map> mydic in PublicValue.mydics.llDictionary)
            foreach (KeyValuePair<string, DB_Map> mydic in SuperMessage.mydics.llDictionary)
            {
                if (mydic.Key == name)
                {
                    return mydic.Value;
                }
            }
            return null;
        }
        /// <summary>
        /// 删除
        /// </summary>
        private void dbconn_delete_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("   您确定要删除连接细节吗?", "安全提示",
            System.Windows.Forms.MessageBoxButtons.YesNo,
            System.Windows.Forms.MessageBoxIcon.Question)
    == System.Windows.Forms.DialogResult.Yes)
            {
                if(getKeyExistsDics(dbconn_comb.Text.Trim()) == null) {
                    MessageBox.Show("       请选择一个希望被删除的数据源！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DB_Map dbconn_delete = new DB_Map(this.dbconn_comb.Text.Trim(), this.dbconn_username.Text.Trim(),
    this.dbconn_password.Text.Trim(), this.dbconn_ipaddr.Text.Trim(), Convert.ToInt32(this.dbconn_port.Text.Trim()), getKeyExistsDics(dbconn_comb.Text.Trim()).property, "否",Publec_Class.UserName);
                byte[] dbconn_deleteData = new ClassSerializers().SerializeBinary(dbconn_delete).ToArray();
                ClassMsg msg = new ClassMsg();
                msg.sendKind = SendKind.SendCommand;
                msg.msgCommand = MsgCommand.DBDelete;
                msg.SPort = this.udpSocket1.LocalPort.ToString();
                msg.SIP = PubClass.getMacAddr_Local(0);
                msg.Data = dbconn_deleteData;

                udpSocket1.Send(IPAddress.Parse(PubClass.GetServerIp().Trim()), Convert.ToInt32(PubClass.GetServerPort().Trim()), new ClassSerializers().SerializeBinary(msg).ToArray());

            }
        }
        /// <summary>
        /// 测试连接
        /// </summary>
        private void dbconn_testcnn_Click(object sender, EventArgs e)
        {
            //获取连接
            url_dbconn_mysql.SetConnectStr("server=" + this.dbconn_ipaddr.Text.Trim() + ";User ID=" + this.dbconn_username.Text.Trim() + ";Password=" + this.dbconn_password.Text.Trim() + ";port=" + this.dbconn_port.Text.Trim() + ";");
            conn = url_dbconn_mysql.getConnection();
            if (conn == null)
            {
                MessageBox.Show("       数据库连接错误：" + url_dbconn_mysql.ErrValue, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //MessageBox.Show("       Connection successfull! " + url_dbconn_mysql.ErrValue, "连接信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("       Connection successfull! ", "连接信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /// <summary>
        /// 连接
        /// </summary>
        private void dbconn_cnn_Click(object sender, EventArgs e)
        {

        }
    }
}
