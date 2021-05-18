using System;

namespace ESparrow.Utils.Patterns.Command
{
    public class Command
    {
        private readonly string _name;

        private readonly Action _doAction = () => { };
        private readonly Action _undoAction = () => { };

        public string Name => _name;

        public Command(string name, Action doAction, Action undoAction)
        {
            _name = name;

            _doAction = doAction;
            _undoAction = undoAction;
        }

        public void Do()
        {
            _doAction.Invoke();
        }

        public void Undo()
        {
            _undoAction.Invoke();
        }
    }
}
