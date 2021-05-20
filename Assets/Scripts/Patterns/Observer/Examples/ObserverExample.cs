using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Patterns.Singleton;

namespace ESparrow.Utils.Patterns.Observer.Examples
{
    [AddComponentMenu("ESparrow/Utils/Patterns/Observer/Examples/ObserverExample")]
    public class ObserverExample : UnitySingleton<ObserverExample>
    {
        private Observer<ObservableExample> _observer;

        private void OnMemberChanged(string name, object oldValue, object newValue)
        {
            Debug.Log($"ObservableExample changed. Property named \"{name}\" changed from {oldValue} to {newValue}");
        }

        private void OnEnable()
        {
            _observer = new Observer<ObservableExample>(ObservableExample.Instance);
            _observer.CreateMemberObserver("_value").OnMemberChanged += OnMemberChanged;
            _observer.CreateMemberObserver("Value").OnMemberChanged += OnMemberChanged;
        }

        private void OnDisable()
        {
            _observer = null;
        }
    }
}
