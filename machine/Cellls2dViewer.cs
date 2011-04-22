using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Doo.Machine.HTM;

namespace Doo.Machine
{
    partial class Cellls2dViewer : UserControl
    {
        Cells2D<HTMCell> _inputs;
        const int cellWidth = 5;
        const int cellHeight = 5;
        
        public Cellls2dViewer(Cells2D<HTMCell> inputs)
        {
            InitializeComponent();
            _inputs = inputs;
            pictureBox.Width = cellWidth * _inputs.Width;
            pictureBox.Height = cellHeight * _inputs.Height;
            Graphics g = pictureBox.CreateGraphics();
            g.Clear(Color.Gray);
        }

        public void UpdateImage()
        {
            if (!showCheckBox.Checked)
                return;

            Graphics g = pictureBox.CreateGraphics();
            int x;
            int y;
            Pen activeColumnPen = new Pen(new SolidBrush(Color.Gray));
            Pen inactiveColumnPen = new Pen(new SolidBrush(Color.White));
            Brush activeColumnBrush = new SolidBrush(Color.Gray);
            Brush inactiveColumnBrush = new SolidBrush(Color.White);
            for (int ix = 0; ix < _inputs.Width; ix++)
            {
                for (int iy = 0; iy < _inputs.Height; iy++)
                {
                    x = (int)(ix * 5);
                    y = (int)(iy * 5);
                    if (_inputs[ix, iy].GetActive(0))
                        g.FillRectangle(activeColumnBrush, x, y, cellWidth, cellHeight);
                    else
                        g.FillRectangle(inactiveColumnBrush, x, y, cellWidth, cellHeight);
                }
            }
        }

        private void showCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Graphics g = pictureBox.CreateGraphics();
            g.Clear(Color.Gray);
        }
    }
}
