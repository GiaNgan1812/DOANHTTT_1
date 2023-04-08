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
    public partial class CurrentUser : Form
    {
        private OracleConnection conn;
        public CurrentUser(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            OracleCommand conn_proc = new OracleCommand("BAP.DA_LIST_USER", conn);
            conn_proc.CommandType = CommandType.StoredProcedure;
            conn_proc.Parameters.Add("A_LIST", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter(conn_proc);
            DataSet dataTable = new DataSet();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable.Tables[0];
            dataGridView1.AutoResizeRows();
            dataGridView1.AutoResizeColumns();

            //
            OracleDataAdapter adapter1 = new OracleDataAdapter("SELECT sys_context('USERENV', 'SESSION_USER') as current_user," +
                " sys_context('USERENV', 'CURRENT_SCHEMA') as current_schema," +
                " sys_context('USERENV', 'SESSIONID') as session_id," +
                " sys_context('USERENV', 'IP_ADDRESS') as ip_address," +
                " sys_context('USERENV', 'HOST') as host," +
                " granted_role as role_name \r\nFROM dba_role_privs" +
                " \r\nWHERE grantee = sys_context('USERENV', 'SESSION_USER')", conn);
            DataTable dataTable1 = new DataTable();
            adapter1.Fill(dataTable1);
            dataGridView2.DataSource = dataTable1;
            dataGridView2.AutoResizeRows();
            dataGridView2.AutoResizeColumns();

            //
            OracleCommand conn_proc_1 = new OracleCommand("BAP.DA_LIST_ROLE", conn);
            conn_proc_1.CommandType = CommandType.StoredProcedure;
            conn_proc_1.Parameters.Add("A_LIST", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter_1 = new OracleDataAdapter(conn_proc_1);
            DataSet dataTable_1 = new DataSet();
            adapter_1.Fill(dataTable_1);
            dataGridView3.DataSource = dataTable_1.Tables[0];
            dataGridView3.AutoResizeRows();
            dataGridView3.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            Login form1 = new Login();
            form1.Show();
            this.Hide();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            User_Role user_role = new User_Role(conn);
            user_role.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
