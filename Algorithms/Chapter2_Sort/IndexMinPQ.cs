using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter2_Sort
{
    class IndexMinPQ<T>
    {
        private Node<T>[] pq;


        public int Size { get; private set; }

        public IndexMinPQ(int maxN)
        {
            Size = maxN;
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void Insert(int k,Node<T> value)
        {
            pq[++Size] = value;
            Swim(Size);
        }

        public void Change(int k, Node<T> item)
        {

        }

        public bool Contains(int k)
        {
            return true;
        }

        public void Delete(int k)
        {

        }

        public void Min()
        {

        }

        public int MinIndex()
        {
            return 0;
        }

        public int DeleteMin()
        {
            return 1;
        }

        

        void Exchange(int a, int b)
        {
            Node<T> temp = pq[a];
            pq[a] = pq[b];
            pq[b] = temp;
        }

        void Swim(int k)
        {
            while (k > 1 && k / 2 < k)
            {
                Exchange(k / 2, k);
                k = k / 2;
            }
        }
    }
}
