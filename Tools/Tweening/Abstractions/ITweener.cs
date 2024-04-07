using Birdhouse.Abstractions.Misc;
using Birdhouse.Abstractions.Renewables;

namespace Birdhouse.Tools.Tweening.Abstractions
{
    public interface ITweener
        : IFlow, IRenewable
    {
        float TargetValue
        {
            get;
            set;
        }
    }
}