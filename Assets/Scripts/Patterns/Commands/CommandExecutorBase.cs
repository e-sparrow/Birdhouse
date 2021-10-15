using System;
using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Patterns.Commands.Interfaces;

namespace ESparrow.Utils.Patterns.Commands
{
    public abstract class CommandExecutorBase<T> : ICommandExecutor<T> where T : Delegate
    {
        public event Action OnEmptyUndoStackInvoked = () => { };
        public event Action OnEmptyRedoStackInvoked = () => { };

        private readonly Stack<ICommand<T>> _undoStack = new Stack<ICommand<T>>();
        private readonly Stack<ICommand<T>> _redoStack = new Stack<ICommand<T>>();

        /// <summary>
        /// Void to execute the delegate if it's a do action.
        /// </summary>
        /// <param name="instruction">Delegate to execute</param>
        protected abstract void Do(T instruction);
        /// <summary>
        /// Void to execute the delegate if it's a undo action.
        /// </summary>
        /// <param name="instruction">Delegate to execute</param>
        protected abstract void Undo(T instruction);

        public void Execute(ICommand<T> command)
        {
            Do(command.Do);
            
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
            Undo(command.Undo);
            
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
            Do(command.Do);
            
            _undoStack.Push(command);
        }

        public void Clear()
        {
            _undoStack.Clear();
            _redoStack.Clear();
        }
    }
}
