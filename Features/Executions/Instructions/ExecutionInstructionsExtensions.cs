using System;
using Birdhouse.Features.Executions.Instructions.Adapters;
using Birdhouse.Features.Executions.Instructions.Interfaces;

namespace Birdhouse.Features.Executions.Instructions
{
    public static class ExecutionInstructionsExtensions
    {
        public static IExecutionInstruction Listen(this IExecutionInstruction self, Action<bool> action)
        {
            var result = new EventExecutionInstructionWrapper(self);
            result.OnInstructionExecuted += action;

            return result;
        }

        public static IExecutionInstruction Append(this IExecutionInstruction self, Action<bool> action)
        {
            var result = new EventExecutionInstructionWrapper(self);
            result.OnInstructionExecuted += Execute;

            return result;
            
            void Execute(bool value)
            {
                result.OnInstructionExecuted -= Execute;
                action.Invoke(value);
            }
        }
    }
}