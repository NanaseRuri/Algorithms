using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using Algorithms.Chapter4_Graph;

namespace Algorithms.Chapter5_String
{
    class NondeterministicFiniteAutomaton
    {
        private char[] re;
        private DirectedGraph g;        //epsilon 转换
        private int m;          //状态数量

        public NondeterministicFiniteAutomaton(string regExp)
        {
            Stack<int> ops = new Stack<int>();
            re = regExp.ToCharArray();
            m = re.Length;
            g = new DirectedGraph(m + 1);

            for (int i = 0; i < m; i++)
            {
                int lp = i;
                if (re[i]=='('||re[i]=='|')
                {
                    ops.Push(i);
                }
                else if (re[i]==')')
                {
                    int or = ops.Pop();
                    if (re[or]=='|')
                    {
                        lp = ops.Pop();
                        g.AddEdge(lp, lp + 1);
                        g.AddEdge(or, i);
                    }
                    else
                    {
                        lp = or;
                    }
                }

                if (i<m-1&&re[i+1]=='*')
                {
                    g.AddEdge(lp,i+1);
                    g.AddEdge(i+1,lp);
                }

                if (re[i]=='('||re[i]=='*'||re[i]==')')
                {
                    g.AddEdge(i,i+1);
                }
            }
        }


        public bool Recognizes(string txt)
        {
            ConcurrentBag<int> pc = new ConcurrentBag<int>();
            DirectedDfs dfs=new DirectedDfs(g,0);
            for (int i = 0; i < g.VertexSize; i++)
            {
                if (dfs.Marked(i))
                {
                    pc.Add(i);
                }
            }

            for (int i = 0; i < txt.Length; i++)
            {
                ConcurrentBag<int> match = new ConcurrentBag<int>();
                foreach (var v in pc)
                {
                    if (v<m)
                    {
                        if (re[v]==txt[i]||re[v]=='.')
                        {
                            match.Add(v + 1);
                        }
                    }
                }

                pc = new ConcurrentBag<int>();
                dfs = new DirectedDfs(g, match);
                for (int v = 0; v < g.VertexSize; v++)
                {
                    if (dfs.Marked(v))
                    {
                        pc.Add(v);
                    }
                }
            }

            foreach (var v in pc)
            {
                if (v==m)
                {
                    return true;
                }
            }

            return false;

        }
    }
}
