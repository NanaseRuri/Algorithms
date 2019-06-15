using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class BreadthFirstPaths
    {
        private bool[] marked;
        private int[] edgeTo;
        private int origin;

        public BreadthFirstPaths(Graph g, int origin)
        {
            this.marked = new bool[g.VertexSize];
            this.edgeTo = new int[g.VertexSize];
            this.origin = origin;
            Bfs(g, origin);
        }

        void Bfs(Graph g, int node)
        {
            Queue<int> queue = new Queue<int>();
            marked[node] = true;
            queue.Enqueue(node);
            while (queue.Count != 0)
            {   
                int v = queue.Dequeue();
                foreach(var i in g.Adj(node))
                {
                    edgeTo[i] = v;
                    marked[i] = true;
                    queue.Enqueue(i);
                }
            }
        }

        public bool HasPathTo(int v)
        {
            return marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v))
            {
                return null;
            }

            Stack<int> path = new Stack<int>();
            for (int i = v; i != origin; i = edgeTo[i])
            {
                path.Push(i);
            }

            path.Push(origin);
            return path;
        }

    }
}
