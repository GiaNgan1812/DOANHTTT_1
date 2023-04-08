using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANHTTT_1
{
    public partial class User_Role : Form
    {
        private OracleConnection conn;
        public User_Role(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void User_Role_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CurrentUser current_user = new CurrentUser(conn);
            current_user.Show();
            this.Hide();
        }

        private void CreateRole_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand conn_proc = new OracleCommand("DA_CREATE_USER_ROLE", conn);
                conn_proc.CommandType = CommandType.StoredProcedure;

                conn_proc.Parameters.Add("A_Name", OracleDbType.Varchar2).Value = RoleName.Text;
                conn_proc.Parameters.Add("A_Option", OracleDbType.Varchar2).Value = "ROLE";

                conn_proc.ExecuteNonQuery();
            }
            catch (OracleException er)
            {
                MessageBox.Show("Error: " + er.Message);
            }
        }
    }
}
