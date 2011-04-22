using System;
using System.Collections.Generic;
using System.Text;

namespace Doo.Machine.HTM
{
    // This data structure holds three pieces of information required to update 
    // a given segment: 
    // a) segment reference (None if it's a new segment), 
    // b) a list of existing active synapses, and 
    // c) a flag indicating whether this segment should be marked as a sequence
    // segment (defaults to false).
    // The structure also determines which learning cells (at this time step)
    // are available to connect (add synapses to) should the segment get updated.
    // If there is a locality radius set on the Region, the pool of learning cells
    // is restricted to those with the radius.
    class SegmentUpdate
    {
        HTMSegment _segment;
        bool _addNewSynapses;
        bool _isSequence;
        List<HTMSynapse> _activeSynapses;
        List<HTMCell> _newSynapses;

        public HTMSegment Segment { get { return _segment; } set { _segment = value; } }
        public bool AddNewSynapses { get { return _addNewSynapses; } set { _addNewSynapses = value; } }
        public bool IsSequence { get { return _isSequence; } set { _isSequence = value; } }
        public List<HTMSynapse> ActiveSynapses { get { return _activeSynapses; } set { _activeSynapses = value; } }
        public List<HTMCell> NewSynapses { get { return _newSynapses; } set { _newSynapses = value; } }
    }

    struct CellSegmentInfo
    {
        HTMCell _cell;
        HTMSegment _segment;

        public HTMCell Cell { get { return _cell; } set { _cell = value; } }
        public HTMSegment Segment { get { return _segment; } set { _segment = value; } }
    }
}
