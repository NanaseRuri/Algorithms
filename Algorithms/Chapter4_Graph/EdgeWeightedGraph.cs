using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class EdgeWeightedGraph
    {
        public int VertexCount { get; private set;}
        public int EdgeCount { get; private set; }
        private ConcurrentBag<Edge>[] adj;

        public EdgeWeightedGraph(int vertexCount)
        {
            this.VertexCount = vertexCount;
            EdgeCount = 0;
            adj=new ConcurrentBag<Edge>[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                adj[i]=new ConcurrentBag<Edge>();
            }
        }

        public void AddEdge(Edge e)
        {
            int v1 = e.CurrentValue;
            int v2 = e.Other(v1);
            adj[v1].Add(e);
            adj[v2].Add(e);
            EdgeCount++;
        }

        public IEnumerable<Edge> Adj(int v)
        {
            return adj[v];
        }

        public IEnumerable<Edge> Edges()
        {
            ConcurrentBag<Edge> b = new ConcurrentBag<Edge>();
            for (int i = 0; i < VertexCount; i++)
            {
                foreach (var edge in adj[i])
                {
                    if (edge.Other(i)>i)
                    {
                        b.Add(edge);
                    }
                }
            }

            return b;
        }
        
    }
}
