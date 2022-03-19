using System;
using ESparrow.Utils.Initialization.Commands.Interfaces;
using ESparrow.Utils.Initialization.Core.Interfaces;

namespace ESparrow.Utils.Initialization.Core
{
    public abstract class InitializationReporterBase<TContext> : IInitializationReporter<TContext>
    {
        protected InitializationReporterBase
        (
            Action<string> report, 
            IInitializationReport preInitializationReport, 
            IInitializationReport initializationReport,
            IInitializationReport<IInitializationCommand<TContext>> commandInitializationReport, 
            Func<Exception, IInitializationCommand<TContext>, string> commandInitializationExceptionReport, 
            string startInitializationReport
        )
        {
            _report = report;
            
            PreInitializationReport = preInitializationReport;
            InitializationReport = initializationReport;
            CommandInitializationReport = commandInitializationReport;
            CommandInitializationExceptionReport = commandInitializationExceptionReport;
            StartInitializationReport = startInitializationReport;
        }

        private readonly Action<string> _report;
        
        public void Report(string message)
        {
            _report.Invoke(message);
        }

        public IInitializationReport PreInitializationReport
        {
            get;
        }

        public IInitializationReport InitializationReport
        {
            get;
        }

        public IInitializationReport<IInitializationCommand<TContext>> CommandInitializationReport
        {
            get;
        }

        public Func<Exception, IInitializationCommand<TContext>, string> CommandInitializationExceptionReport
        {
            get;
        }

        public string StartInitializationReport
        {
            get;
        }
    }
}