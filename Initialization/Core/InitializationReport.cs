using System;
using ESparrow.Utils.Initialization.Core.Interfaces;

namespace ESparrow.Utils.Initialization.Core
{
    public readonly struct InitializationReport : IInitializationReport
    {
        public InitializationReport(Func<string> initializationStartReport, Func<TimeSpan, string> initializationEndReport)
        {
            _initializationStartReport = initializationStartReport;
            _initializationEndReport = initializationEndReport;
        }

        private readonly Func<string> _initializationStartReport;
        private readonly Func<TimeSpan, string> _initializationEndReport;
        
        public string GetInitializationStartReport()
        {
            return _initializationStartReport.Invoke();
        }

        public string GetInitializationEndReport(TimeSpan elapsedTime)
        {
            return _initializationEndReport.Invoke(elapsedTime);
        }
    }
    
    public readonly struct InitializationReport<T> : IInitializationReport<T>
    {
        public InitializationReport(Func<T, string> initializationStartReport, Func<T, TimeSpan, string> initializationEndReport)
        {
            _initializationStartReport = initializationStartReport;
            _initializationEndReport = initializationEndReport;
        }

        private readonly Func<T, string> _initializationStartReport;
        private readonly Func<T, TimeSpan, string> _initializationEndReport;
        
        public string GetInitializationStartReport(T subject)
        {
            return _initializationStartReport.Invoke(subject);
        }

        public string GetInitializationEndReport(T subject, TimeSpan elapsedTime)
        {
            return _initializationEndReport.Invoke(subject, elapsedTime);
        }
    }
    
    public readonly struct InitializationReport<T1, T2> : IInitializationReport<T1, T2>
    {
        public InitializationReport(Func<T1, T2, string> initializationStartReport, Func<T1, T2, TimeSpan, string> initializationEndReport)
        {
            _initializationStartReport = initializationStartReport;
            _initializationEndReport = initializationEndReport;
        }
        
        private readonly Func<T1, T2, string> _initializationStartReport;
        private readonly Func<T1, T2, TimeSpan, string> _initializationEndReport;

        public string GetInitializationStartReport(T1 subject1, T2 subject2)
        {
            return _initializationStartReport.Invoke(subject1, subject2);
        }

        public string GetInitializationEndReport(T1 subject1, T2 subject2, TimeSpan elapsedTime)
        {
            return _initializationEndReport.Invoke(subject1, subject2, elapsedTime);
        }
    }
}