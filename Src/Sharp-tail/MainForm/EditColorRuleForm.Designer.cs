namespace MainForm
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(780, 120);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text";
            // 
            // textBoxRuleText
            // 
            this.textBoxRuleText.Location = new System.Drawing.Point(73, 13);
            this.textBoxRuleText.Name = "textBoxRuleText";
            this.textBoxRuleText.Size = new System.Drawing.Size(599, 31);
            this.textBoxRuleText.TabIndex = 1;
            // 
            // buttonFrontColor
            // 
            this.buttonFrontColor.AutoEllipsis = true;
            this.buttonFrontColor.AutoSize = true;
            this.buttonFrontColor.Location = new System.Drawing.Point(13, 50);
            this.buttonFrontColor.Name = "buttonFrontColor";
            this.buttonFrontColor.Size = new System.Drawing.Size(130, 49);
            this.buttonFrontColor.TabIndex = 2;
            this.buttonFrontColor.Text = "Front-Color";
            this.buttonFrontColor.UseVisualStyleBackColor = true;
            // 
            // buttonBackColor
            // 
            this.buttonBackColor.AutoEllipsis = true;
            this.buttonBackColor.AutoSize = true;
            this.buttonBackColor.Location = new System.Drawing.Point(149, 50);
            this.buttonBackColor.Name = "buttonBackColor";
            this.buttonBackColor.Size = new System.Drawing.Size(128, 49);
            this.buttonBackColor.TabIndex = 3;
            this.buttonBackColor.Text = "Back-Color";
            this.buttonBackColor.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.AutoEllipsis = true;
            this.buttonSave.AutoSize = true;
            this.buttonSave.Location = new System.Drawing.Point(283, 50);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(94, 49);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // EditColorRuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 140);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "EditColorRuleForm";
            this.Padding = new System.Windows.Forms.Padding(10);
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