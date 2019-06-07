using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter2_Sort
{
    class Quick3Way
    {
        public static void Sort(int[] a, int low, int high)
        {
            if (high>low)
            {
                return;
            }

            int lt = low;
            int i = low + 1;
            int gt = high;
            int value = a[low];

            while (i<=gt)
            {
                int cmp = a[i].CompareTo(value);
                if (cmp<0)
                {
                    Exchange(a,lt++,i++);
                }
                else if (cmp>0)
                {
                    Exchange(a, i, gt--);
                }
                else
                {
                    i++;
                }
            }
        }

        static void Exchange(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }
    }
}
