using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Doo.Machine.HTM;

namespace Doo.Machine
{
    public partial class ImagePreprocessor : Form, IAgent
    {
        IAgent _inputAgent;
        IDirector _director;
        int _outputWidth;
        int _outputHeight;
        Image<Gray, byte> _currentImage;
        Image<Gray, byte> _previousImage;
        Image<Gray, byte> _blankImage;
        Cells2D<HTMCell> _outputCells;
        bool _detectMotion;

        public IAgent InputAgent { get { return _inputAgent; } set { _inputAgent = value; } }
        public bool DetectMotion { get { return _detectMotion; } set { _detectMotion = value; } }

        public ImagePreprocessor(IDirector director)
        {
            InitializeComponent();
            outputSizeComboBox.Items.Add(" 40 x  25");
            outputSizeComboBox.Items.Add(" 20 x  01");
            outputSizeComboBox.SelectedIndex = 0;
            _director = director;
        }

        public bool Initialize()
        {
            _currentImage = null;
            _previousImage = null;
            _outputWidth = int.Parse(outputSizeComboBox.Text.Substring(0, 3));
            _outputHeight = int.Parse(outputSizeComboBox.Text.Substring(6, 3));
            _blankImage = new Image<Gray, byte>(_outputWidth, _outputHeight);
            _outputCells = new Cells2D<HTMCell>(_outputWidth, _outputHeight);

            //
            outputSizeComboBox.Enabled = false;
            detectMotionCheckBox.Enabled = true;
            return true;
        }

        public bool Step()
        {
            Image<Bgr, byte> inputImage = (Image<Bgr, byte>)(_inputAgent.GetOutput());
            if (inputImage == null)
            {
                _currentImage = _blankImage;
                for (int x = 0; x < _outputWidth; x++)
                    for (int y = 0; y < _outputHeight; y++)
                        _outputCells[x, y].SetActive(false);
                return true;
            }

            Image<Gray, Byte> grayImage = inputImage.Convert<Gray, Byte>();
            _currentImage = grayImage.Resize(_outputWidth, _outputHeight, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR);
            if (_detectMotion)
                _currentImage = Motion(_currentImage);
            _currentImage = _currentImage.ThresholdBinary(new Gray(128), new Gray(255));

            byte[, ,] underneathArray = (byte[, ,])_currentImage.ManagedArray;
            for (int x = 0; x < _outputWidth; x++)
                for (int y = 0; y < _outputHeight; y++)
                    _outputCells[x, y].SetActive((underneathArray[y, x, 0] == 255));

            return true;
        }

        public object GetOutput()
        {
            return _outputCells;
        }

        Image<Gray, Byte> Motion(Image<Gray, Byte> image)
        {
            if (_previousImage == null)
            {
                _previousImage = image.Clone();
                return _blankImage;
            }

            Image<Gray, Byte> motionImage;
            motionImage = image.AbsDiff(_previousImage);
            _previousImage = image.Clone();
            return motionImage.ThresholdBinary(new Gray(20), new Gray(255));
        }

        private void detectMotionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _detectMotion = detectMotionCheckBox.Checked;
        }
    }
}
