using System.Collections.Generic;

namespace Algorithms.Sorts
{
	public partial class Sorts
	{
		public static void InsertionSort(IList<int> list)
		{
			// 假设以i为界将数组分为两部分,[0, i)是已排好序的，将arr[i]插入[0, i)中合适的位置使[0, i]任然有序.
			for (int i = 1; i < list.Count; i++)
			{
				int temp = list[i];
				int j;
				for (j = i; j > 0 && temp < list[j - 1]; j--)
				{
					list[j] = list[j - 1];
				}
				list[j] = temp;
			}
		}
	}
}