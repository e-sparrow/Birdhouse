using System;
using ESparrow.Utils.Initialization.Commands.Interfaces;

namespace ESparrow.Utils.Initialization.Core.Interfaces
{
    public interface IInitializationReporter<out TContext>
    {
        void Report(string message);

        IInitializationReport PreInitializationReport
        {
            get;
        }

        IInitializationReport InitializationReport
        {
            get;
        }

        IInitializationReport<IInitializationCommand<TContext>> CommandInitializationReport
        {
            get;
        }

        Func<Exception, IInitializationCommand<TContext>, string> CommandInitializationExceptionReport
        {
            get;
        }

        string StartInitializationReport
        {
            get;
        }
    }
}