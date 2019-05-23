#pragma once


template<typename T>
void shellSort(T arr[], int n)
{
	int h = 1;
	while (h < n / 3)
		h = 3 * h + 1;

	// 希尔排序是将整个序列分成若干个子序列，分别进行插入排序，待整个数组基本有序后，再对全体进行一次插入排序
	// 希尔排序是将相隔增量为h的元素组成子序列。增量h是逐次缩短的直至h=1
	while (h >= 1)
	{
		for (int i = h; i < n; i++)
		{
			T e = arr[i];
			int j;
			for (j = i; j >= h && e < arr[j - h]; j -= h)
				arr[j] = arr[j - h];
			arr[j] = e;
		}
		h /= 3;
	}
}