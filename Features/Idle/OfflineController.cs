using System;
using Birdhouse.Mechanics.Idle.Interfaces;
using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Tense.Controllers.Interfaces;

namespace Birdhouse.Mechanics.Idle
{
    public class OfflineController : OfflineControllerBase
    {
        public OfflineController(ITenseProvider<DateTime> tenseProvider, IIdleController idleController) : base(idleController)
        {
            _tenseProvider = tenseProvider;
        }

        private readonly ITenseProvider<DateTime> _tenseProvider;
        private readonly IDataTransmitter<DateTime> _lastVisitTransmitter;

        protected override DateTime GetCurrentTime()
        {
            var result =  _tenseProvider.Now();
            return result;
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