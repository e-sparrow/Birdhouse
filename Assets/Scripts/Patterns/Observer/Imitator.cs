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

        public override bool TrySubscribeToMember(string name)
        {
            if (!Observer.TryCreateMemberObserver(name, out var observer)) return false;
            
            observer.OnMemberChanged += OnMemberChanged;

            return true;

            void OnMemberChanged(object oldValue, object newValue)
            {
                Apply(observer.Mutable, newValue);
            }
        }

        public override void UnsubscribeFromMember(string name)
        {
            Observer.RemoveMemberObserver(Observer.GetObserverByName(name));
        }
    }
}
