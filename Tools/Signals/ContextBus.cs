using System;
using System.Collections.Generic;
using Birdhouse.Common.Collections;
using Birdhouse.Common.Collections.Interfaces;
using Birdhouse.Tools.Signals.Abstractions;

namespace Birdhouse.Tools.Signals
{
    public static class ContextBus<TContext>
    {
        private static readonly IDictionary<Type, SignalBusWrapper> Buses 
            = new Dictionary<Type, SignalBusWrapper>();

        public static ISignalBus<T> GetOrCreateBus<T>()
        {
            SignalBus<T> result = null;

            var hasCached = Buses.TryGetValue(typeof(T), out var value);
            if (!hasCached)
            {
                result = new SignalBus<T>();
                Buses[typeof(T)] = new SignalBusWrapper(typeof(T), result);
            }

            var isValid = value.Bus is ISignalBus<T>;
            if (isValid)
            {
                return result;
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