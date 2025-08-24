using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace for_video
{
    public partial class ListEmployees : Form
    {
        public ListEmployees()
        {
            InitializeComponent();
            LoadDataEmp();
        }

        private void ListEmployees_Load(object sender, EventArgs e)
        {

        }
        private void LoadDataEmp()
        {
            // Настройка столбцов
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].Name = "Surname";
            dataGridView1.Columns[2].Name = "Amount";
            dataGridView1.Columns[3].Name = "Mount";
            // Добавление строк 
            string[,] employeesList = new string[6,4];

            try
            {
                for (int i = 0; i < 6; i++)
                {
                employeesList[i, 0] = (Transformation.payDouble.item[i].Name).ToString();
                employeesList[i, 1] = (Transformation.payDouble.item[i].Surname).ToString();
                employeesList[i, 2] = (Transformation.payDouble.item[i].Amount).ToString();
                employeesList[i, 3] = (Transformation.payDouble.item[i].Mount).ToString();
                }
            }
            catch
            {
                MessageBox.Show("Невозможно отобразить, сначала \t В исходный файл Data1.xml в элемент Pay " +
                    "дописывает атрибут, который отражает сумму всех amount");
            }   
            
            string[] row1 = new string[] { employeesList[0, 0], employeesList[0, 1], employeesList[0, 2], employeesList[0, 3] };
            dataGridView1.Rows.Add(row1);            
            for (int i = 1; i < 6; i++)            
            {
                row1 = new string[] { employeesList[i, 0], employeesList[i, 1], employeesList[i, 2], employeesList[i, 3] };
                dataGridView1.Rows.Add(row1);
            }           

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
