using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter3_Search
{
    class Transaction
    {
        public int Hash(DateTime dateTime)
        {
            int hash = 17;
            hash = 31 * hash + dateTime.Year.GetHashCode();
            hash = 31 * hash + dateTime.Month.GetHashCode();
            hash = 31 * hash + dateTime.Day.GetHashCode();
            return hash;
        }
    }
}
