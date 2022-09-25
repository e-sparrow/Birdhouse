namespace Birdhouse.Common.Generic.References.Interfaces
{
    public interface IReference<T>
    {
        T Value
        {
            get;
            set;
        }
    }
}