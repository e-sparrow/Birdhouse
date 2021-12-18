using System;
using ESparrow.Utils.Serialization.Interfaces;
using ESparrow.Utils.Tools.Offline.Interfaces;
using Global.Interfaces;

namespace ESparrow.Utils.Mechanics.Idle
{
    public class OfflineController : OfflineControllerBase
    {
        public OfflineController(ITimeManager timeManager, IIdleController idleController) : base(idleController)
        {
            _timeManager = timeManager;
        }

        private readonly ITimeManager _timeManager;

        protected override DateTime GetCurrentTime()
        {
            return _timeManager.GetCurrentDateTime();
        }

        protected override void SetLastVisit(DateTime lastVisit)
        {
            throw new NotImplementedException();
        }

        protected override bool TryGetLastVisit(out DateTime lastVisit)
        {
            throw new NotImplementedException();
        }
    }
}