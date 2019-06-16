using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class Quick3WayString
    {
       static int CharAt(string s, int d)
        {
            if (d < s.Length)
            {
                return s[d];
            }

            return -1;
        }

        public static void Sort(string[] a)
        {
            Sort(a,0,a.Length-1,0);
        }

        public static void Sort(string[] a, int low, int high, int d)
        {
            if (high<=low)
            {
                return;
            }

            int lt = low;
            int gt = high;
            int v = CharAt(a[low], d);
            int i = low + 1;

            while (i<=gt)
            {
                int t = CharAt(a[i], d);
                if (t<v)
                {
                    Exchange(a, lt++, i++);
                }else if (t > v)
                {
                    Exchange(a, i, gt--);
                }
                else
                {
                    i++;
                }

            }

            Sort(a, low, lt - 1, d);
            if (v>=0)
            {
                Sort(a,lt,gt,d+1);
            }
            Sort(a,gt+1,high,d);
        }

        static void Exchange(string[] array, int left, int right)
        {
            string temp = array[left];
            array[left] = array[right];
            array[right] = temp;
        }
    }
}
