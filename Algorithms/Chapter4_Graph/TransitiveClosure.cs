using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class TransitiveClosure
    {
        private DirectedDfs[] all;

        public TransitiveClosure(DirectedGraph g)
        {
            all=new DirectedDfs[g.VertexSize];
            for (int i = 0; i < g.VertexSize; i++)
            {
                all[i]=new DirectedDfs(g,i);
            }
        }

        bool Reachable(int v1, int v2)
        {
            return all[v1].Marked(v2);
        }
    }
}
