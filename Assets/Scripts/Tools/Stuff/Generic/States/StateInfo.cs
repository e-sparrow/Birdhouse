using System.Collections.Generic;
using ESparrow.Utils.Tools.Stuff.Generic.States.Interfaces;

namespace ESparrow.Utils.Tools.Stuff.Generic.States
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
