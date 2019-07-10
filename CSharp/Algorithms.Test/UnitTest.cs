using NUnit.Framework;
using System.Collections.Generic;
using Algorithms.Sorts;

namespace Algorithms.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void QuickSortTest()
        {
            List<int> list = new List<int>(new int[10]{3,5,9,8,4,7,1,2,6,0});
            
            Sorts.Sorts.QuickSort(list);
            Assert.IsTrue(Utility.IsSorted(list), "The list is not sorted.");
        }
    }
}