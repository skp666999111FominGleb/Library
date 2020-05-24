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
    public partial class Form2Login : Form
    {
        SqlConnection sqlConnection;
        public Form2Login()
        {
            InitializeComponent();
        }

        private void Form2Login_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string loginn = textBox1.Text;
            string password = textBox2.Text;
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gleb-\source\repos\TRPO3\TRPO\Database2.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            DataTable dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE [login] = @loginn AND [Password] = @password", sqlConnection);
            command.Parameters.AddWithValue("loginn", textBox1.Text);
            command.Parameters.AddWithValue("password", textBox2.Text);
            adapter.SelectCommand = command;
            adapter.Fill(dataTable);
            await command.ExecuteNonQueryAsync();
            if (dataTable.Rows.Count > 0)
            {
                Glava f = new Glava();
                f.Show();
                Hide();

            }
            else
            {
                MessageBox.Show("Авторизация не удалась.");
                textBox2.Clear();
                textBox1.Clear();
            }
            sqlConnection.Close();


        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Form2register f = new Form2register();
            f.Show();
            Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void Form2Login_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form2Login_MouseMove(object sender, MouseEventArgs e)
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
    }
}
