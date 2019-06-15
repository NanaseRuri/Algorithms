using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class DirectedDfs
    {
        private bool[] marked;       

        public DirectedDfs(DirectedGraph g, int s)
        {
            marked = new bool[g.VertexSize];
            Dfs(g, s);
        }

        public DirectedDfs(DirectedGraph g, IEnumerable<int> sources)
        {
            marked = new bool[g.VertexSize];
            foreach (var source in sources)
            {
                if (!marked[source])
                {
                    Dfs(g,source);
                }
            }
        }

        void Dfs(DirectedGraph g, int v)
        {
            marked[v] = true;            
            foreach (var i in g.Adj(v))
            {
                if (!marked[i])
                {
                    Dfs(g, i);
                }
            }
        }

        public bool Marked(int vertex)
        {
            return marked[vertex];
        }
    }
}
