using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class Graph
    {

        public int VertexSize { get; set; }
        public int EdgeSize { get; set; }
        private ConcurrentBag<int>[] adj;
        public Graph(int vertexSize)
        {
            this.VertexSize = vertexSize;
            adj = new ConcurrentBag<int>[vertexSize];
            for (int i = 0; i < vertexSize; i++)
            {
                adj[i] = new ConcurrentBag<int>();
            }
        }

        public Graph()
        {
            if (int.TryParse(Console.ReadLine(), out int size))
            {
                for (int i = 0; i < size; i++)
                {
                    int.TryParse(Console.ReadLine(), out int v1);
                    int.TryParse(Console.ReadLine(), out int v2);
                    AddEdge(v1, v2);
                }
            }
        }

        public void AddEdge(int v1, int v2)
        {
            adj[v1].Add(v2);
            adj[v2].Add(v1);
            EdgeSize++;
        }

        public IEnumerable<int> Adj(int v)
        {
            return adj[v];
        }

        public static int Degree(Graph g, int v)
        {
            int degree = 0;
            for (int i = 0; i < g.Adj(v).Count(); i++)
            {
                degree++;
            }

            return degree;
        }

        public static int MaxDegree(Graph g)
        {
            int max = 0;
            for (int i = 0; i < g.VertexSize; i++)
            {
                if (Degree(g, i) > max)
                {
                    max = Degree(g, i);
                }
            }
            return max;
        }

        public static double AvgDegree(Graph g)
        {
            return 2.0 * g.EdgeSize / g.VertexSize;
        }

        public static int SelfLoopsCount(Graph g)
        {
            int count = 0;
            for (int i = 0; i < g.VertexSize; i++)
            {
                foreach (var i1 in g.Adj(i))
                {
                    if (i1==i)
                    {
                        count++;
                    }
                }
            }
            return count / 2;
        }
    }
}
