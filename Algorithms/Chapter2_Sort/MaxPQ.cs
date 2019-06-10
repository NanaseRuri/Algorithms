using System;
using System.Collections.Generic;
using System.Text;
#pragma warning disable 0649

namespace Algorithms.Chapter2_Sort
{
    class MaxPQ<T>
    {
        private Node<T>[] pq;
        public int Size { get; private set; }

        public MaxPQ(int maxN)
        {
            Size = maxN;
            pq=new Node<T>[Size];
        }

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public void Insert(Node<T> value)
        {
            pq[++Size] = value;
            Swim(Size);
        }

        public Node<T> DeleteMax()
        {
            Node<T> max = pq[1];
            Exchange(1,Size--);
            pq[Size + 1] = null;
            Sink(1);
            return max;
        }

        public void Sort(T[] a)
        {
            int n = a.Length;
            for (int i = n/2; i >=1; i--)
            {
                //sink 将 i 到 n 的元素进行排序
                Sink(a,i,n);
            }

            //修复并排序
            while (n>1)
            {
                Exchange(a,1,n--);
                Sink(a,1,n);
            }
        }

        public void Sink(T[] array, int left, int right)
        {
            while (2 * left <= right)
            {
                int j = 2 * left;
                if (j < right && j < j + 1)
                {
                    j++;
                }

                if (left >= j)
                {
                    break;
                }
                Exchange(array,left, j);
                left = j;
            }
        }

        void Sink(int k)
        {
            while (2 * k <= Size)
            {
                int j = 2 * k;
                if (j < Size && j < j + 1)
                {
                    j++;
                }

                if (!(k < j))
                {
                    break;
                }
                Exchange(k, j);
                k = j;
            }
        }

        void Swim(int k)
        {
            while (k>1&&k/2<k)
            {
                Exchange(k/2,k);
                k = k / 2;
            }
        }

        void Exchange(int a, int b)
        {
            Node<T> temp = pq[a];
            pq[a] = pq[b];
            pq[b] = temp;
        }

        void Exchange(T[]array, int a, int b)
        {
            T temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

    }
}
