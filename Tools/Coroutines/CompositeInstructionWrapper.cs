using System.Collections.Generic;
using Birdhouse.Tools.Coroutines.Interfaces;

namespace Birdhouse.Tools.Coroutines
{
    public sealed class CompositeInstructionWrapper
        : ICompositeInstructionWrapper
    {
        private readonly ICollection<IInstructionWrapper> _wrappers
            = new List<IInstructionWrapper>();

        public bool TryWrap(object target, out ICoroutineInstruction result)
        {
            result = null;
            
            foreach (var wrapper in _wrappers)
            {
                var canWrap = wrapper.TryWrap(target, out result);
                if (canWrap)
                {
                    return true;
                }
            }

            return false;
        }

        public ICompositeInstructionWrapper Append(IInstructionWrapper other)
        {
            _wrappers.Add(other);
            return this;
        }
    }
}