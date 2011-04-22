using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;

namespace Doo.Environments
{
    public partial class BasicEnvironment : Form, IEnvironment
    {
        IAgent _agent;
        Capture _capture;
        string _sourceFilePath;
        Emgu.CV.Image<Bgr, Byte> _stillImage;
        SourceType _sourceType;
        Random _rnd;
        int _genIndex;
        GeneratedFigure _genFigure;
        GeneratedMovementType _genMovementType;
        const int _genWidth = 200;   // width of the generated image.
        const int _genHeight = 200;   // height of the generated image.
        Image<Bgr, Byte> _genImg;

        public BasicEnvironment()
        {
            InitializeComponent();
            //sourceTypeComboBox.Items.Add("webcam");
            //sourceTypeComboBox.Items.Add("video file");
            sourceTypeComboBox.Items.Add("generated");
            //sourceTypeComboBox.Items.Add("still image");
            sourceTypeComboBox.SelectedIndex = 0;
            movementComboBox.Items.Add("Fixed");
            movementComboBox.Items.Add("Left to right");
            movementComboBox.Items.Add("Circular");
            movementComboBox.SelectedIndex = 2;
            figureComboBox.Items.Add(GeneratedFigure.Line.ToString());
            figureComboBox.Items.Add(GeneratedFigure.Square.ToString());
            figureComboBox.Items.Add(GeneratedFigure.Circle.ToString());
            figureComboBox.SelectedIndex = 1;
        }

        protected override void Dispose(bool disposing)
        {
            if (_capture != null)
                _capture.Dispose();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool Initialize()
        {
            switch (_sourceType)
            {
                case SourceType.WebCam:
                    try
                    {
                        _capture = new Capture();
                    }
                    catch (NullReferenceException exch)
                    {
                        MessageBox.Show(exch.Message);
                    }
                    break;
                case SourceType.StillImage:
                    _stillImage = new Emgu.CV.Image<Bgr, Byte>(".\\Images\\ellipse.png");
                    frameBox.Image = _stillImage;
                    break;
                case SourceType.Generated:
                    _rnd = new Random();
                    _genIndex = 0;
                    _genImg = new Image<Bgr, Byte>(_genWidth, _genHeight);
                    break;
                case SourceType.VideoFile:
                    break;
            }
            return true;
        }
        
        void IEnvironment.SetAgent(IAgent agent)
        {
            _agent = agent;
        }

        Image<Bgr, Byte> StepGenerated()
        {
            int totalCycles = 50;
            int x1, y1, x2, y2;
            int dx, dy;
            int left = 30;
            int top = 30;
            dx = 16;
            dy = 16;
            
            switch (_genMovementType)
            {
                case GeneratedMovementType.Fixed:
                    x1 = left;
                    y1 = top;
                    break;
                case GeneratedMovementType.LeftToRight:
                    x1 = left + (int)((Math.Sin((double)_genIndex / totalCycles * 2 * Math.PI) + 1) * 50);
                    y1 = top;
                    break;
                case GeneratedMovementType.Circular:
                    x1 = left + (int)((Math.Sin((double)_genIndex / totalCycles * 2 * Math.PI) + 1) * 50);
                    y1 = top + (int)((Math.Cos((double)_genIndex / totalCycles * 2 * Math.PI) + 1) * 50);
                    break;
                default:
                    throw new Exception();
            }
            x2 = x1 + dx;
            y2 = y1 + dy;

            int thickness = 2;
            
            // Add the noise
            if (noiseCheckBox.Checked)
            {
                double noiseFactor = 3;
                x1 += (int)(_rnd.NextDouble() * noiseFactor);
                y1 += (int)(_rnd.NextDouble() * noiseFactor);
                x2 += (int)(_rnd.NextDouble() * noiseFactor);
                y2 += (int)(_rnd.NextDouble() * noiseFactor);
            }

            Bgr figureColor = new Bgr(255, 255, 255);
            _genImg.SetZero();
            switch (_genFigure)
            {
                case GeneratedFigure.Line:
                    _genImg.Draw(new LineSegment2D(new Point(x1, y1), new Point(x2, y2)), figureColor, thickness);
                    break;
                case GeneratedFigure.Square:
                    _genImg.Draw(new Rectangle(x1, y1, x2 - x1, y2 - y1), figureColor, thickness);
                    break;
                case GeneratedFigure.Circle:
                    _genImg.Draw(new Ellipse(new Point(x1, y1), new SizeF(x2 - x1, y2 - y1), 0), figureColor, thickness);
                    break;
                default:
                    break;
            }

            _genIndex++;
            if (_genIndex == totalCycles)
                _genIndex = 0;
            return _genImg;
        }

        void IEnvironment.Step()
        {
            Image<Bgr, Byte> frame = null;
            switch (_sourceType)
            {
                case SourceType.WebCam:
                    if (_capture == null)
                        frame = null;
                    else
                        frame = _capture.QueryFrame();
                    break;
                case SourceType.VideoFile:
                    break;
                case SourceType.Generated:
                    frame = StepGenerated();
                    break;
                case SourceType.StillImage:
                    frame = _stillImage;
                    break;
                default:
                    break;
            }
            _agent.SetImage(frame);
            
            // Resize if necessary the frame to display.
            if (showFrameCheckBox.Checked && frame != null)
            {
                if (frameBox.Width < frame.Width
                || frameBox.Height < frame.Height)
                {
                    //frame.Resize
                }
                frameBox.Image = frame;
            }
        }

        void showCaptureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!showFrameCheckBox.Checked)
                frameBox.Image = null;
        }

        void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            _sourceFilePath = openFileDialog.FileName;
            switch (_sourceType)
            {
                case SourceType.StillImage:
                    _stillImage = new Emgu.CV.Image<Bgr, Byte>(_sourceFilePath);
                    frameBox.Image = _stillImage;
                    break;
                case SourceType.VideoFile:
                    break;
            }
        }

        void sourceTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (sourceTypeComboBox.Text)
            {
                case "webcam":
                    _sourceType = SourceType.WebCam;
                    break;
                case "video file":
                    _sourceType = SourceType.VideoFile;
                    fileSourceTab.Select();
                    break;
                case "generated":
                    _sourceType = SourceType.Generated;
                    generatedSourceTab.Select();
                    break;
                case "still image":
                    _sourceType = SourceType.StillImage;
                    break;
                default:
                    break;
            }
            Initialize();
        }

        private void figureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (figureComboBox.Text)
            {
                case "Line":
                    _genFigure = GeneratedFigure.Line;
                    break;
                case "Square":
                    _genFigure = GeneratedFigure.Square;
                    break;
                case "Circle":
                    _genFigure = GeneratedFigure.Circle;
                    break;
                default:
                    throw new Exception();
            }
        }

        private void movementComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (movementComboBox.Text)
            {
                case "Fixed":
                    _genMovementType = GeneratedMovementType.Fixed;
                    break;
                case "Left to right":
                    _genMovementType = GeneratedMovementType.LeftToRight;
                    break;
                case "Circular":
                    _genMovementType = GeneratedMovementType.Circular;
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
