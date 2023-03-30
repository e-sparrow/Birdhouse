using System;
using Birdhouse.Tools.Tense.Providers.Interfaces;

namespace Birdhouse.Tools.Tense
{
    public static class TenseExtensions
    {
        public static ITenseProvider<T> AsTenseController<T>(this Func<T> self)
        {
            var result = TenseHelper.CreateTenseController(self);
            return result;
        }
    }
}