using System;
using System.Collections.Generic;
using Emgu.CV;

namespace Doo
{
    public interface IAgent
    {
        void Initialize();
        void Step();
        void SetVisualSensor(int row, int column);
        void SetImage(IImage image);
        void SetVerbalSensor(int letter);
        bool GetActuator(int index);
        void Show();
        int Left { get; set; }
        int Top { get; set; }
    }

    public interface IEnvironment
    {
        bool Initialize();
        void Step();
        void SetAgent(IAgent agent);
        void Show();
        int Left { get; set; }
        int Top { get; set; }
    }

    public interface IDirector
    {
        void Log(string log);
    }
}
