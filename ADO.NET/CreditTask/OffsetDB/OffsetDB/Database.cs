using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OffsetDB
{
    internal class Database
    {
        string strConn = @"Data Source=.\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Initial Catalog=MyNewDB;";
        SqlConnection conn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Initial Catalog=MyNewDB;");

        public void openConnection()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.ConnectionString = strConn;
                    conn.Open();
                    MessageBox.Show("Соединение с базой данных выполнено успешно");
                }
                else
                    MessageBox.Show("Соединение с базой данных уже установлено");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unexpected Exception",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         
        }
        public void closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                MessageBox.Show("Соединение с базой данных закрыто");
            }
            else
                MessageBox.Show("Соединение с базой данных уже закрыто");
        }
        public SqlConnection GetConnection()
        {
            return conn;
        }

    }
}
