using System;
using ESparrow.Utils.Tools.Eases.Interfaces;

namespace ESparrow.Utils.Tools.Eases
{
    public class ReferencedEaseApplier : IReferencedEaseApplier
    {
        public ReferencedEaseApplier(Action<float> onEvaluate, IEase ease)
        {
            _onEvaluate = onEvaluate;
            _ease = ease;
        }

        public ReferencedEaseApplier(IEaseApplier applier)
        {
            _onEvaluate += value => applier.Evaluate(value);
        }

        private readonly Action<float> _onEvaluate;
        private readonly IEase _ease;
        
        public void Evaluate(float progress)
        {
            _onEvaluate.Invoke(_ease.Evaluate(progress));
        }
    }
}
