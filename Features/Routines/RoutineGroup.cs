using Birdhouse.Features.Routines.Interfaces;

namespace Birdhouse.Features.Routines
{
    public class RoutineGroup : IRoutineGroup
    {
        public IRoutine StartRoutine(IRoutineSource source)
        {
            
        }

        public IRoutineGroup CreateSubgroup()
        {
            throw new System.NotImplementedException();
        }

        public void DisposeAll()
        {
            throw new System.NotImplementedException();
        }
    }
}