using System;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Optimization.Memoization.Interfaces;
using ESparrow.Utils.Tools.Tense.Expiration.Interfaces;

namespace ESparrow.Utils.Optimization.Memoization
{
    public class BufferContainer<TKey> : BufferContainerBase<TKey>
    {
        public BufferContainer() : base(MemoizationHelper.CreateBuffer<TKey, IMemoizationBuffer<object[], object>>())
        {
            
        }

        public BufferContainer(IMemoizationBuffer<TKey, IMemoizationBuffer<object[], object>> buffer) : base(buffer)
        {
            
        }

        protected override IMemoizationBuffer<object[], object> CreateBuffer()
        {
            return MemoizationHelper.CreateBuffer<object[], object>();
        }

        protected override IMemoizationBuffer<object[], object> CreateBuffer(TimeSpan elementLifetime)
        {
            return MemoizationHelper.CreateBuffer<object[], object>(elementLifetime);
        }

        protected override IMemoizationBuffer<object[], object> CreateBuffer(Func<ITermInfo> termInfoCreator)
        {
            return MemoizationHelper.CreateBuffer<object[], object>(termInfoCreator);
        }
    }
}