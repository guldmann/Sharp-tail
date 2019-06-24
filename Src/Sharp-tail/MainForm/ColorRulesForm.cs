using Common.Models;
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
    public partial class ColorRulesForm : Form
    {
        private RuleColor FronColor;
        private RuleColor BackColor;


        public ColorRulesForm()
        {
            InitializeComponent();
        }

        private void buttonFrontColor_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                textBoxFilterText.ForeColor = colorDialog1.Color;
                FronColor = new RuleColor { R = colorDialog1.Color.R, G = colorDialog1.Color.G, B = colorDialog1.Color.B };

            }
        }

        private void buttonBackColor_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxFilterText.BackColor = colorDialog1.Color;
                BackColor = new RuleColor { R = colorDialog1.Color.R, G = colorDialog1.Color.G, B = colorDialog1.Color.B };

            }
        }
    }
}
