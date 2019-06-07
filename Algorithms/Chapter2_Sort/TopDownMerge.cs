using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter2_Sort
{
    class TopDownMerge
    {
        private static int[] aux;

        public static void Sort(int[] array)
        {
            aux = new int[array.Length];
            Sort(array, 0, array.Length - 1);
        }

        private static void Sort(int[] array, int low, int high)
        {
            if (high <= low)
            {
                return;
            }

            int mid = low + (high - low) / 2;
            Sort(array, low, mid);
            Sort(array, mid + 1, high);
            MergeSort(array, low, mid, high);
        }

        private static void MergeSort(int[] array, int low, int mid, int high)
        {
            int i = low;
            int j = mid + 1;

            for (int k = low; k <= high; k++)
            {
                aux[k] = array[k];
            }

            for (int k = low; k <= high; k++)
            {
                if (i > mid)
                {
                    array[k] = aux[j++];
                }
                else if (j > high)
                {
                    array[k] = aux[i++];
                }
                else if (aux[j]<aux[i])
                {
                    array[k] = aux[j++];
                }
                else
                {
                    array[k] = aux[i++];
                }
            }
        }
    }
}
