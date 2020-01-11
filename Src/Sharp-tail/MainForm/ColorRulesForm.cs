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

        private ColorRule selectedColorRule = null;
        private ColorRule newColorRule = null;


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
                listViewColorRules.Items[line].BackColor = GetColorFromRuleColor(rule.Background);
                listViewColorRules.Items[line].ForeColor = GetColorFromRuleColor(rule.ForeGround);
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
            //if (selectedColorRule != null)
            //{
            //    selectedColorRule = new ColorRule
            //    {
            //        Background = GetRuleColor(Color.White),
            //        ForeGround = GetRuleColor(Color.Black),
            //        Casesensitiv = false,
            //        Text = ""

            //    };
            //    newColorRule = selectedColorRule;
            //}

            //int line = listViewColorRules.Items.Count;
            //listViewColorRules.Items.Add(textBoxFilterText.Text);


            int line = listViewColorRules.Items.Count;
            listViewColorRules.Items.Add(textBoxFilterText.Text);
            listViewColorRules.Items[line].BackColor = textBoxFilterText.BackColor;
            listViewColorRules.Items[line].ForeColor = textBoxFilterText.ForeColor;

            ColorRules.Add(new ColorRule
            {
                Text = textBoxFilterText.Text,
                Casesensitiv = checkBoxCase.Checked,
                Background = GetRuleColor(textBoxFilterText.BackColor),
                ForeGround = GetRuleColor(textBoxFilterText.ForeColor),
            });
            textBoxFilterText.BackColor = Color.White;
            textBoxFilterText.ForeColor = Color.Black;
            textBoxFilterText.Text = "";
        }

        private RuleColor GetRuleColor(Color color)
        {
            return new RuleColor
            {
                R = color.R,
                G = color.G,
                B = color.B
            };
        }

        private Color GetColorFromRuleColor(RuleColor ruleColor)
        {
            return Color.FromArgb(ruleColor.R, ruleColor.G, ruleColor.B);
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

        private void ColorRulesForm_Load(object sender, EventArgs e)
        {
           
        }

        private void listViewColorRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listViewColorRules.SelectedIndices.Count >= 1)
            //{
            //    var index = listViewColorRules.SelectedIndices[0];
            //    selectedColorRule = ColorRules[index];
            //    textBoxFilterText.Text = selectedColorRule.Text;
            //    textBoxFilterText.ForeColor = GetColorFromRuleColor(selectedColorRule.ForeGround);
            //    textBoxFilterText.BackColor = GetColorFromRuleColor(selectedColorRule.Background);
            //}
        }
    }
}
