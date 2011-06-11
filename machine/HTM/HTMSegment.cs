using System;
using System.Collections.Generic;

namespace Doo.Machine.HTM
{
    public class HTMSegment
    {
        HTMCell _cell;  // the cell that own the segment.
        bool _isSequence; // flag indicating whether the segment predicts feed-forward input the next time step.
        List<HTMSynapse> _synapses;
        int _activationThreshold;

        public HTMCell Cell { get { return _cell; } }
        public bool IsSequence { get { return _isSequence; } set { _isSequence = value; } }
        public List<HTMSynapse> Synapses { get { return _synapses; } set { _synapses = value; } }

        public HTMSegment(HTMCell cell, int activationThreshold)
        {
            _cell = cell;
            _activationThreshold = activationThreshold;
            _synapses = new List<HTMSynapse>();
            _isSequence = false;
        }

        // Return all the connected synapses.
        public List<HTMSynapse> GetConnectedSynapses()
        {
            List<HTMSynapse> syns = new List<HTMSynapse>();
            foreach (HTMSynapse syn in _synapses)
                if (syn.GetConnected())
                    syns.Add(syn);
            return syns;
        }

        // Return the active synapses at time t.
        public List<HTMSynapse> GetActiveSynapses(int t, bool learning, bool connectedOnly)
        {
            List<HTMSynapse> syns = new List<HTMSynapse>();
            foreach (HTMSynapse syn in _synapses)
                if (syn.GetActive(t, learning, connectedOnly))
                    syns.Add(syn);
            return syns;
        }

        public bool GetActive(int t, bool learning, bool connectedOnly)
        {
            int count = 0;
            foreach (HTMSynapse syn in _synapses)
                if (syn.GetActive(t, learning, connectedOnly))
                    count++;
            return (count >= _activationThreshold);
        }

        public int GetActivity(int t)
        {
            int activity = 0;
            foreach (HTMSynapse syn in _synapses)
                if (syn.GetActive(t, false, false))
                    activity++;
            return activity;
        }
    }
}
