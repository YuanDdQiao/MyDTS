using ClassDDTS;
using System;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MyDTS
{
    public partial class Login : Form
    {
        //MySqlConnection conn = null;
        //ClassOptionDataMysql codmysql = new ClassOptionDataMysql();

        public Login()
        {
            InitializeComponent();
        }
        #region//声名变量
        Publec_Class PubClass = new Publec_Class();
        #endregion

        #region  使Label控件透明
        /// <summary>
        /// 使Label控件透明.
        /// </summary>
        public void Trans(Label lab, PictureBox pic)
        {
            lab.BackColor = Color.Transparent;
            lab.Parent = pic;
        }
        #endregion
        //读写Server.ini文件
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        private void login_Load(object sender, EventArgs e)
        {
            //如果程序启动目录中没有Server.ini文件
            //MessageBox.Show("调用登录窗体的加载函数。");
            if (System.IO.File.Exists(PubClass.Get_windows() + "\\Server.ini") == false)
            {
                Regist FrmSerSetup = new Regist();  //创建并引用注册窗体
                FrmSerSetup.Text = "用户注册";  //设置注册窗体的名称
                if (FrmSerSetup.ShowDialog(this) == DialogResult.OK)    //当注册窗体的对话框返回值为OK时
                {
                    FrmSerSetup.Dispose();  //释放注册窗体的所有资源
                }
                else
                {
                    FrmSerSetup.Dispose();
                    DialogResult = DialogResult.Cancel;//将当前窗体的对话框返回值设为Cancel
                }
            }
            //如果Windows目录中有Server.ini文件
            if (System.IO.File.Exists(PubClass.Get_windows() + "\\Server.ini") == true)
            {
                Publec_Class.ClientIP = "";
                Publec_Class.ClientPort = "";
                Publec_Class.ClientName = "";

                //读取INI文件
                StringBuilder temp = new StringBuilder(255);
                //读取客户端的IP地址
                GetPrivateProfileString("MyDTS-Client", "C-UID", "服务器地址读取错误。", temp, 255, PubClass.Get_windows() + "\\Server.ini");
                Publec_Class.ClientIP = temp.ToString();
                //读取端口号
                GetPrivateProfileString("MyDTS-Client", "C-Port", "服务器端口号读取错误。", temp, 255, PubClass.Get_windows() + "\\Server.ini");
                Publec_Class.ClientPort = temp.ToString();
                //读取用户名称
                GetPrivateProfileString("MyDTS", "Name", "服务器端口号读取错误。", temp, 255, PubClass.Get_windows() + "\\Server.ini");
                Publec_Class.ClientName = temp.ToString();
                //读取MacAddr名称
                GetPrivateProfileString("MyDTS-Client", "C-MacAddr", "服务器端口号读取错误。", temp, 255, PubClass.Get_windows() + "\\Server.ini");
                Publec_Class.ClientMacAddr = temp.ToString();
                //初始化登录用户名称
                this.text_login_name.Text = Publec_Class.ClientName;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }

            udpSocket1.Active = true;   //启动自定义的udpSocket1控件
        }

        private void button_login_click_Click(object sender, EventArgs e)
        {
            //输入参数处理
            if ((text_login_passwd.Text.Trim()).Length == 0)
            {
                MessageBox.Show("       用户密码不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);return;
            }
            if (text_login_passwd.Text.Length < 6) { MessageBox.Show("       密码太短！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); return; }

            //传送参数到后台校验
            RegisterMsg registermsg = new RegisterMsg();
            registermsg.UserName = text_login_name.Text.Trim();
            registermsg.PassWord = text_login_passwd.Text.Trim();
            byte[] registerData = new ClassSerializers().SerializeBinary(registermsg).ToArray();
            ClassMsg msg = new ClassMsg();
            msg.sendKind = SendKind.SendCommand;
            msg.msgCommand = MsgCommand.Logining;
            msg.SPort = this.udpSocket1.LocalPort.ToString();
            msg.SIP = PubClass.getMacAddr_Local(0);
            msg.Data = registerData;
            udpSocket1.Send(IPAddress.Parse(Publec_Class.ServerIP), Convert.ToInt32(Publec_Class.ServerPort), new ClassSerializers().SerializeBinary(msg).ToArray());
            Publec_Class.UserName = text_login_name.Text;

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
                    case MsgCommand.Logined://登录成功
                        //Publec_Class.UserID = msg.SID;
                        DialogResult = DialogResult.OK;
                        //udpSocket1.Active = false;
                        break;

                }
            }
            catch (Exception e) {
                Console.WriteLine("---------err-3");
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (udpSocket1.Active)
            {
                udpSocket1.Active = false;
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (udpSocket1.Active)
            {
                udpSocket1.Active = false;
            }
        }
    }
}
