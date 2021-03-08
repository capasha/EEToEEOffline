﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsernameScraper
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool AllocConsole();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Count() > 1)
            {

            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            
            
        }

    }
    
}
