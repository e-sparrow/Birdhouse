using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Patterns.Singleton;

namespace ESparrow.Utils.Patterns.Observer.Examples
{
    [AddComponentMenu("ESparrow/Utils/Patterns/Observer/Examples/ObservableExample")]
    public class ObservableExample : UnitySingleton<ObservableExample>
    {
        private int _value = 0;

        public int Value => _value;

        public void ChangeValue()
        {
            int newValue = Random.Range(0, 100);
            Debug.Log($"Old value: {_value}, new value: {newValue}");
            _value = newValue;
        }
    }
}
