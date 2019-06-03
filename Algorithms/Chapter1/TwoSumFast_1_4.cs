namespace Algorithms.Chapter1
{
    class TwoSumFast_1_4
    {
        public static int TwoSumFast(int[] array)
        {
            int count = 0;
            FastSort_1.Sort(array,0,array.Length-1);
            for (int i = 0; i < array.Length; i++)
            {
                if (BinarySort_1.BinarySort(array,-array[i],i+1,array.Length)>i)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
