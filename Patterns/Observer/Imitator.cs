using System;
using System.Linq;
using UnityEngine;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Patterns.Observer
{
    public class Imitator<T> : ImitatorBase<T>
    {
        public Imitator(T imitator, T exemplar) : base(imitator, exemplar)
        {
            
        }

        protected override bool TrySubscribeToMember(Observer<T> observer, string name)
        {
            if (!observer.TryCreateMemberObserver(name, out var memberObserver)) return false;
            
            memberObserver.OnMemberChanged += OnMemberChanged;

            return true;

            void OnMemberChanged(object oldValue, object newValue)
            {
                Apply(memberObserver.Mutable, newValue);
            }
        }

        protected override void UnsubscribeFromMember(Observer<T> observer, string name)
        {
            observer.RemoveMemberObserver(observer.GetObserverByName(name));
        }
    }
}
