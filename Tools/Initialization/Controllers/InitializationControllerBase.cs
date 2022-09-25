using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Birdhouse.Tools.Initialization.Commands.Interfaces;
using Birdhouse.Tools.Initialization.Controllers.Interfaces;
using Birdhouse.Tools.Initialization.Reports.Enums;
using Birdhouse.Tools.Initialization.Reports.Interfaces;

namespace Birdhouse.Tools.Initialization.Controllers
{
    public abstract class InitializationControllerBase<TContext, TCommand> : IInitializationController<TContext, TCommand> 
        where TCommand : IInitializationCommand<TContext>
    {
        protected InitializationControllerBase(TContext context, IInitializationReporter reporter)
        {
            _context = context;
            _reporter = reporter;
        }

        private readonly TContext _context;
        private readonly IInitializationReporter _reporter;

        protected abstract Task InitializeCommand(TCommand command, TContext context);
        protected abstract void ReportTime(TimeSpan elapsed);

        public async Task Initialize
            (IEnumerable<TCommand> initializationCommands, InitializationCallback<TContext, TCommand> callback)
        {
            try
            {
                _reporter.Report(EInitializationReportType.Start);
                
                var stopwatch = new Stopwatch();
                
                stopwatch.Start();
                await InitializeCommands();
                stopwatch.Stop();
                
                ReportTime(stopwatch.Elapsed);
                
                _reporter.Report(EInitializationReportType.Finish);
            }
            catch
            {
                _reporter.Report(EInitializationReportType.Exception);
            }

            async Task InitializeCommands()
            {
                foreach (var initializationCommand in initializationCommands)
                {
                    await InitializeCommand(initializationCommand, _context);
                    callback.Invoke(initializationCommand);
                }
            }
        }
    }
}