using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class BoyerMoore
    {
        private int[] right;
        private string pat;

        public BoyerMoore(string pat)
        {
            this.pat = pat;
            int m = pat.Length;
            int r = 256;
            right=new int[r];

            for (int c = 0; c < r; c++)
            {
                right[c] = -1;
            }

            for (int i = 0; i < m; i++)
            {
                right[pat[i]] = -1;
            }
        }

        public int Search(string txt)
        {
            int n = txt.Length;
            int m = pat.Length;
            int skip;
            for (int i = 0; i <=n-m; i+=skip)
            {
                skip = 0;
                for (int j = m-1; j>=0; j--)
                {
                    if (pat[j]!=txt[i+j])
                    {
                        skip = j - right[txt[i + j]];
                        if (skip<1)
                        {
                            skip = 1;
                        }

                        break;
                    }
                }

                if (skip==0)
                {
                    return i;
                }                
            }
            return n;
        }
    }
}
