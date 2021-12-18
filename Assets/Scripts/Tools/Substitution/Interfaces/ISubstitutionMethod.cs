using ESparrow.Utils.Tools.Substitution.Enums;

namespace ESparrow.Utils.Tools.Substitution.Interfaces
{
    public interface ISubstitutionMethod<in TElement>
    {
        void Apply(TElement element);

        ESubstitutionType Type
        {
            get;
        }
    }
}