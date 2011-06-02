using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Doo.Machine.HTM
{
    partial class HTMCellsViewer : UserControl
    {
        HTMRegionAgent _region;
        int _indexInColumn;
        //HTMRegionViewerPropertyShowed _propertyShowed;
        Brush _predictiveCellBrush;
        Brush _learningCellBrush;
        Color _backgroundColor;
        Bitmap _bitmap;
        Graphics _g;
        Graphics _g1;
        Point _lastMouseClick;

        //public HTMRegionViewerPropertyShowed PropertyShowed { get { return _propertyShowed; } set { _propertyShowed = value; } }
        public int IndexInColumn { get { return _indexInColumn; } set { _indexInColumn = value; } }

        public HTMCellsViewer(HTMRegionAgent region, int indexInColumn, int width, int height)
        {
            InitializeComponent();
            _region = region;
            _indexInColumn = indexInColumn;
            layerLabel.Text = "Cells with index: " + indexInColumn.ToString();
            _predictiveCellBrush = new SolidBrush(Color.Yellow);
            _learningCellBrush = new SolidBrush(Color.Green);
            _backgroundColor = Color.White;
            this.Width = width;
            this.Height = height + 10; // add the label's height.
            _bitmap = new Bitmap(width, height);
            _g = Graphics.FromImage(_bitmap);
            _g1 = this.CreateGraphics();
            _lastMouseClick = new Point();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _g.Clear(_backgroundColor);

            if (_region == null)
                return;

            int x1, y1, x2, y2;
            int halfColSize = 4;  // TO DO: compute the value
            int width = _bitmap.Width;
            int height = _bitmap.Height;
            foreach (HTMColumn col in _region.Columns)
            {
                x1 = (int)(col.X * (width - 2 * halfColSize));
                x2 = (int)(col.X * (width - 2 * halfColSize)) + 2 * halfColSize;
                y1 = (int)(col.Y * (height - 2 * halfColSize));
                y2 = (int)(col.Y * (height - 2 * halfColSize)) + 2 * halfColSize;
                
                HTMCell cell = col.Cells[_indexInColumn];
                if (cell.GetPredicting(0))
                {
                    //_g.FillEllipse(_predictiveCellBrush, x1, y1, x2 - x1, y2 - y1);
                    //_g.DrawEllipse(new Pen(new SolidBrush(Color.Black), 2), x1, y1, x2 - x1, y2 - y1);

                    _g.FillRectangle(_predictiveCellBrush, x1, y1, x2 - x1, y2 - y1);
                    _g.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2), x1, y1, x2 - x1, y2 - y1);
                }
                else if (cell.GetLearning(0))
                {
                    //_g.FillEllipse(_learningCellBrush, x1, y1, x2 - x1, y2 - y1);
                    //_g.DrawEllipse(new Pen(new SolidBrush(Color.Black), 2), x1, y1, x2 - x1, y2 - y1);

                    _g.FillRectangle(_learningCellBrush, x1, y1, x2 - x1, y2 - y1);
                    _g.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2), x1, y1, x2 - x1, y2 - y1);
                }
                else if (cell.GetActive(0))
                {
                //    _g.DrawEllipse(new Pen(new SolidBrush(Color.Black), 2), x1, y1, x2 - x1, y2 - y1);

                    _g.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2), x1, y1, x2 - x1, y2 - y1);
                }
                else
                {
                    //_g.DrawEllipse(new Pen(new SolidBrush(Color.Black)), x1, y1, x2 - x1, y2 - y1);

                    _g.DrawRectangle(new Pen(new SolidBrush(Color.Black)), x1, y1, x2 - x1, y2 - y1);
                }
            }
            //_g1.DrawRectangle(new Pen(new SolidBrush(Color.White)), 0, 0, width, 10);
            _g1.DrawImageUnscaled(_bitmap, 0, 10);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private void HTMCellsViewer_MouseClick(object sender, MouseEventArgs e)
        {
            _lastMouseClick = e.Location;
        }
    }
}
