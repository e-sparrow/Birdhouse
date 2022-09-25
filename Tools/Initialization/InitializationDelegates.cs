using Birdhouse.Tools.Initialization.Commands.Interfaces;

namespace Birdhouse.Tools.Initialization
{ 
    public delegate void InitializationCallback<TContext, in TCommand>(TCommand command)
        where TCommand : IInitializationCommand<TContext>;
}