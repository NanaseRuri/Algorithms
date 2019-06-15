using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class EdgeWeightedCircleFinder
    {
        private bool[] marked;
        private DirectedEdge[] edgeTo;
        private bool[] onStack;
        private Stack<DirectedEdge> circle;

        public EdgeWeightedCircleFinder(EdgeWeightedDirectedGraph g)
        {
            onStack = new bool[g.VertexSize];
            edgeTo = new DirectedEdge[g.VertexSize];
            marked = new bool[g.VertexSize];
            for (int i = 0; i < g.VertexSize; i++)
            {
                if (!marked[i])
                {
                    Dfs(g, i);
                }
            }
        }

        void Dfs(EdgeWeightedDirectedGraph g, int v)
        {
            onStack[v] = true;
            marked[v] = true;
            foreach (var i in g.Adj(v))
            {
                int end = i.End;
                if (HasCircle())
                {
                    return;
                }
                else if (!marked[i.Start])
                {
                    edgeTo[end] = i;
                }
                else if (onStack[end])
                {
                    circle = new Stack<DirectedEdge>();

                    DirectedEdge f = i;
                    while (f.Start!=end)
                    {
                        circle.Push(f);
                        f = edgeTo[f.Start];
                    }

                    circle.Push(f);
                    return;
                }
            }
            onStack[v] = false;
        }

        public bool HasCircle()
        {
            return circle == null;
        }

        public IEnumerable<DirectedEdge>Circle()
        {
            return circle;
        }
    }
}
