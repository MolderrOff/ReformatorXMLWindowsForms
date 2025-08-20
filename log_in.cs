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
using for_video;
using ReformatorXMLWindowsForms;


namespace for_video
{
    public partial class log_in : Form
    {
        DataBase database = new DataBase();
        public log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            Console.WriteLine("из файла log_in");
        }

        private void log_in_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';
            pictureBox6.Visible = false;
            textBox_login.MaxLength= 50;
            textBox_password.MaxLength = 50;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            var loginUser = textBox_login.Text;
            var passUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";

            Console.WriteLine("Из log_in.cs btnEnter_Click");


            if (database.CheckDB() == true)
            {
                SqlCommand command = new SqlCommand(querystring, database.getConnection());



                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("Из log_in.cs btnEnter_Click сообщение 2");
                    Form1 frm1 = new Form1(); //было
                    //Form2 frm1 = new Form2(); //cтало
                    //Form3 frm1 = new Form3(); //cтало
                    this.Hide();
                    frm1.ShowDialog();
                    this.Show();
                }
                else
                    MessageBox.Show("Такого аккаунта не существует!", "Аккаунта не существует!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            { MessageBox.Show("База данных не существует. Создайте БД"); }

        }

        private void linkLabel1_Click(object sender, EventArgs e)
        {
            sign_up frm_sign = new sign_up();
            frm_sign.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_login.Text = "";
            textBox_password.Text = "";

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = false;
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sign_up frm_sign = new sign_up();
            frm_sign.Show();
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox_login.Text = "";
            textBox_password.Text = "";

        }

        private void log_in_Load_1(object sender, EventArgs e)
        {
            
        }

        private void textBox_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();
            if (dataBase.CheckDB() == true)
            {
                MessageBox.Show("База данных существует>");
               
            }
            else
            {
                MessageBox.Show("База данных не существует. СОЗДАНИЕ БАЗЫ ДАННЫХ");
                dataBase.createMyDataBase();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
