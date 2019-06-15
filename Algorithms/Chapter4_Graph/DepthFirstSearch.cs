using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#pragma warning disable 0108

namespace Algorithms.Chapter4_Graph
{
    class DepthFirstSearch:Search
    {
        private bool[] marked;
        public int Count { get; private set; }

        public DepthFirstSearch(Graph g, int s) : base(g, s)
        {
            marked=new bool[g.VertexSize];
            Dfs(g,s);
        }

        void Dfs(Graph g, int v)
        {
            marked[v] = true;
            Count++;
            foreach(var i in g.Adj(v))
            {
                if (!Marked(i))
                {
                    Dfs(g, i);
                }
            }
        }

        public override bool Marked(int vertex)
        {
            return marked[vertex];
        }
    }
}
