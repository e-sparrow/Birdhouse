using System;

namespace ESparrow.Utils.Patterns.Commands.Interfaces
{
    public interface ICommandExecutor<in T> where T : Delegate
    {
        event Action OnEmptyUndoStackInvoked;
        event Action OnEmptyRedoStackInvoked;
        
        void Execute(ICommand<T> command);
        
        void Undo();
        void Redo();

        void Clear();
    }
}