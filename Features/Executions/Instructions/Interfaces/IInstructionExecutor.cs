using System;
using Birdhouse.Features.Executions.Interfaces;

namespace Birdhouse.Features.Executions.Instructions.Interfaces
{
    public interface IInstructionExecutor : IExecutor
    {
        IDisposable AddInstruction(IExecutionInstruction instruction);
        void AppendInstruction(IExecutionInstruction instruction);
    }
}