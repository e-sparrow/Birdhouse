namespace Birdhouse.Features.Routines.Interfaces
{
    public interface IRoutineGroup
    {
        IRoutine StartRoutine(IRoutineSource source);
        IRoutineGroup CreateSubgroup();
        
        void DisposeAll();
    }
}