namespace Birdhouse.Abstractions.Parsers.Interfaces
{
    public interface IParser<in TIn, TOut>
    {
        bool TryParse(TIn argument, out TOut result);
    }
}