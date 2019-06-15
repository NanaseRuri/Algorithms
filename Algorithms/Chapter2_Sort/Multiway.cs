using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Algorithms.Chapter2_Sort
{
    /// <summary>
    /// 将多个有序的输入流归并成有序的输出流
    /// </summary>
    class Multiway
    {
        public static void Merge(string[] array)
        {
            int n = array.Length;
            IndexMinPQ<string> pq=new IndexMinPQ<string>(n);

            for (int i = 0; i < n; i++)
            {
                pq.Insert(i,array[i]);
            }

            while (!pq.IsEmpty())
            {
                int i = pq.DeleteMin();
                if (!(array[i]==null))
                {
                    pq.Insert(i,array[i]);
                }
            }

        }
    }
}
