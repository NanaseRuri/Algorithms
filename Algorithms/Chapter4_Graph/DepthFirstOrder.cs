using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter4_Graph
{
    class DepthFirstOrder
    {
        private bool[] marked;
        /// <summary>
        /// 顶点的正序
        /// </summary>
        private Queue<int> pre;
        /// <summary>
        /// 顶点的后序
        /// </summary>
        private Queue<int> post;
        /// <summary>
        /// 后序的反序
        /// </summary>
        private Stack<int> reversePost;
        public int Count { get; private set; }

        public DepthFirstOrder(DirectedGraph g)
        {
            pre=new Queue<int>();
            post=new Queue<int>();
            reversePost=new Stack<int>();
            marked = new bool[g.VertexSize];
            for (int i = 0; i < g.VertexSize; i++)
            {
                if (!marked[i])
                {
                    Dfs(g,i);
                }
            }
        }

        void Dfs(DirectedGraph g, int v)
        {
            pre.Enqueue(v);
            marked[v] = true;
            foreach (var i in g.Adj(v))
            {
                if (!marked[i])
                {
                    Dfs(g, i);
                }
            }
            post.Enqueue(v);
            reversePost.Push(v);
        }

        public IEnumerable<int> Pre()
        {
            return pre;
        }

        public IEnumerable<int> Post()
        {
            return post;
        }

        public IEnumerable<int> ReversePost()
        {
            return reversePost;
        }
        
    }
}
