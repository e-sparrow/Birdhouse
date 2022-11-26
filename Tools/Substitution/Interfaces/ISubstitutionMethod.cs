namespace Birdhouse.Tools.Substitution.Interfaces
{
    public interface ISubstitutionMethod<in TElement>
    {
        void Apply(TElement element, bool replace = true);
    }
}