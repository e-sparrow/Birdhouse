using System;

namespace Birdhouse.Features.Executions.Instructions.Kinds
{
    public class ConditionalExecutionInstruction : ConditionalExecutionInstructionBase
    {
        public ConditionalExecutionInstruction(Func<bool> func)
        {
            _func = func;
        }

        private readonly Func<bool> _func;

        protected override bool ExecuteInternal()
        {
            var result = _func.Invoke();
            return result;
        }
    }
}