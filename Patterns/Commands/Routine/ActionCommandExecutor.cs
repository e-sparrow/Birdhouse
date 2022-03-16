using System;
using ESparrow.Utils.Patterns.Commands.Interfaces;

namespace ESparrow.Utils.Patterns.Commands.Routine
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
