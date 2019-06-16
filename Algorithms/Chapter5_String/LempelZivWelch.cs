using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class LempelZivWelch
    {
        private int r = 256;
        private int l = 4096;       //2^w
        private int w = 12;         //码长度

        public void Compress()
        {
            string input = Console.ReadLine();
            TST<int> st=new TST<int>();
            for (int i = 0; i < r; i++)
            {
                st.Put("" + i, i);
            }

            int code = r + 1;
            while (input.Length>0)
            {
                string s = st.LongestPrefixOf(input);
                BinaryStdOut.Write(st.Get(s), w);
                int t = s.Length;
                if (t<input.Length&&code<l)
                {
                    st.Put(input.Substring(0,t+1),code++);
                }

                input = input.Substring(t);
            }
            BinaryStdOut.Write(r,w);
            BinaryStdOut.Close();
        }

        public void Expand()
        {
            string[] st=new string[l];
            int i;
            for (i = 0; i < r; i++)
            {
                st[i] = "" + i;
            }

            st[i++] = "";
            int codeword = BinaryStdIn.ReadInt(w);
            if (codeword==r)
            {
                return;
            }

            string val = st[codeword];
            while (true)
            {
                BinaryStdOut.Write(val);
                codeword = BinaryStdIn.ReadInt(w);
                if (codeword==r)
                {
                    break;
                }

                string s = st[codeword];
                if (i==codeword)
                {
                    s = val + val[0];                    
                }

                if (i<l)
                {
                    st[i++] = val + s[0];
                }

                val = s;
            }
            BinaryStdOut.Close();
        }
    }
}
