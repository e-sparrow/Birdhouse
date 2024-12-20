using System;
using System.Collections.Generic;
using Birdhouse.Tools.Coroutines.Interfaces;
using Birdhouse.Tools.Ticks.Interfaces;

namespace Birdhouse.Tools.Coroutines
{
    // TODO: Cancellation tokens for coroutine starters
    public sealed class TickCoroutineStarter
        : ICoroutineStarter<IEnumerator<ICoroutineInstruction>>, IDisposable
    {
        public TickCoroutineStarter(ITickProvider provider)
        {
            _tickToken = provider.RegisterTick(Tick);
        }

        private readonly IDisposable _tickToken;
        
        private readonly IList<ICoroutineInstruction> _runners = new List<ICoroutineInstruction>();

        // TODO: Start coroutine with disposable tokens
        public void Start(IEnumerator<ICoroutineInstruction> coroutine)
        {
            var runner = new CoroutineRunner(coroutine);
            _runners.Add(runner);
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