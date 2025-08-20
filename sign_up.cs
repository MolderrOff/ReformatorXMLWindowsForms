using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // надо делать для каждой формы
using for_video;
using System.Data.OleDb;

namespace for_video
{
    public partial class sign_up : Form
    {
        DataBase dataBase = new DataBase();   //создаём объект  класса  database
        public sign_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //dataBase.CheckDB();
            if (dataBase.CheckDB() == true)
            {
                //MessageBox.Show("База данных существует>");
                checkuser(); //добавил

                var login = textBox_login2.Text; // создаём две переменные
                var password = textBox_password2.Text;


                string querystring = $"insert into register(login_user, password_user) values('{login}','{password}')";  // объявим переменную типа string в которую будем заность sql запрос

                SqlCommand command = new SqlCommand(querystring, dataBase.getConnection()); // создаём объект класса sqlcommand в который перенесём наш запрос



                dataBase.openConnection(); // вызвать объект класса DataBase

                if (command.ExecuteNonQuery() == 1) // ескли команда успешно запустилась проверка
                {
                    MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                    log_in frm_login = new log_in(); // создаём объект класса формы, чтобы перейти на следующую форму
                    this.Hide();
                    frm_login.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Аккаунт не создан");
                }
                dataBase.closeConnection(); // Закрыть связь с базой данных
            } else
            { 
                MessageBox.Show("База данных не существует. СОЗДАНИЕ БАЗЫ ДАННЫХ");
                dataBase.createMyDataBase();
            }

        }

        private Boolean checkuser()
        {
            var loginUser = textBox_login2.Text;
            var passUser = textBox_password2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";  // запрос выборка проверить нет ли такого уже пользователя

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection()); //объект для   SQL commaand в которую мы просто внесём строку с запросом и подключением к базе данных

            adapter.SelectCommand = command; //куда мы передаём значение нашего объекта, даже переменной
            adapter.Fill(table);

            if (table.Rows.Count > 0) //проверка, если количество строк >0 
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
            {
                return false;
            
            }

        }

        private void sign_up_Load(object sender, EventArgs e)
        {
            textBox_password2.PasswordChar = '*';
            pictureBox3.Visible = false;
            textBox_login2.MaxLength = 50;   //добавил
            textBox_password2.MaxLength = 50; //

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {          
                textBox_password2.UseSystemPasswordChar = false;
                pictureBox3.Visible = false;
                pictureBox2.Visible = true;
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
                textBox_password2.UseSystemPasswordChar = true;
                pictureBox3.Visible = true;
                pictureBox2.Visible = false;
            

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           textBox_login2.Text = "";
           textBox_password2.Text = "";
        }


    }
}
