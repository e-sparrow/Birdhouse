using System;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Ticks.Unity
{
    public static class UnityTicksHelper
    {
        private static readonly Lazy<ITickProvider> LazyUpdateProvider
            = new Lazy<ITickProvider>(() => new UpdateTickProvider());
            
        private static readonly Lazy<ITickProvider> LazyFixedUpdateProvider
            = new Lazy<ITickProvider>(() => new FixedUpdateTickProvider());

        public static ITickProvider UpdateProvider => LazyUpdateProvider.Value;
        public static ITickProvider FixedUpdateProvider => LazyFixedUpdateProvider.Value;
    }
}