namespace Birdhouse.Abstractions.Composites
{
    public static class CompositeExtensions
    {
        public static TComposite Append<TComposite, TAppendable>
            (this TAppendable self, TAppendable other)
            where TComposite : ICreatableComposite<TComposite, TAppendable>, TAppendable, new()
        {
            var result = new TComposite()
                .Append(self)
                .Append(other);

            return result;
        }

        public static TComposite Append<TComposite, TAppendable>
            (this TComposite self, TAppendable other)
            where TComposite : ICreatableComposite<TComposite, TAppendable>, TAppendable, new()
        {
            var result = self.Append(other);
            return result;
        }
    }
}