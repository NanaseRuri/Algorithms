using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class Topological
    {
        public IEnumerable<int> Order { get; private set; }

        public Topological(DirectedGraph graph)
        {
            DirectedCircle circleFinder = new DirectedCircle(graph);
            if (!circleFinder.HasCircle())
            {
                DepthFirstOrder dfs = new DepthFirstOrder(graph);
                Order = dfs.ReversePost();
            }
        }

        public bool IsAcyclicGraph()
        {
            return Order != null;
        }
    }
}
