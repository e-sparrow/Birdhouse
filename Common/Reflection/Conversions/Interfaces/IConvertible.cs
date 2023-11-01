namespace Birdhouse.Common.Reflection.Conversions.Interfaces
{
    public interface IConvertible<out T>
    {
        T Convert();
    }
}
