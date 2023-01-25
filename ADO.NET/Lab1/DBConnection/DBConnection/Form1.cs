using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Configuration;
using DBConnection.Properties;

using ConfigurationManager = System.Configuration.ConfigurationManager;
using DocumentFormat.OpenXml.Wordprocessing;

namespace DBConnection
{
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection();
        // string testConnect = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Northwind;Data Source=LAPTOP-IEIKHMCF\SQLEXPRESS";
        string testConnect = GetConnectionStringByName("DBConnect.NorthwindConnectionString");
	ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
        


        public Form1()
        {
            InitializeComponent();
            this.connection.StateChange += new
                System.Data.StateChangeEventHandler(
                this.connection_StateChange);
            
        }
        static string GetConnectionStringByName(string name)
        {
            string returnValue = null;
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                returnValue = settings.ConnectionString;
            return returnValue;
        }
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.ConnectionString = testConnect;
                    connection.Open();
                    MessageBox.Show("Соединение с базой данных выполнено успешно");
                }
                else
                    MessageBox.Show("Соединение с базой данных уже установлено");
            }
            catch (Exception Xcp)
            {
                MessageBox.Show(Xcp.Message, "Unexpected Exception",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                MessageBox.Show("Соединение с базой данных закрыто");
            }
            else
                MessageBox.Show("Соединение с базой данных уже закрыто");
        }

        private void connection_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            connectToolStripMenuItem.Enabled =
                (e.CurrentState == ConnectionState.Closed);
            disconnectToolStripMenuItem.Enabled =
                (e.CurrentState == ConnectionState.Open);
        }

        private void connectionListToolStripMenuItem_Click(object sender, EventArgs e)
        {
     
            if (settings != null)
            {
                foreach (ConnectionStringSettings cs in settings)
                {
                    MessageBox.Show("name = " + cs.Name);
                    MessageBox.Show("providerName = " + cs.ProviderName);
                    MessageBox.Show("connectionString = " + cs.ConnectionString);
                }
            }
        }

    
    }
}
