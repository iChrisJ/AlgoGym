using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class BinarySearchTree<K, V> where K : IComparable where V : IComparable
	{
		#region Node Class

		private class Node
		{
			public K Key { get; set; }
			public V Value { get; set; }
			public Node Left { get; set; }
			public Node Right { get; set; }

			public Node(K key, V value)
			{
				this.Key = key;
				this.Value = value;
				this.Left = this.Right = null;
			}

			public Node(Node node)
			{
				this.Key = node.Key;
				this.Value = node.Value;
				this.Left = node.Left;
				this.Right = node.Right;
			}
		}

		#endregion Node Class

		#region Fields and Properties

		private Node root;

		public int Count { get; private set; }

		public bool IsEmpty
		{
			get { return Count == 0; }
		}

		#endregion Fields and Properties

		#region Constructors

		public BinarySearchTree()
		{
			this.root = null;
			this.Count = 0;
		}

		#endregion Constructors

		#region Methods

		/// <summary>
		/// 向二分搜索树中插入一个新的(key, value)键值对
		/// </summary>
		/// <param name="key">Key</param>
		/// <param name="value">Value</param>
		public void Insert(K key, V value)
		{
			this.root = Insert(root, key, value);
		}

		private Node Insert(Node node, K key, V value)
		{
			if (node == null)
			{
				Count++;
				return new Node(key, value);
			}

			if (key.CompareTo(node.Key) == 0)
				node.Value = value;
			else if (key.CompareTo(node.Key) < 0)
				node.Left = Insert(node.Left, key, value);
			else // key > root.key
				node.Right = Insert(node.Right, key, value);
			return node;
		}

		/// <summary>
		/// 查看二分搜索树中是否存在键key
		/// </summary>
		/// <param name="key"></param>
		/// <returns>True if it contains</returns>
		public bool Contains(K key)
		{
			return Contains(root, key);
		}

		private bool Contains(Node node, K key)
		{
			if (node == null)
				return false;

			if (key.CompareTo(node.Key) == 0)
				return true;
			else if (key.CompareTo(node.Key) < 0)
				return Contains(node.Left, key);
			else
				return Contains(node.Right, key);
		}

		/// <summary>
		/// 在二分搜索树中搜索键key所对应的值。如果这个值不存在, 则返回defaule值
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public V Search(K key)
		{
			return Search(root, key);
		}

		private V Search(Node node, K key)
		{
			if (node == null)
				return default(V);

			if (key.CompareTo(node.Key) == 0)
				return node.Value;
			else if (key.CompareTo(node.Key) < 0)
				return Search(node.Left, key);
			else
				return Search(node.Right, key);
		}

		/// <summary>
		/// 二分搜索树的深度优先遍历
		/// 前序遍历：先访问当前节点，再依次递归访问左右子树
		/// 中序遍历：先递归访问左子树，再访问自身，再递归访问右子树
		/// 后序遍历：先递归访问左右子树，再访问自身节点
		/// </summary>

		/// <summary>
		/// 前序遍历
		/// </summary>
		public void PreOrder()
		{
			PreOrder(root);
		}

		private void PreOrder(Node node)
		{
			if (node == null)
				return;

			Console.WriteLine($"Key: {node.Key}, Value: {node.Value}");
			PreOrder(node.Left);
			PreOrder(node.Right);
		}

		/// <summary>
		/// 中序遍历
		/// </summary>
		public void InOrder()
		{
			InOrder(root);
		}

		private void InOrder(Node node)
		{
			if (node == null)
				return;

			InOrder(node.Left);
			Console.WriteLine($"Key: {node.Key}, Value: {node.Value}");
			InOrder(node.Right);
		}

		/// <summary>
		/// 后序遍历
		/// </summary>
		public void PostOrder()
		{
			PostOrder(root);
		}

		private void PostOrder(Node node)
		{
			if (node == null)
				return;

			PostOrder(node.Left);
			PostOrder(node.Right);
			Console.WriteLine($"Key: {node.Key}, Value: {node.Value}");
		}

		/// <summary>
		/// 二分搜索树的广度优先遍历
		/// 层级遍历
		/// </summary>
		public void LevelOrder()
		{
			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(root);

			while (queue.Count != 0)
			{
				Node node = queue.Dequeue();

				Console.WriteLine($"Key: {node.Key}, Value: {node.Value}");

				if (node.Left != null)
					queue.Enqueue(node.Left);
				if (node.Right != null)
					queue.Enqueue(node.Right);
			}
		}

		/// <summary>
		/// 寻找二分搜索树的最小的键值
		/// </summary>
		public K Minimun()
		{
			if (root == null)
				throw new Exception("Root node is null, no minimun key.");
			Node minNode = Minimun(root);
			return minNode.Key;
		}

		private Node Minimun(Node node)
		{
			if (node.Left == null)
				return node;
			return Minimun(node.Left);
		}

		/// <summary>
		/// 寻找二分搜索树的最大的键值
		/// </summary>
		public K Maximum()
		{
			if (root == null)
				throw new Exception("Root node is null, no maximum key.");
			Node maxNode = Maximum(root);
			return maxNode.Key;
		}

		private Node Maximum(Node node)
		{
			if (node.Right == null)
				return node;
			return Maximum(node);
		}

		private Node RemoveMin(Node node)
		{
			if (node.Left == null)
			{
				Node right = node.Right;
				Count--;
				return right;
			}

			node.Left = RemoveMin(node.Left);
			return node;
		}

		private Node RemoveMax(Node node)
		{
			if (node.Right == null)
			{
				Node left = node.Left;
				Count--;
				return left;
			}
			node.Right = RemoveMax(node.Right);
			return node;
		}

		public K Remove(K key)
		{
			Node r = Remove(root, key);
			return r == null ? default(K) : r.Key;
		}

		/// <summary>
		/// 删除掉以node为根的二分搜索树中键值为key的节点, 递归算法
		/// 返回删除节点后新的二分搜索树的根
		/// </summary>
		private Node Remove(Node node, K key)
		{
			if (node == null)
				return null;

			if (key.CompareTo(node.Key) < 0)
			{
				node.Left = Remove(node.Left, key);
				return node;
			}
			else if (key.CompareTo(node.Key) > 0)
			{
				node.Right = Remove(node.Right, key);
				return node;
			}
			else // key == node.key
			{
				// 待删除节点左子树为空的情况
				if (node.Left == null)
				{
					Node right = node.Right;
					Count--;
					return right;
				}

				// 待删除节点右子树为空的情况
				if (node.Right == null)
				{
					Node left = node.Left;
					Count--;
					return left;
				}

				// 待删除节点左右子树均不为空的情况
				// 找到比待删除节点大的最小节点, 即待删除节点右子树的最小节点
				// 用这个节点顶替待删除节点的位置
				Node successor = new Node(Minimun(node.Right));
				successor.Right = RemoveMin(node.Right);
				successor.Left = node.Left;

				return successor;
			}
		}
		#endregion Methods
	}
}
