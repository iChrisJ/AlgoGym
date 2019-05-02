using System.Diagnostics;

namespace UF3
{
	class UnionFind
	{
		private int count;
		private int[] parent;
		private int[] sz;

		public UnionFind(int count)
		{
			this.count = count;
			this.parent = new int[this.count];
			this.sz = new int[this.count];
			for (int i = 0; i < this.count; i++)
			{
				parent[i] = i;
				sz[i] = 1;
			}

		}

		public int Find(int p)
		{
			Debug.Assert(p >= 0 && p < this.count);

			while (p != parent[p])
				p = parent[p];

			return p;
		}

		public bool IsConnected(int p, int q)
		{
			return this.Find(p) == this.Find(q);
		}

		public void Union(int p, int q)
		{
			int pRoot = this.Find(p);
			int qRoot = this.Find(q);

			if (pRoot == qRoot)
				return;

			if (sz[pRoot] < sz[qRoot])
			{
				parent[pRoot] = qRoot;
				sz[qRoot] += sz[pRoot];
			}
			else
			{
				parent[qRoot] = pRoot;
				sz[pRoot] += sz[qRoot];
			}

		}
	}
}
