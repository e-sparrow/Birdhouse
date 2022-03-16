using System;

namespace ESparrow.Utils.Patterns.Observer.Interfaces
{
    public interface IImitator<out T>
    {
        /// <summary>
        /// Event which invokes when exemplar was changed.
        /// </summary>
        public event Action<T> OnExemplarChanged;

        /// <summary>
        /// Tries to subscribe to member by name.
        /// </summary>
        /// <param name="name">Name of the member</param>
        /// <returns>True if observer was created and false otherwise</returns>
        bool TrySubscribeToMember(string name);
        /// <summary>
        /// Unsubscribes from member by observer.
        /// </summary>
        /// <param name="name">Name of the member</param>
        void UnsubscribeFromMember(string name);
    }
}
