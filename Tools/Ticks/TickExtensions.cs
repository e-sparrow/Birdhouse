using System;
using Birdhouse.Abstractions.Misc;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Ticks
{
    public static class TickExtensions
    {
        public static IFlow CreateTickFlow(this ITickable self, ITickProvider provider = null, IFlow flow = null)
        {
            provider ??= TickHelper.GetDefaultTickProvider();

            IFlow result = new TickFlowWrapper(self, provider);
            if (flow != null)
            {
                result = result.Append(flow);
            }

            return result;
        }
        
        public static IDisposable ConnectTo(this ITickable self, ITickProvider provider)
        {
            var result = provider.RegisterTick(self.Tick);
            return result;
        }

        public static IDisposable Connect(this ITickProvider self, ITickable target)
        {
            var result = self.RegisterTick(target.Tick);
            return result;
        }

        public static ICompositeTickable Append(this ITickable self, ITickable other)
        {
            var result = new CompositeTickable()
                .Append(self)
                .Append(other);

            return result;
        }
    }
}