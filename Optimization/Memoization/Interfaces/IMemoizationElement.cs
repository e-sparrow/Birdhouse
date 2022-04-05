using ESparrow.Utils.Tools.Tense.Expiration.Interfaces;

namespace ESparrow.Utils.Optimization.Memoization.Interfaces
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