#pragma once

#include <iostream>
#include <cassert>

using namespace std;

template<typename Item>
class IndexMaxHeap
{
private:
	Item *data;
	int *indexes;

	int count;
	int capacity;

	void shiftUp(int k)
	{
		while (k > 1 && data[indexes[k]] > data[indexes[k / 2]])
		{
			swap(indexes[k], indexes[k / 2]);
			k /= 2;
		}
	}

	void shiftDown(int k)
	{
		while (2 * k < this->count)
		{
			int j = 2 * k;
			if (j + 1 <= this->count && data[indexes[j + 1]] > data[indexes[j]])
				j++;

			if (data[indexes[j]] > data[indexes[k]])
				swap(indexes[j], indexes[k]);

			k = j;
		}
	}

public:
	IndexMaxHeap(int capacity)
	{
		data = new Item[capacity + 1];
		indexes = new int[capacity + 1];

		this->count = 0;
		this->capacity = capacity;
	}

	~IndexMaxHeap()
	{
		delete[] data;
		delete[] index;
	}

	int size()
	{
		return this->count;
	}

	bool isEmpty()
	{
		return this->count == 0;
	}

	void insert(int i, Item item)
	{
		assert(this->count + 1 <= this->capacity);
		assert(i + 1 >= 1 && i + 1 <= this->capacity);

		i += 1;
		data[i] = item;
		indexes[this->count + 1] = i;
		this->count++;

		shiftUp(this->count);
	}

	Item extractMax()
	{
		assert(this->count > 0);

		Item ret = data[indexes[1]];
		swap(indexes[1], indexes[this->count]);
		this->count--;
		shiftDown(1);
		return ret;
	}

	int extractMaxIndex()
	{
		assert(this->count > 0);

		int ret = indexes[1] + 1;
		swap(indexes[1], indexes[this->count]);
		this->count--;
		shiftDown(1);
		return ret;
	}

	// 获取最大索引堆中的堆顶元素
	Item getMax() {
		assert(count > 0);
		return data[indexes[1]];
	}

	// 获取最大索引堆中的堆顶元素的索引
	int getMaxIndex() {
		assert(count > 0);
		return indexes[1] - 1;
	}

	Item getItem(int i)
	{
		assert(i + 1 >= 1 && i + 1 <= this->capacity);
		return data[i + 1];
	}

	void change(int i, Item newItem)
	{
		assert(i + 1 >= 1 && i + 1 <= this->capacity);
		i += 1;
		data[i] = newItem;

		for (int j = 1; j < this->count; j++)
		{
			if (indexes[j] == i)
			{
				shiftUp(j);
				shiftDown(j);
				return;
			}
		}
	}
};