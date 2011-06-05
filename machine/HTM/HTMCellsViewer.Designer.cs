namespace Doo.Machine.HTM
{
    partial class HTMCellsViewer
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
            this.layerLabel = new System.Windows.Forms.Label();
            this.cellPointedLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // layerLabel
            // 
            this.layerLabel.AutoSize = true;
            this.layerLabel.BackColor = System.Drawing.Color.White;
            this.layerLabel.Location = new System.Drawing.Point(3, 0);
            this.layerLabel.Name = "layerLabel";
            this.layerLabel.Size = new System.Drawing.Size(29, 13);
            this.layerLabel.TabIndex = 0;
            this.layerLabel.Text = "layer";
            // 
            // cellPointedLabel
            // 
            this.cellPointedLabel.AutoSize = true;
            this.cellPointedLabel.BackColor = System.Drawing.Color.White;
            this.cellPointedLabel.Location = new System.Drawing.Point(149, 0);
            this.cellPointedLabel.Name = "cellPointedLabel";
            this.cellPointedLabel.Size = new System.Drawing.Size(59, 13);
            this.cellPointedLabel.TabIndex = 1;
            this.cellPointedLabel.Text = "cellPointed";
            // 
            // HTMCellsViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cellPointedLabel);
            this.Controls.Add(this.layerLabel);
            this.Name = "HTMCellsViewer";
            this.Size = new System.Drawing.Size(211, 145);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HTMCellsViewer_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HTMCellsViewer_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label layerLabel;
        private System.Windows.Forms.Label cellPointedLabel;

    }
}
