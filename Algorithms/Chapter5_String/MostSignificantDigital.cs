using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class MostSignificantDigital
    {
        private static int R = 256;
        private static int M = 15;//数组长度
        private static string[] Aux;

        static int CharAt(string s, int d)
        {
            if (d<s.Length)
            {
                return s[d];
            }

            return -1;
        }

        //以第d个字符排序
        public static void Sort(string[] a, int low, int high, int d)
        {
            if (high<=low+M)
            {
                throw new NotImplementedException();
            }
            int[] count=new int[R+2];
            for (int i = low; i <=high; i++)
            {
                count[CharAt(a[i], d) + 2]++;
            }

            for (int r = 0; r < R+1; r++)
            {
                count[r + 1] += count[r];
            }

            for (int i = low; i <=high; i++)
            {
                Aux[count[CharAt(a[i], d) + 1]++] = a[i];
            }

            for (int i = 0; i <high; i++)
            {
                a[i] = Aux[i - low];
            }

            for (int r = 0; r < R; r++)
            {
                Sort(a,low+count[r],low+count[r+1]+1,d+1);
            }
        }
    }
}
