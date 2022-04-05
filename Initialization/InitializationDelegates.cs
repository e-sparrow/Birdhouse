using ESparrow.Utils.Initialization.Commands.Interfaces;

namespace ESparrow.Utils.Initialization
{ 
    public delegate void InitializationCallback<TContext, in TCommand>(TCommand command)
        where TCommand : IInitializationCommand<TContext>;
}