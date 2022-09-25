using System;
using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Extensions;
using Birdhouse.Common.Reflection.MutableMembers.Interfaces;
using Birdhouse.Education.Patterns.Observer.Interfaces;

namespace Birdhouse.Education.Patterns.Observer
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
            _observer = new Observer<T>(exemplar);
        }

        public event Action<T> OnExemplarChanged = _ => { };

        private readonly T _imitator;
        private readonly Observer<T> _observer;

        protected abstract bool TrySubscribeToMember(Observer<T> observer, string name);
        protected abstract void UnsubscribeFromMember(Observer<T> observer, string name);
        
        public bool TrySubscribeToMember(string name)
        {
            return TrySubscribeToMember(_observer, name);
        }

        public void UnsubscribeFromMember(string name)
        {
            UnsubscribeFromMember(_observer, name);
        }

        public void SubscribeToAllMembers()
        {
            var mutableMembers = typeof(T).GetMutableMembers();
            foreach (var mutable in mutableMembers)
            {
                TrySubscribeToMember(_observer, mutable.Name);
            }
        }

        public void UnsubscribeFromAll()
        {
            _observer.RemoveAllMemberObservers();
        }

        public void SubscribeToMembers(params string[] names)
        {
            SubscribeToMembers(names.AsEnumerable());
        }
        
        public void SubscribeToMembers(IEnumerable<string> names)
        {
            foreach (var name in names)
            {
                TrySubscribeToMember(_observer, name);
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
                UnsubscribeFromMember(_observer, name);
            }
        }

        protected void Apply(IMutable mutable, object newValue)
        {
            mutable.SetValue(_imitator, newValue);
            OnExemplarChanged.Invoke(_imitator);
        }
    }
}