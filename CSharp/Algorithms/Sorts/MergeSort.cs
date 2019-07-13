using System;
using System.Collections.Generic;

namespace Algorithms.Sorts
{
	public partial class Sorts
	{
		#region Merge Sort

		public static void MergeSort(IList<int> list)
		{
			MergeSort(list, 0, list.Count - 1);
		}

		private static void MergeSort(IList<int> list, int l, int r)
		{
			if (l >= r)
				return;

			int mid = l + (r - l) / 2;

			MergeSort(list, l, mid);
			MergeSort(list, mid + 1, r);

			// 对于arr[mid] <= arr[mid+1]的情况,不进行merge
			// 对于近乎有序的数组非常有效,但是对于一般情况,有一定的性能损失
			if (list[mid] > list[mid + 1])
				Merge(list, l, mid, r);
		}

		private static void Merge(IList<int> list, int l, int mid, int r)
		{
			// 辅助空间
			IList<int> aux = new List<int>();

			for (int index = l; index <= r; index++)
				aux.Add(list[index]);

			// 初始化，i指向左半部分的起始索引位置 l；j指向右半部分起始索引位置 mid+1。
			int i = l, j = mid + 1;

			for (int k = l; k <= r; k++)
			{
				if (i > mid) // 如果左半部分元素已经全部处理完毕
				{
					list[k] = aux[j - l];
					j++;
				}
				else if (j > r) // 如果右半部分元素已经全部处理完毕
				{
					list[k] = aux[i - l];
					i++;
				}
				else if (aux[i - l] <= aux[j - l]) // 左半部分所指元素 <= 右半部分所指元素
				{
					list[k] = aux[i - l];
					i++;
				}
				else // 左半部分所指元素 > 右半部分所指元素
				{
					list[k] = aux[j - l];
					j++;
				}
			}
		}

		#endregion Merge Sort

		#region Merge Sort Bottom Up

		public static void MergeSortBottomUp(IList<int> list)
		{
			for (int sz = 1; sz < list.Count; sz += sz)
				for (int i = 0; i < list.Count - sz; i += sz + sz)
					if (list[i + sz - 1] > list[i + sz])
						Merge(list, i, i + sz - 1, Math.Min(i + 2 * sz - 1, list.Count - 1));
		}

		#endregion Merge Sort Bottom Up
	}
}
