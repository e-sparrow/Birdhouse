using Birdhouse.Common.Mathematics;

namespace Birdhouse.Tools.Filtering.Routine
{
    public class PriorityBasedLevenshteinFilter : PriorityBasedFilterBase<string>
    {
        public PriorityBasedLevenshteinFilter(string landmark, int count, int minPriority = 0) 
            : base(count, minPriority)
        {
            _landmark = landmark;
        }

        private readonly string _landmark;

        // That's Levenshtein distance algorithm. That's used to find how are two strings similar
        protected override int GetPriority(string self)
        {
            var result = LevenshteinDistanceHelper.GetDistance(_landmark, self);
            return result;
        }
    }
}