using System;
using ESparrow.Utils.Data.Interfaces;
using ESparrow.Utils.Serialization.Interfaces;
using ESparrow.Utils.Tools.Offline.Interfaces;
using ESparrow.Utils.Tools.Tense.Controllers.Interfaces;

namespace ESparrow.Utils.Mechanics.Idle
{
    public class OfflineController : OfflineControllerBase
    {
        public OfflineController(ITenseController<DateTime> tenseController, IIdleController idleController) : base(idleController)
        {
            _tenseController = tenseController;
        }

        private readonly ITenseController<DateTime> _tenseController;
        private readonly IDataTransmitter<DateTime> _lastVisitTransmitter;

        protected override DateTime GetCurrentTime()
        {
            return _tenseController.Now();
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