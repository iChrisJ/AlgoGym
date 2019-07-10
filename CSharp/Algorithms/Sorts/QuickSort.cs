using System;
using System.Collections.Generic;

namespace Algorithms.Sorts
{
    public partial class Sorts
    {
        public static void QuickSort(IList<int> list)
        {
            QuickSort(list, 0, list.Count-1);
        }

        private static void QuickSort(IList<int> list, int left, int right)
        {
            if (left > right)
                return;

            int pivotInd = Partition(list, left, right);

            QuickSort(list, left, pivotInd - 1);
            QuickSort(list, pivotInd + 1, right);
        }

        private static int Partition(IList<int> list, int left, int right)
        {
            int pivot = list[left];
            int pos = left;
            for (int i = left + 1; i <= right; i++)
            {
                if (list[i] < pivot)
                {
					int temp = list[i];
					list[i] = list[pos + 1];
					list[pos + 1] = temp;
                    pos++;
                }
            }
			int temp2 = list[left];
			list[left] = list[pos];
			list[pos] = temp2;
			return pos;
        }

        // Swap two elements.
        //private static void Swap<T>(T left, T right)
        //{
        //    T temp = right;
        //    right = left;
        //    left = temp;
        //}
    }
}