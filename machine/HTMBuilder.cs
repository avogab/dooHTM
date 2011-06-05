using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Doo.Machine.HTM;

namespace Doo.Machine
{
    public partial class HTMBuilder : Form, IAgent
    {
        IAgent _inputAgent;
        IDirector _director;
        bool _isInitialized;
        int _inputWidth;
        int _inputHeight;
        int _regionWidth;
        int _regionHeight;
        HTMRegionAgent _regionAgent;
        PreprocessAgent _preprocessAgent;
        HTMRegionViewer _regionViewer;

        public IAgent InputAgent { get { return _inputAgent; } set { _inputAgent = value; } }

        public HTMBuilder(IDirector director)
        {
            InitializeComponent();
            inputSizeComboBox.Items.Add(" 40 x  25");
            inputSizeComboBox.Items.Add(" 20 x  01");
            inputSizeComboBox.SelectedIndex = 0;
            regionSizeComboBox.Items.Add(" 40 x  25");
            regionSizeComboBox.Items.Add(" 20 x  12");
            regionSizeComboBox.Items.Add(" 20 x  01");
            regionSizeComboBox.SelectedIndex = 1;
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
            double proximalSegmentCoverage;
            try
            {
                _inputWidth = int.Parse(inputSizeComboBox.Text.Substring(0, 3));
                _inputHeight = int.Parse(inputSizeComboBox.Text.Substring(6, 3));
                _regionWidth = int.Parse(regionSizeComboBox.Text.Substring(0, 3));
                _regionHeight = int.Parse(regionSizeComboBox.Text.Substring(6, 3));
                cellsPerColumn = int.Parse(networkSizeComboBox.Text.Substring(networkSizeComboBox.Text.Length - 1, 1));
                minimumOverlap = int.Parse(minimumOverlapTextBox.Text);
                desiredLocalActiviy = int.Parse(desiredLocalActivityTextBox.Text);
                segmentActivationThreshold = int.Parse(segmentActivationThresholdTextBox.Text);
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
            _preprocessAgent = new PreprocessAgent(_director, _inputWidth, _inputHeight, true);
            _preprocessAgent.InputAgent = this.InputAgent; // Redirect the input to the first node of the network.
            _regionAgent = new HTMRegionAgent(_director, _inputWidth, _inputHeight, _regionWidth, _regionHeight, cellsPerColumn, minimumOverlap, desiredLocalActiviy, segmentActivationThreshold, proximalSegmentCoverage);
            _regionAgent.InputAgent = _preprocessAgent;
            _preprocessAgent.Initialize();
            _regionAgent.Initialize();

            // Create the viewer
            _regionViewer = new HTMRegionViewer(_regionAgent);
            _regionViewer.Location = new Point(this.Left + this.Width, this.Top);
            _regionViewer.Show();

            _isInitialized = true;
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
            _preprocessAgent.Step();
            _regionAgent.Step();
            _regionViewer.UpdateView();
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Initialize())
                return;
            structureGroupBox.Enabled = false;
            detectMotionCheckBox.Enabled = true;
        }

        private void detectMotionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _preprocessAgent.DetectMotion = detectMotionCheckBox.Checked;
        }

        private void regionSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
