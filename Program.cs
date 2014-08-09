using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace YTPlayer
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
            Form2 f2 = new Form2();
            f2.Hide();
            Application.Run(new Form1());
            Application.Run(f2);
        }
    }
}
