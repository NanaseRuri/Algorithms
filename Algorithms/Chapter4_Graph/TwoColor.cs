using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class TwoColor
    {
        private bool[] marked;
        private bool[] color;

        public bool IsTwoColorable { get; private set; }

        public TwoColor(Graph g)
        {
            marked = new bool[g.VertexSize];
            color = new bool[g.VertexSize];
            for (int i = 0; i < g.VertexSize; i++)
            {
                if (!marked[i])
                {
                    Dfs(g, i);
                }
            }
            IsTwoColorable = true;
        }

        void Dfs(Graph g, int v)
        {
            marked[v] = true;
            foreach(var i in g.Adj(v))
            {
                if (!marked[i])
                {
                    color[i] = !color[v];
                    Dfs(g, i);
                }
                else if (color[i]==color[v])
                {
                    IsTwoColorable = false;
                }
            }
        }
    }
}
