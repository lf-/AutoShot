using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace AutoShot
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var log = new LoggerConfiguration().WriteTo.Console().CreateLogger();
            Log.Logger = log;
            Log.Information("Starting AutoShot...");
            var form = new MainScreen();
            Application.Run(form);
        }
    }
}
