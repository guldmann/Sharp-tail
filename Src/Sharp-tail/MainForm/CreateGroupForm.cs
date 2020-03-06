using System;
using System.Windows.Forms;

namespace MainForm
{
    public partial class CreateGroupForm : Form
    {

        public string name; 

        public CreateGroupForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxGroupName.Text))
            {
                textBoxGroupName.Focus();
                MessageBox.Show("You need to enter a group name");
                return;
            }

            name = textBoxGroupName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
