using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class KnuthMorrisPrattSearch
    {
        private int r;
        private int[,] dfa;
        private char[] pattern; //匹配的字符串或字符数组
        private string pat; 

        public KnuthMorrisPrattSearch(string pat)
        {
            r = 256;
            this.pat = pat;
            int m = pat.Length;
            dfa = new int[r, m];
            dfa[pat[0], 0] = 1;
            for (int x = 0, j = 1; j < m; j++)
            {
                for (int c = 0; c < r; c++)
                {
                    dfa[c, j] = dfa[c, x];
                }

                dfa[pat[j], j] = j + 1;
                x = dfa[pat[j], x];
            }
        }

        public KnuthMorrisPrattSearch(char[] pattern, int r)
        {
            this.r = r;
            this.pattern = new char[pattern.Length];

            for (int i = 0; i < pattern.Length; i++)
            {
                this.pattern[i] = pattern[i];
            }

            int m = pattern.Length;
            dfa = new int[r, m];
            dfa[pattern[0], 0] = 1;
            for (int x = 0, j = 1; j < m; j++)
            {
                for (int c = 0; c < r; c++)
                {
                    dfa[c, j] = dfa[c, x];  //复制匹配失败的值
                }

                dfa[pattern[j], j] = j + 1; //匹配成功情况的值
                x = dfa[pattern[j], x]; //更新重启状态
            }
        }

        public int Search(string origin)
        {
            int m = pat.Length;
            int n = origin.Length;
            int i, j;
            for (i = 0, j = 0; i < n && j < m; i++)
            {
                j = dfa[origin[i], j];
            }

            if (j==m)
            {
                return i - m;
            }

            return n;
        }
    }
}
