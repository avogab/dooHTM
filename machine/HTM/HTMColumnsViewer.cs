using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Doo.Machine.HTM
{
    partial class HTMColumnsViewer : UserControl
    {
        HTMRegionAgent _region;
        HTMRegionViewerPropertyShowed _propertyShowed;
        int _indexInColumn;
        Brush _activeColumnBrush;
        Brush _inactiveColumnBrush;
        Color _backgroundColor;
        Bitmap _bitmap;
        Graphics _g;
        Graphics _g1;
        Point _lastMouseClick;

//        public HTMRegionViewerPropertyShowed PropertyShowed { get { return _propertyShowed; } set { _propertyShowed = value; } }
        public int IndexInColumn { get { return _indexInColumn; } set { _indexInColumn = value; } }

        public HTMColumnsViewer(HTMRegionAgent region, HTMRegionViewerPropertyShowed propertyShowed, int width, int height)
        {
            InitializeComponent();
            _region = region;
            _activeColumnBrush = new SolidBrush(Color.Blue);
            _inactiveColumnBrush = new SolidBrush(Color.White);
            _backgroundColor = Color.White;
            this.Width = width;
            this.Height = height + statLabel.Height + statLabel.Top;
            _bitmap = new Bitmap(width, height);
            _g = Graphics.FromImage(_bitmap);
            _g1 = this.CreateGraphics();
            _lastMouseClick = new Point();
            _propertyShowed = propertyShowed;
            statLabel.Text = propertyShowed.ToString();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _g.Clear(_backgroundColor);
            
            if (_region == null)
                return;

            int x1, y1, x2, y2;
            Brush brush = null;
            int count;
            int width = _bitmap.Width;
            int height = _bitmap.Height;
            int colSize =  Math.Max(Math.Min(width / _region.Width , height / _region.Height) - 1, 2);

            StatInfo stat = _region.GetStatInfo(_propertyShowed);
            double val;
            foreach (HTMColumn col in _region.Columns)
            {
                x1 = (int)(col.X * (width - colSize - 1));
                x2 = (int)(col.X * (width - colSize - 1) + colSize);
                y1 = (int)(col.Y * (height - colSize - 1));
                y2 = (int)(col.Y * (height - colSize - 1) + colSize);

                switch (_propertyShowed)
                {
                    case HTMRegionViewerPropertyShowed.ColumnActivation:
                        if (col.IsActive)
                            brush = _activeColumnBrush;
                        else
                            brush = _inactiveColumnBrush;
                        break;
                    case HTMRegionViewerPropertyShowed.ColumnPermanence:
                        if (stat.Max == stat.Min)
                            val = 0;
                        else
                            val = (col.GetAveragePermanence() - stat.Min) / (stat.Max - stat.Min);
                        brush = new SolidBrush(Rainbow.GetRainbow(val));
                        break;
                    case HTMRegionViewerPropertyShowed.ColumnOverlap:
                        if (stat.Max == stat.Min)
                            val = 0;
                        else
                            val = (col.Overlap - stat.Min) / (stat.Max - stat.Min);
                        brush = new SolidBrush(Rainbow.GetRainbow(val));
                        break;
                    case HTMRegionViewerPropertyShowed.ColumnBoost:
                        if (stat.Max == stat.Min)
                            val = 0;
                        else
                            val = (col.Boost - stat.Min) / (stat.Max - stat.Min);
                        brush = new SolidBrush(Rainbow.GetRainbow(val));
                        break;
                    case HTMRegionViewerPropertyShowed.DistalSegmentsCount:
                        if (stat.Max == stat.Min)
                            val = 0;
                        else
                        {
                            count = 0;
                            foreach (HTMCell cls in col.Cells)
                                count += cls.DistalSegments.Count;
                            val = (count - stat.Min) / (stat.Max - stat.Min);
                        }
                        brush = new SolidBrush(Rainbow.GetRainbow(val));
                        break;
                    default:
                        throw new Exception();
                }

                _g.FillRectangle(brush, x1, y1, x2 - x1, y2 - y1);
                _g.DrawRectangle(new Pen(Color.Black), x1, y1, x2 - x1, y2 - y1);
            }
            _g1.DrawImageUnscaled(_bitmap, 0, statLabel.Height + statLabel.Top);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private void HTMRegionViewerControl_MouseClick(object sender, MouseEventArgs e)
        {
            _lastMouseClick = e.Location;
        }
    }
}
