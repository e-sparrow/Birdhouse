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
            return _buffer.GetOrCreate(key, CreateBuffer);
        }

        public IMemoizationBuffer<object[], object> GetOrCreateBuffer(TKey key, TimeSpan elementLifetime)
        {
            return _buffer.GetOrCreate(key, CreateBufferByLifetime);

            IMemoizationBuffer<object[], object> CreateBufferByLifetime()
            {
                return CreateBuffer(elementLifetime);
            }
        }

        public IMemoizationBuffer<object[], object> GetOrCreateBuffer(TKey key, Func<ITermInfo> termInfoCreator)
        {
            return _buffer.GetOrCreate(key, CreateBufferByTermCreator);

            IMemoizationBuffer<object[], object> CreateBufferByTermCreator()
            {
                return CreateBuffer(termInfoCreator);
            }
        }
    }
}