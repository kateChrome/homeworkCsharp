using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 1 && Int32.TryParse(args[0], out int inputParameter) && inputParameter % 2 == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainFrom(inputParameter));
            }
            else
            {

                Console.WriteLine(@"Usage: ./Task2.exe [some even number]");
            }
        }
    }
}
