using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using for_video;

namespace for_video
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //LoadData();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Transformation.Trans();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transformation.RecordSalary(); //подсчитать сумму всех amount/@salary 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Transformation.SumAmount();
        }  


        private void button4_Click(object sender, EventArgs e)
        {            
            ListEmployees frm1 = new ListEmployees();             
            frm1.ShowDialog();
            this.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox_login_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RewriteData1.RewriteFile();
        }
    }
}
