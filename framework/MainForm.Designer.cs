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
            this.logListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.cycleTextBox = new System.Windows.Forms.TextBox();
            this.sleepLabel = new System.Windows.Forms.Label();
            this.sleepBetweenStepTextBox = new System.Windows.Forms.TextBox();
            this.breakAtStepTextBox = new System.Windows.Forms.TextBox();
            this.breakAtStepLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.imageDesktopButton = new System.Windows.Forms.ToolStripButton();
            this.dataDesktopButton = new System.Windows.Forms.ToolStripButton();
            this.separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.initializeButton = new System.Windows.Forms.ToolStripButton();
            this.stepButton = new System.Windows.Forms.ToolStripButton();
            this.startButton = new System.Windows.Forms.ToolStripButton();
            this.stopButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.logListView.Location = new System.Drawing.Point(12, 33);
            this.logListView.Name = "logListView";
            this.logListView.Size = new System.Drawing.Size(870, 62);
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
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Current cycle";
            // 
            // cycleTextBox
            // 
            this.cycleTextBox.Location = new System.Drawing.Point(91, 7);
            this.cycleTextBox.Name = "cycleTextBox";
            this.cycleTextBox.ReadOnly = true;
            this.cycleTextBox.Size = new System.Drawing.Size(57, 20);
            this.cycleTextBox.TabIndex = 16;
            this.cycleTextBox.Text = "0";
            this.cycleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // sleepLabel
            // 
            this.sleepLabel.AutoSize = true;
            this.sleepLabel.Location = new System.Drawing.Point(303, 10);
            this.sleepLabel.Name = "sleepLabel";
            this.sleepLabel.Size = new System.Drawing.Size(128, 13);
            this.sleepLabel.TabIndex = 17;
            this.sleepLabel.Text = "Sleep between steps (ms)";
            // 
            // sleepBetweenStepTextBox
            // 
            this.sleepBetweenStepTextBox.Location = new System.Drawing.Point(437, 7);
            this.sleepBetweenStepTextBox.Name = "sleepBetweenStepTextBox";
            this.sleepBetweenStepTextBox.Size = new System.Drawing.Size(48, 20);
            this.sleepBetweenStepTextBox.TabIndex = 18;
            this.sleepBetweenStepTextBox.Text = "0";
            this.sleepBetweenStepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // breakAtStepTextBox
            // 
            this.breakAtStepTextBox.Location = new System.Drawing.Point(241, 7);
            this.breakAtStepTextBox.Name = "breakAtStepTextBox";
            this.breakAtStepTextBox.Size = new System.Drawing.Size(38, 20);
            this.breakAtStepTextBox.TabIndex = 20;
            this.breakAtStepTextBox.Text = "0";
            this.breakAtStepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // breakAtStepLabel
            // 
            this.breakAtStepLabel.AutoSize = true;
            this.breakAtStepLabel.Location = new System.Drawing.Point(165, 10);
            this.breakAtStepLabel.Name = "breakAtStepLabel";
            this.breakAtStepLabel.Size = new System.Drawing.Size(70, 13);
            this.breakAtStepLabel.TabIndex = 19;
            this.breakAtStepLabel.Text = "Break at step";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageDesktopButton,
            this.dataDesktopButton,
            this.separator1,
            this.initializeButton,
            this.stepButton,
            this.startButton,
            this.stopButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.ShowItemToolTips = false;
            this.toolStrip1.Size = new System.Drawing.Size(894, 52);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // imageDesktopButton
            // 
            this.imageDesktopButton.Image = global::Doo.Properties.Resources.deskImage;
            this.imageDesktopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imageDesktopButton.Name = "imageDesktopButton";
            this.imageDesktopButton.Size = new System.Drawing.Size(114, 49);
            this.imageDesktopButton.Text = "Image desktop";
            this.imageDesktopButton.Click += new System.EventHandler(this.imageDesktopButton_Click);
            // 
            // dataDesktopButton
            // 
            this.dataDesktopButton.Image = global::Doo.Properties.Resources.deskImage;
            this.dataDesktopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dataDesktopButton.Name = "dataDesktopButton";
            this.dataDesktopButton.Size = new System.Drawing.Size(107, 49);
            this.dataDesktopButton.Text = "Data desktop";
            this.dataDesktopButton.Click += new System.EventHandler(this.dataDesktopButton_Click);
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(6, 52);
            // 
            // initializeButton
            // 
            this.initializeButton.Enabled = false;
            this.initializeButton.Image = global::Doo.Properties.Resources.initializeImage;
            this.initializeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.initializeButton.Name = "initializeButton";
            this.initializeButton.Size = new System.Drawing.Size(50, 49);
            this.initializeButton.Text = "Initialize";
            this.initializeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.initializeButton.Click += new System.EventHandler(this.initializeButton_Click);
            // 
            // stepButton
            // 
            this.stepButton.Enabled = false;
            this.stepButton.Image = global::Doo.Properties.Resources.stepImage;
            this.stepButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stepButton.Name = "stepButton";
            this.stepButton.Size = new System.Drawing.Size(36, 49);
            this.stepButton.Text = "Step";
            this.stepButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.stepButton.Click += new System.EventHandler(this.stepButton_Click);
            // 
            // startButton
            // 
            this.startButton.Enabled = false;
            this.startButton.Image = global::Doo.Properties.Resources.startImage;
            this.startButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(36, 49);
            this.startButton.Text = "Loop";
            this.startButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Image = global::Doo.Properties.Resources.stopImage;
            this.stopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(36, 49);
            this.stopButton.Text = "Stop";
            this.stopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.logListView);
            this.panel1.Controls.Add(this.breakAtStepTextBox);
            this.panel1.Controls.Add(this.sleepBetweenStepTextBox);
            this.panel1.Controls.Add(this.breakAtStepLabel);
            this.panel1.Controls.Add(this.sleepLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cycleTextBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(894, 107);
            this.panel1.TabIndex = 22;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 371);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(450, 234);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Director";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListView logListView;
        private System.Windows.Forms.ColumnHeader time;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox cycleTextBox;
        private System.Windows.Forms.Label sleepLabel;
        private System.Windows.Forms.TextBox sleepBetweenStepTextBox;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox breakAtStepTextBox;
        private System.Windows.Forms.Label breakAtStepLabel;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton stepButton;
        private System.Windows.Forms.ToolStripButton startButton;
        private System.Windows.Forms.ToolStripButton stopButton;
        private System.Windows.Forms.ToolStripButton imageDesktopButton;
        private System.Windows.Forms.ToolStripButton dataDesktopButton;
        private System.Windows.Forms.ToolStripSeparator separator1;
        private System.Windows.Forms.ToolStripButton initializeButton;
        private System.Windows.Forms.Panel panel1;
    }
}

