using System;
using System.Linq;
using UnityEngine;
using ESparrow.Utils.Helpers;

namespace ESparrow.Utils.Patterns.Observer
{
    public class Imitator<T> where T : class
    {
        public event Action<T> OnValueChanged;

        private T _value;
        private T _subject;

        private readonly T _listener;

        private Observer<T> _observer;

        public Imitator(T subject)
        {
            Init(subject);
        }

        public Imitator(T subject, T listener)
        {
            Init(subject);
            _listener = listener;
        }

        public void SubscribeToAll()
        {
            SubscribeToAllBeside();
        }

        public void SubscribeToAllBeside(params string[] names)
        {
            var filteredNames = GetAllMutableMembersBeside(names);
            _observer.CreateMemberObservers(filteredNames).ToList().ForEach(value => value.OnMemberChanged += OnMemberChanged);
        }

        public void SubscribeToMembers(params string[] names)
        {
            foreach (var name in names)
            {
                SubscribeToMember(name);
            }
        }

        public void SubscribeToMember(string name)
        {
            _observer.CreateMemberObserver(name).OnMemberChanged += OnMemberChanged;
        }

        public void UnsubscribeFromAll()
        {
            UnsubscribeFromAllBeside();
        }

        public void UnsubscribeFromAllBeside(params string[] names)
        {
            var filteredNames = GetAllMutableMembersBeside(names);
            _observer.CreateMemberObservers(filteredNames).ToList().ForEach(value => value.OnMemberChanged -= OnMemberChanged);
        }

        public void UnsubscribeFromMembers(params string[] names)
        {
            foreach (var name in names)
            {
                UnsubscribeFromMember(name);
            }
        }

        public void UnsubscribeFromMember(string name)
        {
            _observer.RemovePropertyObserver(name);
        }

        private string[] GetAllMutableMembersBeside(params string[] names)
        {
            var memberNames = typeof(T).GetMutableMemberNames(ReflectionHelper.AnyBindingFlags);
            return memberNames.Where(value => !names.Contains(value)).ToArray();
        }

        private void Init(T subject)
        {
            _subject = subject;
            _value = _subject;

            _observer = new Observer<T>(_subject);
        }

        private void OnMemberChanged(string name, object before, object after)
        {
            object value;

            var field = typeof(T).GetField(name, ReflectionHelper.AnyBindingFlags);
            if (field != null)
            {
                value = field.GetValue(_subject);
                field.SetValue(_value, value);

                if (_listener != null)
                {
                    field.SetValue(_listener, value);
                }
            }
            else
            {
                var property = typeof(T).GetProperty(name, ReflectionHelper.AnyBindingFlags);

                value = field.GetValue(_subject);
                property.SetValue(_value, value);

                if (_listener != null)
                {
                    property.SetValue(_listener, value);
                }
            }

            OnValueChanged?.Invoke(_value);
        }
    }
}
