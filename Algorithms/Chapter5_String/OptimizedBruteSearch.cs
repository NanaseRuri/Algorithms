using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class OptimizedBruteSearch
    {
        public static int Search(string origin, string target)
        {
            int originLength = origin.Length;
            int targetLength = target.Length;
            int i, j;            

            for (i = 0,j=0; i <originLength&&j<targetLength ; i++)
            {
                if (origin[i]==target[j])
                {
                    j++;
                }
                else
                {
                    i -= j;
                    j = 0;
                }
            }

            if (j==targetLength)
            {
                return i-targetLength;
            }
            return originLength;
        }
    }
}
