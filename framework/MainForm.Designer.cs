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
            this.components = new System.ComponentModel.Container();
            this.stopNetButton = new System.Windows.Forms.Button();
            this.stepNetButton = new System.Windows.Forms.Button();
            this.logListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cycleTextBox = new System.Windows.Forms.TextBox();
            this.sleepLabel = new System.Windows.Forms.Label();
            this.sleepBetweenStepTextBox = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.startNetButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.runMacro1 = new System.Windows.Forms.ToolStripMenuItem();
            this.macro1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macro2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.breakAtStepLabel = new System.Windows.Forms.Label();
            this.breakAtStepTextBox = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stopNetButton
            // 
            this.stopNetButton.Enabled = false;
            this.stopNetButton.Image = global::Doo.Properties.Resources.stopImage;
            this.stopNetButton.Location = new System.Drawing.Point(128, 12);
            this.stopNetButton.Name = "stopNetButton";
            this.stopNetButton.Size = new System.Drawing.Size(32, 32);
            this.stopNetButton.TabIndex = 3;
            this.toolTip1.SetToolTip(this.stopNetButton, "Stop");
            this.stopNetButton.UseVisualStyleBackColor = true;
            this.stopNetButton.Click += new System.EventHandler(this.stopNetButton_Click);
            // 
            // stepNetButton
            // 
            this.stepNetButton.Enabled = false;
            this.stepNetButton.Image = global::Doo.Properties.Resources.stepImage;
            this.stepNetButton.Location = new System.Drawing.Point(18, 12);
            this.stepNetButton.Name = "stepNetButton";
            this.stepNetButton.Size = new System.Drawing.Size(35, 32);
            this.stepNetButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.stepNetButton, "Step");
            this.stepNetButton.UseVisualStyleBackColor = true;
            this.stepNetButton.Click += new System.EventHandler(this.stepNetButton_Click);
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
            this.logListView.Size = new System.Drawing.Size(484, 77);
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
            this.sleepLabel.Location = new System.Drawing.Point(306, 22);
            this.sleepLabel.Name = "sleepLabel";
            this.sleepLabel.Size = new System.Drawing.Size(128, 13);
            this.sleepLabel.TabIndex = 17;
            this.sleepLabel.Text = "Sleep between steps (ms)";
            // 
            // sleepBetweenStepTextBox
            // 
            this.sleepBetweenStepTextBox.Location = new System.Drawing.Point(440, 19);
            this.sleepBetweenStepTextBox.Name = "sleepBetweenStepTextBox";
            this.sleepBetweenStepTextBox.Size = new System.Drawing.Size(48, 20);
            this.sleepBetweenStepTextBox.TabIndex = 18;
            this.sleepBetweenStepTextBox.Text = "0";
            this.sleepBetweenStepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.breakAtStepTextBox);
            this.panel2.Controls.Add(this.breakAtStepLabel);
            this.panel2.Controls.Add(this.startNetButton);
            this.panel2.Controls.Add(this.stopNetButton);
            this.panel2.Controls.Add(this.sleepBetweenStepTextBox);
            this.panel2.Controls.Add(this.sleepLabel);
            this.panel2.Controls.Add(this.stepNetButton);
            this.panel2.Location = new System.Drawing.Point(3, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 54);
            this.panel2.TabIndex = 20;
            // 
            // startNetButton
            // 
            this.startNetButton.Enabled = false;
            this.startNetButton.Image = global::Doo.Properties.Resources.startImage;
            this.startNetButton.Location = new System.Drawing.Point(74, 12);
            this.startNetButton.Name = "startNetButton";
            this.startNetButton.Size = new System.Drawing.Size(32, 32);
            this.startNetButton.TabIndex = 2;
            this.toolTip1.SetToolTip(this.startNetButton, "Loop");
            this.startNetButton.UseVisualStyleBackColor = true;
            this.startNetButton.Click += new System.EventHandler(this.startNetButton_Click);
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
            this.panel3.Location = new System.Drawing.Point(3, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(500, 131);
            this.panel3.TabIndex = 21;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runMacro1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(503, 24);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // runMacro1
            // 
            this.runMacro1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.macro1ToolStripMenuItem,
            this.macro2ToolStripMenuItem});
            this.runMacro1.Name = "runMacro1";
            this.runMacro1.Size = new System.Drawing.Size(67, 20);
            this.runMacro1.Text = "run macro";
            this.runMacro1.Visible = false;
            // 
            // macro1ToolStripMenuItem
            // 
            this.macro1ToolStripMenuItem.Name = "macro1ToolStripMenuItem";
            this.macro1ToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.macro1ToolStripMenuItem.Text = "macro1";
            this.macro1ToolStripMenuItem.Click += new System.EventHandler(this.macro1ToolStripMenuItem_Click);
            // 
            // macro2ToolStripMenuItem
            // 
            this.macro2ToolStripMenuItem.Name = "macro2ToolStripMenuItem";
            this.macro2ToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.macro2ToolStripMenuItem.Text = "macro2";
            this.macro2ToolStripMenuItem.Click += new System.EventHandler(this.macro2ToolStripMenuItem_Click);
            // 
            // breakAtStepLabel
            // 
            this.breakAtStepLabel.AutoSize = true;
            this.breakAtStepLabel.Location = new System.Drawing.Point(177, 22);
            this.breakAtStepLabel.Name = "breakAtStepLabel";
            this.breakAtStepLabel.Size = new System.Drawing.Size(70, 13);
            this.breakAtStepLabel.TabIndex = 19;
            this.breakAtStepLabel.Text = "Break at step";
            // 
            // breakAtStepTextBox
            // 
            this.breakAtStepTextBox.Location = new System.Drawing.Point(253, 19);
            this.breakAtStepTextBox.Name = "breakAtStepTextBox";
            this.breakAtStepTextBox.Size = new System.Drawing.Size(38, 20);
            this.breakAtStepTextBox.TabIndex = 20;
            this.breakAtStepTextBox.Text = "0";
            this.breakAtStepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 222);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(450, 234);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Director";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button startNetButton;
        private System.Windows.Forms.Button stopNetButton;
        private System.Windows.Forms.Button stepNetButton;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cycleTextBox;
        private System.Windows.Forms.Label sleepLabel;
        private System.Windows.Forms.TextBox sleepBetweenStepTextBox;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runMacro1;
        private System.Windows.Forms.ToolStripMenuItem macro1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem macro2ToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox breakAtStepTextBox;
        private System.Windows.Forms.Label breakAtStepLabel;
    }
}

