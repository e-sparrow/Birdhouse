using System;

namespace Birdhouse.Features.Executions.Instructions.Kinds
{
    public class UnconditionalExecutionInstruction : ExecutionInstructionBase
    {
        public UnconditionalExecutionInstruction(Action action)
        {
            _action = action;
        }

        private readonly Action _action;
        
        public override bool Execute()
        {
            _action.Invoke();
            return true;
        }
    }
}