using System;
using Birdhouse.Features.Executions.Instructions.Interfaces;
using Birdhouse.Features.Executions.Interfaces;

namespace Birdhouse.Features.Executions
{
    public static class ExecutionsExtensions
    {
        public static IInstructionExecutor AsInstructionExecutor(this IExecutor self)
        {
            throw new NotImplementedException();
        }
    }
}