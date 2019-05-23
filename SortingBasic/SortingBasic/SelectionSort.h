#pragma once

using namespace std;

template<typename T>
void selectionSort(T arr[], int n)
{
	/* iterate the list [i, n) to find out the minimum value and move it to the beginning.*/
	for (int i = 0; i < n; i++)
	{
		int minIndex = i;
		for (int j = i + 1; j < n; j++)
		{
			if (arr[j] < arr[minIndex])
				minIndex = j;
		}
		swap(arr[i], arr[minIndex]);
	}
}

