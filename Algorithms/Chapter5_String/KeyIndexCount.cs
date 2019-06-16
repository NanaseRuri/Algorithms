using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Chapter5_String
{
    class KeyIndexCount
    {
        private Student[] array;
        private int groupCount;

        public void SetArray(Student[] array,int groupCount)
        {
            this.array = array;
            this.groupCount = groupCount;
        }

        public void Sort()
        {
            int length = array.Length;

            string[] aux=new string[length];
            int[] count=new int[groupCount+1];

            //频率
            for (int i = 0; i < length; i++)
            {
                count[array[i].Key + 1]++;
            }
            //索引
            for (int i = 0; i < groupCount; i++)
            {
                count[i + 1] += count[i];
            }
            //将元素分类
            for (int i = 0; i < length; i++)
            {
                aux[count[array[i].Key]++] = array[i].Name;
            }
            //回写
            for (int i = 0; i < length; i++)
            {
                array[i].Name = aux[i];
            }
        }
    }
}
