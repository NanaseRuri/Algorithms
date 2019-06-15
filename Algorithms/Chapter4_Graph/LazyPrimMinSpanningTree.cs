using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Chapter2_Sort;

namespace Algorithms.Chapter4_Graph
{
    class LazyPrimMinSpanningTree
    {
        private bool[] marked;
        private Queue<Edge> mst;
        private IndexMinPQ<Edge> pq;

        public LazyPrimMinSpanningTree(EdgeWeightedGraph g)
        {
            pq=new IndexMinPQ<Edge>(g.EdgeCount);
            marked=new bool[g.VertexCount];
            mst=new Queue<Edge>();

            Visit(g, 0);
            while (!pq.IsEmpty())
            {
                Edge e = pq.DelMin();
                int v1 = e.CurrentValue;
                int v2 = e.Other(v1);
                if (marked[v1]&&marked[v2])
                {
                    continue;
                }

                mst.Enqueue(e);
                if (marked[v1])
                {
                    Visit(g, v1);
                }

                if (!marked[v2])
                {
                    Visit(g, v2);
                }
            }
        }

        public void Visit(EdgeWeightedGraph g, int v)
        {
            marked[v] = true;
            foreach (var edge in g.Adj(v))
            {
                if (!marked[edge.Other(v)])
                {
                    Edge temp=new Edge(edge.V1,edge.V2,edge.CurrentValue);
                    pq.Insert(0,temp);
                }
            }
        }

        public IEnumerable<Edge> Edges()
        {
            return mst;        
        }

        public double Weight()
        {
            throw new NotImplementedException();
        }
    }
}
