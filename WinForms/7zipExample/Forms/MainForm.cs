using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using static _7zipExample.LoggerClass;

namespace _7zipExample
{
    //https://thedeveloperblog.com/7-zip-examples
    //https://www.7-zip.org/faq.html
    //https://ourcodeworld.com/articles/read/890/how-to-solve-csharp-exception-current-thread-must-be-set-to-single-thread-apartment-sta-mode-before-ole-calls-can-be-made-ensure-that-your-main-function-has-stathreadattribute-marked-on-it
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateFolder()
        {
            try
            {
                //CreatFolder
                string path = Application.StartupPath;
                Directory.CreateDirectory(path + "\\Logs");
                Logger.WriteLine(" *** - Application Started - *** ");
                Logger.WriteLine(" *** CreateDirectory Success [MainForm] ***");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Folder Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Ini()
        {
            try
            {
                toolStripStatusLabel1.Text = "Ready";
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                CreateFolder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Initiate Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Ini();
            menuStrip1.Select();
            menuStrip1.Focus();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //About
            Logger.WriteLine(" *** About Form Clicked [MainForm] *** ");
            Form f = new AboutForm();
            f.ShowDialog();
        }

        private void releaseNotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Release Notes
            Logger.WriteLine(" *** Release Notes Form Clicked [MainForm] *** ");
            Form f = new ReleaseNotesForm();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Single Process
                Logger.WriteLine(" *** Single Process Button Clicked [MainForm] ***");
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " ### NEW PROCESS INITIATED ! ###" + Environment.NewLine);
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** Single Process Starting... " + Environment.NewLine);
                    richTextBox1.ScrollToCaret();
                    string sourceName = textBox1.Text;
                    string targetName = textBox1.Text + ".7z";
                    ProcessStartInfo p = new ProcessStartInfo();
                    p.FileName = Application.StartupPath + "\\External\\7za.exe";
                    p.Arguments = "a -t7z \"" + targetName + "\" \"" + sourceName + "\" -mx=9";
                    p.WindowStyle = ProcessWindowStyle.Hidden;
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** a -t7z \"" + targetName + "\" \"" + sourceName + "\" -mx=9" + Environment.NewLine);
                    richTextBox1.ScrollToCaret();
                    Process x = Process.Start(p);
                    x.WaitForExit();
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** Single Process Completed ! " + Environment.NewLine);
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " ----------------------------------------------- " + Environment.NewLine);
                    richTextBox1.ScrollToCaret();
                }
                else 
                {
                    MessageBox.Show("Please Select A File Name", "Select File Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Single Process Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Bulk file Process
                Logger.WriteLine(" *** Bulk File Process Button Clicked [MainForm] ***");
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " ### NEW PROCESS INITIATED ! ###" + Environment.NewLine);
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** Bulk file Process Starting... " + Environment.NewLine);
                    richTextBox1.ScrollToCaret();
                    string sourceName = textBox2.Text + "\\*";
                    string targetName = textBox2.Text + "\\BulkFiles.7z";
                    ProcessStartInfo p = new ProcessStartInfo();
                    p.FileName = Application.StartupPath + "\\External\\7za.exe";
                    p.Arguments = "a -t7z " + targetName + " " + sourceName;
                    p.WindowStyle = ProcessWindowStyle.Hidden;
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** a -t7z " + targetName + " " + sourceName + Environment.NewLine);
                    richTextBox1.ScrollToCaret();
                    Process x = Process.Start(p);
                    x.WaitForExit();
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** Bulk file Process Completed ! " + Environment.NewLine);
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " ----------------------------------------------- " + Environment.NewLine);
                    richTextBox1.ScrollToCaret();
                }
                else 
                {
                    MessageBox.Show("Please Select A Path Name", "Select Path Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bulk File Process Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //Single Process with password
                Logger.WriteLine(" *** Single Process With Password Button Clicked [MainForm] ***");
                if (!string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " ### NEW PROCESS INITIATED ! ###" + Environment.NewLine);
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** Single Process with password Starting... " + Environment.NewLine);
                    richTextBox1.ScrollToCaret();
                    string sourceName = textBox1.Text;
                    string targetName = textBox1.Text + "WithPassword.7z";
                    if (string.IsNullOrWhiteSpace(textBox3.Text))
                    {
                        MessageBox.Show(" Please enter a password ! ", " Set Password Error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** Single Process with password Fail: no password given " + Environment.NewLine);
                        richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " ----------------------------------------------- " + Environment.NewLine);
                        richTextBox1.ScrollToCaret();
                        return;
                    }
                    else
                    {
                        string Secret = textBox3.Text;
                        ProcessStartInfo p = new ProcessStartInfo();
                        p.FileName = Application.StartupPath + "\\External\\7za.exe";
                        p.Arguments = "a -t7z " + targetName + " " + sourceName + " -p" + Secret + " -mhe";
                        p.WindowStyle = ProcessWindowStyle.Hidden;
                        richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** a -t7z \"" + targetName + "\" \"" + sourceName + "\" -mx=9" + Environment.NewLine);
                        richTextBox1.ScrollToCaret();
                        Process x = Process.Start(p);
                        x.WaitForExit();
                        richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** Single Process with password Completed ! " + Environment.NewLine);
                        richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " ----------------------------------------------- " + Environment.NewLine);
                        richTextBox1.ScrollToCaret();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select A File Name", "Select File Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Single Process With Password Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //Bulk file Process with password
                Logger.WriteLine(" *** Bulk File Process With Password Button Clicked [MainForm] ***");
                if (!string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " ### NEW PROCESS INITIATED ! ###" + Environment.NewLine);
                    richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** Bulk file Process with password Starting... " + Environment.NewLine);
                    richTextBox1.ScrollToCaret();
                    string sourceName = textBox2.Text + "\\*";
                    string targetName = textBox2.Text + "\\BulkFilesWithPassword.7z";
                    if (string.IsNullOrWhiteSpace(textBox4.Text))
                    {
                        MessageBox.Show(" Please enter a password ! ", " Set Password Error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** Bulk file Process with password Fail: no password given " + Environment.NewLine);
                        richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " ----------------------------------------------- " + Environment.NewLine);
                        richTextBox1.ScrollToCaret();
                        return;
                    }
                    else
                    {
                        string Secret = textBox4.Text;
                        ProcessStartInfo p = new ProcessStartInfo();
                        p.FileName = Application.StartupPath + "\\External\\7za.exe";
                        p.Arguments = "a -t7z " + targetName + " " + sourceName + " -p" + Secret + " -mhe";
                        p.WindowStyle = ProcessWindowStyle.Hidden;
                        richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** a -t7z " + targetName + " " + sourceName + Environment.NewLine);
                        richTextBox1.ScrollToCaret();
                        Process x = Process.Start(p);
                        x.WaitForExit();
                        richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** Bulk file Process with password Completed ! " + Environment.NewLine);
                        richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " ----------------------------------------------- " + Environment.NewLine);
                        richTextBox1.ScrollToCaret();
                    }
                }
                else
                {
                    MessageBox.Show("Please Select A Path Name", "Select Path Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bulk file Process with password Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = "";
                Thread t = new Thread(() =>
                {
                    //File Selected
                    Logger.WriteLine(" *** File Selected Clicked [MainForm] *** ");
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog1.FileName;
                    }
                });

                // Run your code from a thread that joins the STA Thread
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
                textBox1.Text = filePath;
                textBox1.ReadOnly = true;
                richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** File Selected: " + filePath + Environment.NewLine);
                richTextBox1.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Selected Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            try
            {
                string folderPath = "";
                Thread t = new Thread(() =>
                {
                    //Path Selected 
                    Logger.WriteLine(" *** Path Selected Clicked [MainForm] *** ");
                    OpenFileDialog folderBrowser = new OpenFileDialog();
                    folderBrowser.ValidateNames = false;
                    folderBrowser.CheckFileExists = false;
                    folderBrowser.CheckPathExists = true;
                    folderBrowser.FileName = "Folder Selection.";
                    if (folderBrowser.ShowDialog() == DialogResult.OK)
                    {
                        folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                    }

                });

                // Run your code from a thread that joins the STA Thread
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
                textBox2.Text = folderPath;
                textBox2.ReadOnly = true;
                richTextBox1.AppendText("[" + DateTime.Now.ToString() + "] : " + " *** Path Selected: " + folderPath + Environment.NewLine);
                richTextBox1.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Path Selected Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            try
            {
                //show password box
                Logger.WriteLine(" *** Show Password Box Check Changed Single File [MainForm] ***");
                if (checkBox1.Checked)
                {
                    textBox3.Enabled = true;
                }
                else
                {
                    textBox3.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Set Password Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            try
            {
                //show password box
                Logger.WriteLine(" *** Show Password Box Check Changed Bulk File [MainForm] ***");
                if (checkBox2.Checked)
                {
                    textBox4.Enabled = true;
                }
                else
                {
                    textBox4.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Set Password Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void zipVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Version Form
            Logger.WriteLine(" *** Version Form Clicked [MainForm] *** ");
            Form f = new _7zipVersionForm();
            f.ShowDialog();
        }
    }
}
