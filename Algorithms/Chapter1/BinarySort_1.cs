namespace Algorithms.Chapter1
{
    class BinarySort_1
    {
        public static int BinarySort(int[] array, int value, int left, int right)
        {
            while (left <= right)
            {
                int middle = (left + right) / 2;
                if (value == array[middle])
                {
                    return middle;
                }
                else if (value > array[middle])
                {
                    left = middle + 1;
                }
                else if (value < array[middle])
                {
                    right = middle - 1;
                }
            }

            return -1;
        }
    }
}
