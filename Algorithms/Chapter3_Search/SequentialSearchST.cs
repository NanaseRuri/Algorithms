using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter3_Search
{
    class SequentialSearchST<TKey,TValue>
    {
        private Node first;
        internal class Node
        {
            public TKey key;
            public TValue value;

            public Node Next { get; set; }

            public Node(TKey key, TValue value, Node next)
            {
                this.key = key;
                this.value = value;
                this.Next = next;
            }
        }

        public TValue Get(TKey key)
        {
            for (Node x = first; x!= null; x=x.Next)
            {
                if (key.Equals(x.key))
                {
                    return x.value;
                }
            }

            return default(TValue);
        }

        public void Put(TKey key, TValue value)
        {
            for (Node x = first; x != null; x = x.Next)
            {
                if (key.Equals(x.key))
                {
                    x.value = value;
                    return;
                }
            }

            first = new Node(key, value, first);
        }

    }
}
