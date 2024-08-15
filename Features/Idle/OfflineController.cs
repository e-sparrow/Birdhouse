using System;
using Birdhouse.Features.Idle.Interfaces;
using Birdhouse.Common.Reflection.Conversions;
using Birdhouse.Common.Reflection.Conversions.Routine;
using Birdhouse.Tools.Data.Transmission;
using Birdhouse.Tools.Data.Transmission.Interfaces;
using Birdhouse.Tools.Data.Transmission.Routine;
using Birdhouse.Tools.Tense;
using Birdhouse.Tools.Tense.Providers.Interfaces;

namespace Birdhouse.Features.Idle
{
    public class OfflineController : OfflineControllerBase
    {
        public OfflineController
        (
            IIdleController idleController, 
            ITenseProvider<DateTime> tenseProvider = null,
            IDataTransmitter<DateTime> lastVisitTransmitter = null
        ) : base(idleController)
        {
            tenseProvider ??= TenseHelper
                .UtcNowTenseProvider
                .Value;
            
            lastVisitTransmitter ??= GetDefaultVisitTransmitter();
            
            _tenseProvider = tenseProvider;
            _lastVisitTransmitter = lastVisitTransmitter;
        }

        private readonly ITenseProvider<DateTime> _tenseProvider;
        private readonly IDataTransmitter<DateTime> _lastVisitTransmitter;

        private static IDataTransmitter<DateTime> GetDefaultVisitTransmitter()
        {
            var transmitter = new PlayerPrefsStringDataTransmitter(IdleConstants.PlayerPrefsOfflineControllerKey);
            var conversion = new ReversibleDateTimeToStringConversion().Swap();
            
            var result = transmitter.Convert(conversion);
            return result;
        }

        protected override DateTime GetCurrentTime()
        {
            var result =  _tenseProvider.Now();
            return result;
        }

        protected override void SetLastVisit(DateTime lastVisit)
        {
            _lastVisitTransmitter.Upload(lastVisit);
        }

        protected override bool TryGetLastVisit(out DateTime lastVisit)
        {
            lastVisit = default;
            
            var isValid = _lastVisitTransmitter.IsValid();
            if (isValid)
            {
                lastVisit = _lastVisitTransmitter.Download();
            }

            return isValid;
        }
    }
}