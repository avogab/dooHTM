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
        int _colSize;
        List<HTMCellViewer> _cellViewers;

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
            this.Height = height + layerLabel.Height + layerLabel.Top;
            _bitmap = new Bitmap(width, height);
            _g = Graphics.FromImage(_bitmap);
            _g1 = this.CreateGraphics();
            _cellViewers = new List<HTMCellViewer>();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            _g.Clear(_backgroundColor);

            if (_region == null)
                return;

            int x1, y1, x2, y2;
            int width = _bitmap.Width;
            int height = _bitmap.Height;
            _colSize = Math.Max(Math.Min(width / _region.Width, height / _region.Height) - 2, 2);

            foreach (HTMColumn col in _region.Columns)
            {
                x1 = (int)(col.X * (width - _colSize - 1));
                x2 = (int)(col.X * (width - _colSize - 1)) + _colSize;
                y1 = (int)(col.Y * (height - _colSize - 1));
                y2 = (int)(col.Y * (height - _colSize - 1)) + _colSize;
                
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
            _g1.DrawImageUnscaled(_bitmap, 0, layerLabel.Height + layerLabel.Top);

            // TO DO : move in other method!
            foreach (HTMCellViewer cellViewer in _cellViewers)
                cellViewer.UpdateView();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
        }

        private Point MouseToCell(int x, int y)
        {
            Point p = new Point();
            int cx = (int)((double)x / _bitmap.Width * _region.Width);
            int cy = (int)((double)(y - layerLabel.Height - layerLabel.Top) / _bitmap.Height * _region.Height);

            if (cx < 0 || cx >= _region.Width)
                p.X = -1;
            else
                p.X = cx;
            if (cy < 0 || cy >= _region.Height)
                p.Y = -1;
            else
                p.Y = cy;
            return p;
        }

        private void HTMCellsViewer_MouseClick(object sender, MouseEventArgs e)
        {
            Point p = MouseToCell(e.X, e.Y);
            if (p.X == -1 || p.Y == -1)
                return;
            HTMCellViewer cellViewer = new HTMCellViewer(_region.Columns[p.X, p.Y].Cells[_indexInColumn]);
            cellViewer.MdiParent = ((Form)(this.Parent)).MdiParent;
            cellViewer.Show();
            _cellViewers.Add(cellViewer);
        }

        private void HTMCellsViewer_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = MouseToCell(e.X, e.Y);
            if (p.X == -1 || p.Y == -1)
                cellPointedLabel.Text = "";
            else
                cellPointedLabel.Text = p.X + "," + p.Y;
        }
    }
}
