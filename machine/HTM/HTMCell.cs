using System;
using System.Collections.Generic;

namespace Doo.Machine.HTM
{
    public class HTMCell : ISpatialCell
    {
        HTMColumn _column;
        double _x;
        double _y;
        // double _z;
        bool[] _active;
        bool[] _predicting;
        bool[] _learning;
        List<HTMSegment> _distalSegments;
        List<SegmentUpdate> _segmentUpdateList;
        const int _minSynapsesPerSegmentThreshold = 5;
        const int _stateStored = 3;
        const int _newSynapseCount = 3; // The maximum number of synapses added to a segment during a learning's step.

        public HTMColumn Column { get { return _column; } }
        public double X { get { return _x; } set { _x = value; } }
        public double Y { get { return _y; } set { _y = value; } }
        public List<HTMSegment> DistalSegments { get { return _distalSegments; } }
        public List<SegmentUpdate> SegmentUpdateList { get { return _segmentUpdateList; } }

        // Constructor for a cell not belonging to a column.
        public HTMCell()
        {
            _active = new bool[_stateStored];
            _predicting = new bool[_stateStored];
            _learning = new bool[_stateStored];
            _distalSegments = new List<HTMSegment>();
            _segmentUpdateList = new List<SegmentUpdate>();
        }

        // Constructor for a cell belonging to a column.
        public HTMCell(HTMColumn column)
            : this()
        {
            _x = column.X;
            _y = column.Y;
            _column = column;
        }

        // Get the active state of the cell at time t.
        // t=-1 means previous step.
        public bool GetActive(int t)
        {
            return _active[-t];
        }

        // Set the active state of the cell at current time.
        public void SetActive(bool value)
        {
            _active[0] = value;
        }

        // Get the predictive state of the cell at time t.
        // t=-1 means previous step.
        public bool GetPredicting(int t)
        {
            return _predicting[-t];
        }

        // Set the predictive state of the cell at current time.
        public void SetPredicting(bool value)
        {
            _predicting[0] = value;
        }

        // Get the learning state of the cell at time t.
        // t=-1 means previous step.
        public bool GetLearning(int t)
        {
            return _learning[-t];
        }

        // Set the learning state of the cell at current time.
        public void SetLearning(bool value)
        {
            _learning[0] = value;
        }

        public void Step()
        {
            for (int i = _stateStored - 1; i > 0; i--)
            {
                _active[i] = _active[i - 1];
                _predicting[i] = _predicting[i - 1];
                _learning[i] = _learning[i - 1];
            }
            _active[0] = false;
            _predicting[0] = false;
            _learning[0] = false;
        }

        // Return a segment that is/was active at time t.
        // If multiple segments are active, sequence segments are given preference.
        // Otherwise, segments with most activity are given preference.
        public HTMSegment GetActiveSegment(int t)
        {
            List<HTMSegment> activeSegs = new List<HTMSegment>();
            foreach (HTMSegment seg in _distalSegments)
                if (seg.GetActive(-1, false, false))
                    activeSegs.Add(seg);

            if (activeSegs.Count == 0)
                return null;
            else if (activeSegs.Count == 1)
                return activeSegs[0];

            // There're more the one active segments so sequence segments given priority.
            List<HTMSegment> sequenceSegs = new List<HTMSegment>();
            foreach (HTMSegment seg in activeSegs)
                if (seg.IsSequence)
                    sequenceSegs.Add(seg);
            if (sequenceSegs.Count == 1)
                return sequenceSegs[0];
            else if (sequenceSegs.Count > 1)
                activeSegs = sequenceSegs;

            // Search the segment that had, in the previous step, the highest activity measured by the number of active synapses.
            HTMSegment mostActiveSegment = null;
            int maxActivity = int.MinValue;
            int activity;
            foreach (HTMSegment seg in activeSegs)
            {
                activity = seg.GetActivity(-1);
                if (activity > maxActivity)
                {
                    maxActivity = activity;
                    mostActiveSegment = seg;
                }
            }
            return mostActiveSegment;
        }

        // Return all the learning cells in the near columns (within the inibition radius).
        // TO DO: get a random sample.
        public List<HTMCell> GetRandomLearningCells(int t)
        {
            List<HTMCell> learningCells = new List<HTMCell>();
            List<HTMColumn> columns = this.Column.Region.Neighbors(this.Column);
            foreach (HTMColumn col in columns)
            {
                //if (col == this.Column)
                //    continue;
                foreach (HTMCell cell in col.Cells)
                    if (cell.GetLearning(t))
                        learningCells.Add(cell);
            }
            return learningCells;
        }

        // Return a segmentUpdate data structure containing a list of proposed changes to segment.
        // Let activeSynapses be the list of active synapses where the originating cells have
        // their activeState output = 1 at time step t.
        // (This list is empty if s = -1 since the segment doesn't exist.) newSynapses is an optional argument
        // that defaults to false. If newSynapses is true, then newSynapseCount - count(activeSynapses) synapses
        // are added to activeSynapses. These synapses are randomly chosen from the set of cells that have
        // learnState output = 1 at time step t.
        public SegmentUpdate GetSegmentActiveSynapses(int t, HTMSegment segment = null, bool newSynapses = false)
        {
            SegmentUpdate segmentUpdate = new SegmentUpdate();
            segmentUpdate.ActiveSynapses = new List<HTMSynapse>();
            segmentUpdate.NewSynapses = new List<HTMCell>();
            segmentUpdate.AddNewSynapses = newSynapses;
            segmentUpdate.Segment = segment;

            if (segmentUpdate.Segment != null)
                segmentUpdate.ActiveSynapses = segment.GetActiveSynapses(t, false, false);
            
            if (!newSynapses)
                return segmentUpdate;

            int newSynapseCount = Math.Max(0, _newSynapseCount - segmentUpdate.ActiveSynapses.Count);

            List<HTMCell> learningCells = GetRandomLearningCells(t);
            newSynapseCount = Math.Min(newSynapseCount, learningCells.Count);

            // Truncate the array of learning cells. To do : get a random sample of the array.
            for (int i = 0 ; i < newSynapseCount; i++)
                segmentUpdate.NewSynapses.Add(learningCells[i]);

            return segmentUpdate;
        }

        // Find the segment with the largest number of active synapses.
        // This routine is aggressive in finding the best match.
        // The permanence value of synapses is allowed to be below connectedPerm.
        // The number of active synapses is allowed to be below activationThreshold,
        // but must be above minThreshold.
        public HTMSegment GetBestMatchingSegment(int t, bool sequence)
        {
            HTMSegment bestSegment = null;
            int bestSynapseCount = _minSynapsesPerSegmentThreshold;
            int synCount;
            foreach (HTMSegment seg in _distalSegments)
            {
                synCount = seg.GetActiveSynapses(t, false, false).Count;
                if (synCount > bestSynapseCount)
                {
                    bestSynapseCount = synCount;
                    bestSegment = seg;
                }
            }
            return bestSegment;
        }

        // This function iterates through a list of segmentUpdate's and reinforces each segment.
        // For each segmentUpdate element, the following changes are performed. If positiveReinforcement is true
        // then synapses on the active list get their permanence counts incremented by permanenceInc.
        // All other synapses get their permanence counts decremented by permanenceDec.
        // If positiveReinforcement is false, then synapses on the active list get their permanence counts
        // decremented by permanenceDec. After this step, any synapses in segmentUpdate that do yet exist
        // get added with a permanence count of initialPerm.
        public void AdaptSegments(bool positiveReinforcement)
        {
            foreach (SegmentUpdate segInfo in _segmentUpdateList)
            {
                if (segInfo.Segment != null)
                {
                    if (positiveReinforcement)
                    {
                        foreach (HTMSynapse syn in segInfo.Segment.Synapses)
                            if (segInfo.ActiveSynapses.Contains(syn))
                                syn.IncreasePermanence();
                            else
                                syn.DecreasePermanence();
                    }
                    else
                        foreach (HTMSynapse syn in segInfo.ActiveSynapses)
                            syn.DecreasePermanence();
                    // TO DO : the series of negative reinforcements should bring to eliminate the entire segment.
                }
                
                if (segInfo.AddNewSynapses && segInfo.NewSynapses.Count > 0)
                {
                    // check wheter exist a similar segment
                    bool isFound = false;
                    foreach (HTMSegment seg in _distalSegments)
                    {
                        int foundCount = 0;
                        foreach (HTMSynapse syn in seg.Synapses)
                            if (segInfo.NewSynapses.Contains(syn.InputCell))
                                foundCount++;
                        if (foundCount == segInfo.NewSynapses.Count)
                        {
                            isFound = true;
                            break;
                        }
                    }
                    if (isFound)
                        continue;

                    // update or create a segment
                    HTMSegment segment;
                    if (segInfo.Segment != null)
                        segment = segInfo.Segment;
                    else
                    {
                        segment = new HTMSegment(this);                        
                        _distalSegments.Add(segment);
                        _column.Region.Director.Log("Created new distal segment on a cell on column " + segment.Cell.Column.PosX.ToString() + "," + segment.Cell.Column.PosY.ToString());
                    }
                    segment.IsSequence = segInfo.IsSequence;
                    foreach (HTMCell cell in segInfo.NewSynapses)
                    {
                        //
                        bool find = false;
                        foreach (HTMSynapse syn in segment.Synapses)
                        {
                            if (syn.InputCell == cell)
                            {
                                find = true;
                                break;
                            }
                        }
                        //
                        if (!find)
                            segment.Synapses.Add(new HTMSynapse(cell));

                    }
                }
            }
            _segmentUpdateList.Clear();
        }
    }
}
