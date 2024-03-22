using System;
using Birdhouse.Abstractions.Initializables;
using Birdhouse.Abstractions.Misc.Interfaces;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Ticks
{
    public sealed class TickFlowWrapper
        : IFlow
    {
        public TickFlowWrapper(ITickable tickable, ITickProvider provider)
        {
            _tickable = tickable;
            
            _provider = provider;
        }
        
        private readonly ITickable _tickable;

        private readonly ITickProvider _provider;
        
        private IDisposable _tickToken;
        
        public void Initialize()
        {
            if (_tickToken != null)
            {
                throw new AlreadyInitializedException($"Tick flow of type {GetType()} is already initialized!");
            }
            
            _tickToken = _tickable.ConnectTo(_provider);
        }
        
        public void Dispose()
        {
            if (_tickToken == null)
            {
                throw new NotInitializedException($"Tick flow of type {GetType().Name} is not initialized!");
            }
            
            _tickToken.Dispose();
        }
    }
}