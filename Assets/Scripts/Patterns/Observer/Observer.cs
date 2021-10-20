using System;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Patterns.Observer.Interfaces;
using ESparrow.Utils.Reflection.MutableMembers.Interfaces;

namespace ESparrow.Utils.Patterns.Observer
{
    public class Observer<T> : ObserverBase<T>
    {
        public Observer(T target) : base(target)
        {
            
        }

        public override bool TryCreateMemberObserver(string name, out IMemberObserver observer)
        {
            observer = null;
            
            if (!typeof(T).TryGetMutableMember(name, out var mutable)) return false;
            
            observer = new MemberObserver(mutable, mutable.GetValue(Target));
            Observers.Add(observer);
            
            return true;
        }

        public override void RemoveMemberObserver(IMemberObserver observer)
        {
            Observers.Remove(observer);
        }
    }
}
