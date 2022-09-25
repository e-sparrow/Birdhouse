using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Extensions;
using Birdhouse.Education.Patterns.Observer.Interfaces;

namespace Birdhouse.Education.Patterns.Observer
{
    public abstract class ObserverBase<T> : IObserver
    {
        protected ObserverBase(T target)
        {
            Target = target;
        }

        protected readonly T Target;
        
        protected readonly List<IMemberObserver> Observers = new List<IMemberObserver>();

        public abstract bool TryCreateMemberObserver(string name, out IMemberObserver observer);
        public abstract void RemoveMemberObserver(IMemberObserver observer);
        
        public void Check()
        {
            foreach (var observer in Observers)
            {
                var value = observer.Mutable.GetValue(Target);
                observer.Check(value);
            }
        }

        public IMemberObserver GetObserverByName(string name)
        {
            return Observers.FirstOrDefault(value => value.Mutable.Name == name);
        }

        public IEnumerable<IMemberObserver> CreateAllMemberObservers()
        {
            var members = typeof(T).GetMutableMembers();
            var names = members.Select(value => value.Name);
            
            return CreateMemberObservers(names);
        }

        public void RemoveAllMemberObservers()
        {
            foreach (var observer in Observers)
            {
                RemoveMemberObserver(observer);
            }
        }

        public IEnumerable<IMemberObserver> CreateMemberObservers(params string[] names)
        {
            return CreateMemberObservers(names.AsEnumerable());
        }
        
        public IEnumerable<IMemberObserver> CreateMemberObservers(IEnumerable<string> names)
        {
            var list = new List<IMemberObserver>();
            foreach (var name in names)
            {
                if (TryCreateMemberObserver(name, out var observer))
                {
                    list.Add(observer);
                }
            }

            return list;
        }

        public void RemoveMemberObservers(params IMemberObserver[] observers)
        {
            RemoveMemberObservers(observers.AsEnumerable());
        }

        public void RemoveMemberObservers(IEnumerable<IMemberObserver> observers)
        {
            foreach (var observer in observers)
            {
                RemoveMemberObserver(observer);
            }
        }
    }
}
