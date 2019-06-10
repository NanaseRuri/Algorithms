using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter3_Search
{
    class BinarySearchTree<TKey,TValue> where TKey:IComparable
    {
        private Node root;

        private class Node
        {
            public TKey Key { get; set; }
            public TValue Value { get;set; }
            public int Size { get; set; }

            public Node left;
            public Node right;

            public Node(TKey key, TValue value, int size)
            {
                this.Key = key;
                this.Value = value;
                this.Size = size;
            }
        }

        /// <summary>
        /// 提供查找范围
        /// </summary>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        public IEnumerable<TKey> Keys(TKey low, TKey high)
        {
            Queue<TKey> queue = new Queue<TKey>();
            Keys(root, queue, low, high);
            return queue;
        }

        void Keys(Node x, Queue<TKey> queue, TKey low, TKey high)
        {
            if (x==null)
            {
                return;
            }

            int cmpLow = low.CompareTo(x.Key);
            int cmpHigh = high.CompareTo(x.Key);
            if (cmpLow<0)
            {
                Keys(x.left, queue, low, high);
            }

            if (cmpLow<=0&&cmpHigh>=0)
            {
                queue.Enqueue(x.Key);
            }

            if (cmpHigh>0)
            {
                Keys(x.right, queue, low, high);
            }
        }

        public int Size()
        {
            return Size(root);
        }

        public TValue Get(TKey key)
        {
            return Get(root, key);
        }

        TValue Get(Node node, TKey key)
        {
            if (node==null)
            {
                return default(TValue);
            }

            int cmp = key.CompareTo(node.Key);
            if (cmp<0)
            {
                return Get(node.left, key);
            }
            else if (cmp>0)
            {
                return Get(node.right, key);
            }

            return node.Value;
        }

        public void Put(TKey key, TValue value)
        {
            root = Put(root, key, value);
        }

        private Node Put(Node node, TKey key, TValue value)
        {
            if (node==null)
            {
                return new Node(key, value, 1);
            }

            int cmp = key.CompareTo(node.Key);
            if (cmp<0)
            {
                node.left = Put(node.left, key, value);
            }
            else if (cmp>0)
            {
                node.right = Put(node.right, key, value);
            }
            else
            {
                node.Value = value;
            }

            node.Size = Size(node.left) + Size(node.right) + 1;
            return node;
        }

        public void DeleteMin()
        {
            Node minNode=root;
            while (minNode?.left?.left != null)
            {
                minNode = root.left;
            }

            if (minNode?.left!=null)
            {
                minNode.left = null;
                minNode.Size -= 1;
                root.Size -= 1;
            }
        }

        public void DeleteMax()
        {
            Node maxNode = root;
            while (maxNode?.right?.right!=null)
            {
                maxNode = root.right;
            }

            if (maxNode?.right!=null)
            {
                maxNode.right = null;
                maxNode.Size -= 1;
                root.Size -= 1;
            }
        }

        Node DeleteMin(Node x)
        {
            if (x.left==null)
            {
                return x.right;
            }

            x.left = DeleteMin(x.left);
            x.Size = Size(x.left) + Size(x.right) + 1;
            return x;
        }

        public void Delete(TKey key)
        {
            root = Delete(root, key);
        }

        private Node Delete(Node x, TKey key)
        {
            if (x==null)
            {
                return null;
            }

            int cmp = key.CompareTo(x.Key);
            if (cmp<0)
            {
                x.left = Delete(x.left, key);
            }
            else if (cmp>0)
            {
                x.right = Delete(x.right, key);
            }
            else
            {
                if (x.right==null)
                {
                    return x.left;
                }

                if (x.left==null)
                {
                    return x.right;
                }

                Node t = x;
                x = Min(t.right);
                x.right = DeleteMin(x.right);
                x.left = t.left;
            }

            x.Size = Size(x.left) + Size(x.right) + 1;
            return x;
        }

        int Size(Node node)
        {
            if (node==null)
            {
                return 0;
            }

            return node.Size;
        }

        Node Min(Node x)
        {
            if (x.left==null)
            {
                return x;
            }

            return Min(x);
        }

        Node Floor(Node x, TKey key)
        {
            if (x==null)
            {
                return null;
            }

            int cmp = key.CompareTo(x.Key);
            if (cmp==0)
            {
                return x;
            }

            if (cmp<0)
            {
                return Floor(x.left, key);
            }

            Node t = Floor(x.left, key);
            if (t!=null)
            {
                return t;
            }

            return x;
        }
    }
}
