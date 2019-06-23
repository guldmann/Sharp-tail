using System;
using System.IO;
using System.Windows.Forms;

namespace MainForm
{
    public partial class MainForm : Form
    {
        private FileInfo fInfo;
        public MainForm()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }

        private void OpenFileDialog()
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                SetFile(openFileDialog1.FileName);
            }
        }

        private void SetFileAtrubutesToGui()
        {
            toolStripStatusLabelName.Text = "Name: " + fInfo.Name;
            toolStripStatusLabelSize.Text = "Size: " + (fInfo.Length / 1000) + "Kb";
        }

        private void SetFile(string file)
        {
            fInfo = new FileInfo(file);
            SetFileAtrubutesToGui();
            mainTextBox1.SetDataFile(file);
            MainForm_Resize(this, null);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            mainTextBox1.SetSize(mainTextBox1.ActualWidth, mainTextBox1.ActualHeight);
        }
    }
}
