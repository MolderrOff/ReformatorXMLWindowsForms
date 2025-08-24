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



                dataBase.openConnection(); 

                if (command.ExecuteNonQuery() == 1) 
                {
                    MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                    log_in frm_login = new log_in(); 
                    this.Hide();
                    frm_login.ShowDialog();


                }
                else
                {
                    MessageBox.Show("Аккаунт не создан");
                }
                dataBase.closeConnection(); 
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
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}' and password_user = '{passUser}'";  

            SqlCommand command = new SqlCommand(querystring, dataBase.getConnection()); 

            adapter.SelectCommand = command; 
            adapter.Fill(table);

            if (table.Rows.Count > 0) 
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
            textBox_login2.MaxLength = 50;   
            textBox_password2.MaxLength = 50; 

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
