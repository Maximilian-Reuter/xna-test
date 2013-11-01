using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TestGame1
{
	public class Node
	{

		public int X { get; private set; }

		public int Y { get; private set; }

		public int Z { get; private set; }

		public Node (int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public enum NodeState
		{
			NONE,
			SELECTED
		}
		;

		public NodeState State { get; set; }

		public static int Scale { get; set; }

		public static Node operator + (Node a, Node b)
		{
			return new Node (a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}

		public Vector3 Vector ()
		{
			return new Vector3 (X * Scale, Y * Scale, Z * Scale);
		}
	}

	public class NodeList
	{
		private List<Node> list = new List<Node> ();

		public Node this [int i] {
			get {
				if (i >= 0 && i < list.Count)
					return list [i];
				else if (i == list.Count)
					return list [0];
				else
					throw new ArgumentOutOfRangeException ();
			}
			set {
				if (i >= 0 && i < list.Count) {
					list [i] = value;
				}
			}
		}

		public int Count {
			get {
				return list.Count;
			}
		}

		public void Add (Node node)
		{
			list.Add (node);
		}
	}

	public class Lines
	{
		private NodeList Nodes;

		public Lines (NodeList nodes)
		{
			Nodes = nodes;
		}

		public int Count {
			get {
				if (Nodes.Count >= 2)
					return Nodes.Count;
				else
					return 0;
			}
		}
	}
}

