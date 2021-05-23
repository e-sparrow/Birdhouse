using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Managers;

namespace ESparrow.Utils.Patterns.Observer
{
    public class Observer<T>
    {
        private T _target;

        private readonly List<MemberObserver> _observers = new List<MemberObserver>();

        public Observer(T target)
        {
            Init(target);
        }

        public MemberObserver[] CreateMemberObservers(params string[] names)
        {
            return CollectionsHelper.ForEachResult(names, CreateMemberObserver).ToArray();
        }

        public MemberObserver CreateMemberObserver(string name)
        {
            if (CheckField(name, out var _, out var fieldValue))
            {
                var observer = new MemberObserver(name, MemberTypes.Field, fieldValue);
                _observers.Add(observer);

                return observer;
            }

            if (CheckProperty(name, out _, out var propertyValue))
            {
                var observer = new MemberObserver(name, MemberTypes.Property, fieldValue);
                _observers.Add(observer);

                return observer;
            }

            Debug.LogWarning($"{typeof(T).Name} has no member with name {name}");
            return null;
        }

        public void RemovePropertyObserver(string name)
        {
            RemovePropertyObserver(GetObserverByName(name));
        }

        public void RemovePropertyObserver(MemberObserver observer)
        {
            _observers.Remove(observer);
        }

        public MemberObserver GetObserverByName(string name)
        {
            return _observers.FirstOrDefault(value => value.Name == name);
        }

        private bool CheckField(string name, out FieldInfo field, out object value)
        {
            field = typeof(T).GetField(name, ReflectionHelper.AnyBindingFlags);

            bool exist = field != null;
            value = exist ? field.GetValue(_target) : null;

            return exist;
        }

        private bool CheckProperty(string name, out PropertyInfo property, out object value)
        {
            property = typeof(T).GetProperty(name, ReflectionHelper.AnyBindingFlags);

            bool exist = property != null;
            value = exist ? property.GetValue(_target) : null;

            return exist;
        }

        private void Init(T target)
        {
            _target = target;
            UnityMessagesManager.Instance.UpdateHandler += Check;
        }

        private void Check()
        {
            foreach (var observer in _observers)
            {
                switch (observer.Type)
                {
                    case MemberTypes.Field:
                        var field = typeof(T).GetField(observer.Name, ReflectionHelper.AnyBindingFlags);
                        var fieldValue = field.GetValue(_target);
                        observer.Check(fieldValue);
                        break;

                    case MemberTypes.Property:
                        var property = typeof(T).GetProperty(observer.Name, ReflectionHelper.AnyBindingFlags);
                        var propertyValue = property.GetValue(_target);
                        observer.Check(propertyValue);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public class MemberObserver
        {
            public MemberObserver(string name, MemberTypes type, object lastValue)
            {
                _name = name;
                _type = type;

                _lastValue = lastValue;
            }

            public event Action<string, object, object> OnMemberChanged;

            protected readonly string _name;
            private readonly MemberTypes _type;

            protected object _lastValue;

            public string Name => _name;
            public MemberTypes Type => _type;

            public void Check(object value)
            {
                if (!value.Equals(_lastValue))
                {
                    OnChange(value);
                }
            }

            protected void OnChange(object newValue)
            {
                OnMemberChanged?.Invoke(_name, _lastValue, newValue);
                _lastValue = newValue;
            }
        }
    }
}
