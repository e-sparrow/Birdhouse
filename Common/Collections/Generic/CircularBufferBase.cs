using System;
using Birdhouse.Common.Collections.Generic.Interfaces;

namespace Birdhouse.Common.Collections.Generic
{
    public abstract class CircularBufferBase<T> : ICircularBuffer<T>
    {
        protected CircularBufferBase(int bufferSize)
        {
            _buffer = new T[bufferSize];
            _bufferSize = bufferSize;
            _head = bufferSize - 1;
        }

        private readonly T[] _buffer;
        private readonly int _bufferSize;
        
        private int _head;
        private int _tail;
        private int _length;

        private readonly object _lock = new object();
        
        public void Enqueue(T value)
        {
            lock (_lock)
            {
                _head = NextPosition(_head);
                _buffer[_head] = value;
                
                if (IsFull)
                {
                    _tail = NextPosition(_tail);
                }
                else
                {
                    _length++;
                }
            }
        }

        public T Dequeue()
        {
            lock (_lock)
            {
                if (IsEmpty)
                {
                    throw new InvalidOperationException("Queue exhausted");
                }
 
                var dequeued = _buffer[_tail];
                
                _tail = NextPosition(_tail);
                _length--;
                
                return dequeued;
            }
        }
 
        private int NextPosition(int position)
        {
            return (position + 1) % _bufferSize;
        }

        public bool IsEmpty => _length == 0;
        public bool IsFull => _length == _bufferSize;
    }
}
