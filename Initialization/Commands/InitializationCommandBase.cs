using System.Threading.Tasks;
using ESparrow.ZenjectUtils.Initialization.Commands.Interfaces;
using ESparrow.ZenjectUtils.Initialization.Core.Interfaces;

namespace ESparrow.ZenjectUtils.Initialization.Commands
{
    public abstract class InitializationCommandBase<TContext> : IInitializationCommand<TContext>
    {
        public abstract Task Initialize(TContext context);
    }
}