using System.Collections.Generic;

namespace Algorithms.Sorts
{
	public partial class Sorts
	{
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
			Merge(list, l, mid, r);
		}

		private static void Merge(IList<int> list, int l, int mid, int r)
		{
			IList<int> aux = new List<int>(list);

			int i = l, j = mid + 1;

			for (int k = l; k <= r; k++)
			{
				if (i > mid)
				{
					list[k] = aux[j];
					j++;
				}
				else if (j > r)
				{
					list[k] = aux[i];
					i++;
				}
				else if (aux[i] <= aux[j])
				{
					list[k] = aux[i];
					i++;
				}
				else
				{
					list[k] = aux[j];
					j++;
				}
			}
		}
	}
}
