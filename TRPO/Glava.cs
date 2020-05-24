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

namespace TRPO
{
    public partial class Glava : Form
    {
        SqlConnection sqlConnection;
        public Glava()
        {
            InitializeComponent();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private async void main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database2DataSet.Library". При необходимости она может быть перемещена или удалена.
            this.libraryTableAdapter.Fill(this.database2DataSet.Library);
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gleb-\source\repos\TRPO3\TRPO\Database2.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            await sqlConnection.OpenAsync();
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Library]", sqlConnection);
            try
            {
                sqlReader = await command.ExecuteReaderAsync();

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (sqlReader != null)
                {
                    sqlReader.Close();
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
            
        }
        int i;
        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < libraryDataGridView.RowCount; i++)
            {
                libraryDataGridView.Rows[i].Selected = false;
                for (int j = 0; j < libraryDataGridView.ColumnCount; j++)
                    if (libraryDataGridView.Rows[i].Cells[j].Value != null)
                        if (libraryDataGridView.Rows[i].Cells[j].Value.ToString().Contains(textBox1.Text))
                        {
                            libraryDataGridView.Rows[i].Selected = true;
                            break;
                        }
            }
            //SEARCH f = new SEARCH();
            //f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string str = "Должник";
            for (int i = 0; i < libraryDataGridView.RowCount; i++)
            {
                libraryDataGridView.Rows[i].Selected = false;
                for (int j = 0; j < libraryDataGridView.ColumnCount; j++)
                    if (libraryDataGridView.Rows[i].Cells[j].Value != null)
                        if (libraryDataGridView.Rows[i].Cells[j].Value.ToString().Contains( str     ))
                        {
                            libraryDataGridView.Rows[i].Selected = true;
                            break;
                        }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            
        }
       
        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void button6_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void libraryBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.libraryBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.database2DataSet);

        }

        private void libraryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
         
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
      libraryDataGridView.Refresh();
        }

        private void libraryBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }
    }
}
