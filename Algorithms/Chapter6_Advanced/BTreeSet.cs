using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter6_Advanced
{
    class BTreeSet<TKey,TValue> where TKey:IComparable<TKey>
    {
        private static int M = 4;      //子节点数目为 m-1

        private Node root;
        public int height;
        public int n;      //键值对数目

        public class Node
        {
            public int m;      //子节点数目
            public Entry[] children = new Entry[M];

            public Node(int k)
            {
                m = k;
            }
        }

        public class Entry
        {
            public TKey key;
            public TValue value;
            public Node next;

            public Entry(TKey key, TValue value, Node next)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
        }

        public BTreeSet()
        {
            root = new Node(0);
        }

        public bool IsEmpty()
        {
            return n == 0;
        }

        public TValue Get(TKey key)
        {
            if (key==null)
            {
                throw new NullReferenceException();
            }

            return Search(root, key, height);
        }

        private TValue Search(Node node, TKey key, int i)
        {
            Entry[] children = node.children;

            if (i==0)
            {
                for (int j = 0; j < node.m; j++)
                {
                    if (key.CompareTo(children[j].key)==0)
                    {
                        return children[j].value;
                    }
                }
            }
            else
            {
                for (int j = 0; j < node.m; j++)
                {
                    if (j+1==node.m||key.CompareTo(children[j+1].key)<0)
                    {
                        return Search(children[j].next, key, i - 1);
                    }
                }
            }

            return default(TValue);
        }

        public void Put(TKey key, TValue value)
        {
            if (key==null)
            {
                throw new NullReferenceException();
            }

            Node u = Insert(root, key, value, height);
            n++;
            if (u==null)
            {
                return;
            }

            Node t = new Node(2);
            t.children[0] = new Entry(root.children[0].key,default(TValue), root);
            t.children[1] = new Entry(u.children[1].key, default(TValue), u);
            root = t;
            height++;
        }

        private Node Insert(Node node, TKey key, TValue value, int i)
        {
            int j;
            Entry t = new Entry(key, value, null);

            if (i==0)
            {
                for (j  = 0; j < node.m; j++)
                {
                    if (key.CompareTo(node.children[j].key)<0)
                    {
                        break;
                    }
                }
            }
            else
            {
                for (j = 0; j < node.m; j++)
                {
                    if (j+1==node.m||key.CompareTo(node.children[j+1].key)<0)
                    {
                        Node u = Insert(node.children[j++].next, key, value, i - 1);
                        if (u==null)
                        {
                            return null;
                        }

                        t.key = u.children[0].key;
                        t.next = u;
                        break;
                    }
                }
            }
            for (int k = node.m; k > j; k--)
            {
                node.children[k] = node.children[k - 1];
            }
            node.children[j] = t;
            node.m++;
            if (node.m < M)
            {
                return null;
            }
            else
            {
                return Split(node);
            }
        }

        Node Split(Node node)
        {
            Node n = new Node(M / 2);
            node.m = M / 2;
            for (int i = 0; i < M/2; i++)
            {
                n.children[i] = node.children[M / 2 + i];
            }

            return n;
        }
    }
}
