using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class ShortestPath
    {
        public int Start { get; private set; }
        public int End { get;}
        public double[] DistTo { get; }
        public DirectedEdge[] EdgeTo { get; }


        public ShortestPath(EdgeWeightedGraph g, int start)
        {
            this.Start = start;
        }

        void Relax(DirectedEdge edge)
        {
            int start = edge.Start;
            int end = edge.End;
            if (DistTo[end]>DistTo[start]+edge.Weight)
            {
                DistTo[end] = DistTo[start] + edge.Weight;
                EdgeTo[end] = edge;
            }
        }

        void Relax(EdgeWeightedDirectedGraph graph, int start)
        {
            foreach (var directedEdge in graph.Adj(start))
            {
                int end = directedEdge.End;
                if (DistTo[end] > DistTo[start] + directedEdge.Weight)
                {
                    DistTo[end] = DistTo[start] + directedEdge.Weight;
                    EdgeTo[end] = directedEdge;
                }
            }
        }

        public bool HasPathTo(int v)
        {
            return DistTo[v] < double.MaxValue;
        }

        public IEnumerable<DirectedEdge> PathTo(int v)
        {
            if (!HasPathTo(v))
            {
                return null;
            }

            Stack<DirectedEdge> path = new Stack<DirectedEdge>();
            for (DirectedEdge e=EdgeTo[v]; e!=null;e=EdgeTo[e.Start])
            {
                path.Push(e);
            }

            return path;
        }
    }
}
