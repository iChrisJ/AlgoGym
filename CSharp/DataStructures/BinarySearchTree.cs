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
			Node node = Search(root, key);
			return node == null ? default(V) : node.Value;
		}

		private Node Search(Node node, K key)
		{
			if (node == null)
				return null;

			if (key.CompareTo(node.Key) == 0)
				return node;
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

		/// <summary>
		/// 寻找key的floor值, 递归算法
		/// 如果不存在key的floor值(key比BST中的最小值还小), 返回default value
		/// </summary>
		public K Floor(K key)
		{
			if (Count == 0 || key.CompareTo(Minimun()) < 0)
				return default(K);

			Node floorNode = Floor(root, key);
			return floorNode == null ? default(K) : floorNode.Key;
		}

		/// <summary>
		/// 在以node为根的二叉搜索树中, 寻找key的floor值所处的节点, 递归算法
		/// </summary>
		private Node Floor(Node node, K key)
		{
			if (node == null)
				return null;

			// 如果node的key值和要寻找的key值相等, 则node本身就是key的floor节点.
			if (key.CompareTo(node.Key) == 0)
				return node;

			// 如果node.Key > key, 则要寻找的key的floor节点一定在node的左子树中
			if (key.CompareTo(node.Key) < 0)
				return Floor(node.Left, key);

			// 如果node.Key < key
			// 则node有可能是key的floor节点, 也有可能不是(存在比node->key大但是小于key的其余节点)
			// 需要尝试向node的右子树寻找一下
			Node tempNode = Floor(node.Right, key);
			if (tempNode != null)
				return tempNode;

			return node;
		}

		/// <summary>
		/// 寻找key的ceil值, 递归算法
		/// 如果不存在key的ceil值(key比BST中的最大值还大), 返回default value.
		/// </summary>
		public K Ceil(K key)
		{
			if (Count == 0 || key.CompareTo(Maximum()) > 0)
				return default(K);

			Node ceilNode = Ceil(root, key);
			return ceilNode == null ? default(K) : ceilNode.Key;
		}

		/// <summary>
		/// 在以node为根的二叉搜索树中, 寻找key的ceil值所处的节点, 递归算法
		/// </summary>
		private Node Ceil(Node node, K key)
		{
			if (node == null)
				return null;

			// 如果node的key值和要寻找的key值相等, 则node本身就是key的ceil节点
			if (key.CompareTo(node.Key) == 0)
				return node;

			// 如果node的key值比要寻找的key值小
			// 则要寻找的key的ceil节点一定在node的右子树中
			if (key.CompareTo(node.Key) > 0)
				return Ceil(node.Right, key);

			// 如果node->key > key
			// 则node有可能是key的ceil节点, 也有可能不是(存在比node->key小但是大于key的其余节点)
			// 需要尝试向node的左子树寻找一下
			Node tempNode = Ceil(node.Left, key);
			if (tempNode != null)
				return tempNode;

			return node;
		}

		/// <summary>
		/// 查找key的前驱
		/// 如果不存在key的前驱(key不存在, 或者key是整棵二叉树中的最小值), 则返回NULL
		/// </summary>
		public K Predecessor(K key)
		{
			Node node = Search(root, key);

			if (node == null)
				return default(K);

			if (node.Left != null)
				return Maximum(node.Left).Key;

			Node preNode = PredecessorFromAncestor(root, key);

			return preNode == null ? default(K) : preNode.Key;
		}

		/// <summary>
		/// 在以node为根的二叉搜索树中, 寻找key的祖先中,比key小的最大值所在节点, 递归算法
		/// 向下搜索到的结果直接返回
		/// </summary>
		private Node PredecessorFromAncestor(Node node, K key)
		{
			if (node == null || key.CompareTo(node.Key) == 0)
				return null;

			if (key.CompareTo(node.Key) < 0)
				// 如果当前节点大于key, 则当前节点不可能是比key小的最大值
				// 向下搜索到的结果直接返回
				return PredecessorFromAncestor(node.Left, key);
			else
			{
				// 如果当前节点小于key, 则当前节点有可能是比key小的最大值
				// 向右继续搜索, 将结果存储到tempNode中
				Node tempNode = PredecessorFromAncestor(node.Right, key);
				return tempNode == null ? node : tempNode; // 如果tempNode为空, 则当前节点即为结果
			}

		}

		/// <summary>
		/// 查找key的后继, 递归算法
		/// 如果不存在key的后继(key不存在, 或者key是整棵二叉树中的最大值), 则返回NULL
		/// </summary>
		public K Successor(K key)
		{
			Node node = Search(root, key);

			if (node == null)
				return default(K);

			// 如果key所在的节点右子树不为空,则其右子树的最小值为key的后继
			if (node.Right != null)
				return Minimun(node.Right).Key;

			// 否则, key的后继在从根节点到key的路径上, 在这个路径上寻找到比key大的最小值, 即为key的后继
			Node sucNode = SuccessorFromAncestor(root, key);
			return sucNode == null ? default(K) : sucNode.Key;
		}

		/// <summary>
		/// 在以node为根的二叉搜索树中, 寻找key的祖先中,比key大的最小值所在节点, 递归算法
		/// 算法调用前已保证key存在在以node为根的二叉树中
		/// </summary>
		private Node SuccessorFromAncestor(Node node, K key)
		{
			if (node == null || key.CompareTo(node.Key) == 0)
				return null;

			if (key.CompareTo(node.Key) > 0)
				// 如果当前节点小于key, 则当前节点不可能是比key大的最小值
				// 向下搜索到的结果直接返回
				return SuccessorFromAncestor(node.Right, key);
			else
			{
				// 如果当前节点大于key, 则当前节点有可能是比key大的最小值
				// 向左继续搜索, 将结果存储到tempNode中
				Node tempNode = SuccessorFromAncestor(node.Left, key);
				return tempNode == null ? node : tempNode;
			}
		}
		#endregion Methods
	}
}
