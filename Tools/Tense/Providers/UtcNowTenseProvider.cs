using System;

namespace Birdhouse.Tools.Tense.Providers
{
    public class UtcNowTenseProvider
        : TenseProviderBase<DateTime>
    {
        public override DateTime Now()
        {
            var result = DateTime.UtcNow;
            return result;
        }
    }
}