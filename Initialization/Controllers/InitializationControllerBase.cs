using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ESparrow.Utils.Extensions;
using ESparrow.ZenjectUtils.Initialization.Commands.Interfaces;
using ESparrow.ZenjectUtils.Initialization.Controllers.Interfaces;
using ESparrow.ZenjectUtils.Initialization.Core;
using ESparrow.ZenjectUtils.Initialization.Core.Interfaces;

namespace ESparrow.ZenjectUtils.Initialization.Controllers
{
    public abstract class InitializationControllerBase<TContext> : IInitializationController<TContext>
    {
        protected InitializationControllerBase(TContext context, IInitializationReporter<TContext> reporter)
        {
            _context = context;
            _reporter = reporter;
        }

        private readonly TContext _context;
        private readonly IInitializationReporter<TContext> _reporter;

        public async Task Initialize
            (IEnumerable<IInitializationCommand<TContext>> preInitializationCommands, IEnumerable<IInitializationCommand<TContext>> initializationCommands, InitializeCommand initializeCommand)
        {
            int current = 0;
            int count = preInitializationCommands.Concat(initializationCommands).Count();
            
            _reporter.Report(_reporter.StartInitializationReport);
            
            _reporter.Report(_reporter.PreInitializationReport.GetInitializationStartReport());
            var preCommandsTime = await DiagnosticHelper.MeasureAsyncExecutionTime(InitializePreCommands());
            _reporter.Report(_reporter.PreInitializationReport.GetInitializationEndReport(preCommandsTime));
            
            _reporter.Report(_reporter.InitializationReport.GetInitializationStartReport());
            var commandsTime = await DiagnosticHelper.MeasureAsyncExecutionTime(InitializeCommands());
            _reporter.Report(_reporter.InitializationReport.GetInitializationEndReport(commandsTime));
            
            async Task InitializePreCommands()
            {
                foreach (var preInitializationCommand in preInitializationCommands)
                {
                    await ExecuteCommand(preInitializationCommand);
                }
            }

            async Task InitializeCommands()
            {
                foreach (var initializationCommand in initializationCommands)
                {
                    await ExecuteCommand(initializationCommand);
                }
            }

            async Task ExecuteCommand(IInitializationCommand<TContext> command)
            {
                try
                {
                    _reporter.Report(_reporter.CommandInitializationReport.GetInitializationStartReport(command));
                    var commandTime = await DiagnosticHelper.MeasureAsyncExecutionTime(command.Initialize(_context));
                    _reporter.Report(_reporter.CommandInitializationReport.GetInitializationEndReport(command, commandTime));

                    current++;
                    initializeCommand.Invoke(current, count);
                }
                catch (Exception exception)
                {  
                    _reporter.Report(_reporter.CommandInitializationExceptionReport.Invoke(exception, command));
                }
            }
        }
    }
}