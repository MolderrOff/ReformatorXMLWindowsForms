using System;
using System.Collections.Generic;
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
using net.sf.saxon.functions;

namespace for_video
{
    public class Transformation
    {
        public static void Trans()
        {
            // Пути к файлам
            string inputFile = "Data1.xml"; //"Data1.xml";
            string xsltFile = "Employees.xslt"; //Employees.xslt;
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
            //чтение файла, десериализация
            Employees employeesRec = new Employees();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employees));

            using (FileStream fs = new FileStream("Employees.xml", FileMode.OpenOrCreate))
            {

                Employees newemployees = xmlSerializer.Deserialize(fs) as Employees;
                
                if (newemployees != null)
                {
                    Console.WriteLine("-- newemployees != null --");

                    //Console.WriteLine($"Объект Name  = {newemployees.Employee[0].Name}");
                    //Console.WriteLine($"Объект Surname  = {newemployees.Employee[0].Surname}");
                    xmlSerializer.Serialize(Console.Out, newemployees); //Здесь ! проверка дублирования
                    Console.Read();
                }

            
            Console.WriteLine("Подсчёт зарплаты за квартал:");
                newemployees.Employee[0].QuarterAmount =
                    newemployees.Employee[0].salary[0].Amount +
                    newemployees.Employee[0].salary[1].Amount +
                    newemployees.Employee[0].salary[2].Amount;
                newemployees.Employee[1].QuarterAmount =
                    newemployees.Employee[1].salary[0].Amount +
                    newemployees.Employee[1].salary[1].Amount +
                    newemployees.Employee[1].salary[2].Amount;




                xmlSerializer.Serialize(fs, newemployees);
                MessageBox.Show(" Подсчитана зарплата за квартал в файле: \r Дописан в элемент Employee атрибут - сумму всех amount/@salary в файле \r" + outputFile);
            }



        }
    }
}
    