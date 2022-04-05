using System;
using System.Collections.Generic;
using ESparrow.Utils.Initialization.Reports.Enums;

namespace ESparrow.Utils.Initialization.Reports
{
    public abstract class SubjectInitializationReporterBase<T> : InitializationReporterBase
    {
        public SubjectInitializationReporterBase(T subject, Action<string> report) 
            : this(subject, report, value => value.ToString())
        {
            
        }

        public SubjectInitializationReporterBase(T subject, Action<string> report, Func<T, string> descriptionFunc)
            : this(report, CreateDictionary(subject, descriptionFunc))
        {
            
        }

        public SubjectInitializationReporterBase(Action<string> report, IDictionary<EInitializationReportType, string> dictionary) : base(dictionary)
        {
            _report = report;
        }

        private readonly Action<string> _report;

        private static IDictionary<EInitializationReportType, string> CreateDictionary(T subject, Func<T, string> descriptionFunc)
        {
            var description = descriptionFunc.Invoke(subject);

            return new Dictionary<EInitializationReportType, string>()
            {
                [EInitializationReportType.Start] = $"Started initialization of {description}",
                [EInitializationReportType.Finish] = $"Finished initialization of {description}",
                [EInitializationReportType.Exception] = $"Failed initialization of {description}"
            };
        }

        protected override void Report(string message)
        {
            _report.Invoke(message);
        }
    }
}