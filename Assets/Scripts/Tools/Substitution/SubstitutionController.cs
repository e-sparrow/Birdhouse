using ESparrow.Utils.Tools.Substitution.Interfaces;

namespace ESparrow.Utils.Tools.Substitution
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