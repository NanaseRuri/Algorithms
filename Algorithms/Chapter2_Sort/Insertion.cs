using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter2_Sort
{
    class Insertion
    {
        public static void Sort(int[] a)
        {
            for (int i = 1; i < a.Length; i++)
            {
                for (int j = i; j>0&&a[j]<a[j+1]; j--)
                {
                    Exchange(a,j,j-1);
                }
            }
        }

        static void Exchange(int[] array, int left, int right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }
    }
}
