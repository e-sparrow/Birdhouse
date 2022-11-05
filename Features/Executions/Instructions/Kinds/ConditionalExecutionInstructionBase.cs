using System;

namespace Birdhouse.Features.Executions.Instructions.Kinds
{
    public abstract class ConditionalExecutionInstructionBase : ExecutionInstructionBase
    {
        protected abstract bool ExecuteInternal();
        
        public override bool Execute()
        {
            var result = ExecuteInternal();
            return result;
        }
    }
}