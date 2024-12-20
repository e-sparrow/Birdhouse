using System;
using System.Collections.Generic;
using Birdhouse.Common.Extensions;
using Birdhouse.Tools.Coroutines.Interfaces;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Coroutines
{
    public sealed class TickCoroutineStarter
        : ICoroutineStarter<IEnumerator<ICoroutineInstruction>, IDisposable>, ICoroutineStarter<IEnumerator<ICoroutineInstruction>>, IDisposable
    {
        public TickCoroutineStarter(ITickProvider provider)
        {
            _tickToken = provider.RegisterTick(Tick);
        }

        private readonly IDisposable _tickToken;
        
        private readonly IList<ICoroutineInstruction> _runners = new List<ICoroutineInstruction>();

        
        public IDisposable Start(IEnumerator<ICoroutineInstruction> coroutine)
        {
            var runner = new CoroutineRunner(coroutine);
            var token = _runners.AddAsDisposable(runner);
            return token;
        }

        void ICoroutineStarter<IEnumerator<ICoroutineInstruction>>.Start(IEnumerator<ICoroutineInstruction> coroutine)
        {
            Start(coroutine);
        }
 
        private void Tick(float deltaTime)
        {
            var incomingRunners = new List<ICoroutineInstruction>(_runners);
            foreach (var runner in incomingRunners)
            {
                var isOver = runner.IsFinished(deltaTime);
                if (isOver)
                {
                    _runners.Remove(runner);
                }
            }
        }

        public void Dispose()
        {
            _tickToken.Dispose();
        }
    }
}