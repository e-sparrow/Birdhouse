using System;
using Birdhouse.Tools.Tense;
using Birdhouse.Tools.Tense.Providers.Interfaces;

namespace Birdhouse.Common.Coroutines.YieldInstructions
{
    public class WaitForDateTime : FlowableYieldInstructionBase
    {
        public WaitForDateTime(DateTime expiration, ITenseProvider<DateTime> tenseProvider = null) : base(1f)
        {
            _expiration = expiration;
            _tenseProvider = tenseProvider;

            _tenseProvider ??= TenseHelper.UtcNowTenseProvider;
            _tempValue = _tenseProvider.Now();
        }

        private readonly DateTime _expiration;
        private readonly ITenseProvider<DateTime> _tenseProvider;

        private readonly DateTime _tempValue;

        protected override float GetProgress()
        {
            var delta = _expiration - _tempValue;
            var currentDelta = _expiration - _tenseProvider.Now();

            var result = (float) (currentDelta / delta);
            return result;
        }
    }
}