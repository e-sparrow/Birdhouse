namespace Birdhouse.Tools.Conversion.Interfaces
{
    public interface IConvertible<out T>
    {
        T Convert();
    }
}
