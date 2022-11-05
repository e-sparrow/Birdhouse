using System.Collections.Generic;
using Birdhouse.Features.Executions.Instructions.Interfaces;

namespace Birdhouse.Features.Executions.Instructions.Adapters
{
    public class QueueToExecutionInstructionAdapter : ExecutionInstructionBase
    {
        public QueueToExecutionInstructionAdapter(Queue<IExecutionInstruction> queue)
        {
            _queue = queue;
        }

        private readonly Queue<IExecutionInstruction> _queue;

        public override bool Execute()
        {
            var hasInstruction = _queue.TryDequeue(out var value);
            if (hasInstruction)
            {
                value.Execute();
            }

            return hasInstruction;
        }
    }
}