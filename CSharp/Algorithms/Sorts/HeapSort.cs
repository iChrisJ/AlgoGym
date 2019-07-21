using DataStructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Sorts
{
	public partial class Sorts
	{
		public static void HeapSort(IList<int> list)
		{
			//MaxHeap<int> maxHeap = new MaxHeap<int>();
			//for (int i = 0; i < list.Count; i++)
			//	maxHeap.Insert(list[i]);
			MaxHeap<int> maxHeap = new MaxHeap<int>(list);

			for (int i = list.Count - 1; i >= 0; i--)
				list[i] = maxHeap.ExtractMax();
		}
	}
}
