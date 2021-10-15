using System;

namespace ESparrow.Utils.Patterns.Commands
{
    public class CommandGeneric<T> : CommandBase<T> where T : Delegate
    {
        public CommandGeneric(T doDelegate, T undoDelegate) : base(doDelegate, undoDelegate)
        {
            
        }
    }
}