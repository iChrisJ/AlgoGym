using System;

namespace UnionFindCS
{
	class Program
	{
		static void Main(string[] args)
		{
			int count = 5000000;
			//UnionFindTestHelper.UnionFindTestHelper.TestUF1(count);
			//UnionFindTestHelper.UnionFindTestHelper.TestUF2(count);
			UnionFindTestHelper.UnionFindTestHelper.TestUF3(count);
			UnionFindTestHelper.UnionFindTestHelper.TestUF4(count);
			UnionFindTestHelper.UnionFindTestHelper.TestUF5(count);

			Console.ReadKey();
		}
	}
}
