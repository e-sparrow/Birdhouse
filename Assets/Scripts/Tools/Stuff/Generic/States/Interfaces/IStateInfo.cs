using System.Collections.Generic;

namespace ESparrow.Utils.Tools.Stuff.Generic.States.Interfaces
{
    public interface IStateInfo<out T>
    {
        /// <summary>
        /// Current value of the state.
        /// </summary>
        T Value
        {
            get;
        }
        
        /// <summary>
        /// Undo stack of the state to use "Back" method.
        /// </summary>
        IEnumerable<T> UndoStack
        {
            get;
        }

        /// <summary>
        /// Redo stack of the state to use "Forward" method.
        /// </summary>
        IEnumerable<T> RedoStack
        {
            get;
        }
    }
}
