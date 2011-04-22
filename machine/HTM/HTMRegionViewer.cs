using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Doo.Machine.HTM
{
    partial class HTMRegionViewer : UserControl
    {
        HTMRegion _region;
        HTMRegionViewerControl _control;
        delegate void UpdateViewDelegate();

        public HTMRegionViewer(HTMRegion region)
        {
            InitializeComponent();
            _region = region;
            _control = new HTMRegionViewerControl(_region);
            _control.Location = new Point(10, 60);
            this.Controls.Add(_control);
            propertyShowedComboBox.Items.Add("Column activation");
            propertyShowedComboBox.Items.Add("Column permanence");
            propertyShowedComboBox.Items.Add("Column overlap");
            //propertyShowedComboBox.Items.Add("Column boost");
            propertyShowedComboBox.Items.Add("Distal segments count");
            propertyShowedComboBox.Items.Add("Cell state");
            propertyShowedComboBox.SelectedIndex = 4;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateView();
            //base.OnPaint(e);
        }

        private void propertyShowedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _control.ProperyShowed = propertyShowedComboBox.Text;
            UpdateView();
        }

        public void UpdateView()
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateViewDelegate(UpdateView));
                return;
            }

            inhibitionRadiusTextBox.Text = _region.InhibitionRadius.ToString("0.000");
            correctPredictionTextBox.Text = _region.CorrectPrediction.ToString();
            _control.Refresh();
        }
    }
}
