using System;
using Birdhouse.Tools.Optimization.Memoization.Interfaces;
using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Tools.Optimization.Memoization
{
    public abstract class BufferContainerBase<TKey>  : IBufferContainer<TKey>
    {
        protected BufferContainerBase(IMemoizationBuffer<TKey, IMemoizationBuffer<object[], object>> buffer)
        {
            _buffer = buffer;
        }

        private readonly IMemoizationBuffer<TKey, IMemoizationBuffer<object[], object>> _buffer;

        protected abstract IMemoizationBuffer<object[], object> CreateBuffer();
        protected abstract IMemoizationBuffer<object[], object> CreateBuffer(TimeSpan elementLifetime);
        protected abstract IMemoizationBuffer<object[], object> CreateBuffer(Func<ITermInfo> termInfoCreator);

        public IMemoizationBuffer<object[], object> GetOrCreateBuffer(TKey key)
        {
            var result = _buffer.GetOrCreate(key, CreateBuffer);
            return result;
        }

        public IMemoizationBuffer<object[], object> GetOrCreateBuffer(TKey key, TimeSpan elementLifetime)
        {
            var result = _buffer.GetOrCreate(key, CreateBufferByLifetime);
            return result;

            IMemoizationBuffer<object[], object> CreateBufferByLifetime()
            {
                var buffer = CreateBuffer(elementLifetime);
                return buffer;
            }
        }

        public IMemoizationBuffer<object[], object> GetOrCreateBuffer(TKey key, Func<ITermInfo> termInfoCreator)
        {
            var result = _buffer.GetOrCreate(key, CreateBufferByTermCreator);
            return result;

            IMemoizationBuffer<object[], object> CreateBufferByTermCreator()
            {
                var buffer = CreateBuffer(termInfoCreator);
                return buffer;
            }
        }
    }
}