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
            this.inhibitionRadiusLabel = new System.Windows.Forms.Label();
            this.inhibitionRadiusTextBox = new System.Windows.Forms.TextBox();
            this.correctPredictionLabel = new System.Windows.Forms.Label();
            this.correctPredictionTextBox = new System.Windows.Forms.TextBox();
            this.doTemporalLearningCheckBox = new System.Windows.Forms.CheckBox();
            this.doSpatialLearningCheckBox = new System.Windows.Forms.CheckBox();
            this.showColumnCheckBox = new System.Windows.Forms.CheckBox();
            this.showCellsCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
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
            // doTemporalLearningCheckBox
            // 
            this.doTemporalLearningCheckBox.AutoSize = true;
            this.doTemporalLearningCheckBox.Location = new System.Drawing.Point(132, 32);
            this.doTemporalLearningCheckBox.Name = "doTemporalLearningCheckBox";
            this.doTemporalLearningCheckBox.Size = new System.Drawing.Size(121, 17);
            this.doTemporalLearningCheckBox.TabIndex = 10;
            this.doTemporalLearningCheckBox.Text = "do temporal learning";
            this.doTemporalLearningCheckBox.UseVisualStyleBackColor = true;
            this.doTemporalLearningCheckBox.CheckedChanged += new System.EventHandler(this.doTemporalLearningCheckBox_CheckedChanged);
            // 
            // doSpatialLearningCheckBox
            // 
            this.doSpatialLearningCheckBox.AutoSize = true;
            this.doSpatialLearningCheckBox.Checked = true;
            this.doSpatialLearningCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doSpatialLearningCheckBox.Location = new System.Drawing.Point(13, 32);
            this.doSpatialLearningCheckBox.Name = "doSpatialLearningCheckBox";
            this.doSpatialLearningCheckBox.Size = new System.Drawing.Size(111, 17);
            this.doSpatialLearningCheckBox.TabIndex = 9;
            this.doSpatialLearningCheckBox.Text = "do spatial learning";
            this.doSpatialLearningCheckBox.UseVisualStyleBackColor = true;
            this.doSpatialLearningCheckBox.CheckedChanged += new System.EventHandler(this.doSpatialLearningCheckBox_CheckedChanged);
            // 
            // showColumnCheckBox
            // 
            this.showColumnCheckBox.AutoSize = true;
            this.showColumnCheckBox.Checked = true;
            this.showColumnCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showColumnCheckBox.Location = new System.Drawing.Point(13, 55);
            this.showColumnCheckBox.Name = "showColumnCheckBox";
            this.showColumnCheckBox.Size = new System.Drawing.Size(138, 17);
            this.showColumnCheckBox.TabIndex = 11;
            this.showColumnCheckBox.Text = "refresh column statistics";
            this.showColumnCheckBox.UseVisualStyleBackColor = true;
            this.showColumnCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // showCellsCheckBox
            // 
            this.showCellsCheckBox.AutoSize = true;
            this.showCellsCheckBox.Checked = true;
            this.showCellsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCellsCheckBox.Location = new System.Drawing.Point(13, 247);
            this.showCellsCheckBox.Name = "showCellsCheckBox";
            this.showCellsCheckBox.Size = new System.Drawing.Size(108, 17);
            this.showCellsCheckBox.TabIndex = 12;
            this.showCellsCheckBox.Text = "refresh cells state";
            this.showCellsCheckBox.UseVisualStyleBackColor = true;
            // 
            // HTMRegionViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 314);
            this.Controls.Add(this.showCellsCheckBox);
            this.Controls.Add(this.showColumnCheckBox);
            this.Controls.Add(this.doTemporalLearningCheckBox);
            this.Controls.Add(this.doSpatialLearningCheckBox);
            this.Controls.Add(this.correctPredictionTextBox);
            this.Controls.Add(this.correctPredictionLabel);
            this.Controls.Add(this.inhibitionRadiusTextBox);
            this.Controls.Add(this.inhibitionRadiusLabel);
            this.Name = "HTMRegionViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Region viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label inhibitionRadiusLabel;
        private System.Windows.Forms.TextBox inhibitionRadiusTextBox;
        private System.Windows.Forms.Label correctPredictionLabel;
        private System.Windows.Forms.TextBox correctPredictionTextBox;
        private System.Windows.Forms.CheckBox doTemporalLearningCheckBox;
        private System.Windows.Forms.CheckBox doSpatialLearningCheckBox;
        private System.Windows.Forms.CheckBox showColumnCheckBox;
        private System.Windows.Forms.CheckBox showCellsCheckBox;
    }
}