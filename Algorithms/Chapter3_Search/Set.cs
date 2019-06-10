using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter3_Search
{
    abstract class Set<TKey>
    {
        private List<TKey> set;

        public abstract void Add(TKey key);

        public abstract void Remove(TKey key);

        public abstract bool Contains(TKey key);

        public abstract bool IsEmpty();
        public abstract int Size();        
    }
}
