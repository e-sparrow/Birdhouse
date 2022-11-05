using System;
using System.Collections.Generic;
using Birdhouse.Features.Executions.Instructions.Interfaces;

namespace Birdhouse.Features.Executions.Instructions
{
    public static class InstructionsExtensions
    {
        public static IExecutionInstruction AsInstruction(this IEnumerable<IExecutionInstruction> self)
        {
            throw new NotImplementedException();
        }
    }
}