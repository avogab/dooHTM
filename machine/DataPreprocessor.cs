using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Doo.Machine
{
    public partial class DataPreprocessor : Form, IAgent
    {
        IAgent _inputAgent;
        IDirector _director;

        public IAgent InputAgent { get { return _inputAgent; } set { _inputAgent = value; } }

        public DataPreprocessor(IDirector director)
        {
            InitializeComponent();
            _director = director;
        }

        public bool Initialize()
        {
            throw new NotImplementedException();
        }

        public bool Step()
        {
            throw new NotImplementedException();
        }

        public object GetOutput()
        {
            throw new NotImplementedException();
        }
    }
}
