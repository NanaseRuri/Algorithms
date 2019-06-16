using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class MinPQ<T> where T:IComparable<T>
    {
            public int Count { get; private set; }
            private int[] pq;
            private int[] qp;
            private T[] keys;

            public bool IsEmpty()
            {
                return Count == 0;
            }

            public bool Contains(int k)
            {
                return qp[k] != -1;
            }

            public void Insert(int k, T key)
            {
                Count++;
                pq[k] = Count;
                qp[Count] = k;
                keys[k] = key;
                Swim(k);
            }

            public T Min()
            {
                return keys[pq[1]];
            }

            public T DelMin()
            {
                int indexOfMin = pq[1];
                Exchange(1, Count--);
                Sink(1);
                T temp = (T)keys[pq[Count + 1]];
                keys[pq[Count + 1]] = default(T);
                qp[pq[Count + 1]] = -1;
                return temp;
            }

            public int DeleteMin()
            {
                int indexOfMin = pq[1];
                Exchange(1, Count--);
                Sink(1);
                keys[pq[Count + 1]] = default(T);
                qp[pq[Count + 1]] = -1;
                return indexOfMin;
            }

            private void Exchange(int i, int k)
            {
                T temp = (T)keys[i];
                int temp1 = pq[i];
                int temp2 = qp[i];

                keys[i] = keys[k];
                keys[k] = temp;

                pq[i] = pq[k];
                pq[k] = temp1;

                qp[i] = pq[k];
                pq[k] = temp2;
            }

            void Sink(int index)
            {
                while (2 * index <= Count)
                {
                    int j = 2 * index;
                    if (j < Count && keys[j].CompareTo(keys[j + 1]) < 0)
                    {
                        j++;
                    }

                    if (keys[j].CompareTo(keys[j + 1]) >= 0)
                    {
                        break;
                    }
                    Exchange(index, j);
                    index = j;
                }
            }

        internal void Insert(Huffman.Node parent)
        {
            throw new NotImplementedException();
        }

        internal void Insert(char c, int v, object p1, object p2)
        {
            throw new NotImplementedException();
        }

        void Swim(int index)
            {
                while (index > 1 && keys[index / 2].CompareTo(keys[index]) < 0)
                {
                    Exchange(index / 2, index);
                    index = index / 2;
                }
            }

            public void Change(int index, T value)
            {
                keys[index] = value;
            }
        
    }
}
