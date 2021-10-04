namespace ESparrow.Utils.Patterns.Observer.Interfaces
{
    public interface IObserver
    {
        IMemberObserver CreateMemberObserver(string name);
        void RemovePropertyObserver(IMemberObserver observer);
    }
}
