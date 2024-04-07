using System;
using Birdhouse.Abstractions.Initializables;
using Birdhouse.Abstractions.Misc;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Ticks
{
    public abstract class TickFlowBase  
        : IFlow
    {
        private IDisposable _tickToken;

        protected abstract void Tick(float deltaTime);

        protected virtual ITickProvider GetTickProvider()
        {
            var result = TickHelper.GetDefaultTickProvider();
            return result;
        }

        // These methods made to make sure tick token will be initialized and disposed correctly in inheritors
        protected virtual void OnInitialize() { }
        protected virtual void OnDispose() { }

        public void Initialize()
        {
            if (_tickToken != null)
            {
                throw new AlreadyInitializedException($"Tick flow of type {GetType()} is already initialized!");
            }
            
            _tickToken = GetTickProvider()
                .RegisterTick(Tick);
            
            OnInitialize();
        }
        
        public void Dispose()
        {
            if (_tickToken == null)
            {
                throw new NotInitializedException($"Tick flow of type {GetType().Name} is not initialized!");
            }
            
            _tickToken.Dispose();
            
            OnDispose();
        }
    }
}