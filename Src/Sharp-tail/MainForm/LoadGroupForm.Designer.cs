namespace MainForm
{
    partial class LoadGroupForm
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
            this.checkedListBoxGroups = new System.Windows.Forms.CheckedListBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxGroups
            // 
            this.checkedListBoxGroups.FormattingEnabled = true;
            this.checkedListBoxGroups.Location = new System.Drawing.Point(12, 8);
            this.checkedListBoxGroups.Name = "checkedListBoxGroups";
            this.checkedListBoxGroups.Size = new System.Drawing.Size(690, 312);
            this.checkedListBoxGroups.TabIndex = 0;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(38, 344);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(171, 58);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "Load groups";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // LoadGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.checkedListBoxGroups);
            this.Name = "LoadGroupForm";
            this.Text = "LoadGroupForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxGroups;
        private System.Windows.Forms.Button buttonLoad;
    }
}