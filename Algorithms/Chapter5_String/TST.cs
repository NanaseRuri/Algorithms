using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class TST<TValue>
    {
        public int Size { get; set; }
        public Node<TValue> Root;
        public TValue Value { get; set; }

        public TST() { }

        public bool Contain(string key)
        {
            return Get(key) != null;
        }

        public TValue Get(string key)
        {
            if (key == null)
            {
                throw new NullReferenceException();
            }

            if (key.Length == 0)
            {
                throw new ArgumentException("必须有值");
            }

            Node<TValue> x = Get(Root, key, 0);
            if (x == null)
            {
                return default(TValue);
            }

            return x.Value;
        }

        Node<TValue> Get(Node<TValue> x, string key, int d)
        {
            if (key == null)
            {
                throw new NullReferenceException();
            }

            if (key.Length == 0)
            {
                throw new ArgumentException("必须有值");
            }

            if (x == null)
            {
                return null;
            }

            char c = key[d];
            if (c < x.C)
            {
                return Get(x.left, key, d);
            }

            if (c>x.C)
            {
                return Get(x.right, key, d);
            }

            if (d<key.Length-1)
            {
                return Get(x.mid, key, d + 1);
            }

            return x;
        }

        public void Put(string key, TValue value)
        {
            if (!Contain(key))
            {
                Size++;
            }

            Root = Put(Root, key, value, 0);
        }

        private Node<TValue> Put(Node<TValue> x, string key, TValue value, int d)
        {
            char c = key[d];
            if (x==null)
            {
                x = new Node<TValue> {C = c};
            }

            if (c < x.C)
            {
                return Get(x.left, key, d);
            }

            if (c > x.C)
            {
                return Get(x.right, key, d);
            }

            if (d < key.Length - 1)
            {
                return Get(x.mid, key, d + 1);
            }

            return x;
        }

        public class Node<TValue>
        {
            public char C { get; set; }                       // character
            public Node<TValue> left, mid, right;  // left, middle, and right subtries
            public TValue Value { get; set; }                     // value associated with string
        }

        public string LongestPrefixOf(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return null;
            }

            int length = 0;
            Node<TValue> x = Root;
            int i = 0;
            while (x!=null&&i<query.Length)
            {
                char c = query[i];
                if (c<x.C)
                {
                    x = x.left;
                }
                else if (c > x.C)
                {
                    x = x.right;
                }
                else
                {
                    i++;
                    if (x.Value!=null)
                    {
                        length = i;
                        x = x.mid;
                    }
                }
            }

            return query.Substring(0, length);
        }

    }
}
