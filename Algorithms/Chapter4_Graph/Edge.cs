using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class Edge:IComparable<Edge>
    {
        public int V1 { get; private set; }
        public int V2 { get; private set; }
        public double Weight { get; private set; }

        public Edge(int v1, int v2, double weight)
        {
            this.V1 = v1;
            this.V2 = v2;
            this.Weight = weight;            
        }

        public int Other(int vertex)
        {
            if (vertex==V1)
            {
                return V2;
            }

            if (vertex==V2)
            {
                return V1;
            }
            throw new Exception("No such point");
        }

        public int CurrentValue => V1;

        public int CompareTo(Edge other)
        {
            if (this.Weight<other.Weight)
            {
                return -1;
            }

            if (this.Weight>other.Weight)
            {
                return 1;
            }

            return 0;
        }
    }
}
