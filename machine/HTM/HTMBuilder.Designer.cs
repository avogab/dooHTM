namespace Doo.Machine.HTM
{
    partial class HTMBuilder
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.regionSize = new System.Windows.Forms.Label();
            this.regionSizeComboBox = new System.Windows.Forms.ComboBox();
            this.preprocessGroupBox = new System.Windows.Forms.GroupBox();
            this.minSegmentActivityForLearningTextBox = new System.Windows.Forms.TextBox();
            this.minSegmentActivityForLearningLabel = new System.Windows.Forms.Label();
            this.desiredLocalActivityLabel = new System.Windows.Forms.Label();
            this.desiredLocalActivityTextBox = new System.Windows.Forms.TextBox();
            this.minimumOverlapTextBox = new System.Windows.Forms.TextBox();
            this.segmentActivationThresholdTextBox = new System.Windows.Forms.TextBox();
            this.minimumOverlapLabel = new System.Windows.Forms.Label();
            this.segmentActivationThresholdLabel = new System.Windows.Forms.Label();
            this.structureGroupBox = new System.Windows.Forms.GroupBox();
            this.proximalSegmentCoverageTextBox = new System.Windows.Forms.TextBox();
            this.proximalSegmentCoverageLabel = new System.Windows.Forms.Label();
            this.networkSizeComboBox = new System.Windows.Forms.ComboBox();
            this.networkSizeLabel = new System.Windows.Forms.Label();
            this.preprocessGroupBox.SuspendLayout();
            this.structureGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // regionSize
            // 
            this.regionSize.AutoSize = true;
            this.regionSize.Location = new System.Drawing.Point(10, 59);
            this.regionSize.Name = "regionSize";
            this.regionSize.Size = new System.Drawing.Size(62, 13);
            this.regionSize.TabIndex = 5;
            this.regionSize.Text = "Region size";
            // 
            // regionSizeComboBox
            // 
            this.regionSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionSizeComboBox.FormattingEnabled = true;
            this.regionSizeComboBox.Location = new System.Drawing.Point(204, 56);
            this.regionSizeComboBox.Name = "regionSizeComboBox";
            this.regionSizeComboBox.Size = new System.Drawing.Size(92, 21);
            this.regionSizeComboBox.TabIndex = 6;
            // 
            // preprocessGroupBox
            // 
            this.preprocessGroupBox.Controls.Add(this.minSegmentActivityForLearningTextBox);
            this.preprocessGroupBox.Controls.Add(this.minSegmentActivityForLearningLabel);
            this.preprocessGroupBox.Controls.Add(this.desiredLocalActivityLabel);
            this.preprocessGroupBox.Controls.Add(this.desiredLocalActivityTextBox);
            this.preprocessGroupBox.Controls.Add(this.minimumOverlapTextBox);
            this.preprocessGroupBox.Controls.Add(this.segmentActivationThresholdTextBox);
            this.preprocessGroupBox.Controls.Add(this.minimumOverlapLabel);
            this.preprocessGroupBox.Controls.Add(this.segmentActivationThresholdLabel);
            this.preprocessGroupBox.Location = new System.Drawing.Point(3, 123);
            this.preprocessGroupBox.Name = "preprocessGroupBox";
            this.preprocessGroupBox.Size = new System.Drawing.Size(308, 133);
            this.preprocessGroupBox.TabIndex = 12;
            this.preprocessGroupBox.TabStop = false;
            this.preprocessGroupBox.Text = "On line parameters";
            // 
            // minSegmentActivityForLearningTextBox
            // 
            this.minSegmentActivityForLearningTextBox.Location = new System.Drawing.Point(203, 97);
            this.minSegmentActivityForLearningTextBox.Name = "minSegmentActivityForLearningTextBox";
            this.minSegmentActivityForLearningTextBox.Size = new System.Drawing.Size(33, 20);
            this.minSegmentActivityForLearningTextBox.TabIndex = 20;
            this.minSegmentActivityForLearningTextBox.Text = "3";
            this.minSegmentActivityForLearningTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.minSegmentActivityForLearningTextBox.TextChanged += new System.EventHandler(this.minSegmentActivityForLearningTextBox_TextChanged);
            // 
            // minSegmentActivityForLearningLabel
            // 
            this.minSegmentActivityForLearningLabel.AutoSize = true;
            this.minSegmentActivityForLearningLabel.Location = new System.Drawing.Point(10, 100);
            this.minSegmentActivityForLearningLabel.Name = "minSegmentActivityForLearningLabel";
            this.minSegmentActivityForLearningLabel.Size = new System.Drawing.Size(158, 13);
            this.minSegmentActivityForLearningLabel.TabIndex = 19;
            this.minSegmentActivityForLearningLabel.Text = "Min segment activity for learning";
            // 
            // desiredLocalActivityLabel
            // 
            this.desiredLocalActivityLabel.AutoSize = true;
            this.desiredLocalActivityLabel.Location = new System.Drawing.Point(10, 52);
            this.desiredLocalActivityLabel.Name = "desiredLocalActivityLabel";
            this.desiredLocalActivityLabel.Size = new System.Drawing.Size(104, 13);
            this.desiredLocalActivityLabel.TabIndex = 12;
            this.desiredLocalActivityLabel.Text = "Desired local activity";
            // 
            // desiredLocalActivityTextBox
            // 
            this.desiredLocalActivityTextBox.Location = new System.Drawing.Point(203, 49);
            this.desiredLocalActivityTextBox.Name = "desiredLocalActivityTextBox";
            this.desiredLocalActivityTextBox.Size = new System.Drawing.Size(32, 20);
            this.desiredLocalActivityTextBox.TabIndex = 14;
            this.desiredLocalActivityTextBox.Text = "5";
            this.desiredLocalActivityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.desiredLocalActivityTextBox.TextChanged += new System.EventHandler(this.desiredLocalActivityTextBox_TextChanged);
            // 
            // minimumOverlapTextBox
            // 
            this.minimumOverlapTextBox.Location = new System.Drawing.Point(203, 24);
            this.minimumOverlapTextBox.Name = "minimumOverlapTextBox";
            this.minimumOverlapTextBox.Size = new System.Drawing.Size(32, 20);
            this.minimumOverlapTextBox.TabIndex = 13;
            this.minimumOverlapTextBox.Text = "3";
            this.minimumOverlapTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.minimumOverlapTextBox.TextChanged += new System.EventHandler(this.minimumOverlapTextBox_TextChanged);
            // 
            // segmentActivationThresholdTextBox
            // 
            this.segmentActivationThresholdTextBox.Location = new System.Drawing.Point(203, 73);
            this.segmentActivationThresholdTextBox.Name = "segmentActivationThresholdTextBox";
            this.segmentActivationThresholdTextBox.Size = new System.Drawing.Size(33, 20);
            this.segmentActivationThresholdTextBox.TabIndex = 16;
            this.segmentActivationThresholdTextBox.Text = "2";
            this.segmentActivationThresholdTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.segmentActivationThresholdTextBox.TextChanged += new System.EventHandler(this.segmentActivationThresholdTextBox_TextChanged);
            // 
            // minimumOverlapLabel
            // 
            this.minimumOverlapLabel.AutoSize = true;
            this.minimumOverlapLabel.Location = new System.Drawing.Point(10, 27);
            this.minimumOverlapLabel.Name = "minimumOverlapLabel";
            this.minimumOverlapLabel.Size = new System.Drawing.Size(86, 13);
            this.minimumOverlapLabel.TabIndex = 11;
            this.minimumOverlapLabel.Text = "Minimum overlap";
            // 
            // segmentActivationThresholdLabel
            // 
            this.segmentActivationThresholdLabel.AutoSize = true;
            this.segmentActivationThresholdLabel.Location = new System.Drawing.Point(10, 76);
            this.segmentActivationThresholdLabel.Name = "segmentActivationThresholdLabel";
            this.segmentActivationThresholdLabel.Size = new System.Drawing.Size(144, 13);
            this.segmentActivationThresholdLabel.TabIndex = 15;
            this.segmentActivationThresholdLabel.Text = "Segment activation threshold";
            // 
            // structureGroupBox
            // 
            this.structureGroupBox.Controls.Add(this.proximalSegmentCoverageTextBox);
            this.structureGroupBox.Controls.Add(this.proximalSegmentCoverageLabel);
            this.structureGroupBox.Controls.Add(this.networkSizeComboBox);
            this.structureGroupBox.Controls.Add(this.networkSizeLabel);
            this.structureGroupBox.Controls.Add(this.regionSizeComboBox);
            this.structureGroupBox.Controls.Add(this.regionSize);
            this.structureGroupBox.Location = new System.Drawing.Point(3, 3);
            this.structureGroupBox.Name = "structureGroupBox";
            this.structureGroupBox.Size = new System.Drawing.Size(308, 114);
            this.structureGroupBox.TabIndex = 13;
            this.structureGroupBox.TabStop = false;
            this.structureGroupBox.Text = "Structure";
            // 
            // proximalSegmentCoverageTextBox
            // 
            this.proximalSegmentCoverageTextBox.Location = new System.Drawing.Point(204, 83);
            this.proximalSegmentCoverageTextBox.Name = "proximalSegmentCoverageTextBox";
            this.proximalSegmentCoverageTextBox.Size = new System.Drawing.Size(32, 20);
            this.proximalSegmentCoverageTextBox.TabIndex = 18;
            this.proximalSegmentCoverageTextBox.Text = "10";
            this.proximalSegmentCoverageTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // proximalSegmentCoverageLabel
            // 
            this.proximalSegmentCoverageLabel.AutoSize = true;
            this.proximalSegmentCoverageLabel.Location = new System.Drawing.Point(10, 86);
            this.proximalSegmentCoverageLabel.Name = "proximalSegmentCoverageLabel";
            this.proximalSegmentCoverageLabel.Size = new System.Drawing.Size(154, 13);
            this.proximalSegmentCoverageLabel.TabIndex = 17;
            this.proximalSegmentCoverageLabel.Text = "Proximal segment coverage (%)";
            // 
            // networkSizeComboBox
            // 
            this.networkSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.networkSizeComboBox.FormattingEnabled = true;
            this.networkSizeComboBox.Location = new System.Drawing.Point(204, 29);
            this.networkSizeComboBox.Name = "networkSizeComboBox";
            this.networkSizeComboBox.Size = new System.Drawing.Size(92, 21);
            this.networkSizeComboBox.TabIndex = 8;
            // 
            // networkSizeLabel
            // 
            this.networkSizeLabel.AutoSize = true;
            this.networkSizeLabel.Location = new System.Drawing.Point(10, 32);
            this.networkSizeLabel.Name = "networkSizeLabel";
            this.networkSizeLabel.Size = new System.Drawing.Size(175, 13);
            this.networkSizeLabel.TabIndex = 7;
            this.networkSizeLabel.Text = "HTM size (regions x cells in column)";
            // 
            // HTMBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 260);
            this.Controls.Add(this.structureGroupBox);
            this.Controls.Add(this.preprocessGroupBox);
            this.Name = "HTMBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "HTM Builder";
            this.preprocessGroupBox.ResumeLayout(false);
            this.preprocessGroupBox.PerformLayout();
            this.structureGroupBox.ResumeLayout(false);
            this.structureGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label regionSize;
        private System.Windows.Forms.ComboBox regionSizeComboBox;


        #endregion

        private System.Windows.Forms.GroupBox preprocessGroupBox;
        private System.Windows.Forms.GroupBox structureGroupBox;
        private System.Windows.Forms.ComboBox networkSizeComboBox;
        private System.Windows.Forms.Label networkSizeLabel;
        private System.Windows.Forms.TextBox desiredLocalActivityTextBox;
        private System.Windows.Forms.TextBox minimumOverlapTextBox;
        private System.Windows.Forms.Label desiredLocalActivityLabel;
        private System.Windows.Forms.Label minimumOverlapLabel;
        private System.Windows.Forms.Label segmentActivationThresholdLabel;
        private System.Windows.Forms.TextBox segmentActivationThresholdTextBox;
        private System.Windows.Forms.Label proximalSegmentCoverageLabel;
        private System.Windows.Forms.TextBox proximalSegmentCoverageTextBox;
        private System.Windows.Forms.TextBox minSegmentActivityForLearningTextBox;
        private System.Windows.Forms.Label minSegmentActivityForLearningLabel;

    }
}