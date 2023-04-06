using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.VsDevTools;
using Oracle.ManagedDataAccess.Client;

namespace DOANHTTT_1
{
    public partial class Form1 : Form
    {
        OracleConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_click_Click(object sender, EventArgs e)
        {
            //string strConnectDB = " Data source = (DESCRIPTION = " +
            //    "(ADDRESS = (PROTOCOL = TCP)(HOST = DESKTOP - Q8CECPE)(PORT = 1521)) " +
            //    "(CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = XE)));" +
            //    " USER ID = " + textBox1.Text +
            //    "; Password = " + textBox2.Text + ";";

            string strConnectDB = @"Data source = localhost:1521/xe;" +
                " USER ID = " + textBox1.Text +
                "; Password = " + textBox2.Text + ";";

            //conn = new OracleConnection(strConnectDB);

            try {
                conn = new OracleConnection(strConnectDB);
                conn.Open();
                //MessageBox.Show("Đăng nhập thành công!");
                //conn.Close();

                Form2 form2 = new Form2(conn);
                form2.Show();

                this.Hide();
            }
            catch (Exception ex){
                MessageBox.Show("ERROR!" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
