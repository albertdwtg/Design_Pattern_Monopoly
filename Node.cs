using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
	public class Node<T> : IEquatable<Node<T>>
	{
		public T data { get; set; }
		public Node<T> next { get; set; }
		public Node<T> previous { get; set; }

		public Node(T val)
		{
			data = val;
			next = null;
		}

		public override bool Equals(object o)
		{
			return Equals(o as Node<T>);
		}

		public bool Equals(Node<T> other)
		{
			return this.GetHashCode() == other.GetHashCode();
		}

		public override int GetHashCode()
		{
			return data.GetHashCode();
		}

		
	}
}
