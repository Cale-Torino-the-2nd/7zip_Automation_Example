using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7zipExample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        private static void TrySetCursorsDotHandToSystemHandCursor()
        {
            try
            {
               typeof(Cursors).GetField("hand", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, SystemHandCursor);
            }
            catch 
            {
                
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadCursor(IntPtr hInstance, int lpCursorName);

        private static readonly Cursor SystemHandCursor = new Cursor(LoadCursor(IntPtr.Zero, 32649 /*IDC_HAND*/));
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TrySetCursorsDotHandToSystemHandCursor();
            Application.Run(new MainForm());
        }
    }
}
