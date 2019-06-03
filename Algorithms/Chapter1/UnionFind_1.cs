using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter1
{
    class UnionFind_1
    {
        private int[] id;
        public int Count { get; private set; }

        public UnionFind_1(int n)
        {
            Count = n;
            id=new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
            }
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        //quick find
        public int Find(int p)
        {
            return id[p];
        }

        public void Union(int p, int q)
        {
            int pId = Find(p);
            int qId = Find(q);
            if (pId==qId)
            {
                return;
            }

            for (int i = 0; i < id.Length; i++)
            {
                if (id[i]==pId)
                {
                    id[i] = qId;
                }
            }
        }
        
    }
}
