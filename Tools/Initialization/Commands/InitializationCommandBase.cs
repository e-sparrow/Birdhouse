using System.Threading.Tasks;
using Birdhouse.Tools.Initialization.Commands.Interfaces;

namespace Birdhouse.Tools.Initialization.Commands
{
    public abstract class InitializationCommandBase<TContext> : IInitializationCommand<TContext>
    {
        public abstract Task Initialize(TContext context);
    }
}