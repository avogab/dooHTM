using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Doo.Machine.HTM
{
    partial class HTMRegionViewerControl : UserControl
    {
        HTMRegion _region;
        string _propertyShowed;
        Brush _activeColumnBrush;
        Brush _inactiveColumnBrush;
        Brush _inactiveCellBrush;
        Brush _activeCellBrush;
        Brush _predictiveCellBrush;
        Brush _learningCellBrush;
        Color _backgroundColor;
        Bitmap _bitmap;
        Graphics _g;
        Graphics _g1;

        public string ProperyShowed { get { return _propertyShowed; } set { _propertyShowed = value; } }

        public HTMRegionViewerControl(HTMRegion region)
        {
            InitializeComponent();
            _region = region;
            _activeColumnBrush = new SolidBrush(Color.White);
            _inactiveColumnBrush = new SolidBrush(Color.DarkGray);
            _inactiveCellBrush = new SolidBrush(Color.DarkGray);
            _activeCellBrush = new SolidBrush(Color.White);
            _predictiveCellBrush = new SolidBrush(Color.Yellow);
            _learningCellBrush = new SolidBrush(Color.Blue);
            _backgroundColor = Color.Gray;
            _bitmap = new Bitmap(this.Width, this.Height);
            _g = Graphics.FromImage(_bitmap);
            _g1 = this.CreateGraphics();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _g.Clear(_backgroundColor);
            
            if (_region == null)
                return;

            int x1, y1, x2, y2;
            double halfColSize = 5;  // TO DO: compute the value
            Brush brush = null;
            int count;
            int maxValueProcessed = 20;
            foreach (HTMColumn col in _region.Columns)
            {
                x1 = (int)(col.X * (Width - 2 * halfColSize));
                x2 = (int)(col.X * (Width - 2 * halfColSize) + 2 * halfColSize);
                y1 = (int)(col.Y * (Height - 2 * halfColSize));
                y2 = (int)(col.Y * (Height - 2 * halfColSize) + 2 * halfColSize);

                switch (_propertyShowed)
                {
                    case "Column activation":
                        if (col.IsActive)
                            brush = _activeColumnBrush;
                        else
                            brush = _inactiveColumnBrush;
                        break;
                    case "Column permanence":
                        brush = new SolidBrush(Color.FromArgb((int)(col.GetAveragePermanence() * 255), 0, 0));
                        break;
                    case "Column overlap":
                        brush = new SolidBrush(Color.FromArgb(Math.Min((int)(col.Overlap * 40), 255), 0, 0));
                        break;
                    case "Column boost":
                        throw new NotImplementedException();
                        brush = new SolidBrush(Color.FromArgb(Math.Min((int)((col.Boost - 1) * 300), 255), 0, 0));
                        break;
                    case "Distal segments count":
                        count = 0;
                        foreach (HTMCell cell in col.Cells)
                            count += cell.DistalSegments.Count;
                        int val = (int)(((double)Math.Min(maxValueProcessed, count)) / maxValueProcessed * 255);
                        // TO DO: use a rainbow instead of a single color.
                        brush = new SolidBrush(Color.FromArgb(val, val, val));
                        break;
                    case "Cell state":
                        bool isActive = false;
                        bool isPredicting = false;
                        bool isLearning = false;
                        foreach (HTMCell cell in col.Cells)
                        {
                            if (cell.GetPredicting(0))
                            {
                                isPredicting = true;
                                break;
                            }
                            else if (cell.GetLearning(0))
                            {
                                isLearning = true;
                                break;
                            }
                        }

                        if (isPredicting)
                        {
                            brush = _predictiveCellBrush;
                            break;
                        }
                        else if (isLearning)
                        {
                            brush = _learningCellBrush;
                            break;
                        }
                        else
                        {
                            foreach (HTMCell cell in col.Cells)
                            {
                                if (cell.GetActive(0))
                                {
                                    isActive = true;
                                    break;
                                }
                            }
                            if (isActive)
                                brush = _activeCellBrush;
                            else
                                brush = _inactiveCellBrush;
                        }
                        break;
                    default:
                        throw new Exception();
                }

                _g.FillEllipse(brush, x1, y1, x2 - x1, y2 - y1);
            }
            _g1.DrawImageUnscaled(_bitmap, 0, 0);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //base.OnPaintBackground(e);
        }
    }
}
