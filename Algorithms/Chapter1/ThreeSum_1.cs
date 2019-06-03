namespace Algorithms.Chapter1
{
    class ThreeSum_1
    {
        public static int ThreeSum(int[] array)
        {
            int count = 0;

            FastSort_1.Sort(array,0,array.Length-1);
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++)
                {
                    int position = BinarySort_1.BinarySort(array, -array[i] - array[j], i, array.Length);
                    if (position>i)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
