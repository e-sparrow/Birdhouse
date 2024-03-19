namespace Birdhouse.Common.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] AsSingleArray<T>(this T self)
        {
            var result = new T[1]
            {
                self
            };

            return result;
        }
    }
}