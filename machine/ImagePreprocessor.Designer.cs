namespace Doo.Machine
{
    partial class ImagePreprocessor
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
            this.detectMotionCheckBox = new System.Windows.Forms.CheckBox();
            this.outputSizeComboBox = new System.Windows.Forms.ComboBox();
            this.inputSizeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // detectMotionCheckBox
            // 
            this.detectMotionCheckBox.AutoSize = true;
            this.detectMotionCheckBox.Enabled = false;
            this.detectMotionCheckBox.Location = new System.Drawing.Point(12, 41);
            this.detectMotionCheckBox.Name = "detectMotionCheckBox";
            this.detectMotionCheckBox.Size = new System.Drawing.Size(92, 17);
            this.detectMotionCheckBox.TabIndex = 8;
            this.detectMotionCheckBox.Text = "Detect motion";
            this.detectMotionCheckBox.UseVisualStyleBackColor = true;
            this.detectMotionCheckBox.CheckedChanged += new System.EventHandler(this.detectMotionCheckBox_CheckedChanged);
            // 
            // outputSizeComboBox
            // 
            this.outputSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.outputSizeComboBox.FormattingEnabled = true;
            this.outputSizeComboBox.Location = new System.Drawing.Point(149, 12);
            this.outputSizeComboBox.Name = "outputSizeComboBox";
            this.outputSizeComboBox.Size = new System.Drawing.Size(92, 21);
            this.outputSizeComboBox.TabIndex = 7;
            // 
            // inputSizeLabel
            // 
            this.inputSizeLabel.AutoSize = true;
            this.inputSizeLabel.Location = new System.Drawing.Point(10, 15);
            this.inputSizeLabel.Name = "inputSizeLabel";
            this.inputSizeLabel.Size = new System.Drawing.Size(124, 13);
            this.inputSizeLabel.TabIndex = 6;
            this.inputSizeLabel.Text = "Preprocess image to size";
            // 
            // ImagePreprocessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 69);
            this.Controls.Add(this.detectMotionCheckBox);
            this.Controls.Add(this.outputSizeComboBox);
            this.Controls.Add(this.inputSizeLabel);
            this.Name = "ImagePreprocessor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Image preprocessor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox detectMotionCheckBox;
        private System.Windows.Forms.ComboBox outputSizeComboBox;
        private System.Windows.Forms.Label inputSizeLabel;
    }
}