using System;
using System.Collections;
using System.Collections.Generic;
using ESparrow.Utils.Collections.Generic.Interfaces;

namespace ESparrow.Utils.Collections.Generic.Abstractions
{
    public abstract class GuidedStackBase<T> : IStack<T>
    {
        protected GuidedStackBase()
        {   
            
        }

        protected GuidedStackBase(IEnumerable<T> enumerable)
        {
            _stack = new Stack<T>(enumerable);
        }

        private readonly Stack<T> _stack = new Stack<T>();

        public T Peek()
        {
            return _stack.Peek();
        }

        public T Pop()
        {
            return _stack.Pop();
        }

        public void Push(T element)
        {
            _stack.Push(element);
        }
    }
}