using System;
using ESparrow.Utils.Patterns.CommandPattern;

namespace Demos.Patterns.CommandPattern
{
    public class MathCommand : Command
    {
        private readonly string _message;

        public string Message => _message;

        public MathCommand(Action doAction, Action undoAction, string message) : base(doAction, undoAction)
        {
            _message = message;
        }
    }
}
