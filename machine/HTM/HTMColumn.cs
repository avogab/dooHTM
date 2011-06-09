using System;
using System.Collections.Generic;

namespace Doo.Machine.HTM
{
    // Represents a single column of cells within an HTM Region.
    public class HTMColumn
    {
        HTMRegionAgent _region;
        int _posX;  // The x-position of the column inside the matrix
        int _posY;  // The y-position of the column inside the matrix
        double _x;  // The x spatial position of the column. Range from 0 to 1.
        double _y;  // The x-position of the column inside the matrix. Range from 0 to 1.
        List<HTMCell> _cells;
        HTMSegment _proximalSegment;
        bool _isActive;
        double _overlap;
        double _boost; // The boost value for column c as computed during learning - used to increase the overlap value for inactive columns.
        double _activeDutyCycle;  // A sliding average representing how often column c has been active after inhibition.
        double _overlapDutyCycle;   // A sliding average representing how often column c has had significant overlap (i.e. greater than minOverlap) with its inputs
        const double permanenceInc = 0.1;  // Amount permanence values of synapses are incremented during learning.
        const double permanenceDec = 0.1;  // Amount permanence values of synapses are decremented during learning.
        const double connectedPerm = 0.4;  // If the permanence value for a synapse is greater than this value, it is said to be connected.
        
        public HTMRegionAgent Region { get { return _region; } }
        public int PosX { get { return _posX; } }
        public int PosY { get { return _posY; } }
        public double X { get { return _x; } }
        public double Y { get { return _y; } }
        public List<HTMCell> Cells { get { return _cells; } }
        public HTMSegment ProximalSegment { get { return _proximalSegment; } }
        public bool IsActive { get { return _isActive; } set { _isActive = value; } }
        public double Overlap { get { return _overlap; } }
        public double Boost { get { return _boost; } }
        public double ActiveDutyCycle { get { return _activeDutyCycle; } }
        public double OverlapDutyCycle { get { return _overlapDutyCycle; } }
        
        public HTMColumn(HTMRegionAgent region, int posX, int posY, double x, double y)
        {
            _region = region;
            _posX = posX;
            _posY = posY;
            _x = x;
            _y = y;
            
            _cells = new List<HTMCell>();
            for (int i = 0; i < region.CellsPerColumn; i++)
                _cells.Add(new HTMCell(this, i));
            _proximalSegment = new HTMSegment(null, _region.SegmentActivationThreshold);
            _isActive = false;
            _overlap = 0;
            _boost = 1.0;
            _activeDutyCycle = 1.0;
            _overlapDutyCycle = 1.0;
        }
  
        public double GetAveragePermanence()
        {
            double perm = 0;
            foreach (HTMSynapse syn in _proximalSegment.Synapses)
                perm += syn.Permanence;
            return perm / _proximalSegment.Synapses.Count;
        }

        // For the given column, return the cell with the best matching segment.
        // If no cell has a matching segment, then return the cell with the fewest number of segments.
        public CellSegmentInfo GetBestMatchingCell(bool sequence, int t)
        {
            HTMCell bestCell = null;
            HTMSegment bestSeg = null;
            int bestCount = 0;
            HTMSegment seg;
            int synapseCount;
            foreach (HTMCell cell in _cells)
            {
                seg = cell.GetBestMatchingSegment(t, sequence);
                // TO DO . to study in depth. the previsous function is aggressive in finding the segment but
                // nevertheless exclude segment with activation under minThreshold, this could bring
                // to add step by step similar segments?
                if (seg != null)
                {
                    synapseCount = seg.GetActiveSynapses(t, false, false).Count;
                    if (synapseCount > bestCount)
                    {
                        bestCell = cell;
                        bestSeg = seg;
                        bestCount = synapseCount;
                    }
                }   
            }

            if (bestCell == null)
            {
                int fewestSegmentCount = int.MaxValue;
                foreach (HTMCell cell in _cells)
                {
                    if (cell.DistalSegments.Count < fewestSegmentCount)
                    {
                        fewestSegmentCount = cell.DistalSegments.Count;
                        bestCell = cell;
                        //if (cell.DistalSegments.Count > 0)
                        //    bestSeg = cell.DistalSegments[0]; // choose the first segment
                    }
                }
            }

            CellSegmentInfo cellSegmentInfo = new CellSegmentInfo();
            cellSegmentInfo.Cell = bestCell;
            cellSegmentInfo.Segment = bestSeg;
            return cellSegmentInfo;
        }

        public void ComputeOverlap()
        {
            _overlap = _proximalSegment.GetActiveSynapses(0, false, false).Count;
            if (_overlap < _region.MinOverlap)
                _overlap = 0;
            else
                _overlap *= _boost;
        }

        public void UpdatePermanences()
        {
            foreach (HTMSynapse syn in _proximalSegment.Synapses) // every synapses or potential synapses?
            {
                if (syn.GetActive(0, false, false))
                    syn.IncreasePermanence();
                else
                    syn.DecreasePermanence();
            }
        }

        // If a column does not win often enough (as measured by activeDutyCycle), its overall boost value
        // is increased.
        // Alternatively, if a column's connected synapses do not overlap well with
        // any inputs often enough (as measured by overlapDutyCycle), its permanence values are boosted.
        public void PerformBoosting()
        {
            // minimum desired firing rate for a cell. If a cell's firing rate falls below this value, it will be boosted. This value is calculated as 1% of the maximum firing rate of its neighbors.
            double minDutyCycle = 0.05 * MaxDutyCycle(_region.Neighbors(this));  // 0.05 instead of 0.01

            // Compute the sliding average activeDutyCycle over 500 observations.
            _activeDutyCycle = _activeDutyCycle * 499;
            if (_isActive)
                _activeDutyCycle++;
            _activeDutyCycle = _activeDutyCycle / 500;

            // Boost
            if (_activeDutyCycle < minDutyCycle)
            {
                _boost *= 1.10; // increment by 10% the overlap boosting if the colomn not win often enough.
                _boost = Math.Min(2, _boost); // set a limit to the boost.
            }

            // Compute the sliding average overlapDutyCycle over 500 observations.
            _overlapDutyCycle = _overlapDutyCycle * 499;
            if (_overlap > Region.MinOverlap)
                _overlapDutyCycle++;
            _overlapDutyCycle = _overlapDutyCycle / 500;
            
            //
            if (_overlapDutyCycle < minDutyCycle)
                IncreasePermanences(0.1 * HTMSynapse._connectedPermanence);
        }

        public double MaxDutyCycle(List<HTMColumn> cols)
        {
            double max = double.MinValue;
            foreach (HTMColumn col in cols)
                if (col.ActiveDutyCycle > max)
                    max = col.ActiveDutyCycle;
            return max;
        }

        public void IncreasePermanences(double increment)
        {
            foreach (HTMSynapse synapse in _proximalSegment.Synapses)
                synapse.IncreasePermanence(increment);
        }
    }
}
