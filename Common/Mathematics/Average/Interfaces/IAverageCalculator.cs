namespace Birdhouse.Common.Mathematics.Average.Interfaces
{
    public interface IAverageCalculator<T>
    {
        T Add(T value);

        T Current
        {
            get;
        }
    }
}