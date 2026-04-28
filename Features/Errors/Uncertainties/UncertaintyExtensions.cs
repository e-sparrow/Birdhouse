using System;

namespace Birdhouse.Features.Errors
{
    public static class UncertaintyExtensions
    {
        public static T Perturb<T>(this SerializedUncertainValueBase<T> self, Random random = null) => self.ToUncertainty(random).Perturb();
    }
}