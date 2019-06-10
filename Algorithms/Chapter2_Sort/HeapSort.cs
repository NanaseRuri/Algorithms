using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter2_Sort
{
    class HeapSort
    {
        public int[] Sort(int[] sourceArray)
        {
            int[] arr = sourceArray;

            int len = arr.Length;

            BuildMaxHeap(arr);
                
            for (int i = len - 1; i > 0; i--)
            {
                Swap(arr, 0, i);
                len--;
                Heapify(arr, 0, len);
            }
            return arr;
        }

        private void BuildMaxHeap(int[] arr)
        {
            for (int i = (int)Math.Floor(arr.Length / 2.0); i >= 0; i--)
            {
                Heapify(arr, i, arr.Length);
            }
        }

        private void Heapify(int[] arr, int i, int len)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int largest = i;

            if (left < len && arr[left] > arr[largest])
            {
                largest = left;
            }

            if (right < len && arr[right] > arr[largest])
            {
                largest = right;
            }

            if (largest != i)
            {
                Swap(arr, i, largest);
                Heapify(arr, largest, len);
            }
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
