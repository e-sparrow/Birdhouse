using System;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Ticks;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Abstractions.Misc
{
    public static class EffectExtensions
    {
        public static IFlow Flow
        (
            this IProgressive self, 
            Func<float> speedFunc, 
            ITickProvider tickProvider = null
        )
        {
            tickProvider ??= TickHelper.GetDefaultTickProvider();
            
            var result = new ProgressiveToFlowAdapter(self, tickProvider, speedFunc);
            return result;
        }
        
        public static IFlow Flow
        (
            this IProgressive self, 
            float speed = 1f, 
            ITickProvider tickProvider = null
        )
        {
            var result = self.Flow(speed.AsFunc(), tickProvider);
            return result;
        }
    }
}