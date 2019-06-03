#pragma once

#include <algorithm>
#include "MergeSort.h"

// 使用自底向上的归并排序算法
template<typename T>
void mergeSortBU(T arr[], int n)
{
	// Merge Sort Bottom Up 无优化版本
	//for (int sz = 1; sz < n; sz += sz)
	//{
	//	for (int i = 0; i < n - sz; i += sz + sz)
	//	{
	//		// 对 arr[i...i+sz-1] 和 arr[i+sz...i+2*sz-1] 进行归并
	//		__merge(arr, i, i + sz - 1, min(i + sz + sz - 1, n - 1));
	//	}
	//}

	// Merge Sort Bottom Up 优化
	// 对于小数组, 使用插入排序优化
	for (int i = 0; i < n; i += 16)
		insertionSort(arr, i, min(i + 15, n - 1));

	for (int sz = 16; sz < n; sz += sz)
	{
		for (int i = 0; i < n - sz; i += sz + sz)
		{
			// 对于arr[mid] <= arr[mid+1]的情况,不进行merge
			if (arr[i + sz - 1] > arr[i + sz])
				__merge(arr, i, i + sz - 1, min(i + sz + sz - 1, n - 1));
			// Merge Sort BU 也是一个O(nlogn)复杂度的算法，虽然只使用两重for循环
			// 所以，Merge Sort BU也可以在1秒之内轻松处理100万数量级的数据
			// 注意：不要轻易根据循环层数来判断算法的复杂度，Merge Sort BU就是一个反例
			// 关于这部分陷阱，推荐看我的《玩转算法面试》课程，第二章：《面试中的复杂度分析》
		}
	}
}
