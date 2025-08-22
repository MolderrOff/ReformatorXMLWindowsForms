using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace test_DataBase
{
    internal class Transformation
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

                Console.WriteLine("Преобразование успешно завершено. Результат сохранен в " + outputFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при преобразовании: " + ex.Message);
            }
        }
    }
}
