using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
	public class IndexMaxHeap<T> where T: IComparable
	{
		#region Fields and Properties

		private IList<T> data;
		private IList<int> indexes;

		/// <summary>
		/// Return the length of the heap.
		/// </summary>
		public int Size
		{
			get { return indexes.Count; }
		}

		/// <summary>
		/// Whether the max heap is empty
		/// </summary>
		public bool IsEmpty
		{
			get { return indexes.Count == 0; }
		}

		#endregion Fields and Properties

		#region Constructors

		public IndexMaxHeap()
		{
			this.data = new List<T>();
			this.indexes = new List<int>();
		}

		public IndexMaxHeap(IList<T> list)
		{
			this.data = new List<T>(list);

			for (int i = (data.Count - 2) / 2; i >= 0; i--)
				ShiftDown(i);
		}

		#endregion Constructors

		#region Methods

		public void Insert(T item)
		{
			this.data.Add(item);
			this.indexes.Add(this.data.Count - 1);
			ShiftUp(this.indexes.Count - 1);
		}

		private void ShiftUp(int k)
		{
			while (k > 0 && data[indexes[k]].CompareTo(data[indexes[(k - 1) / 2]]) > 0)
			{
				int temp = indexes[k];
				indexes[k] = indexes[(k - 1) / 2];
				indexes[(k - 1) / 2] = temp;
				k = (k - 1) / 2;
			}
		}

		public T ExtractMax()
		{
			T max = data[indexes[0]];
			// 将data中最后一位值放到首位
			indexes[0] = indexes[indexes.Count - 1];
			indexes.RemoveAt(indexes.Count - 1);
			ShiftDown(0);

			return max;
		}

		private void ShiftDown(int k)
		{
			while (2 * k + 1 < indexes.Count)
			{
				int j = 2 * k + 1; // 在此轮循环中,data[index]和data[j]交换位置
				if (j + 1 < indexes.Count && data[indexes[j + 1]].CompareTo(data[indexes[j]]) > 0) // data[j] 是 data[2*index+1]和data[2*index+2]中的最大值
					j += 1;
				if (data[indexes[j]].CompareTo(data[indexes[k]]) <= 0)
					break;
				int temp = indexes[j];
				indexes[j] = indexes[k];
				indexes[k] = temp;
				k = j;
			}
		}
		#endregion Methods
	}
}
