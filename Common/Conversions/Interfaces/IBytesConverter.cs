namespace Birdhouse.Common.Conversions.Interfaces
{
    public interface IBytesConverter<out TOut>
    {
        TOut Convert(byte[] bytes);
    }
}