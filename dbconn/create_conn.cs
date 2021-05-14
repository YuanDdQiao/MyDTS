using ClassDDTS;
using MyDTS.sync;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MyDTS.dbconn
{
    public partial class create_conn : Form
    {
        public create_conn()
        {
            InitializeComponent();
        }

        private void bt_crenn_name_ok_Click(object sender, EventArgs e)
        {
            if (tb_crenn_name.Text.Trim().Length == 0)
            {
                MessageBox.Show("       名称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (isExistsInDics(tb_crenn_name.Text.Trim()) )
            {
                MessageBox.Show("       名称已经存在，请重新填写一个！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            PublicValue.dbname = tb_crenn_name.Text.Trim();
            DialogResult = DialogResult.OK;
        }

        private void create_conn_Load(object sender, EventArgs e)
        {
            this.tb_crenn_name.Text = PublicValue.dbname + "_new";
        }
        private bool isExistsInDics(string name)
        {
            //全局变量重构//
            //foreach (KeyValuePair<string, DB_Map> mydic in PublicValue.mydics.llDictionary)

            foreach (KeyValuePair<string, DB_Map> mydic in SuperMessage.mydics.llDictionary)
            {
                if (mydic.Key == name)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
