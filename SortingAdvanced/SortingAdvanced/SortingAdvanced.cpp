// SortingAdvanced.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <cassert>
#include "SortTestHelper.h"
#include "InsertionSort.h"
#include "MergeSort.h"
#include "MergeSortBU.h"
#include "QuickSort.h"
#include "QuickSort3Ways.h"
#include "MergeSort2.h"

int main()
{
	int n = 1000000;

	// 测试1 一般性测试
	cout << "Test for random array, size = " << n << ", random range [0, " << n << "]" << endl;
	int* arr1 = SortTestHelper::generateRandomArray(n, 0, n);
	int* arr2 = SortTestHelper::copyIntArray(arr1, n);
	int* arr3 = SortTestHelper::copyIntArray(arr1, n);
	int* arr4 = SortTestHelper::copyIntArray(arr1, n);
	int* arr5 = SortTestHelper::copyIntArray(arr1, n);

	//SortTestHelper::testSort("Insertion Sort", insertionSort, arr1, n);
	SortTestHelper::testSort("Merge Sort", mergeSort, arr2, n);
	SortTestHelper::testSort("Merge Sort 2", mergeSort2, arr3, n);
	//SortTestHelper::testSort("Merge Sort Buttom Up", mergeSortBU, arr3, n);
	//SortTestHelper::testSort("Quick Sort", quickSort, arr4, n);
	//SortTestHelper::testSort("Quick Sort 3 Ways", quickSort3Ways, arr5, n);

	delete[] arr1;
	delete[] arr2;
	delete[] arr3;
	delete[] arr4;
	delete[] arr5;

	cout << endl;

	// 测试2 测试近乎有序的数组
	// 对于近乎有序的数组, 数组越有序, InsertionSort的时间性能越趋近于O(n)
	// 所以可以尝试, 当swapTimes比较大时, MergeSort更快
	// 但是当swapTimes小到一定程度, InsertionSort变得比MergeSort快
	int swapTimes = 100;
	assert(swapTimes >= 0);

	cout << "Test for nearly ordered array, size = " << n << ", swap time = " << swapTimes << endl;
	arr1 = SortTestHelper::generateNearlyOrderedArray(n, swapTimes);
	arr2 = SortTestHelper::copyIntArray(arr1, n);
	arr3 = SortTestHelper::copyIntArray(arr1, n);
	arr4 = SortTestHelper::copyIntArray(arr1, n);

	//SortTestHelper::testSort("Insertion Sort", insertionSort, arr1, n);
	SortTestHelper::testSort("Merge Sort", mergeSort, arr2, n);
	SortTestHelper::testSort("Quick Sort", quickSort, arr3, n);
	SortTestHelper::testSort("Quick Sort 3 Ways", quickSort3Ways, arr4, n);

	delete[] arr1;
	delete[] arr2;
	delete[] arr3;
	delete[] arr4;

	// 测试3 测试存在包含大量相同元素的数组
	cout << "Test for random array, size = " << n << ", random range [0,10]" << endl;
	arr1 = SortTestHelper::generateRandomArray(n, 0, 10);
	arr2 = SortTestHelper::copyIntArray(arr1, n);
	arr3 = SortTestHelper::copyIntArray(arr1, n);

	SortTestHelper::testSort("Merge Sort", mergeSort, arr1, n);
	SortTestHelper::testSort("Quick Sort", quickSort, arr2, n);
	SortTestHelper::testSort("Quick Sort 3 Ways", quickSort3Ways, arr3, n);

	delete[] arr1;
	delete[] arr2;
	delete[] arr3;
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
