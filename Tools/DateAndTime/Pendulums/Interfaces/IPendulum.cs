using System;
using System.Threading;

namespace ESparrow.Utils.Tools.DateAndTime.Pendulums.Interfaces
{
    public interface IPendulum
    {
        event Action OnTick;

        void Start();
        void Stop();
    }
}