using System.Collections.Generic;

namespace Birdhouse.Tools.Filtering
{
    public abstract class EnumerablePriorityBasedFilterBase<TElement> 
        : PriorityBasedFilterBase<IEnumerable<TElement>, TElement>
    {
        protected EnumerablePriorityBasedFilterBase(int count = -1, int minPriority = 0) : base(count, minPriority)
        {
            
        }

        protected override IEnumerable<TElement> CastBack(IEnumerable<TElement> enumerable)
        {
            return enumerable;
        }
    }
}