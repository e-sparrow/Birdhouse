using System;

namespace Birdhouse.Education.Patterns.Commands.Interfaces
{
    public interface ICommand<out T> where T : Delegate
    {
        /// <summary>
        /// Do delegate of this command.
        /// </summary>
        T Do
        {
            get;
        }

        /// <summary>
        /// Undo delegate of this command.
        /// </summary>
        T Undo
        {
            get;
        }
    }
}
