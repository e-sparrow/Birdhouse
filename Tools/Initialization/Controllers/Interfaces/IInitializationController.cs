using System.Collections.Generic;
using System.Threading.Tasks;
using Birdhouse.Tools.Initialization.Commands.Interfaces;

namespace Birdhouse.Tools.Initialization.Controllers.Interfaces
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