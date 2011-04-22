namespace Doo.Machine.HTM
{
    partial class HTMRegionViewer
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
            this.propertyShowedComboBox = new System.Windows.Forms.ComboBox();
            this.propertyShowedLabel = new System.Windows.Forms.Label();
            this.inhibitionRadiusLabel = new System.Windows.Forms.Label();
            this.inhibitionRadiusTextBox = new System.Windows.Forms.TextBox();
            this.correctPredictionLabel = new System.Windows.Forms.Label();
            this.correctPredictionTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // propertyShowedComboBox
            // 
            this.propertyShowedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.propertyShowedComboBox.FormattingEnabled = true;
            this.propertyShowedComboBox.Location = new System.Drawing.Point(101, 35);
            this.propertyShowedComboBox.Name = "propertyShowedComboBox";
            this.propertyShowedComboBox.Size = new System.Drawing.Size(128, 21);
            this.propertyShowedComboBox.TabIndex = 1;
            this.propertyShowedComboBox.SelectedIndexChanged += new System.EventHandler(this.propertyShowedComboBox_SelectedIndexChanged);
            // 
            // propertyShowedLabel
            // 
            this.propertyShowedLabel.AutoSize = true;
            this.propertyShowedLabel.Location = new System.Drawing.Point(9, 38);
            this.propertyShowedLabel.Name = "propertyShowedLabel";
            this.propertyShowedLabel.Size = new System.Drawing.Size(86, 13);
            this.propertyShowedLabel.TabIndex = 2;
            this.propertyShowedLabel.Text = "Property showed";
            // 
            // inhibitionRadiusLabel
            // 
            this.inhibitionRadiusLabel.AutoSize = true;
            this.inhibitionRadiusLabel.Location = new System.Drawing.Point(9, 9);
            this.inhibitionRadiusLabel.Name = "inhibitionRadiusLabel";
            this.inhibitionRadiusLabel.Size = new System.Drawing.Size(80, 13);
            this.inhibitionRadiusLabel.TabIndex = 3;
            this.inhibitionRadiusLabel.Text = "Inhibition radius";
            // 
            // inhibitionRadiusTextBox
            // 
            this.inhibitionRadiusTextBox.Location = new System.Drawing.Point(92, 6);
            this.inhibitionRadiusTextBox.Name = "inhibitionRadiusTextBox";
            this.inhibitionRadiusTextBox.Size = new System.Drawing.Size(58, 20);
            this.inhibitionRadiusTextBox.TabIndex = 4;
            this.inhibitionRadiusTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // correctPredictionLabel
            // 
            this.correctPredictionLabel.AutoSize = true;
            this.correctPredictionLabel.Location = new System.Drawing.Point(162, 9);
            this.correctPredictionLabel.Name = "correctPredictionLabel";
            this.correctPredictionLabel.Size = new System.Drawing.Size(90, 13);
            this.correctPredictionLabel.TabIndex = 5;
            this.correctPredictionLabel.Text = "Correct prediction";
            // 
            // correctPredictionTextBox
            // 
            this.correctPredictionTextBox.Location = new System.Drawing.Point(259, 9);
            this.correctPredictionTextBox.Name = "correctPredictionTextBox";
            this.correctPredictionTextBox.Size = new System.Drawing.Size(63, 20);
            this.correctPredictionTextBox.TabIndex = 6;
            this.correctPredictionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // HTMRegionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.correctPredictionTextBox);
            this.Controls.Add(this.correctPredictionLabel);
            this.Controls.Add(this.inhibitionRadiusTextBox);
            this.Controls.Add(this.inhibitionRadiusLabel);
            this.Controls.Add(this.propertyShowedLabel);
            this.Controls.Add(this.propertyShowedComboBox);
            this.Name = "HTMRegionViewer";
            this.Size = new System.Drawing.Size(332, 272);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox propertyShowedComboBox;
        private System.Windows.Forms.Label propertyShowedLabel;
        private System.Windows.Forms.Label inhibitionRadiusLabel;
        private System.Windows.Forms.TextBox inhibitionRadiusTextBox;
        private System.Windows.Forms.Label correctPredictionLabel;
        private System.Windows.Forms.TextBox correctPredictionTextBox;
    }
}