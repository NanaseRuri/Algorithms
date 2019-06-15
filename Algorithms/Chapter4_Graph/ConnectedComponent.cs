using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class ConnectedComponent
    {
        private bool[] marked;
        private int[] id;
        public int Count { get; private set; }

        public ConnectedComponent(Graph g)
        {
            marked=new bool[g.VertexSize];
            id=new int[g.VertexSize];
            for (int i = 0; i < g.VertexSize; i++)
            {
                if (!marked[i])
                {
                    Dfs(g, i);
                    Count++;
                }
            }
        }

        void Dfs(Graph g, int v)
        {
            marked[v] = true;
            id[v] = Count;
            foreach(var i in g.Adj(v))
            {
                if (!marked[i])
                {
                    Dfs(g, i);
                }
            }
        }

        public bool Connected(int v1, int v2)
        {
            return id[v1] == id[v2];
        }

        public int Id(int i)
        {
            return id[i];
        }
    }
}
