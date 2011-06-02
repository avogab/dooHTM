using System;
using System.Collections.Generic;

namespace Doo.Machine
{
    // Interface implemented by cells with a two-dimension spatial position.
    public interface ISpatialCell
    {
        bool GetActive(int time);
        void SetActive(bool value);
        double X { get; set; }
        double Y { get; set; }
        void Step();
    }
}
