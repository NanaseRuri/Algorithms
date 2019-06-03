﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter2_Sort
{
    class Shell
    {
        public static void Sort(int[] a)
        {
            int h = 1;
            while (h<a.Length/3)
            {
                h = 3 * h + 1;
            }

            while (h>=1)
            {
                for (int i = h; i < a.Length; i++)
                {
                    for (int j = i; j >=h&&a[j]<a[j-h] ; j-=h)
                    {
                       Exchange(a,j,j-h);
                    }
                }

                h = h / 3;
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
