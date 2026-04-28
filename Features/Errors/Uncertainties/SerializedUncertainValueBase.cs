using System;

namespace Birdhouse.Features.Errors
{
    [Serializable]
    public abstract class SerializedUncertainValueBase<T>
    {
        public abstract IUncertainty<T> ToUncertainty(Random random = null);
    }
}