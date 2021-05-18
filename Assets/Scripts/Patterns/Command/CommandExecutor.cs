using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace ESparrow.Utils.Patterns.Command
{
    [AddComponentMenu("ESparrow/Utils/Patterns/CommandExecutor")]
    public class CommandExecutor : MonoBehaviour
    {
        // Если глубина буфера равна нулю, то его размерность не ограничена. Осторожней.
        [SerializeField] private uint undoCommandsDepth;
        [SerializeField] private uint redoCommandsDepth;

        private readonly List<Command> _commands = new List<Command>();

        private readonly Stack<Command> _undoCommands = new Stack<Command>();
        private readonly Stack<Command> _redoCommands = new Stack<Command>();

        public Command GetCommandByName(string name)
        {
            return _commands.FirstOrDefault(value => value.Name == name);
        }

        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        public void RemoveCommand(Command command)
        {
            _commands.Remove(command);
        }

        public void DoCommand(Command command)
        {
            command.Do();

            _undoCommands.Push(command);
            _redoCommands.Clear();
        }

        public void Undo()
        {
            if (_undoCommands.Count == 0) return;

            var command = _undoCommands.Pop();
            command.Undo();

            if (redoCommandsDepth == 0 || _redoCommands.Count + 1 <= redoCommandsDepth)
            {
                _redoCommands.Push(command);
            }
        }

        public void Redo()
        {
            if (_redoCommands.Count == 0) return;

            var command = _redoCommands.Pop();
            command.Do();

            if (undoCommandsDepth == 0 || _undoCommands.Count + 1 <= undoCommandsDepth)
            {
                _undoCommands.Push(command);
            }
        }
    }
}
