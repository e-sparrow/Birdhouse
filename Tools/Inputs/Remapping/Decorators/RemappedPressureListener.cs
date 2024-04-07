using System;
using Birdhouse.Abstractions.Observables;
using Birdhouse.Tools.Inputs.Pressures;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Inputs.Remapping.Interfaces;

namespace Birdhouse.Tools.Inputs.Remapping.Decorators
{
    public class RemappedPressureListener<TFrom, TTo, TTime> 
        : IPressureListener<TTo, TTime>
    {
        public RemappedPressureListener
        (
            IRemapper<TTo, TFrom> remapper, 
            IPressureListener<TFrom, TTime> pressureListener
        )
        {
            _remapper = remapper;
            _pressureListener = pressureListener;
        }

        private readonly IRemapper<TTo, TFrom> _remapper;
        private readonly IPressureListener<TFrom, TTime> _pressureListener;

        public IObservableDisposableValue<PressureStateChange<TTime>> Listen(TTo key)
        {
            var hasValue = _remapper.TryGetValue(key, out var realKey);
            if (hasValue)
            {
                var result = _pressureListener.Listen(realKey.Value);
                return result;
            }

            throw new ArgumentException($"Remapper is not contains necessary key: {key}");
        }
    }
}