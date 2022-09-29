namespace Birdhouse.Features.Routines.Interfaces
{
    public interface IRoutineInstruction 
    {
        void SetPaused(bool isPaused);
        
        bool IsFinished();

        bool IsPaused
        {
            get;
        }
    }
}