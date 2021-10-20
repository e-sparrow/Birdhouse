using System;
using ESparrow.Utils.Serialization.Interfaces;
using ESparrow.Utils.Tools.Offline.Interfaces;

namespace ESparrow.Utils.Tools.Idle
{
    public class OfflineController : OfflineControllerBase
    {
        public OfflineController(IIdleController idleController, ISerializationController serializationController) : base(idleController, serializationController)
        {
            
        }

        protected override DateTime GetCurrentTime()
        {
            return DateTime.UtcNow;
        }
    }
}