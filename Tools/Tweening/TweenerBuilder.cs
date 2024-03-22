using Birdhouse.Abstractions.Builders.Abstractions;
using Birdhouse.Tools.Tweening.Abstractions;

namespace Birdhouse.Tools.Tweening
{
    public class TweenerBuilder<ITweener>
        : IBuilder<ITweener>
    {
        public ITweener Build()
        {
            throw new System.NotImplementedException();
        }
    }
}