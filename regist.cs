using System;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ClassDDTS;

namespace MyDTS
{
    public partial class Regist : Form
    {
        #region//声名变量
        Publec_Class PubClass = new Publec_Class();
        #endregion

        string serID = "";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private delegate void DataArrivaldelegate(byte[] Data, System.Net.IPAddress Ip, int Port);

        public Regist()
        {
            InitializeComponent();
        }

        private void regist_Load(object sender, EventArgs e)
        {
            udpSocket1.Active = true;

        }

        private void udpSocket1_DataArrival(byte[] Data, System.Net.IPAddress Ip, int Port) //当有数据到达后的处理进程
        {
            DataArrivaldelegate outdelegate = new DataArrivaldelegate(DataArrival); //托管
            this.BeginInvoke(outdelegate, new object[] { Data, Ip, Port }); //异步执行托管
        }

        //处理socket接收的数据（且反序列化解码）
        private void DataArrival(byte[] Data, IPAddress Ip, int Port) //当有数据到达后的主要逻辑处理函数（的进程）
        {
            try
            {
                ClassMsg msg = new ClassSerializers().DeSerializeBinary((new System.IO.MemoryStream(Data))) as ClassMsg;

                switch (msg.msgCommand)
                {
                    case MsgCommand.Registered://注册成功
                        DialogResult = DialogResult.OK;
                        WritePrivateProfileString("MyDTS", "UID", serID, PubClass.Get_windows() + "\\Server.ini");
                        WritePrivateProfileString("MyDTS", "Port", PubClass.GetServerPort().Trim(), PubClass.Get_windows() + "\\Server.ini");
                        WritePrivateProfileString("MyDTS", "Name", text_regist_name.Text.Trim(), PubClass.Get_windows() + "\\Server.ini");
                        WritePrivateProfileString("MyDTS-Client", "C-UID", PubClass.getMacAddr_Local(0).Trim(), PubClass.Get_windows() + "\\Server.ini");
                        WritePrivateProfileString("MyDTS-Client", "C-Port", this.udpSocket1.LocalPort.ToString(), PubClass.Get_windows() + "\\Server.ini");
                        WritePrivateProfileString("MyDTS-Client", "C-MacAddr", PubClass.getMacAddr_Local(1).Trim(), PubClass.Get_windows() + "\\Server.ini");

                        break;
                }
            }
            catch { }
        }

        private void button_regist_click_Click(object sender, EventArgs e)
        {
            if (text_regist_password.Text.Length < 6) { MessageBox.Show("       密码太短！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return; }
            if (!Publec_Class.IsMail(text_regist_mail.Text.Trim())) { MessageBox.Show("       邮箱不正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return; }
            if (!Publec_Class.IsPhone(text_regist_phone.Text.Trim())) { MessageBox.Show("       电话号不正确！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return; }
            if ((text_regist_password.Text.Trim()).Length == 0)
            {
                MessageBox.Show("       用户密码不能为空！","提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else { 
                if (text_regist_password.Text.Trim() == text_regist_ack_password.Text.Trim())    //当密码输入相同
                {
                    RegisterMsg registermsg = new RegisterMsg();
                    registermsg.UserName = text_regist_name.Text;
                    registermsg.PassWord = text_regist_password.Text;
                    registermsg.phone = text_regist_phone.Text.Trim();
                    registermsg.mail = text_regist_mail.Text.Trim();
                    registermsg.MacAddr = PubClass.getMacAddr_Local(1).Trim();
                    byte[] registerData = new ClassSerializers().SerializeBinary(registermsg).ToArray();
                    ClassMsg msg = new ClassMsg();
                    msg.sendKind = SendKind.SendCommand;
                    msg.msgCommand = MsgCommand.Registering;
                    msg.SPort = this.udpSocket1.LocalPort.ToString() ;
                    msg.SIP = PubClass.getMacAddr_Local(0);
                    msg.Data = registerData;
                    msg.Suser = text_regist_name.Text;
                    serID = PubClass.GetServerIp().Trim();

                    udpSocket1.Send(IPAddress.Parse(serID), Convert.ToInt32(PubClass.GetServerPort().Trim()), new ClassSerializers().SerializeBinary(msg).ToArray());
                }
                else
                {
                    text_regist_password.Text = "";
                    text_regist_ack_password.Text = "";
                    MessageBox.Show("       输入的密码不匹配，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
        }

        private void button_regist_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void regist_FormClosed(object sender, FormClosedEventArgs e)
        {
            udpSocket1.Active = false;
        }
    }
}
