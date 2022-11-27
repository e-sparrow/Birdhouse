namespace Birdhouse.Abstractions.Renewables.Interfaces
{
    public interface IRenewable
    {
        void SetPaused(bool isPaused);
        
        bool IsPaused
        {
            get;
        }
    }
}