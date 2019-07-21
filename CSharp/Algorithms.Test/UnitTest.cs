using NUnit.Framework;
using System.Collections.Generic;

namespace Algorithms.Test
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void InsertionSortTest()
		{
			List<int> list = Utility.GenerateRandomList(200000, 0, 200000);

			Sorts.Sorts.InsertionSort(list);
			Assert.IsTrue(Utility.IsSorted(list), "The list is not sorted.");
		}

		[Test]
		public void MergeSortTest()
		{
			List<int> list = Utility.GenerateRandomList(1000000, 0, 1000000);

			Sorts.Sorts.MergeSort(list);
			Assert.IsTrue(Utility.IsSorted(list), "The list is not sorted.");
		}

		[Test]
		public void MergeSortBottomUpTest()
		{
			List<int> list = Utility.GenerateRandomList(1000000, 0, 1000000);

			Sorts.Sorts.MergeSortBottomUp(list);
			Assert.IsTrue(Utility.IsSorted(list), "The list is not sorted.");
		}

		[Test]
		public void QuickSortTest()
		{
			List<int> list = Utility.GenerateRandomList(1000000, 0, 1000000);

			Sorts.Sorts.QuickSort(list);
			Assert.IsTrue(Utility.IsSorted(list), "The list is not sorted.");
		}

		[Test]
		public void QuickSort2WaysTest()
		{
			List<int> list = Utility.GenerateRandomList(1000000, 0, 1000000);

			Sorts.Sorts.QuickSort2Ways(list);
			Assert.IsTrue(Utility.IsSorted(list), "The list is not sorted.");
		}

		[Test]
		public void QuickSort3WaysTest()
		{
			List<int> list = Utility.GenerateRandomList(1000000, 0, 1000000);

			Sorts.Sorts.QuickSort3Ways(list);
			Assert.IsTrue(Utility.IsSorted(list), "The list is not sorted.");
		}

		[Test]
		public void HeapSortTest()
		{
			List<int> list = Utility.GenerateRandomList(10000000, 0, 10000000);

			Sorts.Sorts.HeapSort(list);
			Assert.IsTrue(Utility.IsSorted(list), "The list is not sorted.");
		}
	}
}