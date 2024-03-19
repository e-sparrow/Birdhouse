using System;
using Birdhouse.Features.Executions.Instructions.Interfaces;
using Birdhouse.Features.Executions.Interfaces;

namespace Birdhouse.Features.Executions.Instructions.Adapters
{
    public class ExecutorToInstructionExecutorAdapter : IInstructionExecutor
    {
        public ExecutorToInstructionExecutorAdapter(IExecutor executor)
        {
            _executor = executor;
        }

        private readonly IExecutor _executor;
        
        public void Execute()
        {
            _executor.Execute();
        }

        public IDisposable AddInstruction(IExecutionInstruction instruction)
        {
            throw new NotImplementedException();
        }

        public void AppendInstruction(IExecutionInstruction instruction)
        {
            // TODO:
        }
    }
}