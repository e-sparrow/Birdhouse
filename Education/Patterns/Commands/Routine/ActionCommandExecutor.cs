using System;
using Birdhouse.Education.Patterns.Commands.Interfaces;

namespace Birdhouse.Education.Patterns.Commands.Routine
{
    public class ActionCommandExecutor : CommandExecutorBase<ICommand<Action>, Action>
    {
        protected override void Do(ICommand<Action> command)
        {
            command.Do.Invoke();
        }

        protected override void Undo(ICommand<Action> command)
        {
            command.Undo.Invoke();
        }
    }
}
