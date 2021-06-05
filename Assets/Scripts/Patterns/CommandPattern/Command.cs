using System;

namespace ESparrow.Utils.Patterns.CommandPattern
{
    public class Command
    {
        private readonly Action _doAction = () => { };
        private readonly Action _undoAction = () => { };

        public Command(Action doAction, Action undoAction)
        {
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
