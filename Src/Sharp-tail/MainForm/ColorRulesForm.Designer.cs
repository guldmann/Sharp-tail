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
            this.listViewColorRules = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFilterText = new System.Windows.Forms.TextBox();
            this.buttonFrontColor = new System.Windows.Forms.Button();
            this.buttonBackColor = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // listViewColorRules
            // 
            this.listViewColorRules.HideSelection = false;
            this.listViewColorRules.Location = new System.Drawing.Point(12, 12);
            this.listViewColorRules.Name = "listViewColorRules";
            this.listViewColorRules.Size = new System.Drawing.Size(595, 455);
            this.listViewColorRules.TabIndex = 0;
            this.listViewColorRules.UseCompatibleStateImageBehavior = false;
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
            this.buttonFrontColor.Size = new System.Drawing.Size(112, 66);
            this.buttonFrontColor.TabIndex = 3;
            this.buttonFrontColor.Text = "Front Color";
            this.buttonFrontColor.UseVisualStyleBackColor = true;
            this.buttonFrontColor.Click += new System.EventHandler(this.buttonFrontColor_Click);
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.Location = new System.Drawing.Point(135, 525);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(121, 66);
            this.buttonBackColor.TabIndex = 4;
            this.buttonBackColor.Text = "Back Color";
            this.buttonBackColor.UseVisualStyleBackColor = true;
            this.buttonBackColor.Click += new System.EventHandler(this.buttonBackColor_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(262, 525);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(116, 66);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(384, 525);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(102, 66);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(492, 525);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(102, 66);
            this.buttonRemove.TabIndex = 7;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            // 
            // ColorRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 605);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonBackColor);
            this.Controls.Add(this.buttonFrontColor);
            this.Controls.Add(this.textBoxFilterText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewColorRules);
            this.Name = "ColorRulesForm";
            this.Text = "Set color rules";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewColorRules;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFilterText;
        private System.Windows.Forms.Button buttonFrontColor;
        private System.Windows.Forms.Button buttonBackColor;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}