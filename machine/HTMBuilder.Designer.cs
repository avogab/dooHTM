namespace Doo.Machine
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
            this.inputSizeLabel = new System.Windows.Forms.Label();
            this.inputSizeComboBox = new System.Windows.Forms.ComboBox();
            this.regionSize = new System.Windows.Forms.Label();
            this.regionSizeComboBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.preprocessGroupBox = new System.Windows.Forms.GroupBox();
            this.detectMotionCheckBox = new System.Windows.Forms.CheckBox();
            this.structureGroupBox = new System.Windows.Forms.GroupBox();
            this.networkSizeComboBox = new System.Windows.Forms.ComboBox();
            this.networkSizeLabel = new System.Windows.Forms.Label();
            this.minimumOverlapLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.minimumOverlapTextBox = new System.Windows.Forms.TextBox();
            this.desiredLocalActivityTextBox = new System.Windows.Forms.TextBox();
            this.preprocessGroupBox.SuspendLayout();
            this.structureGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputSizeLabel
            // 
            this.inputSizeLabel.AutoSize = true;
            this.inputSizeLabel.Location = new System.Drawing.Point(11, 22);
            this.inputSizeLabel.Name = "inputSizeLabel";
            this.inputSizeLabel.Size = new System.Drawing.Size(88, 13);
            this.inputSizeLabel.TabIndex = 3;
            this.inputSizeLabel.Text = "Region input size";
            // 
            // inputSizeComboBox
            // 
            this.inputSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputSizeComboBox.FormattingEnabled = true;
            this.inputSizeComboBox.Location = new System.Drawing.Point(205, 19);
            this.inputSizeComboBox.Name = "inputSizeComboBox";
            this.inputSizeComboBox.Size = new System.Drawing.Size(92, 21);
            this.inputSizeComboBox.TabIndex = 4;
            // 
            // regionSize
            // 
            this.regionSize.AutoSize = true;
            this.regionSize.Location = new System.Drawing.Point(11, 75);
            this.regionSize.Name = "regionSize";
            this.regionSize.Size = new System.Drawing.Size(62, 13);
            this.regionSize.TabIndex = 5;
            this.regionSize.Text = "Region size";
            // 
            // regionSizeComboBox
            // 
            this.regionSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.regionSizeComboBox.FormattingEnabled = true;
            this.regionSizeComboBox.Location = new System.Drawing.Point(205, 72);
            this.regionSizeComboBox.Name = "regionSizeComboBox";
            this.regionSizeComboBox.Size = new System.Drawing.Size(92, 21);
            this.regionSizeComboBox.TabIndex = 6;
            this.regionSizeComboBox.SelectedIndexChanged += new System.EventHandler(this.regionSizeComboBox_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(225, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // preprocessGroupBox
            // 
            this.preprocessGroupBox.Controls.Add(this.detectMotionCheckBox);
            this.preprocessGroupBox.Location = new System.Drawing.Point(3, 195);
            this.preprocessGroupBox.Name = "preprocessGroupBox";
            this.preprocessGroupBox.Size = new System.Drawing.Size(308, 45);
            this.preprocessGroupBox.TabIndex = 12;
            this.preprocessGroupBox.TabStop = false;
            this.preprocessGroupBox.Text = "Preprocess";
            // 
            // detectMotionCheckBox
            // 
            this.detectMotionCheckBox.AutoSize = true;
            this.detectMotionCheckBox.Checked = true;
            this.detectMotionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.detectMotionCheckBox.Enabled = false;
            this.detectMotionCheckBox.Location = new System.Drawing.Point(14, 19);
            this.detectMotionCheckBox.Name = "detectMotionCheckBox";
            this.detectMotionCheckBox.Size = new System.Drawing.Size(92, 17);
            this.detectMotionCheckBox.TabIndex = 5;
            this.detectMotionCheckBox.Text = "Detect motion";
            this.detectMotionCheckBox.UseVisualStyleBackColor = true;
            this.detectMotionCheckBox.CheckedChanged += new System.EventHandler(this.detectMotionCheckBox_CheckedChanged);
            // 
            // structureGroupBox
            // 
            this.structureGroupBox.Controls.Add(this.desiredLocalActivityTextBox);
            this.structureGroupBox.Controls.Add(this.minimumOverlapTextBox);
            this.structureGroupBox.Controls.Add(this.label2);
            this.structureGroupBox.Controls.Add(this.minimumOverlapLabel);
            this.structureGroupBox.Controls.Add(this.networkSizeComboBox);
            this.structureGroupBox.Controls.Add(this.inputSizeComboBox);
            this.structureGroupBox.Controls.Add(this.inputSizeLabel);
            this.structureGroupBox.Controls.Add(this.networkSizeLabel);
            this.structureGroupBox.Controls.Add(this.button1);
            this.structureGroupBox.Controls.Add(this.regionSizeComboBox);
            this.structureGroupBox.Controls.Add(this.regionSize);
            this.structureGroupBox.Location = new System.Drawing.Point(3, 3);
            this.structureGroupBox.Name = "structureGroupBox";
            this.structureGroupBox.Size = new System.Drawing.Size(308, 186);
            this.structureGroupBox.TabIndex = 13;
            this.structureGroupBox.TabStop = false;
            this.structureGroupBox.Text = "Structure";
            // 
            // networkSizeComboBox
            // 
            this.networkSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.networkSizeComboBox.FormattingEnabled = true;
            this.networkSizeComboBox.Location = new System.Drawing.Point(205, 45);
            this.networkSizeComboBox.Name = "networkSizeComboBox";
            this.networkSizeComboBox.Size = new System.Drawing.Size(92, 21);
            this.networkSizeComboBox.TabIndex = 8;
            // 
            // networkSizeLabel
            // 
            this.networkSizeLabel.AutoSize = true;
            this.networkSizeLabel.Location = new System.Drawing.Point(11, 48);
            this.networkSizeLabel.Name = "networkSizeLabel";
            this.networkSizeLabel.Size = new System.Drawing.Size(191, 13);
            this.networkSizeLabel.TabIndex = 7;
            this.networkSizeLabel.Text = "Network size (regions x cells in column)";
            // 
            // minimumOverlapLabel
            // 
            this.minimumOverlapLabel.AutoSize = true;
            this.minimumOverlapLabel.Location = new System.Drawing.Point(11, 103);
            this.minimumOverlapLabel.Name = "minimumOverlapLabel";
            this.minimumOverlapLabel.Size = new System.Drawing.Size(86, 13);
            this.minimumOverlapLabel.TabIndex = 11;
            this.minimumOverlapLabel.Text = "Minimum overlap";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Desired local activity";
            // 
            // minimumOverlapTextBox
            // 
            this.minimumOverlapTextBox.Location = new System.Drawing.Point(127, 100);
            this.minimumOverlapTextBox.Name = "minimumOverlapTextBox";
            this.minimumOverlapTextBox.Size = new System.Drawing.Size(32, 20);
            this.minimumOverlapTextBox.TabIndex = 13;
            this.minimumOverlapTextBox.Text = "3";
            this.minimumOverlapTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // desiredLocalActivityTextBox
            // 
            this.desiredLocalActivityTextBox.Location = new System.Drawing.Point(127, 126);
            this.desiredLocalActivityTextBox.Name = "desiredLocalActivityTextBox";
            this.desiredLocalActivityTextBox.Size = new System.Drawing.Size(32, 20);
            this.desiredLocalActivityTextBox.TabIndex = 14;
            this.desiredLocalActivityTextBox.Text = "5";
            this.desiredLocalActivityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // HTMBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 246);
            this.Controls.Add(this.structureGroupBox);
            this.Controls.Add(this.preprocessGroupBox);
            this.Name = "HTMBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Agent Control";
            this.preprocessGroupBox.ResumeLayout(false);
            this.preprocessGroupBox.PerformLayout();
            this.structureGroupBox.ResumeLayout(false);
            this.structureGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label inputSizeLabel;
        private System.Windows.Forms.ComboBox inputSizeComboBox;
        private System.Windows.Forms.Label regionSize;
        private System.Windows.Forms.ComboBox regionSizeComboBox;


        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox preprocessGroupBox;
        private System.Windows.Forms.GroupBox structureGroupBox;
        private System.Windows.Forms.ComboBox networkSizeComboBox;
        private System.Windows.Forms.Label networkSizeLabel;
        private System.Windows.Forms.CheckBox detectMotionCheckBox;
        private System.Windows.Forms.TextBox desiredLocalActivityTextBox;
        private System.Windows.Forms.TextBox minimumOverlapTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label minimumOverlapLabel;

    }
}