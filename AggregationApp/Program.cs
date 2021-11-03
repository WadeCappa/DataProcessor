using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace AggregationApp
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
            //ThreadStart threadDelegate = new ThreadStart(Work.DoWork);
            //var thread = new Thread(threadDelegate);
            //// allow UI with ApartmentState.STA though [STAThread] above should give that to you
            //thread.TrySetApartmentState(ApartmentState.STA);
            //thread.Start();
            Application.Run(new CleanData());
        }
    }
}
