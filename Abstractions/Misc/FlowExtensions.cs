namespace Birdhouse.Abstractions.Misc
{
    public static class FlowExtensions
    {
        public static ICompositeFlow Append(this IFlow self, IFlow other)
        {
            var result = new CompositeFlow()
                .Append(self)
                .Append(other);
            
            return result;
        }
    }
}