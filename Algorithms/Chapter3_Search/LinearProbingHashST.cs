using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter3_Search
{
    class LinearProbingHashST<TKey,TValue>
    {
        private int keySize;
        private int tableSize = 16;

        public TKey[] Keys { get; private set; }
        public TValue[] Values { get; private set; }

        public int Size()
        {
            return tableSize;
        }

        private int[] primes = new[] { 31,61,127,251,509};

        public LinearProbingHashST()
        {
            Keys=new TKey[tableSize];
            Values=new TValue[tableSize];
        }
        public LinearProbingHashST(int size)
        {
            Keys=new TKey[size];
            Values=new TValue[size];
        }

        int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % tableSize;
        }

        int AnotherHash(TKey key)
        {
            int t = key.GetHashCode() & 0x7fffffff;
            if (Math.Log10(t)<26)
            {
                t = t % primes[(int)Math.Log10(tableSize + 5)];
            }

            return t % tableSize;
        }

        void Resize(int size)
        {
            LinearProbingHashST<TKey, TValue> table=new LinearProbingHashST<TKey, TValue>(size);
            for (int i = 0; i < tableSize; i++)
            {
                if (Keys[i]!=null)
                {
                    table.Put(Keys[i],Values[i]);
                }                
            }

            Keys = table.Keys;
            Values = table.Values;
            this.tableSize = size;
        }

        public void Put(TKey key, TValue value)
        {
            if (keySize>=tableSize/2)
            {
                Resize(2*tableSize);
            }

            int i=0;
            for (i = Hash(key); Keys[i]!=null; i=(i+1)%tableSize)
            {
                if (Keys[i].Equals(key))
                {
                    Values[i] = value;
                    return;
                }
            }

            Keys[i] = key;
            Values[i] = value;
            keySize++;
        }

        public TValue Get(TKey key)
        {
            for (int i = Hash(key); Keys[i]!=null; i=(i+1)%tableSize)
            {
                if (Keys[i].Equals(key))
                {
                    return Values[i];
                }
            }

            return default(TValue);
        }

        public void Delete(TKey key)
        {
            if (!Contain(key))
            {
                return;
            }

            int i = Hash(key);
            while (!key.Equals(Keys[i]))
            {
                i = (i + 1) % tableSize;
            }

            Keys[i] = default(TKey);
            Values[i] = default(TValue);
            i = (i + 1) % tableSize;

            while (!Keys[i].Equals(default(TKey)))
            {
                TKey keyToRedo = Keys[i];
                TValue valueToRedo = Values[i];
                Keys[i] = default(TKey);
                Values[i] = default(TValue);
                keySize--;
                Put(keyToRedo, valueToRedo);
                i = (i + 1) % tableSize;
            }

            keySize--;
            if (keySize>0&&keySize==tableSize/8)
            {
                Resize(tableSize/2);
            }
        }

        public bool Contain(TKey key)
        {
            if (!Keys[Hash(key)].Equals(default(TKey)))
            {
                return true;
            }

            return false;
        }
    }
}
