using System;
using System.Collections.Generic;


namespace Algorithms.Test
{
	public class Utility
	{
		public static bool IsSorted(IList<int> collection)
		{
			for (int i = 1; i < collection.Count - 1; i++)
			{
				if (collection[i] < collection[i - 1])
					return false;
			}
			return true;
		}

		public static List<int> GenerateRandomList(int n, int rangeL, int rangeR)
		{
			if (rangeL >= rangeR)
				throw new Exception("Right range must larger than left range.");

			Random rd = new Random();

			List<int> res = new List<int>();
			while (n>0)
			{
				res.Add(rd.Next(rangeL, rangeR));
				n--;
			}
			return res;
		}
	}
}