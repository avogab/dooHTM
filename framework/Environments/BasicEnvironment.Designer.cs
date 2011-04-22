namespace Doo.Environments
{
    partial class BasicEnvironment
    {
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.frameBox = new Emgu.CV.UI.ImageBox();
            this.showFrameCheckBox = new System.Windows.Forms.CheckBox();
            this.sourceTypeLabel = new System.Windows.Forms.Label();
            this.sourceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.loopVideoFileCheckBox = new System.Windows.Forms.CheckBox();
            this.genTypeComboBox = new System.Windows.Forms.ComboBox();
            this.genTypeLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.fileSourceTab = new System.Windows.Forms.TabPage();
            this.generatedSourceTab = new System.Windows.Forms.TabPage();
            this.movementComboBox = new System.Windows.Forms.ComboBox();
            this.movementLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.figureComboBox = new System.Windows.Forms.ComboBox();
            this.noiseCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.frameBox)).BeginInit();
            this.tabControl.SuspendLayout();
            this.fileSourceTab.SuspendLayout();
            this.generatedSourceTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // frameBox
            // 
            this.frameBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frameBox.Location = new System.Drawing.Point(382, 59);
            this.frameBox.Name = "frameBox";
            this.frameBox.Size = new System.Drawing.Size(200, 200);
            this.frameBox.TabIndex = 1;
            this.frameBox.TabStop = false;
            // 
            // showFrameCheckBox
            // 
            this.showFrameCheckBox.AutoSize = true;
            this.showFrameCheckBox.Checked = true;
            this.showFrameCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showFrameCheckBox.Location = new System.Drawing.Point(382, 37);
            this.showFrameCheckBox.Name = "showFrameCheckBox";
            this.showFrameCheckBox.Size = new System.Drawing.Size(53, 17);
            this.showFrameCheckBox.TabIndex = 2;
            this.showFrameCheckBox.Text = "Show";
            this.showFrameCheckBox.UseVisualStyleBackColor = true;
            this.showFrameCheckBox.CheckedChanged += new System.EventHandler(this.showCaptureCheckBox_CheckedChanged);
            // 
            // sourceTypeLabel
            // 
            this.sourceTypeLabel.AutoSize = true;
            this.sourceTypeLabel.Location = new System.Drawing.Point(2, 9);
            this.sourceTypeLabel.Name = "sourceTypeLabel";
            this.sourceTypeLabel.Size = new System.Drawing.Size(64, 13);
            this.sourceTypeLabel.TabIndex = 4;
            this.sourceTypeLabel.Text = "Source type";
            // 
            // sourceTypeComboBox
            // 
            this.sourceTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceTypeComboBox.FormattingEnabled = true;
            this.sourceTypeComboBox.Location = new System.Drawing.Point(72, 6);
            this.sourceTypeComboBox.Name = "sourceTypeComboBox";
            this.sourceTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.sourceTypeComboBox.TabIndex = 5;
            this.sourceTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.sourceTypeComboBox_SelectedIndexChanged);
            // 
            // browseButton
            // 
            this.browseButton.Enabled = false;
            this.browseButton.Location = new System.Drawing.Point(235, 14);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(28, 23);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "...";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(76, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(143, 20);
            this.textBox1.TabIndex = 7;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Enabled = false;
            this.fileNameLabel.Location = new System.Drawing.Point(6, 17);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(52, 13);
            this.fileNameLabel.TabIndex = 8;
            this.fileNameLabel.Text = "File name";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // loopVideoFileCheckBox
            // 
            this.loopVideoFileCheckBox.AutoSize = true;
            this.loopVideoFileCheckBox.Enabled = false;
            this.loopVideoFileCheckBox.Location = new System.Drawing.Point(10, 52);
            this.loopVideoFileCheckBox.Name = "loopVideoFileCheckBox";
            this.loopVideoFileCheckBox.Size = new System.Drawing.Size(50, 17);
            this.loopVideoFileCheckBox.TabIndex = 9;
            this.loopVideoFileCheckBox.Text = "Loop";
            this.loopVideoFileCheckBox.UseVisualStyleBackColor = true;
            // 
            // genTypeComboBox
            // 
            this.genTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.genTypeComboBox.FormattingEnabled = true;
            this.genTypeComboBox.Location = new System.Drawing.Point(89, 12);
            this.genTypeComboBox.Name = "genTypeComboBox";
            this.genTypeComboBox.Size = new System.Drawing.Size(109, 21);
            this.genTypeComboBox.TabIndex = 10;
            // 
            // genTypeLabel
            // 
            this.genTypeLabel.AutoSize = true;
            this.genTypeLabel.Location = new System.Drawing.Point(17, 15);
            this.genTypeLabel.Name = "genTypeLabel";
            this.genTypeLabel.Size = new System.Drawing.Size(31, 13);
            this.genTypeLabel.TabIndex = 11;
            this.genTypeLabel.Text = "Type";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.generatedSourceTab);
            this.tabControl.Controls.Add(this.fileSourceTab);
            this.tabControl.Location = new System.Drawing.Point(1, 37);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(375, 223);
            this.tabControl.TabIndex = 12;
            // 
            // fileSourceTab
            // 
            this.fileSourceTab.Controls.Add(this.loopVideoFileCheckBox);
            this.fileSourceTab.Controls.Add(this.fileNameLabel);
            this.fileSourceTab.Controls.Add(this.textBox1);
            this.fileSourceTab.Controls.Add(this.browseButton);
            this.fileSourceTab.Location = new System.Drawing.Point(4, 22);
            this.fileSourceTab.Name = "fileSourceTab";
            this.fileSourceTab.Padding = new System.Windows.Forms.Padding(3);
            this.fileSourceTab.Size = new System.Drawing.Size(367, 197);
            this.fileSourceTab.TabIndex = 0;
            this.fileSourceTab.Text = "File";
            this.fileSourceTab.UseVisualStyleBackColor = true;
            // 
            // generatedSourceTab
            // 
            this.generatedSourceTab.Controls.Add(this.movementComboBox);
            this.generatedSourceTab.Controls.Add(this.movementLabel);
            this.generatedSourceTab.Controls.Add(this.label1);
            this.generatedSourceTab.Controls.Add(this.figureComboBox);
            this.generatedSourceTab.Controls.Add(this.noiseCheckBox);
            this.generatedSourceTab.Controls.Add(this.genTypeComboBox);
            this.generatedSourceTab.Controls.Add(this.genTypeLabel);
            this.generatedSourceTab.Location = new System.Drawing.Point(4, 22);
            this.generatedSourceTab.Name = "generatedSourceTab";
            this.generatedSourceTab.Padding = new System.Windows.Forms.Padding(3);
            this.generatedSourceTab.Size = new System.Drawing.Size(367, 197);
            this.generatedSourceTab.TabIndex = 1;
            this.generatedSourceTab.Text = "Gnerated";
            this.generatedSourceTab.UseVisualStyleBackColor = true;
            // 
            // movementComboBox
            // 
            this.movementComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.movementComboBox.FormattingEnabled = true;
            this.movementComboBox.Location = new System.Drawing.Point(89, 44);
            this.movementComboBox.Name = "movementComboBox";
            this.movementComboBox.Size = new System.Drawing.Size(109, 21);
            this.movementComboBox.TabIndex = 16;
            this.movementComboBox.SelectedIndexChanged += new System.EventHandler(this.movementComboBox_SelectedIndexChanged);
            // 
            // movementLabel
            // 
            this.movementLabel.AutoSize = true;
            this.movementLabel.Location = new System.Drawing.Point(17, 47);
            this.movementLabel.Name = "movementLabel";
            this.movementLabel.Size = new System.Drawing.Size(57, 13);
            this.movementLabel.TabIndex = 15;
            this.movementLabel.Text = "Movement";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Figure";
            // 
            // figureComboBox
            // 
            this.figureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.figureComboBox.FormattingEnabled = true;
            this.figureComboBox.Location = new System.Drawing.Point(89, 75);
            this.figureComboBox.Name = "figureComboBox";
            this.figureComboBox.Size = new System.Drawing.Size(109, 21);
            this.figureComboBox.TabIndex = 13;
            this.figureComboBox.SelectedIndexChanged += new System.EventHandler(this.figureComboBox_SelectedIndexChanged);
            // 
            // noiseCheckBox
            // 
            this.noiseCheckBox.AutoSize = true;
            this.noiseCheckBox.Location = new System.Drawing.Point(20, 146);
            this.noiseCheckBox.Name = "noiseCheckBox";
            this.noiseCheckBox.Size = new System.Drawing.Size(51, 17);
            this.noiseCheckBox.TabIndex = 12;
            this.noiseCheckBox.Text = "noise";
            this.noiseCheckBox.UseVisualStyleBackColor = true;
            // 
            // BasicEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 266);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.sourceTypeComboBox);
            this.Controls.Add(this.sourceTypeLabel);
            this.Controls.Add(this.showFrameCheckBox);
            this.Controls.Add(this.frameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "BasicEnvironment";
            this.Text = "Environment";
            ((System.ComponentModel.ISupportInitialize)(this.frameBox)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.fileSourceTab.ResumeLayout(false);
            this.fileSourceTab.PerformLayout();
            this.generatedSourceTab.ResumeLayout(false);
            this.generatedSourceTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.ComponentModel.IContainer components = null;
        private Emgu.CV.UI.ImageBox frameBox;
        private System.Windows.Forms.CheckBox showFrameCheckBox;
        private System.Windows.Forms.Label sourceTypeLabel;
        private System.Windows.Forms.ComboBox sourceTypeComboBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox loopVideoFileCheckBox;
        private System.Windows.Forms.ComboBox genTypeComboBox;
        private System.Windows.Forms.Label genTypeLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage fileSourceTab;
        private System.Windows.Forms.TabPage generatedSourceTab;
        private System.Windows.Forms.CheckBox noiseCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox figureComboBox;


        #endregion
        private System.Windows.Forms.ComboBox movementComboBox;
        private System.Windows.Forms.Label movementLabel;
    }
}

