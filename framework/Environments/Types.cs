using System;
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
}
