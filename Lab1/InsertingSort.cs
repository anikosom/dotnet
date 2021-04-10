using System;

namespace Lab1
{
    public static class InsertingSort<T> where T : IComparable
    {
        public static void InsertionSort(T[] items)
        {
            for (var i = 1; i < items.Length; ++i)
            {
                var temp = items[i];
                var j = i;
                while (j > 0 && temp.CompareTo(items[j - 1]) < 0)
                {
                    items[j] = items[j - 1];
                    j--;
                }
                items[j] = temp;

            }
        }
    }
}
