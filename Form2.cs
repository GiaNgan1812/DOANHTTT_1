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
    public partial class Form2 : Form
    {
        private OracleConnection conn;
        public Form2(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT * FROM DBA_USERS", conn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Hiển thị dữ liệu trong DataGridView
            dataGridView1.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
