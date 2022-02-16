using System.Collections.Generic;
using ESparrow.Utils.Tools.Eases.Interfaces;

namespace ESparrow.Utils.Tools.Eases
{
    public class FacadeEaseApplier<T> : IEaseApplier<T>
    {
        public FacadeEaseApplier(T target)
        {
            _target = target;
        }

        private readonly T _target;
        
        private readonly List<IReferencedEaseApplier> _appliers = new List<IReferencedEaseApplier>();

        public FacadeEaseApplier<T> AddApplier(IReferencedEaseApplier applier)
        {
            _appliers.Add(applier);
            return this;
        }

        public FacadeEaseApplier<T> AddApplier<TOther>(IEaseApplier<TOther> applier)
        {
            _appliers.Add(new ReferencedEaseApplier(applier as IEaseApplier));
            return this;
        }

        public T Evaluate(float progress)
        {
            _appliers.ForEach(value => value.Evaluate(progress));
            return _target;
        }
    }
}