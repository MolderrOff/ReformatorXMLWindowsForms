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
    //было "Data Source=MOLDERR-PC\SQLEXPRESS;Initial Catalog=test;Integrated Security=True"
    internal class DataBase
    {
        
        SqlConnection sqlConnection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=testdb1;Trusted_Connection=True;");

        public bool CheckDB()
        {
            //SqlConnection myConnection = new SqlConnection(sqlConnection);
            try
            {
                openConnection();
                //sqlConnection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task createMyDataBase()
        {
            //DataBase database = new DataBase();
            ////SqlConnection sqlConnection = new SqlConnection();
            ////sqlConnection.ConnectionString = @"Server=localhost\SQLEXPRESS;Database=testdb1;Trusted_Connection=True;";
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=localhost\SQLEXPRESS;Trusted_Connection=True;")) //@"Server=localhost\SQLEXPRESS;Trusted_Connection=True;"
            {
                await sqlConnection.OpenAsync();
                SqlCommand myCommand = new SqlCommand("CREATE DATABASE testdb1", sqlConnection);
                await myCommand.ExecuteNonQueryAsync();
                MessageBox.Show("База данных СОЗДАНА");
            };
            MessageBox.Show("Между созданием БД И Таблица");
            using (SqlConnection sqlConnection2 = new SqlConnection(@"Server=localhost\SQLEXPRESS;Database=testdb1;Trusted_Connection=True;"))
            {
                MessageBox.Show("Перед созданием Таблица ");
                string str = "CREATE TABLE Register (Id_user INTEGER NULL, Login_user nvarchar(2048) NULL, Password_user NVARCHAR(2048) NULL);";
                await sqlConnection2.OpenAsync();
                SqlCommand myCommand2 = new SqlCommand(str, sqlConnection2);
                await myCommand2.ExecuteNonQueryAsync();
                MessageBox.Show("Таблица СОЗДАНА");
                Console.WriteLine("Таблица Users создана");
            };
                             
                       
            //sqlConnection.Close();
            
            //DataTable register = new DataTable();

            //SqlDataAdapter adapter2 = new SqlDataAdapter(myCommand2);
            //adapter2.Fill(register);
            //sqlConnection2.Close();

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
