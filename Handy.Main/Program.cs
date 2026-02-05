using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using Handy.Lib;

namespace Handy
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            try
            {
                // Read ID.log content and assign to param
                string[] param = new string[1];
                Logger.GetTextData(Logger.HandyPath, "ID.log", param);
                if (param[0] != null)
                {
                    if (Convert.ToInt32(param[0]) != Process.GetCurrentProcess().Id)
                    {
                        try
                        {
                            //Try kill previous runned process if existing
                            Process.GetProcessById(Convert.ToInt32(param[0])).Kill();
                        }
                        catch
                        { }
                    }
                }
                // Write the current proces ID to ID.log
                param[0] = Process.GetCurrentProcess().Id.ToString();
                Logger.WriteTextData(Logger.HandyPath, "ID.log", param, false);
            }
            catch { }

            Application.Run(new MainWindow());
        }
    }
}