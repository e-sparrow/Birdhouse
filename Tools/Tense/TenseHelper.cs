using System;
using Birdhouse.Tools.Tense.Providers;
using Birdhouse.Tools.Tense.Providers.Interfaces;

namespace Birdhouse.Tools.Tense
{
    public static class TenseHelper
    {
        public static readonly Lazy<ITenseProvider<DateTime>> NowTenseProvider
            = new Lazy<ITenseProvider<DateTime>>(() => new NowTenseProvider());

        public static readonly Lazy<ITenseProvider<DateTime>> UtcNowTenseProvider
            = new Lazy<ITenseProvider<DateTime>>(() => new UtcNowTenseProvider());
    }
}