using System;
using System.Collections.Generic;

namespace Doo
{
    public interface IAgent
    {
        IAgent InputAgent { get; set; }
        bool Initialize();
        bool Step();
        object GetOutput();
    }

    public interface IDirector
    {
        void Log(string log);
    }

    public struct StatInfo
    {
        double _min;
        double _max;

        public double Min { get { return _min; } set { _min = value; } }
        public double Max { get { return _max; } set { _max = value; } }
    }
}
