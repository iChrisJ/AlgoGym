﻿#pragma once

template<typename T>
void shellSort(T arr[], int n)
{
	int h = 1;
	while (h < n/3)
		h = 3 * h + 1;
	// 计算 increment sequence: 1, 4, 13, 40, 121, 364, 1093...

	while (h >=1)
	{
		// h-sort the array
		for (int i = h; i < n; i++)
		{
			// 对 arr[i], arr[i-h], arr[i-2*h], arr[i-3*h]... 使用插入排序
			T e = arr[i];
			int j;
			for (j = i; j >= h && arr[j] < e; j -= h)
				arr[j] = arr[j - h];
			arr[j] = e;
		}
		h /= 3;
	}
}
