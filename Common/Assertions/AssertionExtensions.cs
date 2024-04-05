using Birdhouse.Experimental.FluentLogics;

namespace Birdhouse.Common.Assertions
{
    public static class AssertionExtensions
    {
        public static LogicRoot Is<T>(this T self, T other)
        {
            var result = new LogicRoot(() => self.Equals(other));
            return result;
        }
    }
}