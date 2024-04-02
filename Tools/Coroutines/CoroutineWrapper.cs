using System.Collections;
using System.Collections.Generic;
using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines
{
    public readonly struct CoroutineWrapper
        : ICoroutineWrapper<IEnumerator>
    {
        public CoroutineWrapper(IInstructionWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        private readonly IInstructionWrapper _wrapper;
        
        public IEnumerator<ICoroutineInstruction> Wrap(IEnumerator input)
        {
            while (input.MoveNext())
            {
                var canWrap = _wrapper.TryWrap(input.Current, out var result);
                if (canWrap)
                {
                    yield return result;
                }
                else if (input.Current is IEnumerator enumerator)
                {
                    // TODO: Избавиться от рекурсии
                    var wrapped = Wrap(enumerator);
                    while (wrapped.MoveNext())
                    {
                        yield return wrapped.Current;
                    }
                }
            }
        }
    }
}