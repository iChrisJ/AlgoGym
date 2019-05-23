#pragma once

#include <iostream>

using namespace std;

template<typename T>
void bubbleSort(T arr[], int n)
{
	// 相邻的两个元素比较，如果前者比后者大，交换元素。没完成一轮循环，最后的都是有序的最大的元素。
	for (int i = 0; i < n - 1; i++)
	{
		for (int j = 0; j < n - i - 1; j++)
		{
			if (arr[j] > arr[j + 1])
				swap(arr[j], arr[j + 1]);
		}
	}
}