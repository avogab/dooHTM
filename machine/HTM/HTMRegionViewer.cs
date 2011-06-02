using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Doo.Machine.HTM
{
    public partial class HTMRegionViewer : Form
    {
        HTMRegionAgent _region;
        HTMColumnsViewer[] _columnsViewers;
        HTMCellsViewer[] _cellsViewers;
        delegate void UpdateViewDelegate();

        public HTMRegionViewer(HTMRegionAgent region)
        {
            InitializeComponent();
            _region = region;

            int columnViewersWidth = 150;
            _columnsViewers = new HTMColumnsViewer[4];
            _columnsViewers[0] = new HTMColumnsViewer(_region, HTMRegionViewerPropertyShowed.ColumnActivation, columnViewersWidth, columnViewersWidth);
            _columnsViewers[0].Location = new Point(10, 80);
            this.Controls.Add(_columnsViewers[0]);
            _columnsViewers[1] = new HTMColumnsViewer(_region, HTMRegionViewerPropertyShowed.DistalSegmentsCount, columnViewersWidth, columnViewersWidth);
            _columnsViewers[1].Location = new Point(10 + (columnViewersWidth + 10), 80);
            this.Controls.Add(_columnsViewers[1]);
            _columnsViewers[2] = new HTMColumnsViewer(_region, HTMRegionViewerPropertyShowed.ColumnOverlap, columnViewersWidth, columnViewersWidth);
            _columnsViewers[2].Location = new Point(10 + (columnViewersWidth + 10) * 2, 80);
            this.Controls.Add(_columnsViewers[2]);
            _columnsViewers[3] = new HTMColumnsViewer(_region, HTMRegionViewerPropertyShowed.ColumnPermanence, columnViewersWidth, columnViewersWidth);
            _columnsViewers[3].Location = new Point(10 + (columnViewersWidth + 10) * 3, 80);
            this.Controls.Add(_columnsViewers[3]);

            int cellsViewersWidth = 250;
            int cellsViewersHeight = 250;
            _cellsViewers = new HTMCellsViewer[_region.CellsPerColumn];
            for (int i = 0; i < _region.CellsPerColumn; i++)
            {
                _cellsViewers[i] = new HTMCellsViewer(_region, i, cellsViewersWidth, cellsViewersHeight);
                _cellsViewers[i].Location = new Point(10 + (cellsViewersWidth + 10) * i, 270);
                _cellsViewers[i].Visible = true;
                this.Controls.Add(_cellsViewers[i]);
            }
            this.Width = 10 + (Math.Max(_region.CellsPerColumn, 4) + 1)* columnViewersWidth;
            this.Height = 560;

            doSpatialLearningCheckBox.Checked = _region.DoSpatialLearning;
            doTemporalLearningCheckBox.Checked = _region.DoTemporalLearning;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            UpdateView();
            //base.OnPaint(e);
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
            if (showColumnCheckBox.Checked)
                for (int i = 0; i < _columnsViewers.Length; i++)
                    _columnsViewers[i].Refresh();
            if (showCellsCheckBox.Checked)
                for (int i = 0; i < _cellsViewers.Length; i++)
                    _cellsViewers[i].Refresh();
        }

        private void doSpatialLearningCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _region.DoSpatialLearning = doSpatialLearningCheckBox.Checked;
        }

        private void doTemporalLearningCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _region.DoTemporalLearning = doTemporalLearningCheckBox.Checked;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
