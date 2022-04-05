using System;
using System.Collections.Generic;
using ESparrow.Utils.Initialization.Reports.Enums;

namespace ESparrow.Utils.Initialization.Reports
{
    public class InitializationReporter : InitializationReporterBase
    {
        public InitializationReporter(Action<string> report) : this(report, Dictionary)
        {
            
        }
        
        public InitializationReporter(Action<string> report, IDictionary<EInitializationReportType, string> dictionary) : base(dictionary)
        {
            _report = report;
        }

        private static readonly IDictionary<EInitializationReportType, string> Dictionary = new Dictionary<EInitializationReportType, string>()
        {
            [EInitializationReportType.Start] = "Initialization started",
            [EInitializationReportType.Finish] = "Initialization finished",
            [EInitializationReportType.Exception] = "Initialization failed"
        };

        private readonly Action<string> _report;

        protected override void Report(string message)
        {
            _report.Invoke(message);
        }
    }
}