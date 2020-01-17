using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.polTableAdapter.Fill(this.dBDataSet.pol);

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.polTableAdapter.Update(this.dBDataSet.pol);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (reportViewer1.Visible == false)
            {
                reportViewer1.Visible = true;
            }
            else
            {
                reportViewer1.Visible = false;
            }
            }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Validate();
            int col = polDataGridView.SelectedRows.Count;
            for (int i = 0; i < col; i++)
            {
                polDataGridView.Rows.RemoveAt(polDataGridView.SelectedRows[0].Index);
            }
            this.tableAdapterManager.UpdateAll(this.DBDataSet);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Validate();
            int col = dataGridView1.SelectedRows.Count;
            for (int i = 0; i < col; i++)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            this.tableAdapterManager.UpdateAll(this.DBDataSet);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Validate();
            int col = dataGridView2.SelectedRows.Count;
            for (int i = 0; i < col; i++)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
            }
            this.tableAdapterManager.UpdateAll(this.DBDataSet);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string CONNECT_STRING = "Data Source=Slava\\1111;Initial Catalog=TDB;Integrated Security=True";
            string c = textBox1.Text, po = textBox2.Text;
            string selectCmd = string.Format(); //SQl
            DateTime.Parse(c);
                DateTime.Parse(po);
            SqlConnection con = new SqlConnection(CONNECT_STRING);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand(selectCmd, con);
            con.Open();
            da.Fill(ds, "отчет");
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

        
    
}
