using System;
using System.Collections.Generic;
using System.Text;

namespace GenericHw
{
    public class Queue<TElement, TPriority> where TPriority : IComparable<TPriority>
    {
        private class Node
        {
            public TElement Element 
            { 
                get;
                set;
            }
            public TPriority Priority 
            {
                get;
                set;
            }
            public Node Next 
            {
                get;
                set;
            }

            public Node(TElement element, TPriority priority)
            {
                Element = element;
                Priority = priority;
                Next = null;
            }
        }

        private Node _head;
        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public void Enqueue(TElement element, TPriority priority)
        {
            Node newNode = new Node(element, priority);

            if (_head == null || priority.CompareTo(_head.Priority) < 0)
            {
                newNode.Next = _head;
                _head = newNode;
            }
            else
            {
                Node current = _head;
                while (current.Next != null && current.Next.Priority.CompareTo(priority) <= 0)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
            }

            Count++;
        }
        public TElement Dequeue()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Черга порожня.");
            }
            TElement element = _head.Element;
            _head = _head.Next;
            Count--;
            return element;
        }
        public TElement Peek()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Черга порожня.");
            }
            return _head.Element;
        }

        public void Clear()
        {
            _head = null;
            Count = 0;
        }
    }
}
