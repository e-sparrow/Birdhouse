using System.Collections.Generic;
using Birdhouse.Abstractions.Factories.Interfaces;
using Birdhouse.Common.Singleton.Interfaces;

namespace Birdhouse.Common.Singleton
{
    public abstract class SingletonStrategyBase<T> : ISingletonStrategy<T>
    {
        protected SingletonStrategyBase(IFactory<T> factory)
        {
            _factory = factory;
        }

        private readonly IFactory<T> _factory;

        public abstract IEnumerable<T> FindInstances();

        public T CreateInstance()
        {
            var instance = _factory.Create();
            return instance;
        }
    }
}