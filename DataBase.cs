using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using for_video;
using System.Windows.Forms;
using System.Data;



namespace for_video
{
    
    internal class DataBase
    {
        
        SqlConnection sqlConnection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=dbReformator;Trusted_Connection=True;");

        public bool CheckDB()
        {
            try
            {
                openConnection();
               
                return true;
            }
            catch
            { //ссылка на создание бд
                //createMyDataBase();
                return false;
            }
        }

        public async Task createMyDataBase()
        {           
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Trusted_Connection=True;")) 
            {
                await sqlConnection.OpenAsync();
                SqlCommand myCommand = new SqlCommand("CREATE DATABASE dbReformator", sqlConnection);
                await myCommand.ExecuteNonQueryAsync();
                MessageBox.Show("База данных СОЗДАНА");
            };
            MessageBox.Show("Между созданием БД И Таблица");
            using (SqlConnection sqlConnection2 = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=dbReformator;Trusted_Connection=True;")) //Database=testdb1
            {
                MessageBox.Show("Перед созданием Таблица ");
                string str = "CREATE TABLE Register (Id_user INTEGER NULL, Login_user nvarchar(2048) NULL, Password_user NVARCHAR(2048) NULL);";
                await sqlConnection2.OpenAsync();
                SqlCommand myCommand2 = new SqlCommand(str, sqlConnection2);
                await myCommand2.ExecuteNonQueryAsync();
                MessageBox.Show("Таблица СОЗДАНА");
                Console.WriteLine("Таблица Users создана");
            };
                             
                       
    

        }
        public void openConnection()
        {

            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
