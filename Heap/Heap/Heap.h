#pragma once

#include <cassert>
#include <algorithm>
#include <string>
#include <cmath>

using namespace std;

template<typename Item>
class MaxHeap
{
private:
	Item *data;
	int count;
	int capacity;

	void shiftUp(int k)
	{
		while (k > 1 && data[k] > data[k / 2])
		{
			swap(data[k], data[k / 2]);
			k /= 2;
		}
	}

	void shiftDown(int k)
	{
		while (2 * k <= this->count)
		{
			int j = 2 * k; // 在此轮循环中,data[k]和data[j]交换位置

			if (j + 1 <= this->count && data[j] < data[j + 1])
				j++; // data[j] 是 data[2*k]和data[2*k+1]中的最大值

			if (data[k] >= data[j])
				break;

			swap(data[k], data[j]);
			k = j;
		}
	}

public:
	// 构造函数, 构造一个空堆, 可容纳capacity个元素
	MaxHeap(int capactity)
	{
		data = new Item[capacity + 1];
		this->count = 0;
		this->capacity = capactity;
	};

	// 构造函数, 通过一个给定数组创建一个最大堆
	// 该构造堆的过程, 时间复杂度为O(n)
	MaxHeap(Item arr[], int n)
	{
		data = new Item[n + 1];
		capacity = n;

		for (int i = 0; i < n; i++)
			data[i + 1] = arr[i];

		this->count = n;

		for (int i = this->count / 2; i >= 1; i--)
			shiftDown(i);
	}

	~MaxHeap()
	{
		delete[] data;
	};

	// 返回堆中的元素个数
	int size()
	{
		return this->count;
	}

	// 返回一个布尔值, 表示堆中是否为空
	bool isEmpty()
	{
		return this->count == 0;
	}

	// 向最大堆中插入一个新的元素 item
	void insert(Item item)
	{
		assert(this->count + 1 <= this->capacity);
		data[this->count + 1] = item;

		shiftUp(this->count + 1);

		this->count++;
	}

	// 从最大堆中取出堆顶元素, 即堆中所存储的最大数据
	Item extractMax()
	{
		assert(this->count > 0);

		Item ret = data[1];
		swap(data[1], data[this->count]);
		this->count--;

		shiftDown(1);
		return ret;
	}

	// 获取最大堆中的堆顶元素
	Item getMax()
	{
		assert(count > 0);
		return data[1];
	}
};

