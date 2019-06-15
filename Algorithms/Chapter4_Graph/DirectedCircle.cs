using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class DirectedCircle
    {
        private bool[] marked;
        private int[] edgeTo;
        private Stack<int> circle;
        private bool[] onStack;

        public DirectedCircle(DirectedGraph g)
        {
            onStack = new bool[g.VertexSize];
            edgeTo = new int[g.VertexSize];
            marked = new bool[g.VertexSize];
            for (int i = 0; i < g.VertexSize; i++)
            {
                if (!marked[i])
                {
                    Dfs(g, i);
                }
            }
        }

        void Dfs(DirectedGraph g, int v)
        {
            onStack[v] = true;
            marked[v] = true;
            foreach (var i in g.Adj(v))
            {
                if (HasCircle())
                {
                    return;
                }
                else if (!marked[i])
                {
                    edgeTo[i] = v;
                }
                else if (onStack[i])
                {
                    circle=new Stack<int>();
                    for (int j = v; j !=i; j=edgeTo[j])
                    {
                        circle.Push(j);
                    }
                    circle.Push(i);
                    circle.Push(v);
                }
            }

            onStack[v] = false;
        }

        public bool HasCircle()
        {
            return circle == null;
        }

        public IEnumerable<int> Circle()
        {
            return circle;
        }
    }
}
