using System;
using System.Collections.Generic;
using System.Text;

namespace GenericHw
{
    public class DoubleLinkedList<T>
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
            public Node Previous 
            {
                get;
                set;
            }

            public Node(T data)
            {
                Data = data;
                Next = null;
                Previous = null;
            }
        }

        private Node _head;
        private Node _tail;

        public int Count 
        {
            get;
            private set; 
        }
        public bool IsEmpty => Count == 0;

        
        public void AddLast(T data)
        {
            Node newNode = new Node(data);

            if (IsEmpty)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Previous = _tail;
                _tail = newNode;
            }
            Count++;
        }
        public void AddFirst(T data)
        {
            Node newNode = new Node(data);

            if (IsEmpty)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                newNode.Next = _head;
                _head.Previous = newNode;
                _head = newNode;
            }
            Count++;
        }
        public bool Remove(T data)
        {
            Node current = _head;

            while (current != null)
            {
                if (Equals(current.Data, data))
                {
                    if (current.Previous != null)
                        current.Previous.Next = current.Next;
                    else
                        _head = current.Next;

                    if (current.Next != null)
                        current.Next.Previous = current.Previous;
                    else
                        _tail = current.Previous;

                    Count--;
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public void PrintForward()
        {
            Node current = _head;
            Console.Write("Прямий обхід: ");
            while (current != null)
            {
                Console.Write($"{current.Data} <-> ");
                current = current.Next;
            }
            Console.WriteLine("null");
        }
        public void PrintBackward()
        {
            Node current = _tail;
            Console.Write("Зворотний обхід: ");
            while (current != null)
            {
                Console.Write($"{current.Data} <-> ");
                current = current.Previous;
            }
            Console.WriteLine("null");
        }
    }
}
