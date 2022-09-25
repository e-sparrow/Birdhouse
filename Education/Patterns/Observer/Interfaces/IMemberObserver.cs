using System;
using Birdhouse.Common.Reflection.MutableMembers.Interfaces;

namespace Birdhouse.Education.Patterns.Observer.Interfaces
{
    public interface IMemberObserver
    {
        /// <summary>
        /// Event which invokes when observable member is changes.
        /// </summary>
        event Action<object, object> OnMemberChanged;

        /// <summary>
        /// Checks is value of member was changed or not.
        /// </summary>
        /// <param name="value">Value to compare with old</param>
        /// <returns>True if old value doesn't equal value in argument and false otherwise</returns>
        bool Check(object value);

        /// <summary>
        /// Mutable member to observe.
        /// </summary>
        public IMutable Mutable
        {
            get;
        }
    }
}
