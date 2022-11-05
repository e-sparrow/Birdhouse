using Birdhouse.Features.Executions.Instructions.Interfaces;

namespace Birdhouse.Features.Executions.Instructions
{
    public abstract class ExecutionInstructionBase : IExecutionInstruction
    {
        public abstract bool Execute();
    }
}