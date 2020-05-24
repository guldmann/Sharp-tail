using Common.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainForm
{
    public partial class LoadGroupForm : Form
    {
        private Groups _groups;
        public List<string> SelectedGroups = new List<string>();

        public LoadGroupForm(Groups groups)
        {
            InitializeComponent();
            _groups = groups;
            SetGroupListData();
        }

        private void SetGroupListData()
        {
            foreach (var fileGroup in _groups.FileGroups)
            {
                checkedListBoxGroups.Items.Add(fileGroup.GroupName);
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < checkedListBoxGroups.CheckedItems.Count; i++)
            {
                SelectedGroups.Add((string)checkedListBoxGroups.CheckedItems[i]);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}