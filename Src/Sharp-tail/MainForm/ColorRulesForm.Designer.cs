﻿namespace MainForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Text:";
            // 
            // textBoxFilterText
            // 
            this.textBoxFilterText.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxFilterText.Location = new System.Drawing.Point(37, 2);
            this.textBoxFilterText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxFilterText.Name = "textBoxFilterText";
            this.textBoxFilterText.Size = new System.Drawing.Size(260, 20);
            this.textBoxFilterText.TabIndex = 2;
            // 
            // buttonFrontColor
            // 
            this.buttonFrontColor.AutoSize = true;
            this.buttonFrontColor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFrontColor.Location = new System.Drawing.Point(2, 2);
            this.buttonFrontColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFrontColor.Name = "buttonFrontColor";
            this.buttonFrontColor.Size = new System.Drawing.Size(130, 37);
            this.buttonFrontColor.TabIndex = 3;
            this.buttonFrontColor.Text = "Front-Color";
            this.buttonFrontColor.UseVisualStyleBackColor = true;
            this.buttonFrontColor.Click += new System.EventHandler(this.buttonFrontColor_Click);
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.AutoSize = true;
            this.buttonBackColor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBackColor.Location = new System.Drawing.Point(136, 2);
            this.buttonBackColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(126, 37);
            this.buttonBackColor.TabIndex = 4;
            this.buttonBackColor.Text = "Back-Color";
            this.buttonBackColor.UseVisualStyleBackColor = true;
            this.buttonBackColor.Click += new System.EventHandler(this.buttonBackColor_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSize = true;
            this.buttonSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(266, 2);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(74, 37);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Add";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.AutoSize = true;
            this.buttonClose.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(449, 2);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 37);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Save close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.AutoSize = true;
            this.buttonRemove.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(344, 2);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(101, 37);
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
            this.listViewColorRules.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listViewColorRules.MultiSelect = false;
            this.listViewColorRules.Name = "listViewColorRules";
            this.listViewColorRules.Size = new System.Drawing.Size(546, 243);
            this.listViewColorRules.TabIndex = 8;
            this.listViewColorRules.UseCompatibleStateImageBehavior = false;
            this.listViewColorRules.View = System.Windows.Forms.View.Details;
            this.listViewColorRules.SelectedIndexChanged += new System.EventHandler(this.listViewColorRules_SelectedIndexChanged);
            // 
            // Header
            // 
            this.Header.Text = "Current rules";
            this.Header.Width = 30000;
            // 
            // checkBoxCase
            // 
            this.checkBoxCase.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxCase.AutoSize = true;
            this.checkBoxCase.Location = new System.Drawing.Point(301, 3);
            this.checkBoxCase.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxCase.Name = "checkBoxCase";
            this.checkBoxCase.Size = new System.Drawing.Size(88, 17);
            this.checkBoxCase.TabIndex = 9;
            this.checkBoxCase.Text = "Case sensitiv";
            this.checkBoxCase.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.flowLayoutPanel1.Controls.Add(this.buttonFrontColor);
            this.flowLayoutPanel1.Controls.Add(this.buttonBackColor);
            this.flowLayoutPanel1.Controls.Add(this.buttonSave);
            this.flowLayoutPanel1.Controls.Add(this.buttonRemove);
            this.flowLayoutPanel1.Controls.Add(this.buttonClose);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 295);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(531, 43);
            this.flowLayoutPanel1.TabIndex = 10;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.label1);
            this.flowLayoutPanel2.Controls.Add(this.textBoxFilterText);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxCase);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(8, 251);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(464, 41);
            this.flowLayoutPanel2.TabIndex = 11;
            this.flowLayoutPanel2.WrapContents = false;
            // 
            // ColorRulesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(546, 345);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listViewColorRules);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ColorRulesForm";
            this.Text = "Set color rules";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}