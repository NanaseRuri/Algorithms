using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Algorithms.Chapter1;
using Algorithms.Chapter2_Sort;
using Algorithms.Chapter4_Graph;
using Algorithms.Chapter5_String;

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


            //Graph 换成 DirectedGraph        ConnectedComponent 换成 KosarajuConnectedComponent 即有向无环图的连通分量
            Graph g=new Graph();
            ConnectedComponent cc = new ConnectedComponent(g);

            int m = cc.Count;
            ConcurrentBag<int>[] components = new ConcurrentBag<int>[m];
            for (int i = 0; i < m; i++)
            {
                components[i]=new ConcurrentBag<int>();
            }

            for (int i = 0; i < g.VertexSize; i++)
            {
                components[cc.Id(i)].Add(i);
            }

            for (int i = 0; i < m; i++)
            {
                foreach (var i1 in components[i])
                {
                    Console.Write($"{i1} ");
                }
                Console.WriteLine();
            }

            KnuthMorrisPrattSearch search=new KnuthMorrisPrattSearch("aabaaaaa");
            Console.WriteLine(search.Search("aabaabaaaaaa"));
        }
    }
}
