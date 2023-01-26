using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OffsetDB
{
    enum RowState{ Existed, New, Modified, ModifiedNew, Deleted}                //состояние строки
    public partial class Form1 : Form
    {
        Database database = new Database();

        int selectedRow;
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            id_textBox.Visible = false;
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("title", "title");
            dataGridView1.Columns.Add("author", "author");
            dataGridView1.Columns.Add("text", "text");
            dataGridView1.Columns.Add("isNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dataGridView, IDataRecord record)
        {
            
            dataGridView.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), RowState.ModifiedNew);
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns();
            UpdateData(dataGridView1);                                      // вызываем метод загрузки таблицы 
        }   

     

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            addForm.ShowDialog();
        }

        private void refreshBtn_Click(object sender, EventArgs e)           //Обновление таблицы 
        {
            UpdateData(dataGridView1);
        }

        private void ChangeValue_Click(object sender, EventArgs e)          
        {
            Change();

        }
        private void SaveChanges_Click(object sender, EventArgs e)              // Сохраненгие после изменений (удаление, изменение ) кнопка
        {
            Update();
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;

            if(e.RowIndex >=0)
            {

                DataGridViewRow row = dataGridView1.Rows[selectedRow];
             
                id_textBox.Text = row.Cells[0].Value.ToString();
                title_textBox.Text = row.Cells[1].Value.ToString();
                author_textBox.Text = row.Cells[2].Value.ToString();
                text_textBox.Text = row.Cells[3].Value.ToString(); 
                
            }
        }
        //======================================Методы по редактированию строк================================================

        private void DeleteRow()                                    // метод удаление записи
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[4].Value = RowState.Deleted;
                return;
            }
            dataGridView1.Rows[index].Cells[4].Value = RowState.Deleted;
        }

        

        private void Update()                       // метод для применения статуса записи (на удаление, на изменение)
        {
            database.openConnection()
;
            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView1.Rows[index].Cells[4].Value;

                if (rowState == RowState.Existed)
                    continue;

                if (rowState == RowState.Deleted)                               // проверка на удаление строки
                {
                    var id = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var delReq = $"DELETE FROM articles WHERE id = {id}";
                    
                    var cmd = new SqlCommand(delReq, database.GetConnection());
                    cmd.ExecuteNonQuery();
                }
                if(rowState == RowState.Modified)                               //Провека на иземенение строки
                {
                    var id = dataGridView1.Rows[index].Cells[0].Value.ToString();
                    string title = dataGridView1.Rows[index].Cells[1].Value.ToString();
                    string author = dataGridView1.Rows[index].Cells[2].Value.ToString();
                    string text = dataGridView1.Rows[index].Cells[3].Value.ToString();

                    var changeValue = $"UPDATE articles SET title = '{title}', author = '{author}', text = '{text}' WHERE id = '{id}'";
                    var cmd = new SqlCommand(changeValue, database.GetConnection());
                    cmd.ExecuteNonQuery();
                }
            } 
            database.closeConnection();
        }

     

        private void Change()                                      // Изменение значений
        {
            var selectedRowIndex = dataGridView1.CurrentCell.RowIndex;
            var id = id_textBox.Text;
            string title = title_textBox.Text;
            string author = author_textBox.Text;
            string text = text_textBox.Text;
            if (dataGridView1.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView1.Rows[selectedRowIndex].SetValues(title, author, text);
                dataGridView1.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
            }
        }

        private void UpdateData(DataGridView dataGridView)          // Загрузка всей таблицы при запуске
        {
            dataGridView.Rows.Clear();
            string req = $"SELECT * FROM articles";
            SqlCommand cmd = new SqlCommand(req, database.GetConnection());
            database.openConnection();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dataGridView, reader);
            }
            reader.Close();
        }       
    }
}
