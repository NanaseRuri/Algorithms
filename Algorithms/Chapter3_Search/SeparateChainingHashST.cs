#pragma warning disable 0649

namespace Algorithms.Chapter3_Search
{
    class SeparateChainingHashST<TKey,TValue>
    {
        private int stSize;
        private int hashCodeSize;
        private SequentialSearchST<TKey, TValue>[] st;

        public SeparateChainingHashST(): this(997)
        {            
        }

        public SeparateChainingHashST(int size)
        {
            this.stSize = size;
            st=new SequentialSearchST<TKey, TValue>[size];
            for (int i = 0; i < stSize; i++)
            {
                st[i]=new SequentialSearchST<TKey, TValue>();
            }
        }

        int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % hashCodeSize;
        }

        public TValue Get(TKey key)
        {
            return (TValue) st[Hash(key)].Get(key);
        }

        public void Put(TKey key, TValue value)
        {
            st[Hash(key)].Put(key,value);
        }
    }
}
