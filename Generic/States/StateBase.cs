using System;
using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Generic.States.Interfaces;

namespace ESparrow.Utils.Generic.States
{
    public abstract class StateBase<T> : IState<T>
    {
        protected StateBase(T value = default)
        {
            Value = value;
        }

        protected StateBase(IStateInfo<T> stateInfo)
        {
            Value = stateInfo.Value;
            
            _undoStack = new Stack<T>(stateInfo.UndoStack);
            _redoStack = new Stack<T>(stateInfo.RedoStack);
        }

        public event Action<T> OnValueChanged = _ => { };

        private T _value;

        private readonly Stack<T> _undoStack = new Stack<T>();
        private readonly Stack<T> _redoStack = new Stack<T>();

        protected abstract void OnFailBack();
        protected abstract void OnFailForward();

        public IState<T> Back()
        {
            if (!CanGetBack)
            {
                OnFailBack();
                return this;
            }
            
            _redoStack.Push(Value);
            Value = _undoStack.Pop();
            
            return this;
        }
        
        public IState<T> Forward()
        {
            if (!CanGetForward)
            {
                OnFailForward();
                return this;
            }
            
            _undoStack.Push(Value);
            Value = _redoStack.Pop();
            
            return this;
        }

        public IState<T> Set(T value)
        {
            Value = value;
            _redoStack.Clear();

            return this;
        }

        public IStateInfo<T> CreateStateInfo()
        {
            return new StateInfo<T>(Value, _undoStack, _redoStack);
        }

        public T Value
        {
            get => _value;
            
            private set
            {
                _value = value;
                OnValueChanged.Invoke(_value);
            }
        }

        public bool CanGetBack => _undoStack.Any();
        public bool CanGetForward => _redoStack.Any();
    }
}
