using System;
using System.Collections.Generic;
using System.Linq;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Patterns.Observer.Interfaces;
using ESparrow.Utils.Reflection.MutableMembers.Interfaces;

namespace ESparrow.Utils.Patterns.Observer
{
    public abstract class ImitatorBase<T> : IImitator<T>
    {
        /// <summary>
        /// Creates Imitator and forces imitator imitate exemplar's mutable members.
        /// </summary>
        /// <param name="imitator">Object which imitates</param>
        /// <param name="exemplar">Object which imitated</param>
        protected ImitatorBase(T imitator, T exemplar)
        {
            _imitator = imitator;

            Observer = new Observer<T>(exemplar);
        }

        public event Action<T> OnExemplarChanged = _ => { };
        
        private readonly T _imitator;

        protected readonly Observer<T> Observer;

        public abstract bool TrySubscribeToMember(string name);
        public abstract void UnsubscribeFromMember(string name);

        public void SubscribeToAllMembers()
        {
            var mutableMembers = typeof(T).GetMutableMembers();
            foreach (var mutable in mutableMembers)
            {
                TrySubscribeToMember(mutable.Name);
            }
        }

        public void UnsubscribeFromAll()
        {
            Observer.RemoveAllMemberObservers();
        }

        public void SubscribeToMembers(params string[] names)
        {
            SubscribeToMembers(names.AsEnumerable());
        }
        
        public void SubscribeToMembers(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                TrySubscribeToMember(name);
            }
        }

        public void UnsubscribeFromMembers(params string[] names)
        {
            UnsubscribeFromMembers(names.AsEnumerable());
        }

        public void UnsubscribeFromMembers(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                UnsubscribeFromMember(name);
            }
        }

        protected void Apply(IMutable mutable, object newValue)
        {
            mutable.SetValue(_imitator, newValue);
            OnExemplarChanged.Invoke(_imitator);
        }
    }
}