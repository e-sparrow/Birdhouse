namespace ESparrow.Utils.Navigation.Interfaces
{
    public interface IPoint<out T>
    {
        T Subject
        {
            get;
        }
    }
}