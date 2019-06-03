using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter1
{
    class WeightedQuickUnionUnionFind_1
    {
        private int[] id;
        private int[] size;
        public int Count { get; private set; }

        public WeightedQuickUnionUnionFind_1(int n)
        {
            Count = n;
            id=new int[n];
            for (int i = 0; i < n; i++)
            {
                id[i] = i;
            }
            size=new int[n];
            for (int i = 0; i < n; i++)
            {
                size[i] = 1;
            }
        }

        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        int Find(int p)
        {
            while (p!=id[p])
            {
                p = id[p];
            }

            return p;
        }

        public void Union(int p, int q)
        {
            int i = Find(p);
            int j = Find(q);
            if (i==j)
            {
                return;
            }

            if (size[i]<size[j])
            {
                id[i] = j;
                size[j] += size[i];
            }
            else
            {
                id[j] = i;
                size[i] += size[j];
            }

            Count--;
        }
    }
}
