using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class LeastSignificantDigital
    {
        public static void Sort(string[] a, int w)
        {
            int length = a.Length;
            int r = 256;
            string[] aux=new string[length];

            for (int d = w-1; d >=0; d--)
            {
                int[] count=new int[r+1];
                for (int i = 0; i < length; i++)
                {
                    count[a[i][d] + 1]++;
                }

                for (int i = 0; i < r; i++)
                {
                    count[i + 1] += count[i];
                }

                for (int i = 0; i < length; i++)
                {
                    aux[count[a[i][d]]++] = a[i];
                }

                for (int i = 0; i < length; i++)
                {
                    a[i] = aux[i];
                }
            }
        }
    }
}
