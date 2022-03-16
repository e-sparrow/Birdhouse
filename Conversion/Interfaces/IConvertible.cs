namespace ESparrow.Utils.Conversion.Interfaces
{
    public interface IConvertible<out T>
    {
        T Convert();
    }
}
