using System;
using ESparrow.Utils.Tools.DateAndTime.Expiration;
using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

namespace ESparrow.Utils.Optimization.Memoization
{
    public class MemoizationBuffer<TKey, TValue> : MemoizationBufferBase<TKey, TValue>
    {
        public MemoizationBuffer(Func<ITermInfo> termInfoCreator)
        {
            _termInfoCreator = termInfoCreator;
        }

        private readonly Func<ITermInfo> _termInfoCreator;

        protected override ITerm CreateTerm()
        {
            var term = new Term(_termInfoCreator.Invoke());
            term.Initialize();

            return term;
        }
    }
}