using Birdhouse.Tools.Substitution.Enums;

namespace Birdhouse.Tools.Substitution.Interfaces
{
    public interface ISubstitutionMethod<in TElement>
    {
        void Apply(TElement element, bool replace = true);

        ESubstitutionType Type
        {
            get;
        }
    }
}