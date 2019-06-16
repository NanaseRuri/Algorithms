using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class RabinKarp
    {
        private string pat;
        private long patHash;
        private int m;          //pat 的长度
        private long q;         //作为散列运算使用的值
        private int r = 256;
        private long rm;        //r^(m-1)%q

        public RabinKarp(string pat)
        {
            this.pat = pat;
            this.m = pat.Length;
            q = 2011;
            rm = 1;
            for (int i = 1; i <=m-1; i++)
            {
                rm = (r * rm) & q;
            }

            patHash = Hash(pat, m);
        }

        public bool Check(string txt, int i)
        {
            for (int j = 0; j < m; j++)
            {
                if (pat[j]!=txt[i+j])
                {
                    return false;
                }
            }

            return true;
        }

        private long Hash(string s, int i)
        {
            long h = 0;
            for (int j = 0; j < m; j++)
            {
                h = (r * h + s[j]) % q;                
            }

            return h;
        }

        public int Search(string txt)
        {
            int n = txt.Length;
            long txtHash = Hash(txt, m);
            if (patHash==txtHash&&Check(txt,0))
            {
                return 0;
            }

            for (int i = m; i < n; i++)
            {
                txtHash = (txtHash + q - rm * txt[i - m] % q) % q;
                txtHash = (txtHash * r + txt[i]) % q;
                if (patHash==txtHash)
                {
                    if (Check(txt,i-m+1))
                    {
                        return i - m + 1;
                    }
                }                
            }
            return n;
        }
    }
}
