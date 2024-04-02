using System.Collections.Generic;
using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines
{
    public readonly struct CoroutineRunner 
        : ICoroutineInstruction
    {
        public CoroutineRunner(IEnumerator<ICoroutineInstruction> instructions)
        {
            _instructions = instructions;
        }
        
        private readonly IEnumerator<ICoroutineInstruction> _instructions;

        public bool IsFinished(float deltaTime)
        {
            var isCurrentNull = _instructions.Current == null;
            if (isCurrentNull)
            {
                var isNextNull = !_instructions.MoveNext();
                if (isNextNull)
                {
                    return true;
                }
            }

            var isOver = _instructions
                .Current
                .IsFinished(deltaTime);
            
            if (isOver)
            {
                var hasNext = _instructions.MoveNext();
                if (!hasNext)
                {
                    return true;
                }
            }

            return false;
        }
    }
}