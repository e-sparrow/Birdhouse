using System;
using Birdhouse.Tools.Tense;
using Birdhouse.Tools.Tense.Providers.Interfaces;

namespace Birdhouse.Tools.Coroutines.Instructions
{
    public sealed class WaitToDateTimeInstruction 
        : CoroutineInstructionBase
    {
        public WaitToDateTimeInstruction(DateTime target, ITenseProvider<DateTime> tenseProvider = null)
        {
            tenseProvider ??= TenseHelper.UtcNowTenseProvider.Value;
            
            _target = target;
            _tenseProvider = tenseProvider;
        }

        private readonly DateTime _target;
        private readonly ITenseProvider<DateTime> _tenseProvider;

        public override bool IsFinished(float deltaTime)
        {
            var now = _tenseProvider.Now();

            var result = _target <= now;
            return result;
        }
    }
}