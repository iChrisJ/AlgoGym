using System.Diagnostics;

namespace UF1
{
	class UnionFind
	{
		private int count;
		private int[] id;

		public UnionFind(int count)
		{
			this.count = count;
			this.id = new int[this.count];
			for (int i = 0; i < this.count; i++)
				id[i] = i;
		}

		public int Find(int p)
		{
			Debug.Assert(p >= 0 && p < this.count);
			return id[p];
		}

		public bool IsConnected(int p, int q)
		{
			return this.Find(p) == this.Find(q);
		}

		public void Union(int p, int q)
		{
			int pID = this.Find(p);
			int qID = this.Find(q);

			if (pID == qID)
				return;

			for (int i = 0; i < this.count; i++)
				if (id[i] == pID)
					id[i] = qID;
		}
	}
}
