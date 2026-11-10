using System;
using System.Collections.Generic;
using System.Text;

namespace GenericHw
{
    public class LinkedList<T>
    {
        private class Node
        {
            public T Data 
            {
                get; 
                set;
            }
            public Node Next 
            {
                get;
                set;
            }

            public Node(T data)
            {
                Data = data;
                Next = null;
            }
        }

        private Node _head;
        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public void Add(T data)
        {
            Node newNode = new Node(data);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            Count++;
        }

        public void AddFirst(T data)
        {
            Node newNode = new Node(data) { Next = _head };
            _head = newNode;
            Count++;
        }
        public bool Remove(T data)
        {
            if (IsEmpty) return false;

            if (Equals(_head.Data, data))
            {
                _head = _head.Next;
                Count--;
                return true;
            }

            Node current = _head;
            while (current.Next != null && !Equals(current.Next.Data, data))
            {
                current = current.Next;
            }

            if (current.Next != null)
            {
                current.Next = current.Next.Next;
                Count--;
                return true;
            }

            return false;
        }
        public bool Contains(T data)
        {
            Node current = _head;
            while (current != null)
            {
                if (Equals(current.Data, data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public void Print()
        {
            Node current = _head;
            while (current != null)
            {
                Console.Write($"{current.Data} -> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
    }
}
