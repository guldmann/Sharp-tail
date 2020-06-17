namespace MainForm
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOpenFilesAsGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemColorRule = new System.Windows.Forms.ToolStripMenuItem();
            this.goToEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStripTabs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAlButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStripTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelName,
            this.toolStripStatusLabelSize,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1062);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1624, 42);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelName
            // 
            this.toolStripStatusLabelName.Name = "toolStripStatusLabelName";
            this.toolStripStatusLabelName.Size = new System.Drawing.Size(126, 32);
            this.toolStripStatusLabelName.Text = "Name: n/a";
            // 
            // toolStripStatusLabelSize
            // 
            this.toolStripStatusLabelSize.Name = "toolStripStatusLabelSize";
            this.toolStripStatusLabelSize.Size = new System.Drawing.Size(83, 32);
            this.toolStripStatusLabelSize.Text = "Size: 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(155, 32);
            this.toolStripStatusLabel1.Text = "Mem Usage: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItemColorRule,
            this.goToEndToolStripMenuItem,
            this.toolStripMenuItemFilter});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1624, 40);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.closeAllFilesToolStripMenuItem,
            this.loadGroupToolStripMenuItem,
            this.saveOpenFilesAsGroupToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(72, 36);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(421, 44);
            this.openToolStripMenuItem.Text = "Open File";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(421, 44);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // closeAllFilesToolStripMenuItem
            // 
            this.closeAllFilesToolStripMenuItem.Name = "closeAllFilesToolStripMenuItem";
            this.closeAllFilesToolStripMenuItem.Size = new System.Drawing.Size(421, 44);
            this.closeAllFilesToolStripMenuItem.Text = "Close All Files";
            this.closeAllFilesToolStripMenuItem.Click += new System.EventHandler(this.closeAllFilesToolStripMenuItem_Click);
            // 
            // loadGroupToolStripMenuItem
            // 
            this.loadGroupToolStripMenuItem.Name = "loadGroupToolStripMenuItem";
            this.loadGroupToolStripMenuItem.Size = new System.Drawing.Size(421, 44);
            this.loadGroupToolStripMenuItem.Text = "Load Group";
            this.loadGroupToolStripMenuItem.Click += new System.EventHandler(this.loadGroupToolStripMenuItem_Click);
            // 
            // saveOpenFilesAsGroupToolStripMenuItem
            // 
            this.saveOpenFilesAsGroupToolStripMenuItem.Name = "saveOpenFilesAsGroupToolStripMenuItem";
            this.saveOpenFilesAsGroupToolStripMenuItem.Size = new System.Drawing.Size(421, 44);
            this.saveOpenFilesAsGroupToolStripMenuItem.Text = "Save Open Files as Group";
            this.saveOpenFilesAsGroupToolStripMenuItem.Click += new System.EventHandler(this.saveOpenFilesAsGroupToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(421, 44);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItemColorRule
            // 
            this.toolStripMenuItemColorRule.Name = "toolStripMenuItemColorRule";
            this.toolStripMenuItemColorRule.Size = new System.Drawing.Size(150, 36);
            this.toolStripMenuItemColorRule.Text = "Color rules";
            this.toolStripMenuItemColorRule.Click += new System.EventHandler(this.toolStripMenuItemColorRule_Click);
            // 
            // goToEndToolStripMenuItem
            // 
            this.goToEndToolStripMenuItem.Name = "goToEndToolStripMenuItem";
            this.goToEndToolStripMenuItem.Size = new System.Drawing.Size(141, 36);
            this.goToEndToolStripMenuItem.Text = "Go to End";
            this.goToEndToolStripMenuItem.Click += new System.EventHandler(this.goToEndToolStripMenuItem_Click);
            // 
            // toolStripMenuItemFilter
            // 
            this.toolStripMenuItemFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItemFilter.BackColor = System.Drawing.Color.Red;
            this.toolStripMenuItemFilter.Checked = true;
            this.toolStripMenuItemFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemFilter.Name = "toolStripMenuItemFilter";
            this.toolStripMenuItemFilter.Size = new System.Drawing.Size(177, 36);
            this.toolStripMenuItemFilter.Text = "Filter Inactive";
            this.toolStripMenuItemFilter.Click += new System.EventHandler(this.toolStripMenuItemFilter_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 22);
            this.tabControl1.Location = new System.Drawing.Point(0, 40);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1624, 1022);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl1_DrawItem);
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseDown);
            // 
            // contextMenuStripTabs
            // 
            this.contextMenuStripTabs.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStripTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeThisToolStripMenuItem,
            this.closeAlToolStripMenuItem,
            this.closeAlButThisToolStripMenuItem,
            this.reloadFileToolStripMenuItem,
            this.renameTabToolStripMenuItem});
            this.contextMenuStripTabs.Name = "contextMenuStripTabs";
            this.contextMenuStripTabs.Size = new System.Drawing.Size(271, 194);
            // 
            // closeThisToolStripMenuItem
            // 
            this.closeThisToolStripMenuItem.Name = "closeThisToolStripMenuItem";
            this.closeThisToolStripMenuItem.Size = new System.Drawing.Size(270, 38);
            this.closeThisToolStripMenuItem.Text = "Close";
            this.closeThisToolStripMenuItem.Click += new System.EventHandler(this.closeThisToolStripMenuItem_Click);
            // 
            // closeAlToolStripMenuItem
            // 
            this.closeAlToolStripMenuItem.Name = "closeAlToolStripMenuItem";
            this.closeAlToolStripMenuItem.Size = new System.Drawing.Size(270, 38);
            this.closeAlToolStripMenuItem.Text = "Close All";
            this.closeAlToolStripMenuItem.Click += new System.EventHandler(this.closeAlToolStripMenuItem_Click);
            // 
            // closeAlButThisToolStripMenuItem
            // 
            this.closeAlButThisToolStripMenuItem.Name = "closeAlButThisToolStripMenuItem";
            this.closeAlButThisToolStripMenuItem.Size = new System.Drawing.Size(270, 38);
            this.closeAlButThisToolStripMenuItem.Text = "Close All But this";
            this.closeAlButThisToolStripMenuItem.Click += new System.EventHandler(this.closeAlButThisToolStripMenuItem_Click);
            // 
            // reloadFileToolStripMenuItem
            // 
            this.reloadFileToolStripMenuItem.Name = "reloadFileToolStripMenuItem";
            this.reloadFileToolStripMenuItem.Size = new System.Drawing.Size(270, 38);
            this.reloadFileToolStripMenuItem.Text = "Reload Tab";
            // 
            // renameTabToolStripMenuItem
            // 
            this.renameTabToolStripMenuItem.Name = "renameTabToolStripMenuItem";
            this.renameTabToolStripMenuItem.Size = new System.Drawing.Size(270, 38);
            this.renameTabToolStripMenuItem.Text = "Rename Tab";
            this.renameTabToolStripMenuItem.Click += new System.EventHandler(this.renameTabToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1624, 1104);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Sharp-tail";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStripTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSize;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        //private ListBoxControl.Controls.MainTextBox mainTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemColorRule;
		private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripMenuItem goToEndToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTabs;
        private System.Windows.Forms.ToolStripMenuItem closeThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAlButThisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFilter;
        private System.Windows.Forms.ToolStripMenuItem renameTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOpenFilesAsGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

