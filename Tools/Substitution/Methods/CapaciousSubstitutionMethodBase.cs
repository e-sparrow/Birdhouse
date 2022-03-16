using ESparrow.Utils.Tools.Substitution.Enums;
using ESparrow.Utils.Tools.Substitution.Interfaces;

namespace ESparrow.Utils.Tools.Substitution.Methods
{
    public abstract class CapaciousSubstitutionMethodBase<TElement> : SubstitutionMethodBase<TElement>
    {
        protected CapaciousSubstitutionMethodBase(int capacity, ISubstitutionMethod<TElement> method, ISubstitutionOperator<TElement> substitutionOperator) 
            : base(substitutionOperator)
        {
            _capacity = capacity;
            _method = method;
        }

        private readonly int _capacity;
        private readonly ISubstitutionMethod<TElement> _method;

        protected abstract void ReduceTo(int count, ISubstitutionOperator<TElement> substitutionOperator);

        protected override void Replace(TElement element, ISubstitutionOperator<TElement> substitutionOperator)
        {
            if (substitutionOperator.Count > _capacity)
            {
                ReduceTo(_capacity, substitutionOperator);
            }

            var replace = substitutionOperator.Count == _capacity;
            _method.Apply(element, replace);
        }

        public override ESubstitutionType Type => _method.Type;
    }
}