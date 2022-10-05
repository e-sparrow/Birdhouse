namespace Birdhouse.Abstractions.Interfaces
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