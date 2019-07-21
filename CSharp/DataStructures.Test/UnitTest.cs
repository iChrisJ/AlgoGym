using DataStructures.Test;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace DataStructures.Tests
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void MaxHeapTest()
		{
			MaxHeap<int> maxHeap = new MaxHeap<int>();

			for (int i = 0; i < 100000; i++)
				maxHeap.Insert((new Random()).Next(100000));

			List<int> list = new List<int>();

			int length = maxHeap.Size;
			for (int i = 0; i < length; i++)
			{
				list.Add(maxHeap.ExtractMax());
			}

			Assert.IsTrue(Utility.IsInvertedSorted(list), "The list is not sorted desc.");
		}

		[Test]
		public void MaxHeapSortTest()
		{
			List<int> list = Utility.GenerateRandomList(10000000, 0, 10000000);
			MaxHeap<int> maxheap = new MaxHeap<int>(list);

			for (int i = list.Count - 1; i >= 0; i--)
				list[i] = maxheap.ExtractMax();
			Assert.IsTrue(Utility.IsSorted(list), "The list is not sorted.");
		}

		[Test]
		public void MinHeapTest()
		{
			MinHeap<int> minHeap = new MinHeap<int>();

			for (int i = 0; i < 100000; i++)
				minHeap.Insert((new Random()).Next(100000));

			List<int> list = new List<int>();

			int length = minHeap.Size;
			for (int i = 0; i < length; i++)
			{
				list.Add(minHeap.ExtractMin());
			}

			Assert.IsTrue(Utility.IsSorted(list), "The list is not sorted desc.");
		}

		[Test]
		public void MinHeapSortTest()
		{
			List<int> list = Utility.GenerateRandomList(10000000, 0, 10000000);
			MinHeap<int> minHeap = new MinHeap<int>(list);

			for (int i = list.Count - 1; i >= 0; i--)
				list[i] = minHeap.ExtractMin();
			Assert.IsTrue(Utility.IsInvertedSorted(list), "The list is not sorted.");
		}

	}

}