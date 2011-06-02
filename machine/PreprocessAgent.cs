using System;
using System.Collections.Generic;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Doo.Machine
{
    public class PreprocessAgent : IAgent
    {
        IDirector _director;
        int _outputWidth;
        int _outputHeight;
        IAgent _inputAgent;
        Image<Gray, byte> _currentImage;
        Image<Gray, byte> _previousImage;
        Image<Gray, byte> _blankImage;
        Cells2D<Doo.Machine.HTM.HTMCell> _outputCells;
        bool _detectMotion;
        Cellls2dViewer _viewer;
        
        public IAgent InputAgent { get { return _inputAgent; } set { _inputAgent = value; } }
        public bool DetectMotion { get { return _detectMotion; } set { _detectMotion = value; } }

        public PreprocessAgent(IDirector director, int outputWidth, int outputHeight, bool detectMotion)
        {
            _director = director;
            _outputWidth = outputWidth;
            _outputHeight = outputHeight;
            _detectMotion = detectMotion;
            _outputCells = new Cells2D<HTM.HTMCell>(outputWidth, outputHeight);
            //_viewer = new Cellls2dViewer(_outputCells);
            //_viewer.Show();

        }

        public bool Initialize()
        {
            _currentImage = null;
            _previousImage = null;
            _blankImage = new Image<Gray, byte>(_outputWidth, _outputHeight);
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

            //_viewer.UpdateImage();
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
    }
}
