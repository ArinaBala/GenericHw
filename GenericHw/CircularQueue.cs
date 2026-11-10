using System;
using System.Collections.Generic;
using System.Text;

namespace GenericHw
{
    public class CircularQueue<T>
    {
        private readonly T[] _buffer;
        private int _head;
        private int _tail;

        public int Capacity 
        {
            get;
        }
        public int Count 
        {
            get;
            private set;
        }

        public bool IsEmpty => Count == 0;
        public bool IsFull => Count == Capacity;

        public CircularQueue(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Резервована ємність має бути більше 0.", nameof(capacity));

            Capacity = capacity;
            _buffer = new T[capacity];
            _head = 0;
            _tail = 0;
            Count = 0;
        }
        public void Enqueue(T item)
        {
            if (IsFull)
                throw new InvalidOperationException("Кільцева черга заповнена.");

            _buffer[_tail] = item;
            _tail = (_tail + 1) % Capacity;
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Кільцева черга порожня.");

            T item = _buffer[_head];
            _buffer[_head] = default;
            _head = (_head + 1) % Capacity;
            Count--;
            return item;
        }
        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Кільцева черга порожня.");

            return _buffer[_head];
        }

        public void Clear()
        {
            Array.Clear(_buffer, 0, Capacity);
            _head = 0;
            _tail = 0;
            Count = 0;
        }
    }
}
