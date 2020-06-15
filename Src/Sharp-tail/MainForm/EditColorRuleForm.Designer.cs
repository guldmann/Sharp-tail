﻿namespace MainForm
{
    partial class EditColorRuleForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRuleText = new System.Windows.Forms.TextBox();
            this.buttonFrontColor = new System.Windows.Forms.Button();
            this.buttonBackColor = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBoxRuleText);
            this.flowLayoutPanel1.Controls.Add(this.buttonFrontColor);
            this.flowLayoutPanel1.Controls.Add(this.buttonBackColor);
            this.flowLayoutPanel1.Controls.Add(this.buttonSave);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(390, 63);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text";
            // 
            // textBoxRuleText
            // 
            this.textBoxRuleText.Location = new System.Drawing.Point(39, 7);
            this.textBoxRuleText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxRuleText.Name = "textBoxRuleText";
            this.textBoxRuleText.Size = new System.Drawing.Size(302, 20);
            this.textBoxRuleText.TabIndex = 1;
            // 
            // buttonFrontColor
            // 
            this.buttonFrontColor.AutoSize = true;
            this.buttonFrontColor.Location = new System.Drawing.Point(7, 31);
            this.buttonFrontColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFrontColor.Name = "buttonFrontColor";
            this.buttonFrontColor.Size = new System.Drawing.Size(68, 25);
            this.buttonFrontColor.TabIndex = 2;
            this.buttonFrontColor.Text = "Front-Color";
            this.buttonFrontColor.UseVisualStyleBackColor = true;
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.AutoSize = true;
            this.buttonBackColor.Location = new System.Drawing.Point(79, 31);
            this.buttonBackColor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(69, 25);
            this.buttonBackColor.TabIndex = 3;
            this.buttonBackColor.Text = "Back-Color";
            this.buttonBackColor.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.AutoSize = true;
            this.buttonSave.Location = new System.Drawing.Point(152, 31);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(47, 25);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // EditColorRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(400, 73);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditColorRuleForm";
            this.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Text = "Edit Color-Rule";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxRuleText;
        private System.Windows.Forms.Button buttonFrontColor;
        private System.Windows.Forms.Button buttonBackColor;
        private System.Windows.Forms.Button buttonSave;
    }
}