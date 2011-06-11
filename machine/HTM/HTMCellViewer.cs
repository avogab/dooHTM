using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Doo.Machine.HTM
{
    public partial class HTMCellViewer : Form
    {
        HTMCell _cell;

        public HTMCellViewer(HTMCell cell)
        {
            InitializeComponent();
            _cell = cell;
            this.Text = "Cell " + _cell.Column.PosX + "," + _cell.Column.PosY + " index in column: " + _cell.IndexInColumn;
            UpdateView();
        }

        public void UpdateView()
        {
            string str = "";

            //str = "x: " + _cell.X + "  y: " + _cell.Y + Environment.NewLine;
            str += "Status: " + Environment.NewLine;
            str += _cell.StateToString + Environment.NewLine;
            str += Environment.NewLine;
            
            str += "Distal segments:" + Environment.NewLine;
            if (_cell.DistalSegments.Count == 0)
                str += "nothing" + Environment.NewLine;
            int i = 1;
            foreach (HTMSegment seg in _cell.DistalSegments)
            {
                str += "n. " + i;
                foreach (HTMSynapse syn in seg.Synapses)
                    str += " (" + syn.InputCell.Column.PosX + ", " + syn.InputCell.Column.PosY + ")";
                str += Environment.NewLine;
                i++;
            }
            str += Environment.NewLine;
            
            /*
            str += "Segment update list:" + Environment.NewLine;
            if (_cell.SegmentUpdateList.Count == 0)
                str += "nothing" + Environment.NewLine;
            foreach (SegmentUpdate segUpdate in _cell.SegmentUpdateList)
                foreach (HTMCell syn in segUpdate.NewSynapses)
                    str += " (" + syn.Column.PosX + ", " + syn.Column.PosY + ")" + Environment.NewLine;
            */

            str += "Proximal segment (from a matrix with size " + _cell.Column.Region.Width.ToString() + "x" + _cell.Column.Region.Height.ToString() + ")" + Environment.NewLine;
            foreach (HTMSynapse syn in _cell.Column.ProximalSegment.Synapses)
                str += " (" + syn.InputCell.PosX + ", " + syn.InputCell.PosY + ")";
            str += Environment.NewLine;
            str += Environment.NewLine;

            str += "Connected proximal segment" + Environment.NewLine;
            foreach (HTMSynapse syn in _cell.Column.ProximalSegment.Synapses)
                if (syn.GetConnected())
                    str += " (" + syn.InputCell.PosX + ", " + syn.InputCell.PosY + ")";
            str += Environment.NewLine;

            textBox1.Text = str;
        }
    }
}
