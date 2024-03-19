namespace Birdhouse.Abstractions.Providers.Interfaces
{
    public interface IConditionalProvider<TOut>
    {
        bool TryGetValue(out TOut result);
    }

    public interface IConditionalProvider<in TIn, TOut>
    {
        bool TryGetValue(TIn parameter, out TOut result);
    }

    public interface IConditionalProvider<in TIn1, in TIn2, TOut>
    {
        bool TryGetValue(TIn1 parameter1, TIn2 parameter2, out TOut result);
    }
}