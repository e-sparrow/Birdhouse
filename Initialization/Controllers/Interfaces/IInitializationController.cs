using System.Collections.Generic;
using System.Threading.Tasks;
using ESparrow.Utils.Initialization.Commands.Interfaces;
using ESparrow.Utils.Initialization.Core;

namespace ESparrow.Utils.Initialization.Controllers.Interfaces
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