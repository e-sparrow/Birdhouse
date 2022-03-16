using System;

namespace ESparrow.Utils.Patterns.Commands
{
    public class Command<T> : CommandBase<T> where T : Delegate
    {
        public Command(T doDelegate, T undoDelegate) : base(doDelegate, undoDelegate)
        {
            
        }
    }
}