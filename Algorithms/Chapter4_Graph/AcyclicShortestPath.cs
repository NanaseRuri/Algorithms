using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class AcyclicShortestPath
    {
        public DirectedEdge[] EdgeTo { get; private set; }
        public double[] DistTo { get; private set; }

        public AcyclicShortestPath(EdgeWeightedDirectedGraph g, int start)
        {
            EdgeTo=new  DirectedEdge[g.VertexCount];
            DistTo = new double[g.VertexCount];

            for (int i = 0; i < g.VertexCount; i++)
            {
                DistTo[i] = double.PositiveInfinity;
            }

            DistTo[start] = 0;
            Topological top = new Topological(g);

            foreach (var i in top.Order)
            {
                Relax(g, i);
            }
        }

        void Relax(EdgeWeightedDirectedGraph graph, int vertex)
        {
            foreach (var edge in graph.Adj(vertex))
            {
                int v2 = edge.End;
                if (DistTo[v2] > DistTo[vertex] + edge.Weight)
                {
                    DistTo[v2] = DistTo[vertex] + edge.Weight;
                    EdgeTo[v2] = edge;
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
            for (DirectedEdge e = EdgeTo[v]; e != null; e = EdgeTo[e.Start])
            {
                path.Push(e);
            }

            return path;
        }
    }
}
