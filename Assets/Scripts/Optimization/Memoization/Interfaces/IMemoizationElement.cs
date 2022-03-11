using ESparrow.Utils.Tools.DateAndTime.Expiration.Interfaces;

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