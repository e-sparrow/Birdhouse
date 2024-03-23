namespace Birdhouse.Abstractions.Renewables.Interfaces
{
    public interface IRenewable
    {
        bool IsPaused
        {
            get;
            set;
        }
    }
}