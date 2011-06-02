using System;
using System.Collections.Generic;

namespace Doo.Machine.HTM
{
    public class HTMSynapse
    {
        HTMCell _inputCell;
        double _permanence;

        public const double _initialPermanence = 0.2;  // Initial permanence value for a synapse.
        public const double _connectedPermanence = 0.2; // If the permanence value for the synapse is greater than this value, it is said to be connected.
        public const double _permanenceIncrement = 0.05; // Amount permanence values of synapses are incremented when activity-based learning occurs.
        public const double _permanenceDecrement = 0.04; // Amount permanence values of synapses are decremented when activity-based learning occurs.
        
        public HTMCell InputCell { get { return _inputCell; } set { _inputCell = value; } }
        public double Permanence { get { return _permanence; } }
        
        public HTMSynapse(HTMCell inputCell, double permanence = _initialPermanence)
        {
            _inputCell = inputCell;
            _permanence = permanence;
        }

        public bool GetConnected()
        {
            return (_permanence >= _connectedPermanence);
        }

        // Return the active state at time t.
        public bool GetActive(int t, bool learning, bool connectedOnly)
        {
            return _inputCell.GetActive(t) && (_inputCell.GetLearning(t) || !learning) && (GetConnected() || !connectedOnly);
        }

        // Increases the permanence of this synapse.
        public void IncreasePermanence(double increment = _permanenceIncrement)
        {
            _permanence = Math.Min(1.0, _permanence + increment);
        }

        // Decreases the permanence of this synapse.
        public void DecreasePermanence(double decrement = _permanenceDecrement)
        {
            _permanence = Math.Max(0.0, _permanence - decrement);
        }
    }
}
