namespace ESparrow.Utils.Patterns.Observer.Interfaces
{
    public interface IObserver
    {
        /// <summary>
        /// Checks all the member observers.
        /// </summary>
        void Check();
        
        /// <summary>
        /// Tries to create new member observer by name.
        /// </summary>
        /// <param name="name">Name of member</param>
        /// <param name="observer">Created observer</param>
        /// <returns>True if observer is created and false otherwise</returns>
        bool TryCreateMemberObserver(string name, out IMemberObserver observer);
        /// <summary>
        /// Removes property observer.
        /// </summary>
        /// <param name="observer">Observer to remove</param>
        void RemoveMemberObserver(IMemberObserver observer);
    }
}
