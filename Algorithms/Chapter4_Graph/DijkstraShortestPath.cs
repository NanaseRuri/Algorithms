using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Chapter2_Sort;

namespace Algorithms.Chapter4_Graph
{
    class DijkstraShortestPath
    {
        public DirectedEdge[] EdgeTo { get; private set; }
        public double[] DistTo { get; private set; }
        private IndexMinPQ<double> pq;

        public DijkstraShortestPath(EdgeWeightedDirectedGraph graph, int start)
        {
            EdgeTo=new DirectedEdge[graph.VertexCount];
            DistTo=new double[graph.VertexCount];
            pq = new IndexMinPQ<double>(graph.VertexCount);

            for (int i = 0; i < graph.VertexCount; i++)
            {
                DistTo[i] = double.PositiveInfinity;
                DistTo[start] = 0;

                pq.Insert(start, 0);
                while (!pq.IsEmpty())
                {
                    Relax(graph, pq.DeleteMin());
                }
            }
        }

        void Relax(EdgeWeightedDirectedGraph graph, int vertex)
        {
            foreach (var edge in graph.Adj(vertex))
            {
                int v2 = edge.End;
                if (DistTo[v2]>DistTo[vertex]+edge.Weight)
                {
                    DistTo[v2] = DistTo[vertex] + edge.Weight;
                    EdgeTo[v2] = edge;

                    if (pq.Contains(v2))
                    {
                        pq.Change(v2,DistTo[v2]);
                    }
                    pq.Insert(v2,DistTo[v2]);
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
