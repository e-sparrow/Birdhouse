namespace Birdhouse.Common.Mathematics
{
    public static class LevenshteinDistanceExtensions
    {
        public static int GetLevenshteinDistance(this string self, string other)
        {
            var result = LevenshteinDistanceHelper.GetDistance(self, other);
            return result;
        }
    }
}