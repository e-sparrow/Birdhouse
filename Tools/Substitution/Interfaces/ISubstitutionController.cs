namespace Birdhouse.Tools.Substitution.Interfaces
{
    public interface ISubstitutionController<in TElement>
    {
        void Add(TElement element);
    }
}