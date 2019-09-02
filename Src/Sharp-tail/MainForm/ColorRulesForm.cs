using Common.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Common;

namespace MainForm
{
    public partial class ColorRulesForm : Form
    {
        public List<ColorRule> ColorRules { get;}


        public ColorRulesForm(List<ColorRule> colorRules)
        {
            InitializeComponent();
            if (colorRules != null)
            {
                ColorRules = colorRules;
            }
            else
            {
                ColorRules = new List<ColorRule>();
            }

            ListBoxSettings();
        }

        private void ListBoxSettings()
        {
            int line = 0;
            foreach(var rule in ColorRules)
            {
                listViewColorRules.Items.Add(rule.Text);
                listViewColorRules.Items[line].BackColor = Color.FromArgb(
                    rule.Background.R,
                    rule.Background.G,
                    rule.Background.B);
                listViewColorRules.Items[line].ForeColor = Color.FromArgb(
                    rule.ForeGround.R,
                    rule.ForeGround.G,
                    rule.ForeGround.B);
                    line++;
            }
        }

        private void buttonFrontColor_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                textBoxFilterText.ForeColor = colorDialog1.Color;
            }
        }

        private void buttonBackColor_Click(object sender, EventArgs e)
        {
            var result = colorDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBoxFilterText.BackColor = colorDialog1.Color;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int line = listViewColorRules.Items.Count;
            listViewColorRules.Items.Add(textBoxFilterText.Text);
            listViewColorRules.Items[line].BackColor = textBoxFilterText.BackColor;
            listViewColorRules.Items[line].ForeColor = textBoxFilterText.ForeColor;

            ColorRules.Add(new ColorRule
            {
                Text = textBoxFilterText.Text,
                Casesensitiv = checkBoxCase.Checked,
                Background =  new RuleColor
                {
                    R = textBoxFilterText.BackColor.R,
                    G = textBoxFilterText.BackColor.G,
                    B = textBoxFilterText.BackColor.B
                },
                ForeGround = new RuleColor
                {
                    R = textBoxFilterText.ForeColor.R,
                    G = textBoxFilterText.ForeColor.G,
                    B = textBoxFilterText.ForeColor.B
                }
            });
            textBoxFilterText.BackColor = Color.White;
            textBoxFilterText.ForeColor = Color.Black;
            textBoxFilterText.Text = "";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            ColorRules.Save();
            DialogResult =  DialogResult.OK;
            Close();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int index;
            if (listViewColorRules.SelectedIndices.Count >= 1)
            {
                index = listViewColorRules.SelectedIndices[0];
                listViewColorRules.Items.RemoveAt(listViewColorRules.SelectedIndices[0]);
                ColorRules.RemoveAt(index);
                ColorRules.Save();
            }
        }
    }
}
