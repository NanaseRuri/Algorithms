using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    abstract class Paths
    {
        protected Paths(Graph g,int s){}
        public abstract bool HasPathTo(int v);
        public abstract IEnumerable<int> PathTo(int v);
    }
}
