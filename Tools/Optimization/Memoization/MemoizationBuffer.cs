using System;
using System.Collections.Generic;
using Birdhouse.Tools.Optimization.Memoization.Interfaces;
using Birdhouse.Tools.Tense.Expiration;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Tools.Optimization.Memoization
{
    public class MemoizationBuffer<TKey, TValue> : MemoizationBufferBase<TKey, TValue>
    {
        public MemoizationBuffer(Func<ITermInfo> termInfoCreator, bool capacious = false, int capacity = 0) 
            : base(new Dictionary<TKey, IMemoizationElement<TValue>>(), capacious, capacity)
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