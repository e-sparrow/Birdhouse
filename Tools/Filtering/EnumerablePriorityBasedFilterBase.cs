namespace Birdhouse.Tools.Filtering
{
    public abstract class EnumerablePriorityBasedFilterBase<TElement> 
        : PriorityBasedFilterBase<TElement>
    {
        protected EnumerablePriorityBasedFilterBase(int count = -1, int minPriority = 0) : base(count, minPriority)
        {
            
        }
    }
}