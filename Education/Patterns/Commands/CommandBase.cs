using System;
using Birdhouse.Education.Patterns.Commands.Interfaces;

namespace Birdhouse.Education.Patterns.Commands
{
    public abstract class CommandBase<T> : ICommand<T> where T : Delegate
    {
        protected CommandBase(T doDelegate, T undoDelegate)
        {
            Do = doDelegate;
            Undo = undoDelegate;
        }

        public T Do
        {
            get;
        }
        

        public T Undo
        {
            get;
        }
    }
}