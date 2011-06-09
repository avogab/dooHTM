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
    public partial class ImageEnvironment : Form, IAgent
    {
        IDirector _director;
        Capture _capture;
        SourceType _sourceType;
        Random _rnd;
        Image<Bgr, byte> _lastFrame;
        int _genIndex;
        GeneratedFigure _genFigure;
        GeneratedMovementType _genMovementType;
        const int _genWidth = 200;   // width of the generated image.
        const int _genHeight = 200;   // height of the generated image.
        Image<Bgr, Byte> _genImg;
        //AxQTOControlLib.AxQTControl qtPlayer;
        delegate bool StepDelegate();

        public IAgent InputAgent { get { return null; } set { ; } }

        public ImageEnvironment(IDirector director)
        {
            InitializeComponent();
            _director = director;

            // Quick time control initialization
            //qtPlayer = new AxQTOControlLib.AxQTControl();
            //qtPlayer.Name = "qtPlayer";
            //this.Controls.Add(qtPlayer);
            //qtPlayer.Location = frameBox.Location;
            //qtPlayer.Size = frameBox.Size;


            fileNameTextBox.Text = Application.StartupPath + "\\Media\\QuickTimeSample.mov";
            sourceTypeComboBox.Items.Add("generated");
            sourceTypeComboBox.Items.Add("webcam");
            //sourceTypeComboBox.Items.Add("video file");
            //sourceTypeComboBox.Items.Add("still image");
            sourceTypeComboBox.SelectedIndex = 0;
            figureComboBox.Items.Add(GeneratedFigure.VerticalBar.ToString());
            figureComboBox.Items.Add(GeneratedFigure.ObliqueLine.ToString());
            figureComboBox.Items.Add(GeneratedFigure.Square.ToString());
            figureComboBox.Items.Add(GeneratedFigure.Circle.ToString());
            figureComboBox.SelectedIndex = 2;
            genSizeComboBox.Items.Add("small");
            genSizeComboBox.Items.Add("medium");
            genSizeComboBox.Items.Add("big");
            genSizeComboBox.SelectedIndex = 0;
            movementComboBox.Items.Add("fixed");
            movementComboBox.Items.Add("left to right");
            movementComboBox.Items.Add("circular clockwise");
            movementComboBox.Items.Add("circular anticlockwise");
            movementComboBox.SelectedIndex = 2;
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
            if (_capture != null && _sourceType != SourceType.WebCam)
                _capture.Dispose();
            
            switch (_sourceType)
            {
                case SourceType.WebCam:
                    frameBox.Visible = true;
                    try
                    {
                        if (_capture == null)
                            _capture = new Capture();
                    }
                    catch (NullReferenceException exch)
                    {
                        MessageBox.Show(exch.Message);
                    }
                    break;
                case SourceType.Generated:
                    frameBox.Visible = true;
                    _rnd = new Random();
                    _genIndex = 0;
                    _genImg = new Image<Bgr, Byte>(_genWidth, _genHeight);
                    break;
                case SourceType.VideoFile:
                    //frameBox.Visible = false;
                    //try
                    //{
                    //    qtPlayer.URL = fileNameTextBox.Text;
                    //}
                    //catch (Exception exch)
                    //{
                    //    _director.Log(exch.ToString());
                    //}
                    break;
            }
            return true;
        }
        
        Image<Bgr, Byte> StepGenerated()
        {
            int totalCycles = 50;
            int x1, y1, x2, y2;
            int dx = 0, dy = 0; // figure size
            int left = 0;
            int top = 0;
            int thickness = 0;

            if (_genFigure == GeneratedFigure.VerticalBar)
            {
                switch (genSizeComboBox.Text)
                {
                    case "small":
                        thickness = 3;
                        break;
                    case "medium":
                        thickness = 10;
                        break;
                    case "big":
                        thickness = 20;
                        break;
                    default:
                        break;
                }
                dy = _genHeight;
            }
            else
            {
                switch (genSizeComboBox.Text)
                {
                    case "small":
                        dx = 16;
                        dy = 16;
                        break;
                    case "medium":
                        dx = 32;
                        dy = 32;
                        break;
                    case "big":
                        dx = 64;
                        dy = 64;
                        break;
                }
                thickness = 3;
            }
           
            int width = _genWidth;
            int height = _genHeight;
            
            
            switch (_genMovementType)
            {
                case GeneratedMovementType.Fixed:
                    x1 = left;
                    y1 = top;
                    break;
                case GeneratedMovementType.LeftToRight:
                    x1 = left + (int)((Math.Sin((double)_genIndex / totalCycles * 2 * Math.PI) + 1) / 2 * (width - dx));
                    y1 = top;
                    break;
                case GeneratedMovementType.CircularClockwise:
                    x1 = left + (int)((Math.Sin(-(double)_genIndex / totalCycles * 2 * Math.PI) + 1) / 2 * (width - dx));
                    y1 = top + (int)((Math.Cos((double)_genIndex / totalCycles * 2 * Math.PI) + 1) / 2 * (height - dy));
                    break;
                case GeneratedMovementType.CircularAnticlockwise:
                    x1 = left + (int)((Math.Sin((double)_genIndex / totalCycles * 2 * Math.PI) + 1) / 2 * (width - dx));
                    y1 = top + (int)((Math.Cos((double)_genIndex / totalCycles * 2 * Math.PI) + 1) / 2 * (height - dy));
                    break;
                default:
                    throw new Exception();
            }
            x2 = x1 + dx;
            y2 = y1 + dy;
            
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
                case GeneratedFigure.VerticalBar:
                    _genImg.Draw(new LineSegment2D(new Point(x1, y1), new Point(x1, y2)), figureColor, thickness);
                    break;
                case GeneratedFigure.ObliqueLine:
                    _genImg.Draw(new LineSegment2D(new Point(x1, y1), new Point(x2, y2)), figureColor, thickness);
                    break;
                case GeneratedFigure.Square:
                    _genImg.Draw(new Rectangle(x1, y1, x2 - x1, y2 - y1), figureColor, thickness);
                    break;
                case GeneratedFigure.Circle:
                    _genImg.Draw(new Ellipse(new Point(x1 + dx / 2, y1 + dy / 2), new SizeF(x2 - x1, y2 - y1), 0), figureColor, thickness);
                    break;
                default:
                    break;
            }

            _genIndex++;
            if (_genIndex == totalCycles)
                _genIndex = 0;
            return _genImg;
        }

        public bool Step()
        {
            if (this.InvokeRequired)
            {
                return (bool)this.Invoke(new StepDelegate(Step));
            }

            Image<Bgr, Byte> frame = null;
            Image<Bgr, Byte> frameToShow = null;
            switch (_sourceType)
            {
                case SourceType.WebCam:
                    if (_capture == null)
                        frame = null;
                    else
                        frame = _capture.QueryFrame();
                    // Resize if necessary the frame to display.
                    if (showFrameCheckBox.Checked && frame != null)
                    {
                        frameToShow = frame.Resize(frameBox.Width, frameBox.Height, Emgu.CV.CvEnum.INTER.CV_INTER_NN);
                        frameBox.Image = frameToShow;
                    }
                    break;
                    
                case SourceType.VideoFile:
                    //if (qtPlayer.Movie == null)
                    //{
                    //    _director.Log("Movie not set in the quicktimeplayer.");
                    //    return false;
                    //}
                    //qtPlayer.Movie.StepFwd();
                    //qtPlayer.Movie.CopyFrame();
                    //Bitmap bmp = (Bitmap)Clipboard.GetImage();
                    //if (bmp != null)
                    //    frame = new Emgu.CV.Image<Bgr, byte>(bmp);
                    break;
                case SourceType.Generated:
                    frame = StepGenerated();
                    if (showFrameCheckBox.Checked && frame != null)
                    {
                        frameToShow = frame.Resize(frameBox.Width, frameBox.Height, Emgu.CV.CvEnum.INTER.CV_INTER_NN);
                        frameBox.Image = frameToShow;
                    }
                    break;
                default:
                    break;
            }
            _lastFrame = frame;
            return true;
        }

        public object GetOutput()
        {
            return _lastFrame;
        }

        void showCaptureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!showFrameCheckBox.Checked)
                frameBox.Image = null;
        }

        void browseButton_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            fileNameTextBox.Text = openFileDialog.FileName;
            switch (_sourceType)
            {
                //case SourceType.StillImage:
                //    _stillImage = new Emgu.CV.Image<Bgr, Byte>(_sourceFilePath);
                //    frameBox.Image = _stillImage;
                //    break;
                case SourceType.VideoFile:
                    //try
                    //{
                    //    if (qtPlayer.Movie != null)
                    //        qtPlayer.Movie.Disconnect();
                    //    qtPlayer.URL = fileNameTextBox.Text;
                    //}
                    //catch (Exception exch)
                    //{
                    //    _director.Log(exch.ToString());
                    //}
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
                default:
                    break;
            }
            Initialize();
        }

        private void figureComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (figureComboBox.Text)
            {
                case "VerticalBar":
                    _genFigure = GeneratedFigure.VerticalBar;
                    break;
                case "ObliqueLine":
                    _genFigure = GeneratedFigure.ObliqueLine;
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
                case "fixed":
                    _genMovementType = GeneratedMovementType.Fixed;
                    break;
                case "left to right":
                    _genMovementType = GeneratedMovementType.LeftToRight;
                    break;
                case "circular clockwise":
                    _genMovementType = GeneratedMovementType.CircularClockwise;
                    break;
                case "circular anticlockwise":
                    _genMovementType = GeneratedMovementType.CircularAnticlockwise;
                    break;
                default:
                    throw new Exception();
            }
        }

        private void loopVideoFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //qtPlayer.Movie.Loop = loopVideoFileCheckBox.Checked;
        }
    }
}
