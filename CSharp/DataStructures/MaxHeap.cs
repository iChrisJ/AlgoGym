using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class MaxHeap<T> where T : IComparable
	{
		#region Fields and Properties

		private IList<T> data;

		/// <summary>
		/// Return the length of the heap.
		/// </summary>
		public int Size
		{
			get { return data.Count; }
		}

		/// <summary>
		/// Whether the max heap is empty
		/// </summary>
		public bool IsEmpty
		{
			get { return data.Count == 0; }
		}

		#endregion Fields and Properties

		#region Constructors

		public MaxHeap()
		{
			this.data = new List<T>();
		}

		public MaxHeap(IList<T> list)
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
			ShiftUp(this.Size - 1);
		}

		private void ShiftUp(int index)
		{
			while (index > 0 && data[index].CompareTo(data[(index - 1) / 2]) > 0)
			{
				T temp = data[index];
				data[index] = data[(index - 1) / 2];
				data[(index - 1) / 2] = temp;
				index = (index - 1) / 2;
			}
		}

		public T ExtractMax()
		{
			T max = data[0];
			// 将data中最后一位值放到首位
			data[0] = data[data.Count - 1];
			data.RemoveAt(data.Count - 1);
			ShiftDown(0);

			return max;
		}

		private void ShiftDown(int index)
		{
			while (2 * index + 1 < data.Count)
			{
				int j = 2 * index + 1; // 在此轮循环中,data[index]和data[j]交换位置
				if (j + 1 < data.Count && data[j + 1].CompareTo(data[j]) > 0) // data[j] 是 data[2*index+1]和data[2*index+2]中的最大值
					j += 1;
				if (data[j].CompareTo(data[index]) <= 0)
					break;
				T temp = data[j];
				data[j] = data[index];
				data[index] = temp;
				index = j;
			}
		}
		#endregion Methods

	}
}
