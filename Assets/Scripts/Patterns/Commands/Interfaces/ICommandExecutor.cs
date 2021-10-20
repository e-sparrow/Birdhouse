using System;

namespace ESparrow.Utils.Patterns.Commands.Interfaces
{
    public interface ICommandExecutor<in TCommand, TDelegate> where TCommand : ICommand<TDelegate> where TDelegate : Delegate
    {
        /// <summary>
        /// What to do if undo stack invoked when it is empty.
        /// </summary>
        event Action OnEmptyUndoStackInvoked;
        /// <summary>
        /// What to do if redo stack invoked when it is empty.
        /// </summary>
        event Action OnEmptyRedoStackInvoked;
        
        /// <summary>
        /// Executes specified command.
        /// </summary>
        /// <param name="command">Specified command</param>
        void Execute(TCommand command);
        
        /// <summary>
        /// Undoes last done action.
        /// </summary>
        void Undo();
        /// <summary>
        /// Redoes last undone action
        /// </summary>
        void Redo();

        /// <summary>
        /// Clears actions in both stacks.
        /// </summary>
        void Clear();
    }
}