namespace Birdhouse.Tools.Substitution.Interfaces
{
    public interface ISubstitutionOperator<in TElement>
    {
        void InsertAt(int index, TElement element);
        bool RemoveAt(int index);

        int Count
        {
            get;
        }
    }
}