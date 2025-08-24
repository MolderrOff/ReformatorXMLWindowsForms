using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;
using for_video;


namespace for_video
{

    public class Transformation
    {
        /// <summary>
        /// XSLT преобразование, создание файла  employees.xml
        /// </summary>
        public static void Trans()
        {
            string inputFile = "Data1.xml"; 
            string xsltFile = "Employees.xslt"; 
            string outputFile = "Employees.xml";

            try
            {
                // Создание объекта XmlDocument для входного XML-файла
                XmlDocument doc = new XmlDocument();
                doc.Load(inputFile);

                // Создание объекта XslCompiledTransform для XSLT преобразования
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(xsltFile);

                // Создание XmlWriter для записи выходного XML-файла
                using (XmlWriter writer = XmlWriter.Create(outputFile, xslt.OutputSettings))
                {
                    // Применение XSLT преобразования
                    xslt.Transform(doc, writer);
                }
                MessageBox.Show("На основе Data1.xml построен файл: \r" + outputFile);
                Console.WriteLine("Преобразование успешно завершено. Результат сохранен в " + outputFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при преобразовании: " + ex.Message);
            }
        }
        public static void RecordSalary()
        {
            string outputFile = "Employees.xml";
            Employees employeesRec = new Employees();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employees));

            Employees employeesDouble = new Employees();

            employeesDouble.Employee = new Employee[2];
            employeesDouble.Employee[0] = new Employee();
            employeesDouble.Employee[1] = new Employee();
            employeesDouble.Employee[0].name = "test";
            employeesDouble.Employee[0].surname = "test";
            employeesDouble.Employee[0].quarteramount = 100;
            employeesDouble.Employee[1].name = "test1";
            employeesDouble.Employee[1].surname = "test1";
            employeesDouble.Employee[1].quarteramount = 100;

            employeesDouble.Employee[0].salary = new Salary[3];
            employeesDouble.Employee[0].salary[0] = new Salary();
            employeesDouble.Employee[0].salary[1] = new Salary();
            employeesDouble.Employee[0].salary[2] = new Salary();

            employeesDouble.Employee[1].salary = new Salary[3];
            employeesDouble.Employee[1].salary[0] = new Salary();
            employeesDouble.Employee[1].salary[1] = new Salary();
            employeesDouble.Employee[1].salary[2] = new Salary();


            for (int i = 0; i < 3; i++)
            {
                employeesDouble.Employee[0].salary[i].Amount = 100;
                employeesDouble.Employee[0].salary[i].Mount = "test";
                employeesDouble.Employee[1].salary[i].Amount = 100;
                employeesDouble.Employee[1].salary[i].Mount = "test";
            }

            using (FileStream fs = new FileStream("Employees.xml", FileMode.OpenOrCreate))
            {

                Employees newemployees = xmlSerializer.Deserialize(fs) as Employees;

                if (newemployees != null)
                {
                    Console.WriteLine("До сериализации");
                    ////xmlSerializer.Serialize(fs, newemployees);  //Console.Out

                    Console.WriteLine("завершено xmlSerializer.Serialize(Console.Out, newemployees); ");
                    Console.WriteLine("");
                    Console.WriteLine($"newemployees.Employee[0].Name  = >> {newemployees.Employee[0].name} << ");
                    Console.WriteLine($"newemployees.Employee[0].salary[0].Amount  = >>{newemployees.Employee[0].salary[0].Amount}<< ");


                    Console.WriteLine($"newemployees.Employee[0].Surname  = {newemployees.Employee[0].surname}");
                    Console.WriteLine($"newemployees.Employee[0].QuarterAmount  = {newemployees.Employee[0].quarteramount}");
                 
                    Console.WriteLine("");
                    Console.WriteLine("Подсчёт зарплаты за квартал:");
                    newemployees.Employee[0].quarteramount =
                    newemployees.Employee[0].salary[0].Amount +
                    newemployees.Employee[0].salary[1].Amount +
                    newemployees.Employee[0].salary[2].Amount;
                    newemployees.Employee[1].quarteramount =
                    newemployees.Employee[1].salary[0].Amount +
                    newemployees.Employee[1].salary[1].Amount +
                    newemployees.Employee[1].salary[2].Amount;
                }

                employeesDouble.Employee[0].name = newemployees.Employee[0].name;
                employeesDouble.Employee[0].surname = newemployees.Employee[0].surname;
                employeesDouble.Employee[0].quarteramount = newemployees.Employee[0].quarteramount;

                employeesDouble.Employee[1].name = newemployees.Employee[1].name;
                employeesDouble.Employee[1].surname = newemployees.Employee[1].surname;
                employeesDouble.Employee[1].quarteramount = newemployees.Employee[1].quarteramount;


                for (int i = 0; i < 3; i++)
                {
                    employeesDouble.Employee[0].salary[i].Amount = newemployees.Employee[0].salary[i].Amount;
                    employeesDouble.Employee[1].salary[i].Amount = newemployees.Employee[1].salary[i].Amount;
                    employeesDouble.Employee[0].salary[i].Mount = newemployees.Employee[0].salary[i].Mount;
                    employeesDouble.Employee[1].salary[i].Mount = newemployees.Employee[1].salary[i].Mount;
                }
            }



            File.WriteAllText("Employees.xml", String.Empty);
            using (FileStream fs = new FileStream("Employees.xml", FileMode.OpenOrCreate))
            {

                xmlSerializer.Serialize(fs, employeesDouble);
                MessageBox.Show(" Подсчитана зарплата за квартал в файле \r Дописан в элемент <Employee> атрибут <quarteramount> - сумма всех <amount/@salary> в файле: " + outputFile);

            }
        }

        public static void SumAmount()
        {
            string inputFile = "Data1.xml";
            Pay pay = new Pay();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Pay));

            Pay payDouble = new Pay();

            payDouble.AllMount = 0;
            payDouble.item = new Item[6];
            for (int i = 0; i < 6; i++)
            {
                payDouble.item[i] = new Item(); //???
                payDouble.item[i].Name = "testName";
                payDouble.item[i].Surname = "testSur";
                payDouble.item[i].Amount = 0;
                payDouble.item[i].Mount = "testMount";
            }

            using (FileStream fs = new FileStream(inputFile, FileMode.OpenOrCreate))
            {
                Pay newpay = xmlSerializer.Deserialize(fs) as Pay;

                Console.WriteLine("Подсчёт начислений AllMount за все месяц mount:");
                double allmount = 0;
                if (newpay != null)
                {
                    
                    for (int i = 0; i < 6; i++) 
                    {
                        allmount = allmount + newpay.item[i].Amount;
                    }
                    newpay.AllMount = allmount;
                }
                Console.WriteLine($"Начислений AllMount = {allmount.ToString()}");

                payDouble.AllMount = newpay.AllMount;
                for (int i = 0; i < 6; i++)
                {
                    payDouble.item[i].Name = newpay.item[i].Name;
                    payDouble.item[i].Surname = newpay.item[i].Surname;
                    payDouble.item[i].Amount = newpay.item[i].Amount;
                    payDouble.item[i].Mount = newpay.item[i].Mount;
                }
            }
            File.WriteAllText(inputFile, String.Empty);

            using (FileStream fs = new FileStream(inputFile, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, payDouble);
                MessageBox.Show("Cумма всех <amount> файла Data1.xml подсчитана \r Результат в <AllMount>");
                Console.WriteLine("Cумма всех <amount> подсчитана \r Результат в <AllMount> ");
            }
        }
    }
}
