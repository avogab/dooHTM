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
    public partial class AgentControl : Form, IAgent
    {
        IDirector _director;
        int _inputWidth;
        int _inputHeight;
        int _regionWidth;
        int _regionHeight;
        Cells2D<HTMCell> _inputCells;
        HTMRegion _region;
        //FilterVertex<HTMCell> _filterVertex;
        //Cellls2dViewer _inputViewer;
        HTMRegionViewer _regionViewer;
        Image<Gray, Byte> _previousImage;

        public AgentControl(IDirector director)
        {
            InitializeComponent();
            inputSizeComboBox.Items.Add(" 40 x  25");
            inputSizeComboBox.SelectedIndex = 0;
            regionSizeComboBox.Items.Add(" 20 x  12");
            //regionSizeComboBox.Items.Add(" 40 x  25");
            regionSizeComboBox.SelectedIndex = 0;
            _director = director;
        }

        public AgentControl(IDirector director, int visualRows, int visualColumns, int actuatorsNumber)
        {
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Initialize()
        {
            _inputWidth = int.Parse(inputSizeComboBox.Text.Substring(0, 3));
            _inputHeight = int.Parse(inputSizeComboBox.Text.Substring(6, 3));
            _regionWidth = int.Parse(regionSizeComboBox.Text.Substring(0, 3));
            _regionHeight = int.Parse(regionSizeComboBox.Text.Substring(6, 3));
            _inputCells = new Cells2D<HTMCell>(_inputWidth, _inputHeight);
            //_filterVertex = new FilterVertex<HTMCell>(_inputCells);
            _region = new HTMRegion(this, _inputCells, _regionWidth, _regionHeight, 1, 3, 5);
            _region.DoSpatialLearning = doSpatialLearningCheckBox.Checked;
            _region.DoTemporalLearning = doTemporalLearningCheckBox.Checked;
            //_inputViewer = new Cellls2dViewer(_inputCells);
            //_inputViewer.Show();
            _regionViewer = new HTMRegionViewer(_region);
            panel1.Controls.Add(_regionViewer);
            //_regionViewer.Location = new Point(100, 100);
        }
        
        public void Log(string msg)
        {
            _director.Log(msg);
        }
        
        Image<Gray, Byte> DetectMotion(Image<Gray, Byte> image)
        {
            if (_previousImage == null)
            {
                _previousImage = image.Clone();
                return new Image<Gray, byte>(_inputWidth, _inputHeight);
            }

            Image<Gray, Byte> motionImage;
            motionImage = image.AbsDiff(_previousImage);
            _previousImage = image.Clone();
            return motionImage.ThresholdBinary(new Gray(20), new Gray(255));
        }

        public void SetImage(IImage image)
        {
            Image<Gray, Byte> preprocessedImage;
            if (image != null)
            {
                // Preprocess the received image.
                Image<Gray, Byte> grayImage;
                if (image.NumberOfChannels > 1)
                    grayImage = ((Image<Bgr, Byte>)image).Convert<Gray, Byte>();
                else
                    grayImage = (Image<Gray, Byte>)image;
                preprocessedImage = grayImage.Resize(_inputWidth, _inputHeight, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
                preprocessedImage = preprocessedImage.ThresholdBinary(new Gray(90), new Gray(255));
                preprocessedImage = DetectMotion(preprocessedImage);
                //preprocessedImage = preprocessedImage.ThresholdBinary(new Gray(128), new Gray(255));
            }
            else
            {
                preprocessedImage = new Image<Gray, byte>(_inputWidth, _inputHeight);
            }
            
            // Update the region's input cell.
            byte[, ,] underneathArray = (byte[, ,])preprocessedImage.ManagedArray;
            for (int x = 0; x < _inputWidth; x++)
                for (int y = 0; y < _inputHeight; y++)
                    _inputCells[x, y].SetActive( (underneathArray[y, x, 0] == 255) );

            // Detect the edges
            //_filterVertex.Step();            
            //_inputViewer.UpdateImage();
        }

        public void Step()
        {
            _region.Step();
            _regionViewer.UpdateView();
        }

        public void SetVisualSensor(int row, int column)
        {
            throw new NotImplementedException();
        }

        public void SetVerbalSensor(int letter)
        {
            throw new NotImplementedException();
        }

        public bool GetActuator(int index)
        {
            throw new NotImplementedException();
        }

        private void doSpatialLearningCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _region.DoSpatialLearning = doSpatialLearningCheckBox.Checked;
        }

        private void doTemporalLearningCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _region.DoTemporalLearning = doTemporalLearningCheckBox.Checked;
        }
    }
}
