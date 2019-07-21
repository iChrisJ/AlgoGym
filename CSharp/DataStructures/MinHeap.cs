using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class MinHeap<T> where T : IComparable
	{
		#region Fields and Properties

		private IList<T> data;

		public int Size
		{
			get { return data.Count; }
		}

		public bool IsEmpty
		{
			get { return data.Count == 0; }
		}

		#endregion Fields and Properties

		#region Constructors

		public MinHeap()
		{
			this.data = new List<T>();
		}

		public MinHeap(IList<T> list)
		{
			this.data = new List<T>(list);
			for (int i = (data.Count - 1 - 1) / 2; i >= 0; i--)
				ShiftDown(i);
		}

		#endregion Constructors

		#region Methods

		public void Insert(T item)
		{
			this.data.Add(item);
			ShiftUp(this.data.Count - 1);
		}

		private void ShiftUp(int k)
		{
			while (k - 1 > 0 && data[k].CompareTo(data[(k - 1) / 2]) < 0)
			{
				T temp = data[k];
				data[k] = data[(k - 1) / 2];
				data[(k - 1) / 2] = temp;

				k = (k - 1) / 2;
			}
		}

		public T ExtractMin()
		{
			T min = data[0];
			data[0] = data[data.Count - 1];
			data.RemoveAt(data.Count - 1);
			ShiftDown(0);
			return min;
		}

		private void ShiftDown(int k)
		{
			while (2 * k + 1 < data.Count)
			{
				int j = 2 * k + 1;
				if (j + 1 < data.Count && data[j + 1].CompareTo(data[j]) < 0)
					j++;
				if (data[k].CompareTo(data[j]) <= 0)
					break;
				T temp = data[k];
				data[k] = data[j];
				data[j] = temp;

				k = j;
			}
		}
		#endregion Methods
	}
}
