using System;

namespace UnionFindTestHelper
{
	public static class UnionFindTestHelper
	{
		public static void TestUF1(int count)
		{
			Random random = new Random();
			UF1.UnionFind uf = new UF1.UnionFind(count);
			DateTime startTime = DateTime.Now;
			for (int i = 0; i < count; i++)
			{
				int a = random.Next(0, count);
				int b = random.Next(0, count);
				uf.Union(a, b);
			}

			for (int i = 0; i < count; i++)
			{
				int a = random.Next(0, count);
				int b = random.Next(0, count);
				uf.IsConnected(a, b);
			}
			DateTime endTime = DateTime.Now;

			Console.WriteLine($"UF1, {2 * count} ops, {endTime - startTime}.");
		}

		public static void TestUF2(int count)
		{
			Random random = new Random();
			UF2.UnionFind uf = new UF2.UnionFind(count);
			DateTime startTime = DateTime.Now;
			for (int i = 0; i < count; i++)
			{
				int a = random.Next(0, count);
				int b = random.Next(0, count);
				uf.Union(a, b);
			}

			for (int i = 0; i < count; i++)
			{
				int a = random.Next(0, count);
				int b = random.Next(0, count);
				uf.IsConnected(a, b);
			}
			DateTime endTime = DateTime.Now;

			Console.WriteLine($"UF2, {2 * count} ops, {endTime - startTime}.");
		}

		public static void TestUF3(int count)
		{
			Random random = new Random();
			UF3.UnionFind uf = new UF3.UnionFind(count);
			DateTime startTime = DateTime.Now;
			for (int i = 0; i < count; i++)
			{
				int a = random.Next(0, count);
				int b = random.Next(0, count);
				uf.Union(a, b);
			}

			for (int i = 0; i < count; i++)
			{
				int a = random.Next(0, count);
				int b = random.Next(0, count);
				uf.IsConnected(a, b);
			}
			DateTime endTime = DateTime.Now;

			Console.WriteLine($"UF3, {2 * count} ops, {endTime - startTime}.");
		}

		public static void TestUF4(int count)
		{
			Random random = new Random();
			UF4.UnionFind uf = new UF4.UnionFind(count);
			DateTime startTime = DateTime.Now;
			for (int i = 0; i < count; i++)
			{
				int a = random.Next(0, count);
				int b = random.Next(0, count);
				uf.Union(a, b);
			}

			for (int i = 0; i < count; i++)
			{
				int a = random.Next(0, count);
				int b = random.Next(0, count);
				uf.IsConnected(a, b);
			}
			DateTime endTime = DateTime.Now;

			Console.WriteLine($"UF4, {2 * count} ops, {endTime - startTime}.");
		}

		public static void TestUF5(int count)
		{
			Random random = new Random();
			UF5.UnionFind uf = new UF5.UnionFind(count);
			DateTime startTime = DateTime.Now;
			for (int i = 0; i < count; i++)
			{
				int a = random.Next(0, count);
				int b = random.Next(0, count);
				uf.Union(a, b);
			}

			for (int i = 0; i < count; i++)
			{
				int a = random.Next(0, count);
				int b = random.Next(0, count);
				uf.IsConnected(a, b);
			}
			DateTime endTime = DateTime.Now;

			Console.WriteLine($"UF5, {2 * count} ops, {endTime - startTime}.");
		}
	}
}
