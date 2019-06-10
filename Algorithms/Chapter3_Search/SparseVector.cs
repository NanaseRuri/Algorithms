using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter3_Search
{
    //解决了大量的0导致的冗余，节省空间
    class SparseVector
    {
        private LinearProbingHashST<int, double> st;

        public SparseVector()
        {
            st=new LinearProbingHashST<int, double>();
        }

        public int Size()
        {
            return st.Size();
        }

        public void Put(int i, double x)
        {
            st.Put(i, x);
        }

        public double Get(int i)
        {
            if (!st.Contain(i))
            {
                return 0.0;
            }

            return st.Get(i);
        }

        public double Dot(double[] that)
        {
            double sum = 0;
            for (int i = 0; i < st.Keys.Length; i++)
            {
                sum += that[i] * Get(i);
            }

            return sum;
        }
    }
}
