using System.Text.RegularExpressions;

namespace Birdhouse.Tools.Filtering.Routine
{
    public class PriorityBasedStringFilter : EnumerablePriorityBasedFilterBase<string>
    {
        public PriorityBasedStringFilter(string landmark, int count = -1, int minPriority = 0) 
            : base(count, minPriority)
        {
            _landmark = landmark;
        }

        private readonly string _landmark;

        protected override int GetPriority(string self)
        {
            var pattern = @$"/*{_landmark}/*";
            var escape = Regex.Escape(self);
            var matches = Regex.Matches(escape, pattern);
            var count = matches.Count;
            var priority = pattern.Length * count;

            return priority;
        }
    }
}