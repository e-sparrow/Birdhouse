using Birdhouse.Abstractions.Composites.Abstractions;

namespace Birdhouse.Abstractions.Composites
{
    public static class CompositeExtensions
    {
        public static TComposite Append<TComposite, TAppendable>
            (this TAppendable self, TAppendable other)
            where TComposite : IComposite<TComposite, TAppendable>, new()
        {
            var result = new TComposite()
                .Append(self)
                .Append(other);

            return result;
        }

        public static TComposite Append<TComposite, TAppendable>
            (this TComposite self, TAppendable other)
            where TComposite : IComposite<TComposite, TAppendable>
        {
            var result = self.Append(other);
            return result;
        }
    }
}