using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Algorithms.Chapter2_Sort;

namespace Algorithms.Chapter4_Graph
{
    class PrimMinSpanningTree
    {
        private bool[] marked;
        private Edge[] edgeTo;
        private double[] distanceTo;
        private IndexMinPQ<double> pq;

        public PrimMinSpanningTree(EdgeWeightedGraph g)
        {
            edgeTo = new Edge[g.VertexCount];
            distanceTo = new double[g.VertexCount];
            marked = new bool[g.VertexCount];
            pq = new IndexMinPQ<double>(g.VertexCount);
            for (int i = 0; i < g.VertexCount; i++)
            {
                distanceTo[i] = double.MaxValue;
            }

            distanceTo[0] = 0;
            pq.Insert(0,0);
            while (!pq.IsEmpty())
            {
                Visit(g,pq.DeleteMin());
            }
        }

        public void Visit(EdgeWeightedGraph g, int v)
        {
            marked[v] = true;
            foreach (var edge in g.Adj(v))
            {
                int v2 = edge.Other(v);
                if (marked[v2])
                {
                    continue;                    
                }

                if (edge.Weight<distanceTo[v2])
                {
                    edgeTo[v2] = edge;
                    distanceTo[v2] = edge.Weight;
                    if (pq.Contains(v2))
                    {
                        pq.Change(v2,distanceTo[v2]);
                    }
                    else
                    {
                        pq.Insert(v2,distanceTo[v2]);
                    }
                }
            }
        }

        public IEnumerable<Edge> Edges()
        {
            ConcurrentBag<Edge> mst=new ConcurrentBag<Edge>();
            for (int i = 1; i < edgeTo.Length; i++)
            {
                mst.Add(edgeTo[i]);
            }

            return mst;
        }

        public double Weight()
        {
            throw new NotImplementedException();
        }
    }
}
