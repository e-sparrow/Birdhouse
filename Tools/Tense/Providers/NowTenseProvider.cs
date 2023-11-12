using System;

namespace Birdhouse.Tools.Tense.Providers
{
    public class NowTenseProvider 
        : TenseProviderBase<DateTime>
    {
        public override DateTime Now()
        {
            var result = DateTime.Now;
            return result;
        }
    }
}