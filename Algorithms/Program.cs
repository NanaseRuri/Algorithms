using System;
using System.Collections;
using System.Collections.Generic;
using Algorithms.Chapter1;
using Algorithms.Chapter2_Sort;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(sizeof(int));
            //Console.WriteLine(sizeof(double));
            //Console.WriteLine(sizeof(char));
            //Console.WriteLine(sizeof(bool));
            //int x = 5;
            //Console.WriteLine(x+=5*3);
            //Console.WriteLine();

            int[] array = new[] { 8, 5, 1, 9, 3, 15, 7, 25, 6, 32, 35 };
            //QuickSort.Sort(array, 0, array.Length - 1);
            //Console.WriteLine();

            Quick3Way.Sort(array,0,array.Length-1);
            foreach (var i in array)
            {
                Console.WriteLine(i);
            }
        }
    }
}
