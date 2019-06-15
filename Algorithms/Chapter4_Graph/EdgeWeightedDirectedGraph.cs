using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class EdgeWeightedDirectedGraph:DirectedGraph
    {
        public int VertexCount { get; private set; }
        public int EdgeCount { get; private set; }
        private ConcurrentBag<DirectedEdge>[] adj;

        public EdgeWeightedDirectedGraph(int v):base(v)
        {
            VertexCount = v;
            EdgeCount = 0;
            adj = new ConcurrentBag<DirectedEdge>[v];
            for (int i = 0; i < v; i++)
            {
                adj[i] = new ConcurrentBag<DirectedEdge>();
            }
        }

        public void AddEdge(DirectedEdge edge)
        {
            adj[edge.Start].Add(edge);
            EdgeCount++;
        }

        public IEnumerable<DirectedEdge> Adj(int vertex)
        {
            return adj[vertex];
        }

        public IEnumerable<DirectedEdge> Edges()
        {
            ConcurrentBag<DirectedEdge> edges = new ConcurrentBag<DirectedEdge>();
            for (int i = 0; i < EdgeCount; i++)
            {
                foreach (var directedEdge in adj[i])
                {
                    edges.Add(directedEdge);
                }
            }
            return edges;
        }
    }
}
