using System.Collections.Generic;
using Birdhouse.Common.Generic.States.Interfaces;

namespace Birdhouse.Common.Generic.States
{
    public readonly struct StateInfo<T> : IStateInfo<T>
    {
        public StateInfo(T value, IEnumerable<T> undoStack, IEnumerable<T> redoStack)
        {
            Value = value;
            
            UndoStack = undoStack;
            RedoStack = redoStack;
        }

        public T Value
        {
            get;
        }

        public IEnumerable<T> UndoStack
        {
            get;
        }

        public IEnumerable<T> RedoStack
        {
            get;
        }
    }
}
