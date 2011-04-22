namespace Doo.Machine
{
    partial class AgentControl
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputSizeLabel = new System.Windows.Forms.Label();
            this.inputSizeComboBox = new System.Windows.Forms.ComboBox();
            this.regionSize = new System.Windows.Forms.Label();
            this.regionSizeComboBox = new System.Windows.Forms.ComboBox();
            this.doSpatialLearningCheckBox = new System.Windows.Forms.CheckBox();
            this.doTemporalLearningCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // inputSizeLabel
            // 
            this.inputSizeLabel.AutoSize = true;
            this.inputSizeLabel.Location = new System.Drawing.Point(11, 17);
            this.inputSizeLabel.Name = "inputSizeLabel";
            this.inputSizeLabel.Size = new System.Drawing.Size(88, 13);
            this.inputSizeLabel.TabIndex = 3;
            this.inputSizeLabel.Text = "Region input size";
            // 
            // inputSizeComboBox
            // 
            this.inputSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputSizeComboBox.FormattingEnabled = true;
            this.inputSizeComboBox.Location = new System.Drawing.Point(105, 14);
            this.inputSizeComboBox.Name = "inputSizeComboBox";
            this.inputSizeComboBox.Size = new System.Drawing.Size(92, 21);
            this.inputSizeComboBox.TabIndex = 4;
            // 
            // regionSize
            // 
            this.regionSize.AutoSize = true;
            this.regionSize.Location = new System.Drawing.Point(11, 43);
            this.regionSize.Name = "regionSize";
            this.regionSize.Size = new System.Drawing.Size(62, 13);
            this.regionSize.TabIndex = 5;
            this.regionSize.Text = "Region size";
            // 
            // regionSizeComboBox
            // 
            this.regionSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionSizeComboBox.FormattingEnabled = true;
            this.regionSizeComboBox.Location = new System.Drawing.Point(105, 40);
            this.regionSizeComboBox.Name = "regionSizeComboBox";
            this.regionSizeComboBox.Size = new System.Drawing.Size(92, 21);
            this.regionSizeComboBox.TabIndex = 6;
            // 
            // doSpatialLearningCheckBox
            // 
            this.doSpatialLearningCheckBox.AutoSize = true;
            this.doSpatialLearningCheckBox.Checked = true;
            this.doSpatialLearningCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.doSpatialLearningCheckBox.Location = new System.Drawing.Point(253, 18);
            this.doSpatialLearningCheckBox.Name = "doSpatialLearningCheckBox";
            this.doSpatialLearningCheckBox.Size = new System.Drawing.Size(111, 17);
            this.doSpatialLearningCheckBox.TabIndex = 7;
            this.doSpatialLearningCheckBox.Text = "do spatial learning";
            this.doSpatialLearningCheckBox.UseVisualStyleBackColor = true;
            this.doSpatialLearningCheckBox.CheckedChanged += new System.EventHandler(this.doSpatialLearningCheckBox_CheckedChanged);
            // 
            // doTemporalLearningCheckBox
            // 
            this.doTemporalLearningCheckBox.AutoSize = true;
            this.doTemporalLearningCheckBox.Location = new System.Drawing.Point(253, 42);
            this.doTemporalLearningCheckBox.Name = "doTemporalLearningCheckBox";
            this.doTemporalLearningCheckBox.Size = new System.Drawing.Size(121, 17);
            this.doTemporalLearningCheckBox.TabIndex = 8;
            this.doTemporalLearningCheckBox.Text = "do temporal learning";
            this.doTemporalLearningCheckBox.UseVisualStyleBackColor = true;
            this.doTemporalLearningCheckBox.CheckedChanged += new System.EventHandler(this.doTemporalLearningCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 273);
            this.panel1.TabIndex = 9;
            // 
            // AgentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 361);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.doTemporalLearningCheckBox);
            this.Controls.Add(this.doSpatialLearningCheckBox);
            this.Controls.Add(this.regionSizeComboBox);
            this.Controls.Add(this.regionSize);
            this.Controls.Add(this.inputSizeComboBox);
            this.Controls.Add(this.inputSizeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AgentControl";
            this.Text = "Agent Control";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label inputSizeLabel;
        private System.Windows.Forms.ComboBox inputSizeComboBox;
        private System.Windows.Forms.Label regionSize;
        private System.Windows.Forms.ComboBox regionSizeComboBox;
        private System.Windows.Forms.CheckBox doSpatialLearningCheckBox;
        private System.Windows.Forms.CheckBox doTemporalLearningCheckBox;


        #endregion
        private System.Windows.Forms.Panel panel1;

    }
}