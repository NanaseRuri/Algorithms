using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class TreeWaySearchTree<TValue>
    {
        private Node root;

        class Node
        {
            public char Char { get; set; }
            public Node left, mid, right;
            public TValue Value { get; set; }
        }

        public TValue Get(string key)
        {
            Node x = Get(root, key, 0);
            if (x == null)
            {
                return default(TValue);
            }

            return x.Value;
        }

        private Node Get(Node node, string key, int d)
        {
            if (node == null)
            {
                return null;
            }

            char c = key[d];
            if (c<node.Char)
            {
                return Get(node.left, key, d);                
            }

            if (c>node.Char)
            {
                return Get(node.right, key, d);
            }

            if (d<key.Length-1)
            {
                return Get(node.mid, key, d + 1);
            }

            return node;
        }

        public void Put(string key, TValue value)
        {
            root=Put(root, key, value, 0);
        }

        private Node Put(Node node, string key, TValue value, int d)
        {
            char c = key[d];
            if (node==null)
            {
                node=new Node()
                {
                    Char=c
                };
            }

            if (c<node.Char)
            {
                node.left = Put(node.left, key, value, d);
            }

            else if (c>node.Char)
            {
                node.right = Put(node.right, key, value, d);
            }
            else if (d < key.Length - 1)
            {
                node.mid = Put(node.mid, key, value, d + 1);
            }
            else
            {
                node.Value = value;
            }

            return node;
        }
    }
}
