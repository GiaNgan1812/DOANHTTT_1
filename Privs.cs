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
    public partial class Privs : Form
    {
        private OracleConnection conn;
        public Privs(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            checkBox1.Checked = false;
        }

        private void Privs_Load(object sender, EventArgs e)
        {
            OracleCommand conn_proc = new OracleCommand("BAP.DA_PRIVS_USER_TABLE", conn);
            conn_proc.CommandType = CommandType.StoredProcedure;
            conn_proc.Parameters.Add("A_LIST", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter(conn_proc);
            DataSet dataTable = new DataSet();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable.Tables[0];
            dataGridView1.AutoResizeRows();
            dataGridView1.AutoResizeColumns();

            //

            OracleCommand conn_proc_1 = new OracleCommand("BAP.DA_PRIVS_USER", conn);
            conn_proc_1.CommandType = CommandType.StoredProcedure;
            conn_proc_1.Parameters.Add("A_LIST", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter_1 = new OracleDataAdapter(conn_proc_1);
            DataSet dataTable_1 = new DataSet();
            adapter_1.Fill(dataTable_1);
            dataGridView2.DataSource = dataTable_1.Tables[0];
            dataGridView2.AutoResizeRows();
            dataGridView2.AutoResizeColumns();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            CurrentUser current_user = new CurrentUser(conn);
            current_user.Show();
            this.Hide();
        }

        private void Grant_Click(object sender, EventArgs e)
        {
            OracleCommand conn_proc = new OracleCommand("BAP.GRANT_PRIVS_ADMIN", conn);
            conn_proc.CommandType = CommandType.StoredProcedure;

            conn_proc.Parameters.Add("AD_GRANTEE", OracleDbType.Varchar2).Value = textBox1.Text;
            conn_proc.Parameters.Add("AD_PRIVILEGE", OracleDbType.Varchar2).Value = textBox2.Text;
            conn_proc.Parameters.Add("AD_OBJ_NAME", OracleDbType.Varchar2).Value = textBox3.Text;
            conn_proc.Parameters.Add("AD_COL_NAME", OracleDbType.Varchar2).Value = textBox4.Text;

            if (checkBox1.Checked)
            {
                conn_proc.Parameters.Add("AD_COL_NAME", OracleDbType.Varchar2).Value = "WITH GRANT OPTION";
            }
            else
            {
                conn_proc.Parameters.Add("AD_COL_NAME", OracleDbType.Varchar2).Value = " ";
            }

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
                    MessageBox.Show("Grant Privs success!");
                }
                else
                {
                    MessageBox.Show("Grant Privs fail!");
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

        private void button2_Click(object sender, EventArgs e)
        {
            OracleCommand conn_proc_1 = new OracleCommand("BAP.DA_PRIVS_USER", conn);
            conn_proc_1.CommandType = CommandType.StoredProcedure;
            conn_proc_1.Parameters.Add("A_LIST", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter_1 = new OracleDataAdapter(conn_proc_1);
            DataSet dataTable_1 = new DataSet();
            adapter_1.Fill(dataTable_1);
            dataGridView2.DataSource = dataTable_1.Tables[0];
            dataGridView2.AutoResizeRows();
            dataGridView2.AutoResizeColumns();

            OracleCommand conn_proc = new OracleCommand("BAP.DA_PRIVS_USER_TABLE", conn);
            conn_proc.CommandType = CommandType.StoredProcedure;
            conn_proc.Parameters.Add("A_LIST", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter(conn_proc);
            DataSet dataTable = new DataSet();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable.Tables[0];
            dataGridView1.AutoResizeRows();
            dataGridView1.AutoResizeColumns();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OracleCommand conn_proc = new OracleCommand("BAP.REVOKE_PRIVS_ADMIN", conn);
            conn_proc.CommandType = CommandType.StoredProcedure;

            conn_proc.Parameters.Add("AD_GRANTEE", OracleDbType.Varchar2).Value = textBox8.Text;
            conn_proc.Parameters.Add("AD_PRIVILEGE", OracleDbType.Varchar2).Value = textBox7.Text;
            conn_proc.Parameters.Add("AD_OBJ_NAME", OracleDbType.Varchar2).Value = textBox6.Text;

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
                    MessageBox.Show("Revoke Privs success!");
                }
                else
                {
                    MessageBox.Show("Revoke Privs fail!");
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
    }
}
