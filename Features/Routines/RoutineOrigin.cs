using Birdhouse.Education.Patterns.Singleton.Mono;
using Birdhouse.Features.Routines.Interfaces;

namespace Birdhouse.Features.Routines
{
    public class RoutineOrigin : MonoSingleton<RoutineOrigin>, IRoutineGroup
    {
        public IRoutine StartRoutine(IRoutineSource source)
        {
            throw new System.NotImplementedException();
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