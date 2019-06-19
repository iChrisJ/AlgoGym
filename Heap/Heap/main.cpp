// Heap.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "pch.h"
#include <iostream>
#include <cmath>
#include <cassert>
#include <ctime>
#include <string>
#include "Heap.h"
#include "SortTestHelper.h"


int main()
{
	MaxHeap<int> maxheap = MaxHeap<int>(2);

	srand(time(NULL));
	int n = 2; // 随机生成n个元素放入最大堆中
	for (int i = 0; i < n; i++) {
		maxheap.insert(rand() % 100);
	}

	int* arr = new int[n];
	// 将maxheap中的数据逐渐使用extractMax取出来
	// 取出来的顺序应该是按照从大到小的顺序取出来的
	for (int i = 0; i < n; i++) {
		arr[i] = maxheap.extractMax();
		cout << arr[i] << " ";
	}
	cout << endl;

	// 确保arr数组是从大到小排列的
	for (int i = 1; i < n; i++)
	{
		if (arr[i - 1] < arr[i])
		{
			cout << "abc";
		}
	}

	delete[] arr;


	return 0;
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
