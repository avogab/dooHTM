using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Doo
{
    public static class Rainbow
    {
        // index range from 0 to 255 --> colors from [0 255 0] to [255 255 0]
        // index range from 256 to 510 --> colors from [255 255 0] to [0 255 0]
        // index range from 511 to 765 --> colors from [0 255 0] to [0 255 255]
        // index range from 766 to 1020 --> colors from [0 255 255] to [0 0 255]
        // index range from 1021 to 1270 --> colors from [0 0 255] to [255 0 255]
        public static Color GetRainbow(double dbl)
        {
            int val = (int)(dbl * 1270);
            int red = 0;
            int green = 0;
            int blue = 0;

            if (val <= 255)
                red = 255;
            else if (val > 1020)
                red = val - 1020;

            if (val <= 255)
                green = val;
            else if (val <= 765)
                green = 255;

            if (val > 510 && val <= 765)
                blue = val - 510;
            else if (val > 765)
                blue = 255;

            return Color.FromArgb(red, green, blue);
        }
    }
}
