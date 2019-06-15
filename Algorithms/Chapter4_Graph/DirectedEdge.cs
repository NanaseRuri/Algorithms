using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class DirectedEdge:Edge
    {
        public int Start { get; private set; }
        public int End { get; private set; }
        public double Weight { get; private set; }

        public DirectedEdge(int start, int end, double weight) : base(start,end,weight)
        {
            this.Start = start;
            this.End = end;
            this.Weight = weight;
        }
    }
}
