namespace ESparrow.Utils.Tools.Substitution.Interfaces
{
    public interface ISubstitutionOperator<in TElement>
    {
        void InsertAt(int index, TElement element);
        void RemoveAt(int index);

        int Count
        {
            get;
        }
    }
}