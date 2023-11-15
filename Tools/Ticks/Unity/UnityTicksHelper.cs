using System;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Ticks.Unity
{
    public static class UnityTicksHelper
    {
        public static readonly Lazy<ITickProvider> UpdateProvider
            = new Lazy<ITickProvider>(() => new UpdateTickProvider());
            
        public static readonly Lazy<ITickProvider> FixedUpdateProvider
            = new Lazy<ITickProvider>(() => new FixedUpdateTickProvider());
    }
}