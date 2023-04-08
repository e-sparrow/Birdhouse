using System;
using System.Diagnostics.Contracts;

namespace Birdhouse.Common.Mathematics
{
    public static class LevenshteinDistanceHelper
    {
        [Pure]
        public static int GetDistance(string left, string right)
        {
            if (string.IsNullOrEmpty(left) && string.IsNullOrEmpty(right)) 
            {
                return 0;
            }
            
            if (string.IsNullOrEmpty(left)) 
            {
                return right.Length;
            }
            
            if (string.IsNullOrEmpty(right))
            {
                return left.Length;
            }
            
            var leftLength = left.Length;
            var rightLength = right.Length;
            
            var distances = new int[leftLength + 1, rightLength + 1];

            for (var i = 0; i <= leftLength; distances[i, 0] = i++);
            for (var j = 0; j <= rightLength;  distances[0, j] = j++);

            for (var i = 1; i <= leftLength; i++)
            {
                for (var j = 1; j <= rightLength; j++)
                {
                    var cost = right[j - 1] == left[i - 1] ? 0 : 1;
                    
                    var minDistance = Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1);
                    var distanceAndCost = distances[i - 1, j - 1] + cost;
                    
                    distances[i, j] = Math.Min(minDistance, distanceAndCost);
                }
            }

            var result = distances[leftLength, rightLength];
            return result;
        }
    }
}