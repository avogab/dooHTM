using System;
using System.Collections.Generic;
using System.Text;

namespace Doo.Machine
{
    class FilterVertex<T> : Cells2D<T> where T : ISpatialCell, new()
    {
        Cells2D<T> _inputs;

        public FilterVertex(Cells2D<T> inputs)
            : base(inputs.Width, inputs.Height)  // to change. the width and height of this structure is a function of inputs.width and inputs.height
        {
            _inputs = inputs;
        }

        public void Step()
        {
            for (int ix = 0; ix < _inputs.Width - 1; ix++)
            {
                for (int iy = 0; iy < _inputs.Height; iy++)
                {
                    //this[ix, iy].IsActive = _inputs[ix, iy].IsActive;
                    if (_inputs[ix, iy].GetActive(0) && _inputs[ix + 1, iy].GetActive(0))
                        this[ix, iy].SetActive(true);
                    else
                        this[ix, iy].SetActive(false);
                }
            }
        }
    }
}
