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
            this.closeAllFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemColorRule = new System.Windows.Forms.ToolStripMenuItem();
            this.goToEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.contextMenuStripTabs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAlButThisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItemFilter = new System.Windows.Forms.ToolStripMenuItem();
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 530);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 7, 0);
            this.statusStrip1.Size = new System.Drawing.Size(812, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelName
            // 
            this.toolStripStatusLabelName.Name = "toolStripStatusLabelName";
            this.toolStripStatusLabelName.Size = new System.Drawing.Size(63, 17);
            this.toolStripStatusLabelName.Text = "Name: n/a";
            // 
            // toolStripStatusLabelSize
            // 
            this.toolStripStatusLabelSize.Name = "toolStripStatusLabelSize";
            this.toolStripStatusLabelSize.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabelSize.Text = "Size: 0";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(76, 17);
            this.toolStripStatusLabel1.Text = "Mem Usage: ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItemColorRule,
            this.goToEndToolStripMenuItem,
            this.toolStripMenuItemFilter});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(812, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeAllFilesToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 22);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open File";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeAllFilesToolStripMenuItem
            // 
            this.closeAllFilesToolStripMenuItem.Name = "closeAllFilesToolStripMenuItem";
            this.closeAllFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeAllFilesToolStripMenuItem.Text = "Close All Files";
            this.closeAllFilesToolStripMenuItem.Click += new System.EventHandler(this.closeAllFilesToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItemColorRule
            // 
            this.toolStripMenuItemColorRule.Name = "toolStripMenuItemColorRule";
            this.toolStripMenuItemColorRule.Size = new System.Drawing.Size(76, 22);
            this.toolStripMenuItemColorRule.Text = "Color rules";
            this.toolStripMenuItemColorRule.Click += new System.EventHandler(this.toolStripMenuItemColorRule_Click);
            // 
            // goToEndToolStripMenuItem
            // 
            this.goToEndToolStripMenuItem.Name = "goToEndToolStripMenuItem";
            this.goToEndToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.goToEndToolStripMenuItem.Text = "Go to End";
            this.goToEndToolStripMenuItem.Click += new System.EventHandler(this.goToEndToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(812, 506);
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
            this.reloadFileToolStripMenuItem});
            this.contextMenuStripTabs.Name = "contextMenuStripTabs";
            this.contextMenuStripTabs.Size = new System.Drawing.Size(164, 92);
            // 
            // closeThisToolStripMenuItem
            // 
            this.closeThisToolStripMenuItem.Name = "closeThisToolStripMenuItem";
            this.closeThisToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.closeThisToolStripMenuItem.Text = "Close";
            this.closeThisToolStripMenuItem.Click += new System.EventHandler(this.closeThisToolStripMenuItem_Click);
            // 
            // closeAlToolStripMenuItem
            // 
            this.closeAlToolStripMenuItem.Name = "closeAlToolStripMenuItem";
            this.closeAlToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.closeAlToolStripMenuItem.Text = "Close All";
            this.closeAlToolStripMenuItem.Click += new System.EventHandler(this.closeAlToolStripMenuItem_Click);
            // 
            // closeAlButThisToolStripMenuItem
            // 
            this.closeAlButThisToolStripMenuItem.Name = "closeAlButThisToolStripMenuItem";
            this.closeAlButThisToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.closeAlButThisToolStripMenuItem.Text = "Close All But this";
            this.closeAlButThisToolStripMenuItem.Click += new System.EventHandler(this.closeAlButThisToolStripMenuItem_Click);
            // 
            // reloadFileToolStripMenuItem
            // 
            this.reloadFileToolStripMenuItem.Name = "reloadFileToolStripMenuItem";
            this.reloadFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.reloadFileToolStripMenuItem.Text = "Reload Tab";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripMenuItemFilter
            // 
            this.toolStripMenuItemFilter.BackColor = System.Drawing.Color.Red;
            this.toolStripMenuItemFilter.Name = "toolStripMenuItemFilter";
            this.toolStripMenuItemFilter.Size = new System.Drawing.Size(89, 22);
            this.toolStripMenuItemFilter.Text = "Filter Inactive";
            this.toolStripMenuItemFilter.Click += new System.EventHandler(this.toolStripMenuItemFilter_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 552);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
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
    }
}

