using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Managers;
using ESparrow.Utils.Patterns.Observer.Interfaces;

namespace ESparrow.Utils.Patterns.Observer
{
    public class Observer<T> : IObserver
    {
        private T _target;

        private readonly List<IMemberObserver> _observers = new List<IMemberObserver>();

        public Observer(T target)
        {
            Init(target);
        }

        public IMemberObserver[] CreateMemberObservers(params string[] names)
        {
            return CollectionsHelper.ForEachResult(names, CreateMemberObserver).ToArray();
        }

        public IMemberObserver CreateMemberObserver(string name)
        {
            if (CheckField(name, out var _, out var fieldValue))
            {
                var observer = new MemberObserver(name, MemberTypes.Field, fieldValue);
                _observers.Add(observer);

                return observer;
            }
            else if (CheckProperty(name, out _, out var propertyValue))
            {
                var observer = new MemberObserver(name, MemberTypes.Property, propertyValue);
                _observers.Add(observer);

                return observer;
            }

            Debug.LogWarning($"{typeof(T).Name} has no member with name {name}");
            return null;
        }

        public void RemovePropertyObserver(IMemberObserver observer)
        {
            _observers.Remove(observer);
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
    }
}
