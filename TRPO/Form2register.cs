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
    public partial class Form2register : Form
    {
        SqlConnection sqlConnection;
        public Form2register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form2register_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            Form2Login f = new Form2Login();
            f.Show();
            Hide();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string loginn = textBox1.Text;
            string password = textBox3.Text;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gleb-\source\repos\TRPO3\TRPO\Database2.mdf;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
            if (label2.Visible)
                label2.Visible = false;

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) &&
                
                !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO [User] (login, Password)VALUES(@loginn, @password)", sqlConnection);
             
                
                command.Parameters.AddWithValue("loginn", textBox1.Text);
                command.Parameters.AddWithValue("password", textBox3.Text);
              
                await command.ExecuteNonQueryAsync();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт успешно создан.");
                    Form2Login log = new Form2Login();
                    log.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Аккаунт не создан.");
                   
                    textBox1.Clear();
                    
                    textBox3.Clear();
                }
                sqlConnection.Close();
            }
            else
            {
                label2.Visible = true;
                label2.Text = "Поля 'Login' и 'Password' должны быть заполнены!";
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

        }
        Point lastPoint;
        private void button1_MouseDown(object sender, MouseEventArgs e)
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
