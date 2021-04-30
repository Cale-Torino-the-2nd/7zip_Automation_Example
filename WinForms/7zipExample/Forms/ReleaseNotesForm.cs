using System;
using System.IO;
using System.Windows.Forms;
using static _7zipExample.LoggerClass;

namespace _7zipExample
{
    public partial class ReleaseNotesForm : Form
    {
        public ReleaseNotesForm()
        {
            InitializeComponent();
        }

        private void ReleaseNotesForm_Load(object sender, EventArgs e)
        {
            Logger.WriteLine(" *** Release Notes Form Show Success [ReleaseNotesForm] *** ");
            try
            {
                richTextBox1.Text = File.ReadAllText("Textfiles/ReleaseNotes.txt");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString(), "ReleaseNotes Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, "ReleaseNotes Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logger.WriteLine(" *** Close Clicked [ReleaseNotesForm] *** ");
            Close();
        }
    }
}
