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
            conn.Close();
            CurrentUser current_user = new CurrentUser(conn);
            current_user.Show();
            this.Hide();
        }

        private void CreateRole_Click(object sender, EventArgs e)
        {
                OracleCommand conn_proc_2 = new OracleCommand("BAP.DA_CREATE_ROLE", conn);
                conn_proc_2.CommandType = CommandType.StoredProcedure;

                conn_proc_2.Parameters.Add("A_Name", OracleDbType.Varchar2).Value = RoleName.Text;

                OracleParameter conn_proc_p = new OracleParameter();
                conn_proc_p.ParameterName = "A_SUCCESS";
                conn_proc_p.OracleDbType = OracleDbType.Int32;
                conn_proc_p.Direction = System.Data.ParameterDirection.Output;
                conn_proc_2.Parameters.Add(conn_proc_p);


            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", conn);
                cmd.ExecuteNonQuery();

                conn_proc_2.ExecuteNonQuery();

                OracleDecimal result = (OracleDecimal)conn_proc_p.Value;
                int intValue = result.ToInt32();

                if (intValue == 1)
                {
                    MessageBox.Show("Create Role success!");
                }
                else
                {
                    MessageBox.Show("Create Role fail!");
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


        private void CreateUser_Click(object sender, EventArgs e)
        {
            OracleCommand conn_proc = new OracleCommand("BAP.DA_CREATE_USER", conn);
            conn_proc.CommandType = CommandType.StoredProcedure;

            conn_proc.Parameters.Add("A_Name", OracleDbType.Varchar2).Value = NameCreU.Text;
            conn_proc.Parameters.Add("A_Password", OracleDbType.Varchar2).Value = PassCreU.Text;

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
                    MessageBox.Show("Create User success!");
                }
                else
                {
                    MessageBox.Show("Create User fail!");
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


        private void GrantRButton_Click(object sender, EventArgs e)
        {
            OracleCommand conn_proc_2 = new OracleCommand("BAP.DA_GRANT_USER_ROLE", conn);
            conn_proc_2.CommandType = CommandType.StoredProcedure;

            conn_proc_2.Parameters.Add("Name_User", OracleDbType.Varchar2).Value = GrantR_U.Text;
            conn_proc_2.Parameters.Add("Name_Role", OracleDbType.Varchar2).Value = GrantR_R.Text;

            OracleParameter conn_proc_p = new OracleParameter();
            conn_proc_p.ParameterName = "A_SUCCESS";
            conn_proc_p.OracleDbType = OracleDbType.Int32;
            conn_proc_p.Direction = System.Data.ParameterDirection.Output;
            conn_proc_2.Parameters.Add(conn_proc_p);


            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", conn);
                cmd.ExecuteNonQuery();

                conn_proc_2.ExecuteNonQuery();

                OracleDecimal result = (OracleDecimal)conn_proc_p.Value;
                int intValue = result.ToInt32();

                if (intValue == 1)
                {
                    MessageBox.Show("Grant Role success!");
                }
                else
                {
                    MessageBox.Show("Grant Role fail!");
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

        private void DeleteRole_Click(object sender, EventArgs e)
        {
            OracleCommand conn_proc_2 = new OracleCommand("BAP.DA_DELETE_ROLE", conn);
            conn_proc_2.CommandType = CommandType.StoredProcedure;

            conn_proc_2.Parameters.Add("A_Name", OracleDbType.Varchar2).Value = De_Role.Text;

            OracleParameter conn_proc_p = new OracleParameter();
            conn_proc_p.ParameterName = "A_SUCCESS";
            conn_proc_p.OracleDbType = OracleDbType.Int32;
            conn_proc_p.Direction = System.Data.ParameterDirection.Output;
            conn_proc_2.Parameters.Add(conn_proc_p);


            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", conn);
                cmd.ExecuteNonQuery();

                conn_proc_2.ExecuteNonQuery();

                OracleDecimal result = (OracleDecimal)conn_proc_p.Value;
                int intValue = result.ToInt32();

                if (intValue == 1)
                {
                    MessageBox.Show("Delete Role success!");
                }
                else
                {
                    MessageBox.Show("Delete Role fail!");
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

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            OracleCommand conn_proc_2 = new OracleCommand("BAP.DA_DELETE_USER", conn);
            conn_proc_2.CommandType = CommandType.StoredProcedure;

            conn_proc_2.Parameters.Add("A_Name", OracleDbType.Varchar2).Value = De_User.Text;

            OracleParameter conn_proc_p = new OracleParameter();
            conn_proc_p.ParameterName = "A_SUCCESS";
            conn_proc_p.OracleDbType = OracleDbType.Int32;
            conn_proc_p.Direction = System.Data.ParameterDirection.Output;
            conn_proc_2.Parameters.Add(conn_proc_p);


            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", conn);
                cmd.ExecuteNonQuery();

                conn_proc_2.ExecuteNonQuery();

                OracleDecimal result = (OracleDecimal)conn_proc_p.Value;
                int intValue = result.ToInt32();

                if (intValue == 1)
                {
                    MessageBox.Show("Delete User success!");
                }
                else
                {
                    MessageBox.Show("Delete User fail!");
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
