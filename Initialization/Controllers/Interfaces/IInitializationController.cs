using System.Collections.Generic;
using System.Threading.Tasks;
using ESparrow.ZenjectUtils.Initialization.Commands.Interfaces;
using ESparrow.ZenjectUtils.Initialization.Core;

namespace ESparrow.ZenjectUtils.Initialization.Controllers.Interfaces
{
    public interface IInitializationController<out TContext>
    {
        Task Initialize
        (
            IEnumerable<IInitializationCommand<TContext>> preInitializationCommands, 
            IEnumerable<IInitializationCommand<TContext>> initializationCommands, 
            InitializeCommand initializeCommand
        );
    }
}