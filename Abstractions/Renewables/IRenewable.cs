namespace Birdhouse.Abstractions.Renewables
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