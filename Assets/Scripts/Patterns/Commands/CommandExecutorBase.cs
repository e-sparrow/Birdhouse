using System;
using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Patterns.Commands.Interfaces;

namespace ESparrow.Utils.Patterns.Commands
{
    public abstract class CommandExecutorBase<TCommand, TDelegate> : ICommandExecutor<TCommand, TDelegate>
        where TCommand : ICommand<TDelegate> where TDelegate : Delegate
    {
        public event Action OnEmptyUndoStackInvoked = () => { };
        public event Action OnEmptyRedoStackInvoked = () => { };

    private readonly Stack<TCommand> _undoStack = new Stack<TCommand>();
        private readonly Stack<TCommand> _redoStack = new Stack<TCommand>();

        /// <summary>
        /// Void to execute the command.
        /// </summary>
        /// <param name="command">Command to execute</param>
        protected abstract void Do(TCommand command);
        /// <summary>
        /// Void to execute the command if it's undo action.
        /// </summary>
        /// <param name="command">Command to execute</param>
        protected abstract void Undo(TCommand command);

        public void Execute(TCommand command)
        {
            Do(command);
            
            _undoStack.Push(command);
            _redoStack.Clear();
        }

        public void Undo()
        {
            if (!_undoStack.Any())
            {
                OnEmptyUndoStackInvoked.Invoke();
                return;
            }

            var command = _undoStack.Pop();
            Undo(command);
            
            _redoStack.Push(command);
        }

        public void Redo()
        {
            if (!_redoStack.Any())
            {
                OnEmptyRedoStackInvoked.Invoke();
                return;
            }

            var command = _redoStack.Pop();
            Do(command);
            
            _undoStack.Push(command);
        }

        public void Clear()
        {
            _undoStack.Clear();
            _redoStack.Clear();
        }
    }
}
