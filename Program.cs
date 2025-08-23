using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using for_video;
using System.Diagnostics;
using Microsoft.Extensions.Logging;


namespace for_video
{ 
    internal static class Program
    {

        [STAThread]
        static void Main()
        {          
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new log_in());

        }
    }
}
