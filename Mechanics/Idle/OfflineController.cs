using System;
using Birdhouse.Mechanics.Idle.Interfaces;
using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Tense.Controllers.Interfaces;

namespace Birdhouse.Mechanics.Idle
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