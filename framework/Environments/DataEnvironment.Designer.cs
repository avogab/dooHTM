namespace Doo.Environments
{
    partial class DataEnvironment
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pathButton = new System.Windows.Forms.Button();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.currentDataTextBox = new System.Windows.Forms.TextBox();
            this.currentDataLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(251, 10);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(24, 23);
            this.pathButton.TabIndex = 0;
            this.pathButton.Text = "...";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.pathButton_Click);
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(7, 14);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(47, 13);
            this.filePathLabel.TabIndex = 1;
            this.filePathLabel.Text = "File path";
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(60, 12);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(185, 20);
            this.filePathTextBox.TabIndex = 2;
            // 
            // currentDataTextBox
            // 
            this.currentDataTextBox.Location = new System.Drawing.Point(103, 52);
            this.currentDataTextBox.Name = "currentDataTextBox";
            this.currentDataTextBox.Size = new System.Drawing.Size(142, 20);
            this.currentDataTextBox.TabIndex = 3;
            // 
            // currentDataLabel
            // 
            this.currentDataLabel.AutoSize = true;
            this.currentDataLabel.Location = new System.Drawing.Point(12, 55);
            this.currentDataLabel.Name = "currentDataLabel";
            this.currentDataLabel.Size = new System.Drawing.Size(65, 13);
            this.currentDataLabel.TabIndex = 4;
            this.currentDataLabel.Text = "Current data";
            // 
            // DataEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 84);
            this.Controls.Add(this.currentDataLabel);
            this.Controls.Add(this.currentDataTextBox);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.pathButton);
            this.Name = "DataEnvironment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Data Environment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button pathButton;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.TextBox currentDataTextBox;
        private System.Windows.Forms.Label currentDataLabel;
    }
}