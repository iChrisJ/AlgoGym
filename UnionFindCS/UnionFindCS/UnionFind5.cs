using System.Diagnostics;

namespace UF5
{
	class UnionFind
	{
		private int count;
		private int[] parent;
		private int[] rank;

		public UnionFind(int count)
		{
			this.count = count;
			this.parent = new int[this.count];
			this.rank = new int[this.count];
			for (int i = 0; i < this.count; i++)
			{
				parent[i] = i;
				rank[i] = 1;
			}

		}

		public int Find(int p)
		{
			Debug.Assert(p >= 0 && p < this.count);

			//while (p != parent[p])
			//{
			//	parent[p] = parent[parent[p]];
			//	p = parent[p];
			//}
			//return p;

			if (p != parent[p])
				parent[p] = Find(parent[parent[p]]);
			return parent[p];
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

			if (rank[pRoot] < rank[qRoot])
			{
				parent[pRoot] = qRoot;
			}
			else if (rank[pRoot] > rank[qRoot])
			{
				parent[qRoot] = pRoot;
			}
			else //rank[pRoot] == rank[qRoot]
			{
				parent[pRoot] = qRoot;
				rank[qRoot]++;
			}

		}
	}
}
