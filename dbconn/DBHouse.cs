using ClassDDTS;
using MyDTS.sync;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDTS.dbconn
{
    public partial class DBHouse : Form
    {
        MyDictioinary<string, DB_Map> mydics;
        public DBHouse()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void DBH_init_dblist()
        {
            Publec_Class pc = new Publec_Class();
            ClassMsg msg = new ClassMsg();
            msg.sendKind = SendKind.SendCommand;
            msg.msgCommand = MsgCommand.DBList;
            msg.SIP = pc.getMacAddr_Local(0);
            msg.SPort = this.udpSocket1.LocalPort.ToString();
            msg.Suser = Publec_Class.UserName;
            //打开socket，后台通信
            udpSocket1.Active = true;

            udpSocket1.Send(IPAddress.Parse(Publec_Class.ServerIP), Convert.ToInt32(Publec_Class.ServerPort), new ClassSerializers().SerializeBinary(msg).ToArray());

        }

        private void DBHouse_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("dataGridView1.rows =" + this.dataGridView1.Rows.Count);
            //Console.WriteLine("dataGridView1.cells =" + this.dataGridView1.Rows[this.dataGridView1.Rows.Count -1].Cells.Count);
            if(SuperMessage.dbtype == 1)
            {
                this.getprivileges.Enabled = true;
                //是否允許使用者編輯
                dataGridView1_house.ReadOnly = true;
                //是否允許使用者自行新增
                //dataGridView1_house.AllowUserToAddRows = false;
            }
            else
            {
                this.getprivileges.Enabled = false;
                //是否允許使用者編輯
                dataGridView1_house.ReadOnly = true;
                //是否允許使用者自行新增
                //dataGridView1_house.AllowUserToAddRows = false;


            }
            DBH_init_dblist();
        }

        private void DBHouse_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                ClassMsg msg = new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as ClassMsg;
                switch (msg.msgCommand)
                {
                    case MsgCommand.DBList:
                        //DialogResult = DialogResult.OK;
                        mydics = (MyDictioinary<string, DB_Map>)new ClassSerializers().DeSerializeBinary(new MemoryStream(msg.Data));
                        //渲染数据库资源下拉按钮之前，保存列表字典到全局区PublicValue.mydics
                        //全局变量重构//
                        //PublicValue.mydics = mydics;
                        SuperMessage.mydics = mydics;

                        //数据库列表展开
                        dataGridView1_house.AllowUserToAddRows = true;

                        int i = this.dataGridView1_house.Rows.Count;
                        int j = this.dataGridView1_house.Rows[0].Cells.Count;
                        int i_tmp = 0;
                        foreach (KeyValuePair<string, DB_Map> mydic in mydics.llDictionary)
                        {
                            //针对不同的数据资源展现不同列表
                            if (SuperMessage.dbtype == 1)
                            {
                                if (SuperMessage.dbtype == 1 && mydic.Value.property == 0) { continue; }
                                if (i_tmp + 1 >= dataGridView1_house.Rows.Count)
                                {
                                    this.dataGridView1_house.Rows.Add();
                                }
                                this.dataGridView1_house.Rows[i_tmp].Cells[0].Value = "(公司)" + mydic.Value.name;
                                this.dataGridView1_house.Rows[i_tmp].Cells[1].Value = mydic.Value.username;
                                this.dataGridView1_house.Rows[i_tmp].Cells[2].Value = mydic.Value.password;
                                this.dataGridView1_house.Rows[i_tmp].Cells[3].Value = mydic.Value.ipaddr;
                                this.dataGridView1_house.Rows[i_tmp].Cells[4].Value = mydic.Value.port;
                            }
                            if (SuperMessage.dbtype == 0)
                            {
                                if (mydic.Value.ack != "是" && mydic.Value.property == 1) { continue; }
                                if (mydic.Value.rguser != Publec_Class.UserName && mydic.Value.property == 0) { continue; }
                                if (i_tmp + 1 >= dataGridView1_house.Rows.Count)
                                {
                                    this.dataGridView1_house.Rows.Add();
                                }
                                if (mydic.Value.property == 0)
                                {
                                    this.dataGridView1_house.Rows[i_tmp].Cells[0].Value = "(私有)" + mydic.Value.name;
                                }
                                else
                                {
                                    this.dataGridView1_house.Rows[i_tmp].Cells[0].Value = "(公司)" + mydic.Value.name;

                                }
                                this.dataGridView1_house.Rows[i_tmp].Cells[1].Value = mydic.Value.username;
                                this.dataGridView1_house.Rows[i_tmp].Cells[2].Value = mydic.Value.password;
                                this.dataGridView1_house.Rows[i_tmp].Cells[3].Value = mydic.Value.ipaddr;
                                this.dataGridView1_house.Rows[i_tmp].Cells[4].Value = mydic.Value.port;

                            }

                            i_tmp += 1;
                        }
/*                        for (int k = i_tmp; k <= dataGridView1_house.Rows.Count; k++)
                        {
                            dataGridView1_house.Rows.Remove(dataGridView1_house.Rows[k]);
                        }
*/
                        //dataGridView1_house.AllowUserToAddRows = false;
                        break;
                    case MsgCommand.PVSUCCESS://数据资源申请后返回、
                        MessageBox.Show("       申请成功已提交-请等待管理员确认！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return;
                        break;
                    case MsgCommand.PVFAIL://数据资源申请后返回、
                        MessageBox.Show("       操作失败-或者已经申请过-如有疑问请联系管理员！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
                        break;
                    case MsgCommand.DBCount://数据库资源为0
                        break;

                }
            }
            catch { }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 把第3列显示*号，*号的个数和实际数据的长度相同
            if (e.ColumnIndex == 2)
            {
                if (e.Value != null && e.Value.ToString().Length > 0)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
            }

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // 编辑第3列时，把第3列显示为*号
            TextBox t = e.Control as TextBox;
            if (t != null)
            {
                if (this.dataGridView1_house.CurrentCell.ColumnIndex == 2)
                    t.PasswordChar = '*';
                else
                    t.PasswordChar = new char();
            }

        }

        private void getprivileges_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("       当前选择了："+ dataGridView1_house.Rows[dataGridView1_house.CurrentRow.Index].Cells[0].Value , "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return;
            if (dataGridView1_house.Rows[dataGridView1_house.CurrentRow.Index].Cells[0].Value == null) {
                MessageBox.Show("       不能选择空行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            PrivigesMsg pvMsg = new PrivigesMsg();
            pvMsg.UserName = Publec_Class.UserName;
            pvMsg.cover = dataGridView1_house.Rows[dataGridView1_house.CurrentRow.Index].Cells[0].Value.ToString().Replace("(公司)","");
            Publec_Class pc = new Publec_Class();
            byte[] pvMsgData = new ClassSerializers().SerializeBinary(pvMsg).ToArray();
            ClassMsg msg = new ClassMsg();
            msg.sendKind = SendKind.SendCommand;
            msg.msgCommand = MsgCommand.DBPRIV;
            msg.SIP = pc.getMacAddr_Local(0);
            msg.SPort = this.udpSocket1.LocalPort.ToString();
            msg.Data = pvMsgData;
            //打开socket，后台通信
            udpSocket1.Active = true;

            udpSocket1.Send(IPAddress.Parse(Publec_Class.ServerIP), Convert.ToInt32(Publec_Class.ServerPort), new ClassSerializers().SerializeBinary(msg).ToArray());

        }
    }
}
