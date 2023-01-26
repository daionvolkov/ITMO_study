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

namespace DataAdapterProgram
{
    public partial class Form1 : Form
    {
        private SqlConnection NorthwindConnection = new SqlConnection("Data Source=LAPTOP-IEIKHMCF\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
        private SqlDataAdapter SqlDataAdapter1;

        private DataSet NorthwindDataset = new DataSet("Northwind");
        private DataTable CustomersTable = new DataTable("Customers");


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter1 = new SqlDataAdapter("SELECT * FROM Customers", NorthwindConnection);
            NorthwindDataset.Tables.Add(CustomersTable);
            SqlDataAdapter1.Fill(NorthwindDataset.Tables["Customers"]);
            dataGridView1.DataSource = NorthwindDataset.Tables["Customers"];
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            NorthwindDataset.EndInit();
            SqlDataAdapter1.Update(NorthwindDataset.Tables["Customers"]);
        }
    }
}
