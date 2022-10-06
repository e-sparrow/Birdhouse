using System;

namespace Birdhouse.Features.Idle.Interfaces
{
    public interface IIdleController
    {
        void IdleFor(TimeSpan time);
    }
}