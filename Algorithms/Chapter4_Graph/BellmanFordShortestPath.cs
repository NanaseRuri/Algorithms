using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class BellmanFordShortestPath
    {
        public double[] DistanceTo { get; private set; }
        public DirectedEdge[] EdgeTo { get; private set; }

        /// <summary>
        /// 顶点是否在队列中
        /// </summary>
        public bool[] OnQueue { get; private set; }
        public Queue<int> Queue { get; private set; }
        /// <summary>
        /// Relax 被调用次数
        /// </summary>
        public int Cost { get; private set; }

        /// <summary>
        /// 是否有负权重环
        /// </summary>
        public IEnumerable<DirectedEdge> Circle { get; private set; }

        public BellmanFordShortestPath(EdgeWeightedDirectedGraph graph, int start)
        {
            DistanceTo=new double[graph.VertexCount];
            EdgeTo=new DirectedEdge[graph.VertexCount];
            OnQueue=new bool[graph.VertexCount];
            Queue = new Queue<int>();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                DistanceTo[i] = double.PositiveInfinity;
            }

            DistanceTo[start] = 0;
            OnQueue[start] = true;
            while (Queue.Count != 0)
            {
                int v = Queue.Dequeue();
                OnQueue[v] = false;
                Relax(graph, v);
            }
        }

        public void Relax(EdgeWeightedDirectedGraph graph, int v)
        {
            foreach (var edge in graph.Adj(v))
            {
                int end = edge.End;
                if (DistanceTo[end]>DistanceTo[v]+edge.Weight)
                {
                    DistanceTo[end] = DistanceTo[v] + edge.Weight;
                    EdgeTo[end] = edge;
                    if (!OnQueue[end])
                    {
                        Queue.Enqueue(end);
                        OnQueue[end] = true;
                    }
                }

                if (Cost++ % graph.VertexCount==0)
                {
                    FindNegativeCircle();
                }
            }
        }

        private void FindNegativeCircle()
        {
            int v = EdgeTo.Length;
            EdgeWeightedDirectedGraph spt = new EdgeWeightedDirectedGraph(v);

            for (int i = 0; i < v; i++)
            {
                if (EdgeTo[i] != null) 
                {
                    spt.AddEdge(EdgeTo[i]);
                }

                EdgeWeightedCircleFinder cf = new EdgeWeightedCircleFinder(spt);
                Circle = cf.Circle();
            }
        }

        public bool HasPathTo(int v)
        {
            return DistanceTo[v] < double.MaxValue;
        }

        public IEnumerable<DirectedEdge> PathTo(int v)
        {
            if (!HasPathTo(v))
            {
                return null;
            }

            Stack<DirectedEdge> path = new Stack<DirectedEdge>();
            for (DirectedEdge e = EdgeTo[v]; e != null; e = EdgeTo[e.Start])
            {
                path.Push(e);
            }

            return path;
        }

        public bool HasNegativeCircle()
        {
            return Circle != null;
        }

        public IEnumerable<Edge> NegativeCircle()
        {
            return Circle;
        }
    }
}
