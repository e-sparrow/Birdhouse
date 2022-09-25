namespace Birdhouse.Common.Generic.Vectors.Interfaces
{
    public interface IVector<T>
    {
        T this[int dimension]
        {
            get;
            set;
        }

        int Dimensions
        {
            get;
        }
    }

    public interface IVector : IVector<object>
    {
        
    }
}