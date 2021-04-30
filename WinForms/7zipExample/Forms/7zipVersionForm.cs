using System;
using System.IO;
using System.Windows.Forms;
using static _7zipExample.LoggerClass;

namespace _7zipExample
{
    public partial class _7zipVersionForm : Form
    {
        public _7zipVersionForm()
        {
            InitializeComponent();
        }

        private void _7zipVersionForm_Load(object sender, EventArgs e)
        {
            Logger.WriteLine(" *** 7zip Version Form Show Success [7zipVersionForm] *** ");
            try
            {
                richTextBox1.Text = File.ReadAllText("Textfiles/7zipcommands.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "7zip Version Form Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger.WriteLine(" *** Close Clicked [7zipVersionForm] *** ");
            Close();
        }
    }
}
