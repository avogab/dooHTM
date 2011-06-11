using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Doo;

namespace Doo.Environments
{
    public partial class MNistEnvironment : Form, IAgent
    {
        IDirector _director;
        IAgent _inputAgent;
        string _path;
        int _itemsToLoad = 1;
        bool _reversePixel;
        MNistData[] _mnists;
        int _itemIndex;
        const string trainLabelFilename = "train-labels.idx1-ubyte";
        const string trainImageFilename = "train-images.idx3-ubyte";
        const string trainingLabelFilename = "t10k-labels.idx1-ubyte";
        const string trainingImageFilename = "t10k-images.idx3-ubyte";

        public IAgent InputAgent { get { return _inputAgent; } set { _inputAgent = value; } }
        public byte GetCurrentLabel { get { return _mnists[_itemIndex].Label; } }
        public string Path { get { return _path; } set { _path = value; } }
        public int ItemsToLoad { get { return _itemsToLoad; } set { _itemsToLoad = value; } }
        public bool ReversePixel { get { return _reversePixel; } set { _reversePixel = value; } }

        public int ItemIndex
        {
            get
            {
                return _itemIndex;
            }
            set
            {
                if (_mnists != null && value >= 0 && value < _mnists.Length)
                {
                    dbIndexTextBox.Text = value.ToString();
                    mnistTextBox.Text = _mnists[value].Label.ToString();
                    pictureBox1.Image = _mnists[value].Image;
                }
                else
                {
                    dbIndexTextBox.Text = "";
                    mnistTextBox.Text = "";
                    pictureBox1.Image = null;
                }
                pictureBox1.Refresh();
                _itemIndex = value;
            }
        }

        public MNistEnvironment(IDirector director)
        {
            InitializeComponent();
            _director = director;
        }

        public object GetOutput()
        {
            if (_itemIndex == -1)
                return null;
            else
                return _mnists[_itemIndex].Image;
        }

        private void scrollBar1_ValueChanged(object sender, EventArgs e)
        {
            ItemIndex = scrollBar1.Value - 1;
        }

        public bool Initialize()
        {
            string labelFileName = _path + trainLabelFilename;
            string imageFileName = _path + trainImageFilename;
            int itemsCount;

            using (BinaryReader br = new BinaryReader(File.Open(labelFileName, FileMode.Open)))
            {
                int pos = 0;
                int length = (int)br.BaseStream.Length;
                int maginNumber = (br.ReadByte() << 24) + (br.ReadByte() << 16) + (br.ReadByte() << 8) + (br.ReadByte() << 0);
                if (maginNumber != 2049)
                    throw new Exception("Invalid format.");
                pos += 4;
                itemsCount = (br.ReadByte() << 24) + (br.ReadByte() << 16) + (br.ReadByte() << 8) + (br.ReadByte() << 0);
                if (_itemsToLoad > 0)
                    itemsCount = Math.Min(_itemsToLoad, itemsCount);
                pos += 4;
                _mnists = new MNistData[itemsCount];
                int index = 0;
                for (int item = 0; item < itemsCount; item++)
                {
                    _mnists[index].Label = br.ReadByte();
                    pos += 1;
                    if (pos > length)
                        throw new Exception("Unexpected end of file.");
                    index++;
                }
            }

            using (BinaryReader br = new BinaryReader(File.Open(imageFileName, FileMode.Open)))
            {
                int pos = 0;
                int length = (int)br.BaseStream.Length;
                int maginNumber = (br.ReadByte() << 24) + (br.ReadByte() << 16) + (br.ReadByte() << 8) + (br.ReadByte() << 0);
                if (maginNumber != 2051)
                    throw new Exception("Invalid format.");
                pos += 4;
                int imagesCount = (br.ReadByte() << 24) + (br.ReadByte() << 16) + (br.ReadByte() << 8) + (br.ReadByte() << 0);
                pos += 4;
                int rowsCount = (br.ReadByte() << 24) + (br.ReadByte() << 16) + (br.ReadByte() << 8) + (br.ReadByte() << 0);
                pos += 4;
                int columnsCount = (br.ReadByte() << 24) + (br.ReadByte() << 16) + (br.ReadByte() << 8) + (br.ReadByte() << 0);
                pos += 4;
                int index = 0;
                Emgu.CV.Image<Bgr, byte> image;
                byte pixel;

                for (int item = 0; item < itemsCount; item++)
                {
                    image = new Emgu.CV.Image<Bgr, byte>(columnsCount, rowsCount);
                    byte[, ,] arr = (byte[, ,])image.ManagedArray;
                    for (int row = 0; row < rowsCount; row++)
                    {
                        for (int column = 0; column < columnsCount; column++)
                        {
                            if (_reversePixel)
                                pixel = (byte)(255 - br.ReadByte());
                            else
                                pixel = br.ReadByte();
                            arr[row, column, 0] = pixel;
                            arr[row, column, 1] = pixel;
                            arr[row, column, 2] = pixel;
                            pos += 1;
                        }
                    }
                    _mnists[index].Image = image;
                    index++;
                }

                scrollBar1.Minimum = 1;
                scrollBar1.Maximum = itemsCount;
                scrollBar1.SmallChange = 1;
                scrollBar1.LargeChange = Math.Max(1, itemsCount / 10);
                scrollBar1.Value = 1;
                //pictureBox1.Width = columnsCount;
                //pictureBox1.Height = rowsCount;
                ItemIndex = 0;
            }
            return true;
        }

        public bool Step()
        {
            return true;
        }
    }
}
