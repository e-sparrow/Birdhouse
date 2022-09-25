using Birdhouse.Tools.Substitution.Interfaces;

namespace Birdhouse.Tools.Substitution
{
    public class SubstitutionController<TElement> : SubstitutionControllerBase<TElement>
    {
        public SubstitutionController(ISubstitutionMethod<TElement> substitutionMethod) : base(substitutionMethod)
        {
            
        }

        protected override void Add(TElement element, ISubstitutionMethod<TElement> method)
        {
            method.Apply(element);
        }
    }
}