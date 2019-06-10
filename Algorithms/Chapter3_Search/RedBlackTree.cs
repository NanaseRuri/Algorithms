using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter3_Search
{
    class RedBlackTree<TValue, TKey> where TKey : IComparable
    {
        private Node root;

        public class Node
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            public int Size { get; set; }
            public bool IsRed { get; set; }

            public Node left;
            public Node right;

            public Node(TKey key, TValue value, int size, bool isRed)
            {
                this.Key = key;
                this.Value = value;
                this.Size = size;
                IsRed = isRed;
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
            if (x == null)
            {
                return;
            }

            int cmpLow = low.CompareTo(x.Key);
            int cmpHigh = high.CompareTo(x.Key);
            if (cmpLow < 0)
            {
                Keys(x.left, queue, low, high);
            }

            if (cmpLow <= 0 && cmpHigh >= 0)
            {
                queue.Enqueue(x.Key);
            }

            if (cmpHigh > 0)
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
            if (node == null)
            {
                return default(TValue);
            }

            int cmp = key.CompareTo(node.Key);
            if (cmp < 0)
            {
                return Get(node.left, key);
            }
            else if (cmp > 0)
            {
                return Get(node.right, key);
            }

            return node.Value;
        }

        public Node RotateLeft(Node h)
        {
            Node x = h.right;
            h.right = x.left;
            x.left = h;
            x.IsRed = h.IsRed;
            h.IsRed = true;
            x.Size = h.Size;
            h.Size = Size(h.left) + Size(h.right) + 1;
            return x;
        }

        public Node RotateRight(Node h)
        {
            Node x = h.left;
            h.left = x.right;
            x.right = h;
            x.IsRed = h.IsRed;
            h.IsRed = true;
            x.Size = h.Size;
            h.Size = Size(h.left) + Size(h.right) + 1;
            return x;
        }

        public void Put(TKey key, TValue value)
        {
            root = Put(root, key, value);
        }

        private Node Put(Node node, TKey key, TValue value)
        {
            if (node == null)
            {
                return new Node(key, value, 1, true);
            }

            int cmp = key.CompareTo(node.Key);
            if (cmp < 0)
            {
                node.left = Put(node.left, key, value);
            }
            else if (cmp > 0)
            {
                node.right = Put(node.right, key, value);
            }
            else
            {
                node.Value = value;
            }

            if (node.right.IsRed && !node.left.IsRed)
            {
                node = RotateLeft(node);
            }

            if (node.left.IsRed && node.left.left.IsRed)
            {
                node = RotateRight(node);
            }

            if (node.left.IsRed && node.right.IsRed)
            {
                FlipColors(node);
            }

            node.Size = node.left.Size + node.right.Size + 1;
            return node;
        }

        void FlipColors(Node node)
        {
            node.left.IsRed = false;
            node.right.IsRed = false;
            node.IsRed = true;
        }

        public void Delete(TKey key)
        {
            if (!root.left.IsRed && !root.right.IsRed)
            {
                root.IsRed = true;
            }

            root = Delete(root, key);
            if (root.Size != 0)
            {
                root.IsRed = true;
            }
        }

        private Node Delete(Node node, TKey key)
        {
            if (key.CompareTo(node.Key) < 0)
            {
                if (!node.left.IsRed && !node.left.left.IsRed)
                {
                    node = MoveRedLeft(node);
                }

                node.left = Delete(node.left, key);
            }
            else
            {
                if (node.left.IsRed)
                {
                    node = RotateRight(node);
                }

                if (key.CompareTo(node.Key) == 0 && node.right == null)
                {
                    return null;
                }

                if (!node.right.IsRed && !node.right.left.IsRed)
                {
                    node = MoveRedRight(node);
                }

                if (key.CompareTo(node.Key) == 0)
                {
                    node.Value = Get(node.right, Min(node.right).Key);
                    node.Key = Min(node.right).Key;
                    node.right = DeleteMin(node.right);
                }
                else
                {
                    node.right = Delete(node.right, key);
                }
            }
            return Balance(node);

        }

        public void DeleteMin()
        {
            if (!root.left.IsRed && !root.right.IsRed)
            {
                root.IsRed = true;
            }

            root = DeleteMin(root);
            if (Size() != 0)
            {
                root.IsRed = false;
            }
        }

        Node DeleteMin(Node node)
        {
            if (node.left == null)
            {
                return null;
            }

            if (!node.left.IsRed && node.left.left.IsRed)
            {
                node = MoveRedLeft(node);
            }

            node.left = DeleteMin(node.left);
            return Balance(node);
        }

        private Node Balance(Node node)
        {
            if (node.right.IsRed && node.left.IsRed)
            {
                node = RotateLeft(node);
            }

            if (node.left.IsRed && node.left.left.IsRed)
            {
                node = RotateRight(node.left.left);
            }

            if (node.left.IsRed && node.right.IsRed)
            {
                FlipColors(node);
            }

            node.Size = node.left.Size + node.right.Size + 1;
            return node;
        }

        private Node MoveRedLeft(Node node)
        {
            FlipColors(node);
            if (node.right.left.IsRed)
            {
                node.right = RotateRight(node.right);
                node = RotateLeft(node);
            }

            return node;
        }

        public void DeleteMax()
        {
            if (!root.left.IsRed && !root.right.IsRed)
            {
                root.IsRed = true;
            }

            root = DeleteMax(root);
            if (Size() != 0)
            {
                root.IsRed = false;
            }
        }

        private Node DeleteMax(Node node)
        {
            if (node.left.IsRed)
            {
                node = RotateRight(node);
            }

            if (node.right == null)
            {
                return null;
            }

            if (!node.right.IsRed && !node.right.left.IsRed)
            {
                node = MoveRedRight(node);
            }

            node.right = DeleteMax(node.right);
            return Balance(node);
        }

        Node MoveRedRight(Node node)
        {
            FlipColors(node);
            if (!node.left.left.IsRed)
            {
                node = RotateRight(node);
            }

            return node;
        }

        int Size(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Size;
        }

        Node Min(Node x)
        {
            if (x.left == null)
            {
                return x;
            }

            return Min(x);
        }

        Node Floor(Node x, TKey key)
        {
            if (x == null)
            {
                return null;
            }

            int cmp = key.CompareTo(x.Key);
            if (cmp == 0)
            {
                return x;
            }

            if (cmp < 0)
            {
                return Floor(x.left, key);
            }

            Node t = Floor(x.left, key);
            if (t != null)
            {
                return t;
            }

            return x;
        }
    }
}
