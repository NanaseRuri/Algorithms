using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter3_Search
{
    class BinarySearchST<TKey,TValue> where TKey:IComparable
    {
        private TKey[] keys;
        private TValue[] values;
        public int Size { get; private set; }

        public BinarySearchST(int capacity)
        {
            keys=new TKey[capacity];
            values=new TValue[capacity];
        }

        public TValue Get(TKey key)
        {
            if (IsEmpty())
            {
                return default(TValue);
            }

            int i = Rank(key);
            if (i<Size&&keys[i].CompareTo(key)==0)
            {
                return values[i];
            }

            return default(TValue);
        }

        private int Rank(TKey key)
        {
            int low = 0;
            int high = Size - 1;
            while (low<=high)
            {
                int mid = (low + high) / 2;
                int cmp = key.CompareTo(keys[mid]);
                if (cmp<0)
                {
                    high = mid - 1;
                }
                else if (cmp>0)                                                    
                {
                    low = mid + 1;
                }else
                {
                    return mid;
                }
            }

            return low;
        }

        public bool IsEmpty()
        {
            return false;
        }
    }
}
