using System;
using System.Collections.Generic;
using ListBoxControl.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Common.Helpers;
using Serilog.Core;

namespace MainForm.Extension
{
    public static class TabPageExtension
    {
        /// <summary>
        /// Set text-box in tab page to update
        /// </summary>
        /// <param name="page"></param>
        /// <param name="control"></param>
        /// <returns></returns>
        public static TabPage Update(this TabPage page, TabControl control)
        {
            if (!page.Focused)
            {
                var host = (ElementHost)page.Controls[0];
                var textBox = (MainTextBox)host.Child;
                textBox.Updated = true;
            }
            page.Refresh();
            control.Refresh();
            return page;
        }

        /// <summary>
        /// remove all resources from a tab. to free memory
        /// NOTE: this is not working...
        /// </summary>
        /// <param name="page"></param>
        public static void Clean(this TabPage page)
        {
            var host = (ElementHost)page.Controls[0];
            var textBox = (MainTextBox)host.Child;
            textBox.Dispose();
            page.Dispose();
            host.Controls.Clear();
        }
    }
}