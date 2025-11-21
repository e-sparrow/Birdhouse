using Birdhouse.Experimental.FluentLogics;

namespace Birdhouse.Common.Assertions
{
    public static class AssertionExtensions
    {
        public static BranchingRoot Is<T>(this T self, T other)
        {
            var result = new BranchingRoot(() => self.Equals(other));
            return result;
        }
    }
}