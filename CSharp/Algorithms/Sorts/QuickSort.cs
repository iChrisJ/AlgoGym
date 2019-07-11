using System.Collections.Generic;

namespace Algorithms.Sorts
{
	public partial class Sorts
	{
		#region Quick Sort in one way

		/// <summary>
		/// Quick Sort in one way
		/// </summary>
		/// <param name="list">Unsorted list</param>
		public static void QuickSort(IList<int> list)
		{
			QuickSort(list, 0, list.Count - 1);
		}

		/// <summary>
		/// Quick Sort in one way
		/// </summary>
		/// <param name="list">Unsorted list</param>
		/// <param name="left">Left boundary in the list</param>
		/// <param name="right">Right boundary in the list</param>
		private static void QuickSort(IList<int> list, int left, int right)
		{
			if (left > right)
				return;

			int pivotInd = Partition(list, left, right);

			QuickSort(list, left, pivotInd - 1);
			QuickSort(list, pivotInd + 1, right);
		}

		/// <summary>
		/// Get Partition postion of the list
		/// </summary>
		/// <param name="list">The list</param>
		/// <param name="left">Left boundary in the list</param>
		/// <param name="right">Right boundary in the list</param>
		/// <returns>Partition postion index</returns>
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

		#endregion Quick Sort in one way

		#region Quick Sort in two ways

		/// <summary>
		/// Quick Sort in two ways.
		/// </summary>
		/// <param name="list"></param>
		public static void QuickSort2Ways(IList<int> list)
		{
			QuickSort2Ways(list, 0, list.Count - 1);
		}

		private static void QuickSort2Ways(IList<int> list, int left, int right)
		{
			if (left >= right)
				return;

			int pivotInd = Partition2(list, left, right);
			QuickSort2Ways(list, left, pivotInd - 1);
			QuickSort2Ways(list, pivotInd + 1, right);
		}

		private static int Partition2(IList<int> list, int left, int right)
		{
			int pivot = list[left];
			int i = left + 1, j = right; // list[lift + 1.. i] <= pivot; list[j..right] >=v
			while (true)
			{
				while (i <= right && list[i] <= pivot)
					i++;
				while (j >= left + 1 && list[j] >= pivot)
					j--;

				if (i > j)
					break;

				int temp = list[i];
				list[i] = list[j];
				list[j] = temp;
				i++;
				j--;
			}

			int temp2 = list[j];
			list[j] = list[left];
			list[left] = temp2;
			return j;
		}

		#endregion Quick Sort in two ways

		#region Quick Sort in three ways

		/// <summary>
		/// Quick Sort in three ways
		/// </summary>
		/// <param name="list"></param>
		public static void QuickSort3Ways(IList<int> list)
		{
			QuickSort3Ways(list, 0, list.Count - 1);
		}

		private static void QuickSort3Ways(IList<int> list, int left, int right)
		{
			if (left >= right)
				return;

			int pivot = list[left];
			int lt = left, gt = right + 1, i = left + 1; // list[left+1...lt] < pivot, list[gt...right] > pivot, arr[lt+1...i) == pivot
			int temp;
			while (i < gt)
			{
				if (list[i] < pivot)
				{
					temp = list[i];
					list[i] = list[lt + 1];
					list[lt + 1] = temp;
					lt++;
					i++;
				}
				else if (list[i] > pivot)
				{
					temp = list[i];
					list[i] = list[gt - 1];
					list[gt - 1] = temp;
					gt--;
				}
				else // list[i] == pivot
				{
					i++;
				}
			}

			temp = list[lt];
			list[lt] = list[left];
			list[left] = temp;

			QuickSort3Ways(list, left, lt - 1);
			QuickSort3Ways(list, gt, right);
		}

		#endregion Quick Sort in three ways
	}
}