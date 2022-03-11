namespace ESparrow.Utils.Patterns.Builders.Interfaces
{
    public interface IBuilder<out T>
    {
        T Build();
    }
}