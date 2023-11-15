using Birdhouse.Tools.Inputs.AnyKey.Interfaces;
using Birdhouse.Tools.Inputs.Pressures.Interfaces;
using Birdhouse.Tools.Inputs.Remapping.Decorators;
using Birdhouse.Tools.Inputs.Remapping.Interfaces;

namespace Birdhouse.Tools.Inputs.Remapping
{
    public static class RemappingExtensions
    {
        public static IPressureListener<TTo, TTime> Remap<TFrom, TTo, TTime>
        (
            this IPressureListener<TFrom, TTime> self,
            IRemapper<TTo, TFrom> remapper
        )
        {
            var result = new RemappedPressureListener<TFrom, TTo, TTime>(remapper, self);
            return result;
        }

        public static IPressureStateProvider<TTo> Remap<TFrom, TTo>
        (
            this IPressureStateProvider<TFrom> self, 
            IRemapper<TTo, TFrom> remapper
        )
        {
            var result = new RemappedPressureStateProvider<TFrom, TTo>(remapper, self);
            return result;
        }

        public static IAnyKeyListener<TTo> Remap<TFrom, TTo>
        (
            this IAnyKeyListener<TFrom> self,
            IRemapper<TTo, TFrom> remapper
        )
        {
            var result = new RemappedAnyKeyListener<TFrom, TTo>(remapper, self);
            return result;
        }
    }
}