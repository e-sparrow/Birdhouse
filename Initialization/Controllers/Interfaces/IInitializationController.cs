using System.Collections.Generic;
using System.Threading.Tasks;
using ESparrow.Utils.Initialization.Commands.Interfaces;
using ESparrow.Utils.Initialization.Reports;

namespace ESparrow.Utils.Initialization.Controllers.Interfaces
{
    public interface IInitializationController<TContext, TCommand> where TCommand : IInitializationCommand<TContext>
    {
        Task Initialize
        (
            IEnumerable<TCommand> initializationCommands, 
            InitializationCallback<TContext, TCommand> callback
        );
    }
}