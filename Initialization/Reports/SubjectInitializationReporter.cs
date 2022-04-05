using System;
using System.Collections.Generic;
using ESparrow.Utils.Initialization.Reports.Enums;

namespace ESparrow.Utils.Initialization.Reports
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