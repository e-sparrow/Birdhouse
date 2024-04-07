namespace Birdhouse.Abstractions.Parsers
{
    public interface IParser<in TIn, TOut>
    {
        bool TryParse(TIn argument, out TOut result);
    }
}