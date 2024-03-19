using System;
using Birdhouse.Tools.Inputs.Pressures.Enums;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Inputs.Remapping.Interfaces;

namespace Birdhouse.Tools.Inputs.Remapping.Decorators
{
    public class RemappedPressureStateProvider<TFrom, TTo>
        : IPressureStateProvider<TTo>
    {
        public RemappedPressureStateProvider(IRemapper<TTo, TFrom> remapper, IPressureStateProvider<TFrom> stateProvider)
        {
            _remapper = remapper;
            _stateProvider = stateProvider;
        }

        private readonly IRemapper<TTo, TFrom> _remapper;
        private readonly IPressureStateProvider<TFrom> _stateProvider;

        public EPressureState GetPressureState(TTo key)
        {
            var hasValue = _remapper.TryGetValue(key, out var realPressure);
            if (hasValue)
            {
                var result = _stateProvider.GetPressureState(realPressure.Value);
                return result;
            }

            throw new ArgumentException($"Remapper is not contains necessary key: {key}");
        }
    }
}