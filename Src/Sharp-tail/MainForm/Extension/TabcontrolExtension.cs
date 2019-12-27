using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Common.Models;
using ListBoxControl.Controls;
using Serilog;
using Serilog.Core;


namespace MainForm.Extension
{
    public static class TabControlExtension
    {
        public static void UpdateTextBoxColorRule(this TabControl tabControl, List<ColorRule> colorRules, ILogger logger )
        {
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                var host = (ElementHost)tabPage.Controls[0];
                var textBox = (MainTextBox)host.Child;
                textBox.UpdateColorRules(colorRules, logger);
            }
        }
    }
}
