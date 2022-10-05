using System.Threading;
using Birdhouse.Abstractions.Interfaces;
using UnityEngine;

namespace Birdhouse.Common.Coroutines.YieldInstructions
{
    public class CancellableYieldInstructionBase : YieldInstructionBase, ICancellable
    {
        public CancellableYieldInstructionBase(CustomYieldInstruction instruction)
        {
            _instruction = instruction;
        }

        private readonly CustomYieldInstruction _instruction;
        private readonly CancellationTokenSource _source = new CancellationTokenSource();
        
        protected override bool IsFinished()
        {
            var finished = !_instruction.keepWaiting;
            var cancelled = _source.IsCancellationRequested;

            var result = finished || cancelled;
            return result;
        }

        public void Cancel()
        {
            _source.Cancel();
        }
    }
}