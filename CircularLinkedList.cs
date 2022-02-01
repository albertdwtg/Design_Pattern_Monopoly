using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project_Cohen_Watrigant
{
    public class CircularLinkedList <T>
    {
        public Node<T> head = null;
        public Node<T> tail = null;

        public void Add(T item)
        {
            // if head is null, then this will be the first item
            if (head == null)
            {

                this.AddFirst(item);
            }
            else
            {
                Node<T> newNode = new Node<T>(item);
                tail.next = newNode;
                newNode.next = head;
                newNode.previous = tail;
                tail = newNode;
                head.previous = tail;
            }
            
        }

        void AddFirst(T item)
        {
            head = new Node<T>(item);
            tail = head;
            head.next = tail;
            head.previous = tail;
        }

        public Node<T> Find(Node<T> item)
        {
            Node<T> node = FindNode(head, item);
            return node;
        }

        Node<T> FindNode(Node<T> node, Node<T> nodeToCompare)
        {
            Node<T> result = null;
            if (node.Equals(nodeToCompare))
            {
                result = node;

            }
            else if (result == null && node.next != head)
            {
                result = FindNode(node.next,nodeToCompare);

            }
            return result;
        }
    }
}
