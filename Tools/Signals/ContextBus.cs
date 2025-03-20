using System;
using System.Collections.Generic;
using Birdhouse.Tools.Signals.Abstractions;

namespace Birdhouse.Tools.Signals
{
    public static class ContextBus<TContext>
    {
        private static readonly IDictionary<Type, SignalBusWrapper> Buses 
            = new Dictionary<Type, SignalBusWrapper>();

        public static ISignalBus<T> GetOrCreateBus<T>()
        {
            var hasCached = Buses.TryGetValue(typeof(T), out var value);
            if (!hasCached)
            {
                var result = new SignalBus<T>();
                Buses[typeof(T)] = new SignalBusWrapper(typeof(T), result);
                return result;
            }

            var isValid = value.Bus is ISignalBus<T>;
            if (isValid)
            {
                return value.Bus as ISignalBus<T>;
            }

            throw new ArgumentException();
        }

        private readonly struct SignalBusWrapper
        {
            public SignalBusWrapper(Type type, object bus)
            {
                Type = type;
                Bus = bus;
            }

            public Type Type
            {
                get;
            }

            public object Bus
            {
                get;
            }
        }
    }
}