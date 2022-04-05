using System;
using System.Threading;

namespace ESparrow.Utils.Tools.Tense.Pendulums.Interfaces
{
    public interface IPendulum
    {
        event Action OnTick;

        void Start();
        void Stop();
    }
}