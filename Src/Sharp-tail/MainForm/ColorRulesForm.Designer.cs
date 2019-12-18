namespace MainForm
{
    partial class ColorRulesForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFilterText = new System.Windows.Forms.TextBox();
            this.buttonFrontColor = new System.Windows.Forms.Button();
            this.buttonBackColor = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.listViewColorRules = new System.Windows.Forms.ListView();
            this.Header = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkBoxCase = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 483);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text:";
            // 
            // textBoxFilterText
            // 
            this.textBoxFilterText.Location = new System.Drawing.Point(78, 481);
            this.textBoxFilterText.Name = "textBoxFilterText";
            this.textBoxFilterText.Size = new System.Drawing.Size(516, 31);
            this.textBoxFilterText.TabIndex = 2;
            // 
            // buttonFrontColor
            // 
            this.buttonFrontColor.Location = new System.Drawing.Point(17, 525);
            this.buttonFrontColor.Name = "buttonFrontColor";
            this.buttonFrontColor.Size = new System.Drawing.Size(165, 66);
            this.buttonFrontColor.TabIndex = 3;
            this.buttonFrontColor.Text = "Front-Color";
            this.buttonFrontColor.UseVisualStyleBackColor = true;
            this.buttonFrontColor.Click += new System.EventHandler(this.buttonFrontColor_Click);
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.Location = new System.Drawing.Point(188, 525);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(165, 66);
            this.buttonBackColor.TabIndex = 4;
            this.buttonBackColor.Text = "Back-Color";
            this.buttonBackColor.UseVisualStyleBackColor = true;
            this.buttonBackColor.Click += new System.EventHandler(this.buttonBackColor_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(359, 527);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(149, 66);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Add";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(695, 527);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(159, 66);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(514, 527);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(175, 66);
            this.buttonRemove.TabIndex = 7;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // listViewColorRules
            // 
            this.listViewColorRules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Header});
            this.listViewColorRules.Dock = System.Windows.Forms.DockStyle.Top;
            this.listViewColorRules.FullRowSelect = true;
            this.listViewColorRules.GridLines = true;
            this.listViewColorRules.HideSelection = false;
            this.listViewColorRules.Location = new System.Drawing.Point(0, 0);
            this.listViewColorRules.MultiSelect = false;
            this.listViewColorRules.Name = "listViewColorRules";
            this.listViewColorRules.Size = new System.Drawing.Size(854, 463);
            this.listViewColorRules.TabIndex = 8;
            this.listViewColorRules.UseCompatibleStateImageBehavior = false;
            this.listViewColorRules.View = System.Windows.Forms.View.Details;
            // 
            // Header
            // 
            this.Header.Text = "Current rules";
            this.Header.Width = 30000;
            // 
            // checkBoxCase
            // 
            this.checkBoxCase.AutoSize = true;
            this.checkBoxCase.Location = new System.Drawing.Point(600, 483);
            this.checkBoxCase.Name = "checkBoxCase";
            this.checkBoxCase.Size = new System.Drawing.Size(173, 29);
            this.checkBoxCase.TabIndex = 9;
            this.checkBoxCase.Text = "Case sensitiv";
            this.checkBoxCase.UseVisualStyleBackColor = true;
            // 
            // ColorRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 605);
            this.Controls.Add(this.checkBoxCase);
            this.Controls.Add(this.listViewColorRules);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonBackColor);
            this.Controls.Add(this.buttonFrontColor);
            this.Controls.Add(this.textBoxFilterText);
            this.Controls.Add(this.label1);
            this.Name = "ColorRulesForm";
            this.Text = "Set color rules";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFilterText;
        private System.Windows.Forms.Button buttonFrontColor;
        private System.Windows.Forms.Button buttonBackColor;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ListView listViewColorRules;
        private System.Windows.Forms.ColumnHeader Header;
        private System.Windows.Forms.CheckBox checkBoxCase;
    }
}