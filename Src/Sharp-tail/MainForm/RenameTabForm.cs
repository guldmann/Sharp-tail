using System;
using System.Windows.Forms;
using Common.Helpers;

namespace MainForm
{
    public partial class RenameTabForm : Form
    {
        public string tabText; 

        public RenameTabForm(TabPage page)
        {
            InitializeComponent();
            textBoxTabName.Text = page.Text.RemoveCross();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            tabText = textBoxTabName.Text.Truncate();
            DialogResult = DialogResult.OK;

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void textBoxTabName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOk_Click(sender, EventArgs.Empty);
            }
        }
    }
}
