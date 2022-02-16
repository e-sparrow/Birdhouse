using System.Collections.Generic;
using ESparrow.Utils.Tools.Eases.Interfaces;

namespace ESparrow.Utils.Tools.Eases
{
    public class ReferencedFacadeApplier : IReferencedEaseApplier
    {
        public ReferencedFacadeApplier(IEnumerable<IReferencedEaseApplier> appliers)
        {
            _appliers = new List<IReferencedEaseApplier>(appliers);
        }

        private readonly List<IReferencedEaseApplier> _appliers;
        
        public void Evaluate(float progress)
        {
            _appliers.ForEach(value => value.Evaluate(progress));
        }
    }
}