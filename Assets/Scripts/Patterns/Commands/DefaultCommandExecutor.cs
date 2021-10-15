using System;

namespace ESparrow.Utils.Patterns.Commands.Interfaces
{
    public class DefaultCommandExecutor : CommandExecutorBase<Action>
    {
        protected override void Do(Action instruction)
        {
            Execute(instruction);
        }

        protected override void Undo(Action instruction)
        {
            Execute(instruction);
        }

        private void Execute(Action instruction)
        {
            instruction.Invoke();
        }
    }
}