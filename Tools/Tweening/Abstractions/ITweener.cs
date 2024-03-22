using Birdhouse.Abstractions.Misc.Interfaces;
using Birdhouse.Abstractions.Renewables.Interfaces;

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