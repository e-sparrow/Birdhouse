using System;
using Birdhouse.Features.Executions.Instructions.Interfaces;

namespace Birdhouse.Features.Executions.Instructions.Adapters
{
    public class EventExecutionInstructionWrapper : ExecutionInstructionBase
    {
        public EventExecutionInstructionWrapper(IExecutionInstruction instruction)
        {
            _instruction = instruction;
        }

        public event Action<bool> OnInstructionExecuted = _ => { }; 

        private readonly IExecutionInstruction _instruction;
        
        public override bool Execute()
        {
            var result = _instruction.Execute();
            OnInstructionExecuted.Invoke(result);
            
            return result;
        }
    }
}