using System.Collections.Generic;
using System.Linq;

namespace Birdhouse.Common.Collections
{
    public static class QueueExtensions
    {
        public static bool TryDequeue<T>(this Queue<T> self, out T value)
        {
            value = default;

            var hasValue = self.Any();
            if (!hasValue) return false;
            
            value = self.Dequeue();
            return true;

        }
        
        public static bool TryPeek<T>(this Queue<T> self, out T value)
        {
            value = default;

            var hasValue = self.Any();
            if (!hasValue) return false;
            
            value = self.Peek();
            return true;

        }
    }
}