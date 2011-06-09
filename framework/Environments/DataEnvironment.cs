using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Doo.Machine;
using Doo.Machine.HTM;

namespace Doo.Environments
{
    public partial class DataEnvironment : Form, IAgent
    {
        IDirector _director;
        Cells2D<HTMCell> _outputCells;

        public IAgent InputAgent { get { return null; } set { ; } }

        public DataEnvironment(IDirector director)
        {
            InitializeComponent();
            _director = director;

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool Initialize()
        {
            _outputCells = new Cells2D<HTMCell>(20, 20);
            return true;
        }

        public bool Step()
        {
            // Clear the output matrix.
            for (int x = 0; x < _outputCells.Width; x++)
                for (int y = 0; y < _outputCells.Height; y++)
                    _outputCells[x, y].SetActive(false);

            // Randomly activate some cells.
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
                _outputCells[rnd.Next(_outputCells.Width), rnd.Next(_outputCells.Height)].SetActive(true);

            return true;
        }

        public object GetOutput()
        {
            return _outputCells;
        }
    }
}
