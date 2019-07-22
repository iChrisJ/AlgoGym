using DataStructures;
using System.Collections.Generic;

namespace Algorithms.Sorts
{
	public partial class Sorts
	{
		public static void Heapify(IList<int> list)
		{
			//MaxHeap<int> maxHeap = new MaxHeap<int>();
			//for (int i = 0; i < list.Count; i++)
			//	maxHeap.Insert(list[i]);
			MaxHeap<int> maxHeap = new MaxHeap<int>(list);

			for (int i = list.Count - 1; i >= 0; i--)
				list[i] = maxHeap.ExtractMax();
		}

		public static void HeapSort(IList<int> list)
		{
			for (int i = (list.Count - 1 - 1) / 2; i >= 0; i--)
				ShiftDown(list, list.Count, i);

			for (int i = list.Count - 1; i >= 0; i--)
			{
				int temp = list[0];
				list[0] = list[i];
				list[i] = temp;
				ShiftDown(list, i, 0);
			}

		}

		private static void ShiftDown(IList<int> list, int n, int k)
		{
			int e = list[k];
			while (2 * k + 1 < n)
			{
				int j = 2 * k + 1;
				if (j + 1 < n && list[j + 1] > list[j])
					j++;
				if (e >= list[j])
					break;

				list[k] = list[j];
				k = j;
			}
			list[k] = e;
		}
	}
}
