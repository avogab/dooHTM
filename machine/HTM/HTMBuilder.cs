using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Doo.Machine.HTM;

namespace Doo.Machine.HTM
{
    public partial class HTMBuilder : Form, IAgent
    {
        IAgent _inputAgent;  // tipically an image preprocessor
        IDirector _director;
        bool _isInitialized;
        int _inputWidth;
        int _inputHeight;
        int _regionWidth;
        int _regionHeight;
        HTMRegionAgent _regionAgent;
        HTMRegionViewer _regionViewer;

        public IAgent InputAgent { get { return _inputAgent; } set { _inputAgent = value; } }
        public int MinimumOverlap { set { minimumOverlapTextBox.Text = value.ToString(); } }
        public int DesiredLocalActivity { set { desiredLocalActivityTextBox.Text = value.ToString(); } }
        public int SegmentActivationThreshold { set { segmentActivationThresholdTextBox.Text = value.ToString(); } }
        public int MinSegmentActivityForLearning { set { minSegmentActivityForLearningTextBox.Text = value.ToString(); } }
        public int RegionWidth { set { regionWidthTextBox.Text = value.ToString(); } }
        public int RegionHeight { set { regionHeightTextBox.Text = value.ToString(); } }

        public HTMBuilder(IDirector director)
        {
            InitializeComponent();
            regionWidthTextBox.Text = "20";
            regionHeightTextBox.Text = "12";
            networkSizeComboBox.Items.Add("1 x 1");
            networkSizeComboBox.Items.Add("1 x 2");
            networkSizeComboBox.Items.Add("1 x 3");
            networkSizeComboBox.Items.Add("1 x 4");
            networkSizeComboBox.SelectedIndex = 1;
            _director = director;
            _isInitialized = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool Initialize()
        {
            // Network param
            int cellsPerColumn;
            int minimumOverlap;
            int desiredLocalActiviy;
            int segmentActivationThreshold;
            int minSegmentActivityForLearning;
            double proximalSegmentCoverage;
            try
            {
                _regionWidth = int.Parse(regionWidthTextBox.Text);
                _regionHeight = int.Parse(regionHeightTextBox.Text);
                cellsPerColumn = int.Parse(networkSizeComboBox.Text.Substring(networkSizeComboBox.Text.Length - 1, 1));
                minimumOverlap = int.Parse(minimumOverlapTextBox.Text);
                desiredLocalActiviy = int.Parse(desiredLocalActivityTextBox.Text);
                segmentActivationThreshold = int.Parse(segmentActivationThresholdTextBox.Text);
                minSegmentActivityForLearning = int.Parse(segmentActivationThresholdTextBox.Text);
                proximalSegmentCoverage = double.Parse(proximalSegmentCoverageTextBox.Text) / 100;
            }
            catch (Exception exch)
            {
                _director.Log(exch.ToString());
                return false;
            }
            if (proximalSegmentCoverage < 0 && proximalSegmentCoverage > 1)
            {
                _director.Log("Proximal segment coverage out of range.");
                return false;
            }

            // Create the network.
            _regionAgent = new HTMRegionAgent(_director, _regionWidth, _regionHeight, cellsPerColumn, minimumOverlap, desiredLocalActiviy, segmentActivationThreshold, minSegmentActivityForLearning, proximalSegmentCoverage);
            _regionAgent.InputAgent = _inputAgent;
            _regionAgent.Initialize();

            // Create the viewer
            _regionViewer = new HTMRegionViewer(_regionAgent);
            _regionViewer.MdiParent = this.MdiParent;
            _regionViewer.Location = new Point(this.Left + this.Width, 20);
            _regionViewer.Show();

            _isInitialized = true;
            structureGroupBox.Enabled = false;  // disable the structural parameters
            return true;
        }

        public object GetOutput()
        {
            throw new NotImplementedException();
        }

        public void Log(string msg)
        {
            _director.Log(msg);
        }

        public bool Step()
        {
            if (!_isInitialized)
            {
                _director.Log("Called Step() before network creation.");
                return false;
            }
            _regionAgent.Step();
            _regionViewer.UpdateView();
            return true;
        }

        private void minimumOverlapTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_regionAgent == null)
                return;

            _regionAgent.MinOverlap = int.Parse(minimumOverlapTextBox.Text);
        }

        private void desiredLocalActivityTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_regionAgent == null)
                return;
            _regionAgent.DesiredLocalActivity = int.Parse(desiredLocalActivityTextBox.Text);
        }

        private void segmentActivationThresholdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_regionAgent == null)
                return;
            _regionAgent.SegmentActivationThreshold = int.Parse(segmentActivationThresholdTextBox.Text);
        }

        private void minSegmentActivityForLearningTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_regionAgent == null)
                return;
            _regionAgent.MinSegmentActivityForLearning = int.Parse(minSegmentActivityForLearningTextBox.Text);
        }

        private void regionWidthTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
