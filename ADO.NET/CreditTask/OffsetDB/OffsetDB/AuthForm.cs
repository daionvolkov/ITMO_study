using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OffsetDB
{
    public partial class AuthForm : Form
    {
        Database database = new Database();
        public AuthForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        
        private void LoginBtn_Click(object sender, EventArgs e)
        {
   

            string loginUser = loginField.Text;
            string passUser = passField.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();  
            DataTable dt = new DataTable();

            string strConn = @"Data Source=.\SQLEXPRESS;Integrated Security=True;Persist Security Info=False;Initial Catalog=MyNewDB;" +
                "User ID=" + loginUser + ";" +
                "Password=" + passUser + ";";
            using (SqlConnection conn = new SqlConnection(strConn))
            {
                try
                {
                    if (conn.State != ConnectionState.Open)
                    {
                        conn.ConnectionString = strConn;
                        conn.Open();
                        MessageBox.Show("Соединение с базой данных выполнено успешно");
                        Form1 frm1 = new Form1();
                        this.Hide();
                        frm1.ShowDialog();
                    }
                    else
                        
                        MessageBox.Show("Неверный пользователь или пароль");
                        this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unexpected Exception",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            /*string authRequest = $"SELECT userID, Password FROM users WHERE userID = '{loginUser}' AND Password ='{passUser}'";
            SqlCommand cmd = new SqlCommand(authRequest, database.GetConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(dt);

            if (dt.Rows.Count == 1)
            {
                MessageBox.Show("Вы подключились к базе");
                Form1 frm1 = new Form1();
                this.Hide();
                frm1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный пользователь или пароль");
                this.Close();
            }    */


        }


    }
}
