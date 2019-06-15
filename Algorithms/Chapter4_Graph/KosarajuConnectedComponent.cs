using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class KosarajuConnectedComponent
    {
        private bool[] marked;
        private int[] id;
        public int Count { get; private set; }

        public KosarajuConnectedComponent(DirectedGraph g)
        {
            marked=new bool[g.VertexSize];
            id = new int[g.VertexSize];
            DepthFirstOrder order=new DepthFirstOrder(g.Reverse());
            foreach(var i in order.ReversePost())
            {
                if (!marked[i])
                {
                    Dfs(g, i);
                    Count++;
                }
            }
        }

        void Dfs(DirectedGraph g, int v)
        {
            marked[v] = true;
            id[v] = Count;
            foreach (var i in g.Adj(v))
            {
                if (!marked[i])
                {
                    Dfs(g, i);
                }
            }
        }

        public bool StronglyConnected(int v1, int v2)
        {
            return id[v1] == id[v2];
        }

        public int Id(int v)
        {
            return id[v];
        }        
    }
}
