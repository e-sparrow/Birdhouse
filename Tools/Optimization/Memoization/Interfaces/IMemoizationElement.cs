using Birdhouse.Tools.Tense.Expiration.Interfaces;

namespace Birdhouse.Tools.Optimization.Memoization.Interfaces
{
    public interface IMemoizationElement<out TValue>
    {
        TValue Value
        {
            get;
        }

        ITerm Term
        {
            get;
        }
    }
}