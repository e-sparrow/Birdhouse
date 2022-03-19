using System;
using ESparrow.ZenjectUtils.Initialization.Commands.Interfaces;
using ESparrow.ZenjectUtils.Initialization.Core.Interfaces;
using UnityEngine;

namespace ESparrow.ZenjectUtils.Initialization.Core
{
    public class InitializationReporter<TContext> : InitializationReporterBase<TContext>
    {
        public InitializationReporter
        (
            Action<string> report = null, 
            IInitializationReport preInitializationReport = null, 
            IInitializationReport initializationReport = null, 
            IInitializationReport<IInitializationCommand<TContext>> commandInitializationReport = null, 
            Func<Exception, IInitializationCommand<TContext>, string> commandInitializationExceptionReport = null, 
            string startInitializationReport = DefaultStartInitializationReport
        ) : base
        (
            report = Debug.Log, 
            preInitializationReport ?? DefaultPreInitializationReport, 
            initializationReport ?? DefaultInitializationReport, 
            commandInitializationReport ?? DefaultCommandInitializationReport, 
            commandInitializationExceptionReport ?? DefaultCommandInitializationExceptionReport, 
            startInitializationReport
        )
        {
            
        }
        
        private const string DefaultStartInitializationReport = "Started game initializing...";

        private static readonly IInitializationReport DefaultPreInitializationReport 
            = new InitializationReport(() => $"Started preinitialization", elapsed => $"Ended preinitialization in {elapsed}");
        
        private static readonly IInitializationReport DefaultInitializationReport 
            = new InitializationReport(() => $"Started initialization", elapsed => $"Ended initialization in {elapsed}");

        private static readonly IInitializationReport<IInitializationCommand<TContext>> DefaultCommandInitializationReport
            = new InitializationReport<IInitializationCommand<TContext>>
            (command => $"Started initialization of command of type {command.GetType().Name}",
                (command, elapsed) => $"Ended initialization of command of type {command.GetType().Name} in {elapsed}");
        
        private static readonly Func<Exception, IInitializationCommand<TContext>, string> DefaultCommandInitializationExceptionReport
            = (exception, command) => $"Failed to initialize command of type {command.GetType().Name}. Reason exception message: {exception.Message}";
    }
}