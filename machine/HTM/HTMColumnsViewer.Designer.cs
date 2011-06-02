namespace Doo.Machine.HTM
{
    partial class HTMColumnsViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // statLabel
            // 
            this.statLabel.AutoSize = true;
            this.statLabel.Location = new System.Drawing.Point(3, 0);
            this.statLabel.Name = "statLabel";
            this.statLabel.Size = new System.Drawing.Size(24, 13);
            this.statLabel.TabIndex = 0;
            this.statLabel.Text = "stat";
            // 
            // HTMColumnsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statLabel);
            this.Name = "HTMColumnsViewer";
            this.Size = new System.Drawing.Size(150, 95);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HTMRegionViewerControl_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label statLabel;
    }
}
