using System;
using System.Threading;

namespace Birdhouse.Tools.Tense.Pendulums.Interfaces
{
    public interface IPendulum
    {
        event Action OnTick;

        void Start();
        void Stop();
    }
}