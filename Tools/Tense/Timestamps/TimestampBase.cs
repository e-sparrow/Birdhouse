using Birdhouse.Tools.Tense.Providers.Interfaces;
using Birdhouse.Tools.Tense.Timestamps.Interfaces;

namespace Birdhouse.Tools.Tense.Timestamps
{
    public abstract class TimestampBase<T> : ITimestamp<T>
    {
        protected TimestampBase(ITenseProvider<T> tenseProvider)
        {
            _tenseProvider = tenseProvider;
            _lastStamp = _tenseProvider.Now();
        }

        private readonly ITenseProvider<T> _tenseProvider;

        private T _lastStamp;

        protected abstract T GetDeltaTime(T current, T previous);
        
        public T Stamp()
        {
            var current = _tenseProvider.Now();
            var delta = GetDeltaTime(current, _lastStamp);
            
            _lastStamp = current;
            
            return delta;
        }
    }
}
