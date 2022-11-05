using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Features.Executions.Instructions.Interfaces;

namespace Birdhouse.Features.Executions.Instructions
{
    // TODO: разобраться. Можно добавлять инструкции в очередь для того, чтобы выполнять их каждый раз
    // при выполнении метода, а можно проходиться по всем до упора (до возвращения false) каждый раз
    public class InstructionExecutorBase : IInstructionExecutor
    {
        private readonly IList<IExecutionInstruction> _instructions = new List<IExecutionInstruction>();
        private readonly Queue<IExecutionInstruction> _instructionsQueue = new Queue<IExecutionInstruction>();

        public void Execute()
        {
            foreach (var instruction in _instructions)
            {
                
            }
        }

        public IDisposable AddInstruction(IExecutionInstruction instruction)
        {
            var result = instruction.AddAsDisposableTo(_instructions);
            return result;
        }

        public IDisposable AppendInstruction(IExecutionInstruction instruction)
        {
            throw new NotImplementedException();
        }
    }
}