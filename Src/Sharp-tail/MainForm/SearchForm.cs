using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForm
{
    public partial class SearchForm : Form
    {
        public delegate void CloseEvent();

        public CloseEvent WindowClosed;

        public string SearchWord = "";

        public SearchForm()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchWord = textBox1.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void SearchForm_Leave(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            Close();
        }

        private void SearchForm_Deactivate(object sender, EventArgs e)
        {
            SearchWord = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            WindowClosed();
        }
    }
}