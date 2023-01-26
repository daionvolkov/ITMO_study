using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OffsetDB
{
    public partial class AddForm : Form
    {
        Database database = new Database();
        public AddForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void addToTable_Click(object sender, EventArgs e)
        {
            database.openConnection();

            string title = titleTextBox.Text;
            string author = authorTextBox.Text;
            string text = textTextBox.Text;

            if(title != "" && author != "" && text != "")
            {
                var addToTable = $"INSERT INTO articles(title, author, text) VALUES('{title}', '{author}', '{text}')";
                var cmd = new SqlCommand(addToTable, database.GetConnection());
                cmd.ExecuteNonQuery();
                MessageBox.Show("Запись добавлена");
            }
            else
            {
                MessageBox.Show("Запись не удалось добавить, возможно не заполнены все поля");
            }
        }
    }
}
