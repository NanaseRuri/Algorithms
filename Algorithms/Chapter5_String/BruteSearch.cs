using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class BruteSearch
    {
        public static int Search(string origin, string target)
        {
            int originLength = origin.Length;
            int targetLength = target.Length;

            for (int i = 0; i <= originLength - targetLength; i++)
            {
                int j;
                for (j = 0; j < targetLength; j++)
                {
                    if (origin[i+j]!=target[j])
                    {
                        break;
                    }                    
                }

                if (j==targetLength)
                {
                    return i;
                }
            }

            return originLength;
        }
    }
}
