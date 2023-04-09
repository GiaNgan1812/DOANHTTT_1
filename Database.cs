using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
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
    public partial class Database : Form
    {
        private OracleConnection conn;
        public Database(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void Database_Load(object sender, EventArgs e)
        {
            OracleCommand conn_proc = new OracleCommand("BAP.DA_LIST_TABLE", conn);
            conn_proc.CommandType = CommandType.StoredProcedure;
            conn_proc.Parameters.Add("A_LIST", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter(conn_proc);
            DataSet dataTable = new DataSet();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable.Tables[0];
            dataGridView1.AutoResizeRows();
            dataGridView1.AutoResizeColumns();

            //

            OracleCommand conn_proc_1 = new OracleCommand("BAP.DA_LIST_VIEW", conn);
            conn_proc_1.CommandType = CommandType.StoredProcedure;
            conn_proc_1.Parameters.Add("A_LIST", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter_1 = new OracleDataAdapter(conn_proc_1);
            DataSet dataTable_1 = new DataSet();
            adapter_1.Fill(dataTable_1);
            dataGridView2.DataSource = dataTable_1.Tables[0];
            dataGridView2.AutoResizeRows();
            dataGridView2.AutoResizeColumns();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            CurrentUser current_user = new CurrentUser(conn);
            current_user.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand conn_proc = new OracleCommand("BAP.DA_CREATE_TABLE", conn);
            conn_proc.CommandType = CommandType.StoredProcedure;

            conn_proc.Parameters.Add("A_Name", OracleDbType.Varchar2).Value = textBox1.Text;
            conn_proc.Parameters.Add("A_NAME_ATTRIBUTE", OracleDbType.Varchar2).Value = textBox2.Text;
            conn_proc.Parameters.Add("A_NAME_ATTRIBUTE_VAL", OracleDbType.Varchar2).Value = textBox3.Text;

            OracleParameter conn_proc_p = new OracleParameter();
            conn_proc_p.ParameterName = "A_SUCCESS";
            conn_proc_p.OracleDbType = OracleDbType.Int32;
            conn_proc_p.Direction = System.Data.ParameterDirection.Output;
            conn_proc.Parameters.Add(conn_proc_p);


            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", conn);
                cmd.ExecuteNonQuery();

                conn_proc.ExecuteNonQuery();

                OracleDecimal result = (OracleDecimal)conn_proc_p.Value;
                int intValue = result.ToInt32();

                if (intValue == 1)
                {
                    MessageBox.Show("Create Table success!");
                }
                else
                {
                    MessageBox.Show("Create Table fail!");
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand conn_proc = new OracleCommand("BAP.DA_LIST_TABLE", conn);
            conn_proc.CommandType = CommandType.StoredProcedure;
            conn_proc.Parameters.Add("A_LIST", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter(conn_proc);
            DataSet dataTable = new DataSet();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable.Tables[0];
            dataGridView1.AutoResizeRows();
            dataGridView1.AutoResizeColumns();
        }
    }
}
