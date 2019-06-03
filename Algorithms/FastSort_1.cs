using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class FastSort_1
    {
        public static int SortUnit(int[] array, int left, int right)
        {
            int key = array[left];
            while (left < right)
            {
                while (array[right] >= key && right > left)
                {
                    right--;
                }
                array[left] = array[right];
                while (array[left] <= key && left < right)
                {
                    left++;
                }
                array[right] = array[left];
            }

            array[left] = key;
            foreach (var i in array)
            {
                Console.WriteLine($"{i}");
            }

            Console.WriteLine();
            return right;
        }

        public static void Sort(int[] array, int left, int right)
        {
            if (left > right)
            {
                return;
            }

            int index = SortUnit(array, left, right);
            Sort(array, left, index - 1);
            Sort(array, index + 1, right);
        }
    }
}
