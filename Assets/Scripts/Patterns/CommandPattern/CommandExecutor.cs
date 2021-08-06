using System;
using System.Linq;
using System.Collections.Generic;

namespace ESparrow.Utils.Patterns.CommandPattern
{
    public class CommandExecutor
    {
        public event Action OnEmptyUndoExecuted; // События вызова команды Undo, когда стек _undoCommands пуст.
        public event Action OnEmptyRedoExecuted; // Аналогично событию сверху, но с _redoCommands.

        // Если глубина буфера равна нулю, то его размерность не ограничена. Осторожней.
        private readonly uint _undoDepth;
        private readonly uint _redoDepth;

        private readonly Stack<Command> _undoCommands = new Stack<Command>();
        private readonly Stack<Command> _redoCommands = new Stack<Command>();

        public CommandExecutor(uint undoDepth = 0, uint redoDepth = 0)
        {
            _undoDepth = undoDepth;
            _redoDepth = redoDepth;
        }

        public void Execute(Command command)
        {
            command.Do();

            _undoCommands.Push(command);
            _redoCommands.Clear();
        }

        public void Clear()
        {
            _undoCommands.Clear();
            _redoCommands.Clear();
        }

        public void Undo()
        {
            if (!_undoCommands.Any())
            {
                OnEmptyUndoExecuted?.Invoke();
                return;
            }

            var command = _undoCommands.Pop();
            command.Undo();

            if (_redoDepth == 0 || _redoCommands.Count + 1 <= _redoDepth)
            {
                _redoCommands.Push(command);
            }
        }

        public void Redo()
        {
            if (!_redoCommands.Any())
            {
                OnEmptyRedoExecuted?.Invoke();
                return;
            }

            var command = _redoCommands.Pop();
            command.Do();

            if (_undoDepth == 0 || _undoCommands.Count + 1 <= _undoDepth)
            {
                _undoCommands.Push(command);
            }
        }
    }
}
