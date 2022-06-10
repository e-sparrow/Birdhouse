using System.Text.RegularExpressions;

namespace ESparrow.Utils.Tools.Filtering.Routine
{
    public class PriorityBasedStringFilter : PriorityBasedFilterBase<string>
    {
        public PriorityBasedStringFilter(string landmark, int count, int minPriority = 0) : base(count, minPriority)
        {
            _landmark = landmark;
        }

        private readonly string _landmark;

        protected override int GetPriority(string self)
        {
            var pattern = @$"/*{_landmark}/*";
            var count = Regex.Matches(Regex.Escape(self), pattern).Count;
            var priority = pattern.Length * count;

            return priority;
        }
    }
}