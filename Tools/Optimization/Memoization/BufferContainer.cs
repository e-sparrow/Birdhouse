using System;
using Birdhouse.Common.Helpers;
using Birdhouse.Tools.Optimization.Memoization.Interfaces;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Tools.Optimization.Memoization
{
    public class BufferContainer<TKey> 
        : BufferContainerBase<TKey>
    {
        public BufferContainer() : base(MemoizationHelper.CreateBuffer<TKey, IMemoizationBuffer<object[], object>>()) { }
        public BufferContainer(IMemoizationBuffer<TKey, IMemoizationBuffer<object[], object>> buffer) : base(buffer) { }

        protected override IMemoizationBuffer<object[], object> CreateBuffer() => MemoizationHelper.CreateBuffer<object[], object>();
        protected override IMemoizationBuffer<object[], object> CreateBuffer(TimeSpan elementLifetime) => MemoizationHelper.CreateBuffer<object[], object>(elementLifetime);
        protected override IMemoizationBuffer<object[], object> CreateBuffer(Func<ITermInfo> termInfoCreator) => MemoizationHelper.CreateBuffer<object[], object>(termInfoCreator);
        
    }
}