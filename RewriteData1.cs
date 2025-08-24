using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace for_video
{
    public class RewriteData1
    {
        static string filePath = @"Data1.xml";
        static string newText = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Pay>\r\n\t<item name=\"Lena\" surname=\"Ivanova\" amount=\"1001.1\" mount=\"march\"/>\r\n\t<item name=\"Lena\" surname=\"Ivanova\" amount=\"2001\" mount=\"january\"/>\r\n\t<item name=\"Lena\" surname=\"Ivanova\" amount=\"3001.10\" mount=\"february\"/>\r\n\t<item name=\"Masha\" surname=\"Ivanova\" amount=\"1000\" mount=\"march\"/>\r\n\t<item name=\"Masha\" surname=\"Ivanova\" amount=\"2000.0\" mount=\"january\"/>\r\n\t<item name=\"Masha\" surname=\"Ivanova\" amount=\"3000\" mount=\"february\"/>\t\r\n</Pay>";
        /// <summary>
        /// Перезаписать файл  Data1.xml эталонной версией
        /// </summary>
        public static void RewriteFile()
        {
            try
            {
                File.WriteAllText(filePath, newText);
                MessageBox.Show("Файл успешно перезаписан!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при перезаписи файла: {ex.Message}");
            }
        }
       
    }
}
