using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class Circle
    {
        private bool[] marked;
        public bool HasCycle { get; private set; }       

        public Circle(Graph g)
        {
            marked=new bool[g.VertexSize];
            for (int i = 0; i < g.VertexSize; i++)
            {
                if (!marked[i])
                {
                    Dfs(g, i,i);                    
                }
            }
        }

        void Dfs(Graph g, int v1,int v2)
        {
            marked[v1] = true;            
            foreach(var i in g.Adj(v1))
            {
                if (!marked[i])
                {
                    Dfs(g, i, v2);
                }
                else if (i!=v2)
                {
                    HasCycle = true;
                }
            }
        }
    }
}
