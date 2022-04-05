using System.Threading.Tasks;
using ESparrow.Utils.Initialization.Commands.Interfaces;
using ESparrow.Utils.Initialization.Reports.Interfaces;

namespace ESparrow.Utils.Initialization.Commands
{
    public abstract class InitializationCommandBase<TContext> : IInitializationCommand<TContext>
    {
        public abstract Task Initialize(TContext context);
    }
}