namespace Doo
{
    partial class MainForm
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.initNetButton = new System.Windows.Forms.Button();
            this.startNetButton = new System.Windows.Forms.Button();
            this.stopNetButton = new System.Windows.Forms.Button();
            this.stepNetButton = new System.Windows.Forms.Button();
            this.environmentsComboBox = new System.Windows.Forms.ComboBox();
            this.logListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.environmentsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cycleTextBox = new System.Windows.Forms.TextBox();
            this.sleepLabel = new System.Windows.Forms.Label();
            this.sleepBetweenStepTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // initNetButton
            // 
            this.initNetButton.Location = new System.Drawing.Point(268, 12);
            this.initNetButton.Name = "initNetButton";
            this.initNetButton.Size = new System.Drawing.Size(121, 30);
            this.initNetButton.TabIndex = 1;
            this.initNetButton.Text = "Create and Initialize";
            this.initNetButton.UseVisualStyleBackColor = true;
            this.initNetButton.Click += new System.EventHandler(this.initNetButton_Click);
            // 
            // startNetButton
            // 
            this.startNetButton.Enabled = false;
            this.startNetButton.Location = new System.Drawing.Point(16, 15);
            this.startNetButton.Name = "startNetButton";
            this.startNetButton.Size = new System.Drawing.Size(69, 27);
            this.startNetButton.TabIndex = 2;
            this.startNetButton.Text = "Start";
            this.startNetButton.UseVisualStyleBackColor = true;
            this.startNetButton.Click += new System.EventHandler(this.startNetButton_Click);
            // 
            // stopNetButton
            // 
            this.stopNetButton.Enabled = false;
            this.stopNetButton.Location = new System.Drawing.Point(166, 15);
            this.stopNetButton.Name = "stopNetButton";
            this.stopNetButton.Size = new System.Drawing.Size(69, 27);
            this.stopNetButton.TabIndex = 3;
            this.stopNetButton.Text = "Stop";
            this.stopNetButton.UseVisualStyleBackColor = true;
            this.stopNetButton.Click += new System.EventHandler(this.stopNetButton_Click);
            // 
            // stepNetButton
            // 
            this.stepNetButton.Enabled = false;
            this.stepNetButton.Location = new System.Drawing.Point(91, 15);
            this.stepNetButton.Name = "stepNetButton";
            this.stepNetButton.Size = new System.Drawing.Size(69, 27);
            this.stepNetButton.TabIndex = 5;
            this.stepNetButton.Text = "Step";
            this.stepNetButton.UseVisualStyleBackColor = true;
            this.stepNetButton.Click += new System.EventHandler(this.stepNetButton_Click);
            // 
            // environmentsComboBox
            // 
            this.environmentsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.environmentsComboBox.FormattingEnabled = true;
            this.environmentsComboBox.Location = new System.Drawing.Point(91, 16);
            this.environmentsComboBox.Name = "environmentsComboBox";
            this.environmentsComboBox.Size = new System.Drawing.Size(148, 21);
            this.environmentsComboBox.TabIndex = 6;
            // 
            // logListView
            // 
            this.logListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.time,
            this.description});
            this.logListView.FullRowSelect = true;
            this.logListView.Location = new System.Drawing.Point(8, 39);
            this.logListView.Name = "logListView";
            this.logListView.Size = new System.Drawing.Size(468, 91);
            this.logListView.TabIndex = 13;
            this.logListView.UseCompatibleStateImageBehavior = false;
            this.logListView.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.Text = "Id";
            this.id.Width = 40;
            // 
            // time
            // 
            this.time.Text = "Time";
            this.time.Width = 70;
            // 
            // description
            // 
            this.description.Text = "Description";
            this.description.Width = 280;
            // 
            // environmentsLabel
            // 
            this.environmentsLabel.Location = new System.Drawing.Point(13, 19);
            this.environmentsLabel.Name = "environmentsLabel";
            this.environmentsLabel.Size = new System.Drawing.Size(72, 23);
            this.environmentsLabel.TabIndex = 0;
            this.environmentsLabel.Text = "Environment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Current cycle";
            // 
            // cycleTextBox
            // 
            this.cycleTextBox.Location = new System.Drawing.Point(94, 13);
            this.cycleTextBox.Name = "cycleTextBox";
            this.cycleTextBox.Size = new System.Drawing.Size(66, 20);
            this.cycleTextBox.TabIndex = 16;
            this.cycleTextBox.Text = "0";
            this.cycleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sleepLabel
            // 
            this.sleepLabel.AutoSize = true;
            this.sleepLabel.Location = new System.Drawing.Point(254, 22);
            this.sleepLabel.Name = "sleepLabel";
            this.sleepLabel.Size = new System.Drawing.Size(123, 13);
            this.sleepLabel.TabIndex = 17;
            this.sleepLabel.Text = "Sleep between step (ms)";
            // 
            // sleepBetweenStepTextBox
            // 
            this.sleepBetweenStepTextBox.Location = new System.Drawing.Point(399, 19);
            this.sleepBetweenStepTextBox.Name = "sleepBetweenStepTextBox";
            this.sleepBetweenStepTextBox.Size = new System.Drawing.Size(48, 20);
            this.sleepBetweenStepTextBox.TabIndex = 18;
            this.sleepBetweenStepTextBox.Text = "0";
            this.sleepBetweenStepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.environmentsLabel);
            this.panel1.Controls.Add(this.initNetButton);
            this.panel1.Controls.Add(this.environmentsComboBox);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 55);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.startNetButton);
            this.panel2.Controls.Add(this.stopNetButton);
            this.panel2.Controls.Add(this.sleepBetweenStepTextBox);
            this.panel2.Controls.Add(this.sleepLabel);
            this.panel2.Controls.Add(this.stepNetButton);
            this.panel2.Location = new System.Drawing.Point(3, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(485, 54);
            this.panel2.TabIndex = 20;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.cycleTextBox);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.logListView);
            this.panel3.Location = new System.Drawing.Point(3, 124);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(485, 145);
            this.panel3.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 273);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "MainForm";
            this.Text = "Director";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button initNetButton;
        private System.Windows.Forms.Button startNetButton;
        private System.Windows.Forms.Button stopNetButton;
        private System.Windows.Forms.Button stepNetButton;
        private System.Windows.Forms.ComboBox environmentsComboBox;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.Label environmentsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cycleTextBox;
        private System.Windows.Forms.Label sleepLabel;
        private System.Windows.Forms.TextBox sleepBetweenStepTextBox;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;

        #endregion
    }
}

