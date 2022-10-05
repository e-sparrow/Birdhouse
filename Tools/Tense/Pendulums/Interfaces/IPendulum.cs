using System;
using System.Threading;
using Birdhouse.Abstractions.Interfaces;

namespace Birdhouse.Tools.Tense.Pendulums.Interfaces
{
    public interface IPendulum
    {
        event Action OnTick;
    }
}