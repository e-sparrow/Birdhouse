using System.Collections.Generic;

namespace Birdhouse.Common.Extensions
{
    public static class EnumeratorExtensions
    {
        public static T CircularNext<T>(this IEnumerator<T> self)
        {
            var isLast = !self.MoveNext();
            if (isLast)
            {
                self.Reset();
            }

            return self.Current;
        }
    }
}