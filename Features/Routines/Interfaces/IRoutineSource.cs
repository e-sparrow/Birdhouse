namespace Birdhouse.Features.Routines.Interfaces
{
    public interface IRoutineSource
    {
        IRoutine Create();

        IRoutineSource Append(IRoutineSource source);
    }
}