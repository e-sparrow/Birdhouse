using System;
using Birdhouse.Features.Idle.Interfaces;

namespace Birdhouse.Features.Idle
{
    public abstract class IdleControllerBase : IIdleController
    {
        public abstract void IdleFor(TimeSpan time);
    }
}