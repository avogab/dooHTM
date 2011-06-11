using System;
using System.Collections.Generic;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Doo.Environments
{
    enum GeneratedFigure
    {
        Missing = 0,
        VerticalBar,
        ObliqueLine,
        Square,
        Circle
    }

    enum GeneratedMovementType
    {
        Missing = 0,
        Fixed,
        LeftToRight,
        CircularClockwise,
        CircularAnticlockwise
    }

    struct MNistData
    {
        byte _label;
        Image<Bgr, byte> _image;

        public byte Label { get { return _label; } set { _label = value; } }
        public Image<Bgr, byte> Image { get { return _image; } set { _image = value; } }
    }

    struct BinaryData
    {
//        int _width;
        List<bool[]> _data;

        public List<bool[]> Data { get { return _data; } set { _data = value; } }
        
        public string ToString(int index)
        {
            string str = "";
            for (int i = 0; i < _data[index].Length; i++)
                if (_data[index][i])
                    str += "1";
                else
                    str += "0";
            return str;
        }
    }
}
