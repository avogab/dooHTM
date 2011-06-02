using System;
using System.Collections.Generic;
using Doo;

namespace Doo.Machine.HTM
{
    // The main unit of memory and prediction in an HTM.
    public class HTMRegionAgent : IAgent
    {
        IDirector _director;
        IAgent _inputAgent;
        int _inputWidth;
        int _inputHeight;
        int _width;
        int _height;
        int _cellsPerColumn;
        HTMColumn[,] _columns;
        int _minOverlap;
        int _desiredLocalActivity;
        double _inhibitionRadius;  // Average connected receptive field size of the columns.
        bool _doSpatialLearning;
        bool _doTemporalLearning;
        RandomEx _random;
        List<HTMColumn> _activeColumns;  // The list of active columns after the spatial pooling phases.
        int _correctPrediction;
        Cells2D<HTMCell> _inputCells;
        Cells2D<HTMCell> _outputCells;
        int _distalSegmentSpan;

        public IDirector Director { get { return _director; } set { _director = value; } }
        public IAgent InputAgent { get { return _inputAgent; } set { _inputAgent = value; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
        public int CellsPerColumn { get { return _cellsPerColumn; } }
        internal HTMColumn[,] Columns { get { return _columns; } }
        public double MinOverlap { get { return _minOverlap; } }
        public int DesiredLocalActivity { get { return _desiredLocalActivity; } }
        public double InhibitionRadius { get { return _inhibitionRadius; } }
        public bool DoSpatialLearning { get { return _doSpatialLearning; } set { _doSpatialLearning = value; } }
        public bool DoTemporalLearning { get { return _doTemporalLearning; } set { _doTemporalLearning = value; } }
        public int CorrectPrediction { get { return _correctPrediction; } }

        // param inputCells: input data matrix
        // param regionWidth: number of columns in the region
        // param regionHeight: number of rows in the region
        // param cellsPerColumn: Number of (temporal context) cells to use for each column.
        // param minOverlap: the minimum number of inputs that must be active for a column to be considered during the inhibition step.
        // param desiredLocalActivity number of columns that will be winners after the inhibition step.
        public HTMRegionAgent(IDirector director, int inputWidth, int inputHeight, int regionWidth, int regionHeight, int cellsPerColumn,
            int minOverlap, int desiredLocalActivity, int distalSegmentSpan)
        {
            _director = director;
            _inputWidth = inputWidth;
            _inputHeight = inputHeight;
            _width = regionWidth;
            _height = regionHeight;
            _cellsPerColumn = cellsPerColumn;
            _minOverlap = minOverlap;
            _desiredLocalActivity = desiredLocalActivity;
            _distalSegmentSpan = distalSegmentSpan;
            _doSpatialLearning = true;
            _doTemporalLearning = true;
            
            _random = new RandomEx(0);
            _inputCells = new Cells2D<HTMCell>(inputWidth, inputHeight);
            _activeColumns = new List<HTMColumn>(_width * _height);

            // Create the columns
            _columns = new HTMColumn[_width, _height];
            for (int cx = 0; cx < _width; cx++)
                for (int cy = 0; cy < _height; cy++)
                    _columns[cx, cy] = new HTMColumn(this, cx, cy, (cx + 0.5)/_width, (cy + 0.5)/_height);

            // Create the output matrix.
            _outputCells = new Cells2D<HTMCell>(_width, _height);
        }

        public object GetOutput()
        {
            for (int cx = 0; cx < _width; cx++)
                for (int cy = 0; cy < _height; cy++)
                    _outputCells[cx, cy].SetActive(_columns[cx, cy].IsActive);
            return _outputCells;
        }

        public HTMColumn GetMostActiveColumn()
        {
            HTMColumn mostActive = null;
            double maxOverlap = double.MinValue;
            // TO DO: at the moment gets the last (in the array) most active
            foreach (HTMColumn col in _activeColumns)
            {
                if (col.Overlap > maxOverlap)
                {
                    maxOverlap = col.Overlap;
                    mostActive = col;
                }
            }
            return mostActive;
        }

        public bool Step()
        {
            foreach (HTMColumn col in _columns)
                foreach (HTMCell cell in col.Cells)
                    cell.Step();

            // Retrieve the region's input cell.
            Cells2D<HTMCell> inputCells = (Cells2D<HTMCell>)_inputAgent.GetOutput();
            
            // TO DO: avoid the copy
            for (int x = 0; x < _inputWidth; x++)
                for (int y = 0; y < _inputHeight; y++)
                    _inputCells[x, y].SetActive(inputCells[x, y].GetActive(0));

            StepSpatialPooling();
            StepTemporalPooling();            
            return true;
        }

        // Return all the columns within inhibitionRadius of the input column.
        internal List<HTMColumn> Neighbors(HTMColumn column)
        {
            int irad = (int)System.Math.Round(_inhibitionRadius);
            int x0 = Math.Max(0, Math.Min(column.PosX - 1, column.PosX - irad));
            int y0 = Math.Max(0, Math.Min(column.PosY - 1, column.PosY - irad));
            int x1 = Math.Min(_width - 1, Math.Max(column.PosX + 1, column.PosX + irad));
            int y1 = Math.Min(_height - 1, Math.Max(column.PosY + 1, column.PosY + irad));
            
            List<HTMColumn> cols = new List<HTMColumn>( (x1 - x0 + 1) * (y1 - y0 + 1) );
            // TO DO : filter only the colomn within a circle and not a rectangle!
            for (int x = x0; x <= x1; x++)
                for (int y = y0; y <= y1; y++)
                    cols.Add(_columns[x, y]);
            return cols;
        }

        // Given the list of columns, return the k'th highest overlap value.
        internal double KthScore(List<HTMColumn> cols, int k)
        {
            List<double> overlaps = new List<double>();
            foreach (HTMColumn col in _columns)
                overlaps.Add(col.Overlap);
            overlaps.Sort();
            return overlaps[overlaps.Count - k];
        }

        // The radius of the average connected receptive field size of all the columns.
        // The connected receptive field size of a column includes only the connected synapses
        // (those with permanence values >= connectedPerm). This is used to determine the extent
        // of lateral inhibition between columns.
        public double AverageReceptiveFieldSize()
        {
            double average = 0;
            int count = 0;
            foreach (HTMColumn col in _columns)
            {
                foreach (HTMSynapse syn in col.ProximalSegment.GetConnectedSynapses())
                {
                    average += Math.Sqrt(Math.Pow(col.X - syn.InputCell.X, 2) + Math.Pow(col.Y - syn.InputCell.Y, 2));
                    count++;
                }
            }
            if (count > 0)
                return average / count;
            else
                return 0;
        }

        public void StepSpatialPooling()
        {
            // Phase 1: Overlap
            // From Numenta's doc
            // Given an input vector, the first phase calculates the overlap of each column with that vector.
            // The overlap for each column is simply the number of connected synapses with active inputs,
            // multiplied by its boost. If this value is below minOverlap, we set the overlap score to zero.
            foreach (HTMColumn col in _columns)
                col.ComputeOverlap();

            // Phase 2: Inhibition
            // From Numenta's doc
            // The second phase calculates which columns remain as winners after the inhibition step.
            // desiredLocalActivity is a parameter that controls the number of columns that end up winning.
            // For example, if desiredLocalActivity is 10, a column will be a winner if its overlap score is greater than
            // the score of the 10'th highest column within its inhibition radius.
            _activeColumns.Clear();
            foreach (HTMColumn col in _columns)
            {
                col.IsActive = false;
                if (col.Overlap == 0)
                    continue;

                double minLocalActivity = KthScore(Neighbors(col), _desiredLocalActivity);
                if (col.Overlap >= minLocalActivity)
                {
                    col.IsActive = true;
                    _activeColumns.Add(col);
                }
            }

            // Phase 3: Learning
            // From Numenta's doc
            // The third phase performs learning; it updates the permanence values of all synapses as necessary,
            // as well as the boost and inhibition radius. The main learning rule is implemented in lines 20-26.
            // For winning columns, if a synapse is active, its permanence value is incremented, otherwise it is decremented.
            // Permanence values are constrained to be between 0 and 1. Lines 28-36 implement boosting.
            // There are two separate boosting mechanisms in place to help a column learn connections.
            // If a column does not win often enough (as measured by activeDutyCycle), its overall boost value
            // is increased (line 30-32). Alternatively, if a column's connected synapses do not overlap well with
            // any inputs often enough (as measured by overlapDutyCycle), its permanence values are boosted (line 34-36).
            // Note: once learning is turned off, boost(c) is frozen.
            // Finally, at the end of Phase 3 the inhibition radius is recomputed (line 38).
            if (_doSpatialLearning)
            {
                foreach (HTMColumn col in _activeColumns)
                    col.UpdatePermanences();
                foreach (HTMColumn col in _columns)
                    col.PerformBoosting();

                _inhibitionRadius = AverageReceptiveFieldSize();
            }
        }

        public void StepTemporalPooling()
        {
            // Phase 1
            // From the Numenta Docs:
            // The first phase calculates the active state for each cell.
            // For each winning column we determine which cells should become active.
            // If the bottom-up input was predicted by any cell (i.e. its predictiveState was 1 due to
            // a sequence segment in the previous time step), then those cells become active (lines 4-9).
            // If the bottom-up input was unexpected (i.e. no cells had predictiveState output on),
            // then each cell in the column becomes active (lines 11-13).
            foreach (HTMColumn col in _activeColumns)
            {
                bool buPredicted = false;
                bool lcChosen = false;
                foreach (HTMCell cell in col.Cells)
                {
                    if (cell.GetPredicting(-1))
                    {
                        //
                        _correctPrediction++;

                        HTMSegment segment = cell.GetActiveSegment(-1);
                        if (segment != null && segment.IsSequence)
                        {
                            buPredicted = true;
                            cell.SetActive(true);
                            if (_doTemporalLearning)
                            {
                                if (segment.GetActive(-1, true, false))
                                {
                                    lcChosen = true;
                                    cell.SetLearning(true);
                                }
                            }
                        }
                    }
                }

                if (!buPredicted)
                    foreach (HTMCell cell in col.Cells)
                        cell.SetActive(true);

                // If the bottom-up input was not predicted, the best matching cell is chosen as the learning cell and a new segment is added to that cell.
                if (_doTemporalLearning)
                {
                    if (!lcChosen)
                    {
                        CellSegmentInfo bestCellSegmentInfo = col.GetBestMatchingCell(true, -1);
                        bestCellSegmentInfo.Cell.SetLearning(true);
                        
                        SegmentUpdate segmentToUpdate = bestCellSegmentInfo.Cell.GetSegmentActiveSynapses(-1, bestCellSegmentInfo.Segment, true);
                        segmentToUpdate.IsSequence = true;
                        if (segmentToUpdate.Segment != null || (segmentToUpdate.AddNewSynapses && segmentToUpdate.NewSynapses.Count > 0)) // queue the update only if necessary
                        {
                            bestCellSegmentInfo.Cell.SegmentUpdateList.Add(segmentToUpdate);
                        }
                    }
                }
            }
            
            // Phase 2
            // The second phase calculates the predictive state for each cell.
            // A cell will turn on its predictive state output if one of its segments becomes active,
            // i.e. if enough of its lateral inputs are currently active due to feed-forward input.
            // In this case, the cell queues up the following changes:
            // a) reinforcement of the currently active segment (lines 47-48),
            // and b) reinforcement of a segment that could have predicted this activation,
            // i.e. a segment that has a (potentially weak) match to activity during the previous time step (lines 50-53).
            foreach (HTMColumn col in _columns)
            {
                foreach (HTMCell cell in col.Cells)
                {
                    //if (cell.GetActive(0))  // Cells with active dendrite segments are put in the predictive state UNLESS they are already active due to feed-forward input.
                    //    continue;

                    foreach (HTMSegment seg in cell.DistalSegments)
                    {
                        if (!seg.GetActive(0, false, false))
                            continue;

                        cell.SetPredicting(true);
                        // TO DO : check. Active and predictive state are mutual exclusive?
                        // if so, the changing from active to predicting must be done
                        // through a temporary array to avoid cell asymmetrical behavior.
                        //cell.SetActive(false);

                        if (_doTemporalLearning)
                        {
                            // a) reinforcement of the currently active segment
                            SegmentUpdate activeSegUpdate = cell.GetSegmentActiveSynapses(0, seg);
                            cell.SegmentUpdateList.Add(activeSegUpdate);

                            // b)  reinforcement of a segment that could have predicted this activation,
                            HTMSegment predSegment = cell.GetBestMatchingSegment(-1, true);
                            if (predSegment == null)
                                continue;
                            _director.Log("New predSegment on col x:" + col.PosX.ToString() + " y:" + col.PosY.ToString());
                            SegmentUpdate predSegUpdate = cell.GetSegmentActiveSynapses(-1, predSegment, true);
                            cell.SegmentUpdateList.Add(predSegUpdate);
                        }
                    }
                }
            }

            // Phase 3
            // The third and last phase actually carries out learning.
            // In this phase segment updates that have been queued up are actually
            // implemented once we get feed-forward input and the cell is chosen
            // as a learning cell (lines 56-57). Otherwise,
            // if the cell ever stops predicting for any reason,
            // we negatively reinforce the segments (lines 58-60).
            if (_doTemporalLearning)
            {
                foreach (HTMColumn col in _columns)
                {
                    foreach (HTMCell cell in col.Cells)
                    {
                        if (cell.SegmentUpdateList.Count == 0) // if there isn't segment to adapt then continue.
                            continue;
                        if (/*cell.GetActive(0) &*/ cell.GetLearning(0))
                        {
                            // once we get feed-forward input and the cell is chosen as a learning cell
                            cell.AdaptSegments(true);
                        }
                        else if (!cell.GetPredicting(0) && cell.GetPredicting(-1))
                        {
                            // if the cell ever stops predicting for any reason,
                            // we negatively reinforce the segments 
                            cell.AdaptSegments(false);
                        }
                    }
                }
            }
        }

        public bool Initialize()
        {
            // Connect all potentialSynapses.
            double permanence;
            HTMSynapse synapse;
            foreach (HTMColumn col in _columns)
            {
                // TO DO : get a random sample from the input matrix
                List<HTMCell> cells = _inputCells.GetRectangle(col.X, col.Y, _distalSegmentSpan, _distalSegmentSpan);
                foreach (HTMCell c in cells)
                {
                    permanence = _random.NextGauss(HTMSynapse._connectedPermanence, HTMSynapse._permanenceIncrement * 2.0, true);
                    synapse = new HTMSynapse(c, permanence);
                    col.ProximalSegment.Synapses.Add(synapse);
                }
            }
            _inhibitionRadius = AverageReceptiveFieldSize();
            return true;
        }

        public StatInfo GetStatInfo(HTMRegionViewerPropertyShowed property)
        {
            StatInfo statInfo = new StatInfo();

            double max = double.MinValue;
            double min = double.MaxValue;
            double val;
            switch (property)
            {
                case HTMRegionViewerPropertyShowed.ColumnActivation:
                    break;
                case HTMRegionViewerPropertyShowed.ColumnPermanence:
                    foreach (HTMColumn col in _columns)
                    {
                        val = col.GetAveragePermanence();
                        if (val > max)
                            max = val;
                        if (val < min)
                            min = val;
                    }
                    break;
                case HTMRegionViewerPropertyShowed.ColumnOverlap:
                    foreach (HTMColumn col in _columns)
                    {
                        if (col.Overlap > max)
                            max = col.Overlap;
                        if (col.Overlap < min)
                            min = col.Overlap;
                    }
                    break;
                case HTMRegionViewerPropertyShowed.ColumnBoost:
                    foreach (HTMColumn col in _columns)
                    {
                        if (col.Boost > max)
                            max = col.Boost;
                        if (col.Boost < min)
                            min = col.Boost;
                    }
                    break;
                case HTMRegionViewerPropertyShowed.DistalSegmentsCount:
                    int count;
                    foreach (HTMColumn col in _columns)
                    {
                        count = 0;
                        foreach (HTMCell cls in col.Cells)
                            count += cls.DistalSegments.Count;
                        if (count > max)
                            max = count;
                        if (count < min)
                            min = count;
                    }        
                    break;
                default:
                    break;
            }
            statInfo.Min = min;
            statInfo.Max = max;
            return statInfo;
        }
    }
}
