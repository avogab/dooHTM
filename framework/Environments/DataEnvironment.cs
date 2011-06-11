using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Doo.Machine;
using Doo.Machine.HTM;

namespace Doo.Environments
{
    public partial class DataEnvironment : Form, IAgent
    {
        IDirector _director;
        int _width;
        Cells2D<HTMCell> _outputCells;
        BinaryData _binaryData;
        int _index;
        delegate void UpdateViewDelegate();

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
            if (_binaryData.Data == null || _binaryData.Data.Count == 0)
            {
                _director.Log("No data uploaded.");
                return false;
            }
            _outputCells = new Cells2D<HTMCell>(_width, 1);
            filePathTextBox.Enabled = false;
            pathButton.Enabled = false;
            return true;
        }

        public bool Step()
        {
            // Clear the output matrix.
            for (int x = 0; x < _outputCells.Width; x++)
                for (int y = 0; y < _outputCells.Height; y++)
                    _outputCells[x, y].SetActive(false);

            // Randomly activate some cells.
            //Random rnd = new Random();
            //for (int i = 0; i < 3; i++)
            //    _outputCells[rnd.Next(_outputCells.Width), rnd.Next(_outputCells.Height)].SetActive(true);

            bool[] row = _binaryData.Data[_index];
            for (int i = 0; i < _width; i++)
                _outputCells[i, 0].SetActive(row[i]);

            UpdateView();

            _index++;
            if (_index >= _binaryData.Data.Count)
                _index = 0;

            return true;
        }

        public object GetOutput()
        {
            return _outputCells;
        }

        private void UpdateView()
        {
            if (this.InvokeRequired)
            {
                Invoke(new UpdateViewDelegate(UpdateView));
                return;
            }
            currentDataTextBox.Text = _binaryData.ToString(_index);
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Binary file (*.*)|*.*|Other file|(*.*)";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            filePathTextBox.Text = openFileDialog1.FileName;
            LoadBinaryFile(openFileDialog1.FileName);
        }

        private void LoadBinaryFile(string path)
        {
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                string line;
                line = reader.ReadLine();
                _width = line.Length;  // Look at the first line to set the width.
                int rows = 0;
                bool[] vector;
                List<bool[]> data = new List<bool[]>();
                do
                {
                    rows++;
                    vector = new bool[_width];
                    for (int i = 0; i < _width; i++)
                    {
                        if (line[i] == '0')
                            vector[i] = false;
                        else if (line[i] == '1')
                            vector[i] = true;
                        else
                        {
                            _director.Log("Invalid file format at line " + rows.ToString());
                            goto final;
                        }
                    }
                    data.Add(vector);
                    _director.Log(line);
                } while ((line = reader.ReadLine()) != null);
                _binaryData = new BinaryData();
                _binaryData.Data = data;
            final:
                reader.Close();
            }
        }
    }
}
