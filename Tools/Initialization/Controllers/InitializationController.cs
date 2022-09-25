using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Birdhouse.Tools.Initialization.Commands.Interfaces;
using Birdhouse.Tools.Initialization.Reports;
using Birdhouse.Tools.Initialization.Reports.Enums;
using Birdhouse.Tools.Initialization.Reports.Interfaces;
using Birdhouse.Tools.Logging;
using Birdhouse.Tools.Logging.Enums;
using Birdhouse.Tools.Logging.Interfaces;
using Debug = UnityEngine.Debug;

namespace Birdhouse.Tools.Initialization.Controllers
{
    public class InitializationController<TContext> : InitializationControllerBase<TContext, IInitializationCommand<TContext>>
    {
        public InitializationController(TContext context) : this(context, new InitializationReporter(Debug.Log))
        {
            
        }
        
        public InitializationController(TContext context, IInitializationReporter reporter) : base(context, reporter)
        {
            
        }

        private readonly ILogger _logger = new Logger();
        private readonly IInitializationReporter _selfReporter = new InitializationReporter(Debug.Log);

        protected override async Task InitializeCommand(IInitializationCommand<TContext> command, TContext context)
        {
            try
            {
                _selfReporter.Report(EInitializationReportType.Start);

                var stopwatch = new Stopwatch();
                
                stopwatch.Start();
                await command.Initialize(context);
                stopwatch.Stop();
                
                _logger.Log($"Finished initialization of command {command.GetType().Name} in {stopwatch.Elapsed.ToString()}", ELogType.Message);
                
                _selfReporter.Report(EInitializationReportType.Finish);
            }
            catch
            {
                _selfReporter.Report(EInitializationReportType.Exception);
            }
        }

        protected override void ReportTime(TimeSpan elapsed)
        {
            _logger.Log($"Finished initialization in {elapsed.ToString()}", ELogType.Message);
        }
    }
}