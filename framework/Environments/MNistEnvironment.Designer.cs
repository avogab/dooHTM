namespace Doo.Environments
{
    partial class MNistEnvironment
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
            this.scrollBar1 = new System.Windows.Forms.VScrollBar();
            this.pictureBox1 = new Emgu.CV.UI.ImageBox();
            this.mnistLabel = new System.Windows.Forms.Label();
            this.mnistTextBox = new System.Windows.Forms.TextBox();
            this.dbIndexLabel = new System.Windows.Forms.Label();
            this.dbIndexTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // scrollBar1
            // 
            this.scrollBar1.Location = new System.Drawing.Point(102, 69);
            this.scrollBar1.Name = "scrollBar1";
            this.scrollBar1.Size = new System.Drawing.Size(18, 80);
            this.scrollBar1.TabIndex = 2;
            this.scrollBar1.ValueChanged += new System.EventHandler(this.scrollBar1_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // mnistLabel
            // 
            this.mnistLabel.AutoSize = true;
            this.mnistLabel.Location = new System.Drawing.Point(9, 44);
            this.mnistLabel.Name = "mnistLabel";
            this.mnistLabel.Size = new System.Drawing.Size(33, 13);
            this.mnistLabel.TabIndex = 4;
            this.mnistLabel.Text = "Label";
            // 
            // mnistTextBox
            // 
            this.mnistTextBox.Location = new System.Drawing.Point(85, 41);
            this.mnistTextBox.Name = "mnistTextBox";
            this.mnistTextBox.ReadOnly = true;
            this.mnistTextBox.Size = new System.Drawing.Size(35, 20);
            this.mnistTextBox.TabIndex = 5;
            this.mnistTextBox.TabStop = false;
            this.mnistTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dbIndexLabel
            // 
            this.dbIndexLabel.AutoSize = true;
            this.dbIndexLabel.Location = new System.Drawing.Point(9, 19);
            this.dbIndexLabel.Name = "dbIndexLabel";
            this.dbIndexLabel.Size = new System.Drawing.Size(50, 13);
            this.dbIndexLabel.TabIndex = 6;
            this.dbIndexLabel.Text = "DB index";
            // 
            // dbIndexTextBox
            // 
            this.dbIndexTextBox.Location = new System.Drawing.Point(85, 15);
            this.dbIndexTextBox.Name = "dbIndexTextBox";
            this.dbIndexTextBox.ReadOnly = true;
            this.dbIndexTextBox.Size = new System.Drawing.Size(35, 20);
            this.dbIndexTextBox.TabIndex = 7;
            this.dbIndexTextBox.TabStop = false;
            this.dbIndexTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MNistEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(132, 161);
            this.Controls.Add(this.dbIndexTextBox);
            this.Controls.Add(this.dbIndexLabel);
            this.Controls.Add(this.mnistTextBox);
            this.Controls.Add(this.mnistLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.scrollBar1);
            this.Name = "MNistEnvironment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MNist";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.VScrollBar scrollBar1;
        private Emgu.CV.UI.ImageBox pictureBox1;
        private System.Windows.Forms.Label mnistLabel;
        private System.Windows.Forms.TextBox mnistTextBox;
        private System.Windows.Forms.Label dbIndexLabel;
        private System.Windows.Forms.TextBox dbIndexTextBox;
    }
}