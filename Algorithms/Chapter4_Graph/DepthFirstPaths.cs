using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class DepthFirstPaths:Paths
    {
        private bool[] marked;
        private int[] edgeTo;
        private int origin;

        public DepthFirstPaths(Graph g, int s) : base(g, s)
        {
            marked=new bool[g.VertexSize];
            edgeTo=new int[g.VertexSize];
            this.origin = s;
            Dfs(g, s);
        }

        void Dfs(Graph g, int v)
        {
            marked[v] = true;
            foreach(var i in g.Adj(v))
            {
                if (!marked[i])
                {
                    edgeTo[i] = v;
                    Dfs(g, i);
                }
            }
        }

        public override bool HasPathTo(int v)
        {
            return marked[v];
        }

        public override IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
            {
                return null;
            }

            Stack<int> path = new Stack<int>();
            for (int i = v; i!=origin; i=edgeTo[i])
            {
                path.Push(i);
            }

            path.Push(origin);
            return path;
        }
    }
}
