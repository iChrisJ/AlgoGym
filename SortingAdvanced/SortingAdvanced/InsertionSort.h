#pragma once

#include <iostream>

using namespace std;

template<typename T>
void insertionSort(T arr[], int n)
{
	// 假设以i为界将数组分为两部分,[0, i)是已排好序的，将arr[i]插入[0, i)中合适的位置使[0, i]任然有序 
	for (int i = 1; i < n; i++)
	{
		int temp = arr[i];
		int j;
		for (j = i; j >= 0 && temp < arr[j - 1]; j--)
			arr[j] = arr[j - 1];
		arr[j] = temp;

		/*for (int j = i; j > 0 && arr[j] < arr[j - 1]; j--)
			swap(arr[j], arr[j - 1]);*/
	}
}

template<typename T>
void insertionSort(T arr[], int l, int r)
{
	for (int i = l + 1; i <= r; i++)
	{
		int temp = arr[i];
		int j;
		for (j = i; j > l && temp < arr[j - 1]; j--)
			arr[j] = arr[j - 1];
		arr[j] = temp;
	}
}
