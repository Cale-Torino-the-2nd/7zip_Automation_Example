using System;
using System.IO;
using System.Windows.Forms;

namespace _7zipExample
{
    class LoggerClass
    {
        public static class Logger
        {
            //private static string LogFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Hex_Traccar\\Logs\\Hex_Traccar_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".log";
            private static string LogFile = Application.StartupPath + "\\Logs\\7zipExample_" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".log";

            public static void WriteLine(string txt)
            {
                try
                {
                    File.AppendAllText(LogFile, "[" + DateTime.Now.ToString() + "] : " + txt + "\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Could Not Append Text To Log File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            public static void DeleteLog()
            {
                try
                {
                    File.Delete(LogFile);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Could Not Delete Log File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
    }
}
