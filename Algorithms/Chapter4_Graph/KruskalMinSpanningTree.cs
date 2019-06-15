using System;
using System.Collections.Generic;
using System.Text;
using Algorithms.Chapter1;
using Algorithms.Chapter2_Sort;

namespace Algorithms.Chapter4_Graph
{
    class KruskalMinSpanningTree
    {
        private Queue<Edge> mst;

        public KruskalMinSpanningTree(EdgeWeightedGraph g)
        {
            mst = new Queue<Edge>();
            IndexMinPQ<Edge> pq = new IndexMinPQ<Edge>(g.EdgeCount);
            UnionFind_1 uf = new UnionFind_1(g.VertexCount);

            while (!pq.IsEmpty()&&mst.Count<g.VertexCount-1)
            {
                Edge e = pq.DelMin();
                int v1 = e.V1;
                int v2 = e.Other(v1);
                if (uf.Connected(v1,v2))
                {
                    continue;
                }

                uf.Union(v1, v2);
                mst.Enqueue(e);
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
