using System.Collections.Generic;
using ESparrow.Utils.Initialization.Reports.Enums;
using ESparrow.Utils.Initialization.Reports.Interfaces;

namespace ESparrow.Utils.Initialization.Reports
{
    public abstract class InitializationReporterBase : IInitializationReporter
    {
        protected InitializationReporterBase(IDictionary<EInitializationReportType, string> dictionary)
        {
            _dictionary = dictionary;
        }

        private readonly IDictionary<EInitializationReportType, string> _dictionary;

        protected abstract void Report(string message);
        
        public void Report(EInitializationReportType type)
        {
            var message = _dictionary[type];
            Report(message);
        }
    }
}