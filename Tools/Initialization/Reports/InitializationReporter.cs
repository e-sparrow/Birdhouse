using System;
using System.Collections.Generic;
using Birdhouse.Tools.Initialization.Reports.Enums;

namespace Birdhouse.Tools.Initialization.Reports
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