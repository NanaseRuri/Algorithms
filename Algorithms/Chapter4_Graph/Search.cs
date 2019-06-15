using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    abstract class Search
    {
        protected Search(Graph g, int s)
        {

        }

        public abstract bool Marked(int vertex);

        public int Count { get; private set; }
    }
}
