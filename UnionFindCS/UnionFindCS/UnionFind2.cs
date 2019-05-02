using System.Diagnostics;

namespace UF2
{
	class UnionFind
	{
		private int count;
		private int[] parent;

		public UnionFind(int count)
		{
			this.count = count;
			this.parent = new int[this.count];
			for (int i = 0; i < this.count; i++)
				parent[i] = i;
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

			parent[pRoot] = qRoot;
		}
	}
}
