using System;
using System.Collections.Generic;
using Birdhouse.Tools.Initialization.Reports.Enums;

namespace Birdhouse.Tools.Initialization.Reports
{
    public class SubjectInitializationReporter<T> : SubjectInitializationReporterBase<T>
    {
        public SubjectInitializationReporter(T subject, Action<string> report) : base(subject, report)
        {
            
        }

        public SubjectInitializationReporter(T subject, Action<string> report, Func<T, string> descriptionFunc) : base(subject, report, descriptionFunc)
        {
            
        }

        public SubjectInitializationReporter(Action<string> report, IDictionary<EInitializationReportType, string> dictionary) : base(report, dictionary)
        {
            
        }
    }
}