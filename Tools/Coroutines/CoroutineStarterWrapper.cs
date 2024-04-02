using System.Collections;
using System.Collections.Generic;
using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines
{
    public sealed class CoroutineStarterWrapper<TFrom>
        : ICoroutineStarter<TFrom>
    {
        public CoroutineStarterWrapper
        (
            ICoroutineStarter<IEnumerator<ICoroutineInstruction>> inner,
            ICoroutineWrapper<TFrom> wrapper
        )
        {
            _inner = inner;
            _wrapper = wrapper;
        }

        private readonly ICoroutineStarter<IEnumerator<ICoroutineInstruction>> _inner;
        private readonly ICoroutineWrapper<TFrom> _wrapper;

        public void Start(TFrom coroutine)
        {
            _inner.Start(_wrapper.Wrap(coroutine));
        }
    }
}