using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class TrieSearchTree<TValue>
    {
        class Node
        {
            public TValue Value { get; set; }
            public Node[] Next { get; set; }
        }

        private static int R = 256;
        private Node root;

        public TValue Get(string key)
        {
            Node x = Get(root, key, 0);
            if (x==null)
            {
                return default(TValue);
            }

            return x.Value;
        }

        //d 为具体字符的索引
        // 同时也是字符串本身的长度
        //还是查找树的深度
        private Node Get(Node node, string key, int d)
        {
            if (node==null)
            {
                return null;
            }

            if (d==key.Length)
            {
                return node;
            }

            char c = key[d];
            return Get(node.Next[c], key, d + 1);
        }

        public void Put(string key, TValue value)
        {
            root = Put(root, key, value, 0);
        }

        private Node Put(Node node, string key, TValue value, int d)
        {
            if (node==null)
            {
                node=new Node();                
            }

            if (d==key.Length)
            {
                node.Value = value;
                return node;
            }

            char c = key[d];
            node.Next[c] = Put(node.Next[c], key, value, d + 1);
            return node;
        }

        public IEnumerable<string> Keys()
        {
            return KeysWithPrefix("");
        }

        public IEnumerable<string> KeysWithPrefix(string prefix)
        {
            Queue<string> q = new Queue<string>();
            Collect(Get(root, prefix, 0), prefix, q);
            return q;
        }

        void Collect(Node node, string prefix, Queue<string> q)
        {
            if (node==null)
            {
                return;
            }

            if (node.Value!=null)
            {
                q.Enqueue(prefix);
            }

            for (char c=(char)0;c<R;c++)
            {
                Collect(node.Next[c], prefix + c, q);
            }
        }

        public IEnumerable<string> KeysThatMatch(string pat)
        {
            Queue<string> q = new Queue<string>();
            Collect(root, "", pat, q);
            return q;
        }

        private void Collect(Node node, string prefix, string pat, Queue<string> queue)
        {
            int d = prefix.Length;
            if (node==null)
            {
                return;
            }

            if (d==pat.Length&&node.Value!=null)
            {
                queue.Enqueue(prefix);
            }

            if (d==pat.Length)
            {
                return;
            }

            char next = pat[d];
            for (char c=(char)0;c<R;c++)
            {
                if (next=='.'||next==c)
                {
                    Collect(node.Next[c], prefix + c, pat, queue);
                }
            }
        }

        public string LongestPrefixOf(string s)
        {
            int length = Search(root, s, 0, 0);
            return s.Substring(0, length);
        }

        int Search(Node node, string s, int d, int length)
        {
            if (node==null)
            {
                return length;
            }

            if (node.Value!=null)
            {
                length = d;
            }

            if (d==s.Length)
            {
                return length;
            }

            char c = s[d];
            return Search(node.Next[c], s, d + 1, length);
        }

        public void Delete(string key)
        {
            root = Delete(root, key, 0);
        }

        private Node Delete(Node node, string key, int d)
        {
            if (node == null)
            {
                return null;
            }

            if (d==key.Length)
            {
                node.Value = default(TValue);
            }
            else
            {
                char c = key[d];
                node.Next[c] = Delete(node.Next[c], key, d + 1);
            }

            if (node.Value!=null)
            {
                return node;
            }

            for (char c=(char)0;c<R;c++)
            {
                if (node.Next[c]!=null)
                {
                    return node;
                }                
            }
            return null;
        }
    }
}
