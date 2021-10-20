using System;

namespace ESparrow.Utils.Tools.Offline.Interfaces
{
    public interface IIdleController
    {
        void IdleFor(TimeSpan time);
    }
}