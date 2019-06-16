using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class Huffman
    {
        private int r = 256;

        public class Node :IComparable<Node>
        {
            public char ch;
            public int freq;
            public Node left, right;

            public Node(char ch, int freq, Node left, Node right)
            {
                this.ch = ch;
                this.freq = freq;
                this.left = left;
                this.right = right;
            }

            public bool IsLeaf()
            {
                return left == null && right == null;
            }

            public int CompareTo(Node other)
            {
                return other.freq - other.freq;                
            }
        }

        public void Compress()
        {
            string s = Console.ReadLine();
            char[] input = s.ToCharArray();

            int[] freq=new int[r];
            foreach (var i in input)
            {
                freq[i]++;
            }

            Node root = BuildTrie(freq);
            
            string[] st=new string[r];
            BuildCode(st, root, "");

            //霍夫曼编码树
            WriteTrim(root);

            BinaryStdOut.Write(input.Length);

            foreach (var i in input)
            {
                string code = st[i];
                foreach (var c in code)
                {
                    if (c=='0')
                    {
                        BinaryStdOut.Write(false);
                    }else if (c == '1')
                    {
                        BinaryStdOut.Write(true);
                    }
                    throw new AggregateException("Illegal state");
                }
            }

            BinaryStdOut.Close();            
        }

        public void Expand()
        {
            Node root = ReadTrie();
            int n = BinaryStdIn.ReadInt();
            for (int i = 0; i < n; i++)
            {
                Node x = root;
                while (!x.IsLeaf())
                {
                    x = BinaryStdIn.ReadBoolean() ? x.right : x.left;
                    BinaryStdOut.Write(x.ch);
                }
            }

            BinaryStdOut.Close();
        }

        public Node ReadTrie()
        {
            bool isLeaf = BinaryStdIn.ReadBoolean();
            if (isLeaf)
            {
                return new Node(BinaryStdIn.ReadChar(), -1, null, null);
            }
            return new Node('\0',-1,ReadTrie(),ReadTrie());
        }

        public string[] BuildCode(Node root)
        {
            string[] st=new string[r];
            BuildCode(st, root, "");
            return st;
        }

        Node BuildTrie(int[] freq)
        {
            MinPQ<Node> pq=new MinPQ<Node>();
            for (char c = (char) 0; c < r; c++)
            {
                if (freq[c] > 0)
                {
                    pq.Insert(c, freq[c], null, null);
                }
            }

            while (pq.Count>1)
            {
                Node x = pq.DelMin();
                Node y = pq.DelMin();
                Node parent = new Node('\0', x.freq + y.freq, x, y);
                pq.Insert(parent);
            }

            return pq.DelMin();
        }

        void WriteTrim(Node x)
        {
            if (x.IsLeaf())
            {
                BinaryStdOut.Write(true);
                BinaryStdOut.Write(x.ch, 8);
                return;
            }

            BinaryStdOut.Write(false);
            WriteTrim(x.left);
            WriteTrim(x.right);
        }

        void BuildCode(string[] st, Node x, string s)
        {
            if (!x.IsLeaf())
            {
                BuildCode(st, x.left, s + '0');
                BuildCode(st, x.right, s + '1');
            }

            st[x.ch] = s;
        }
    }
}
