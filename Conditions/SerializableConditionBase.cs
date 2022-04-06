using System;
using ESparrow.Utils.Conditions.Enums;
using ESparrow.Utils.Conditions.Interfaces;
using ESparrow.Utils.Conversion.Enums;
using ESparrow.Utils.Helpers;
using UnityEngine;

namespace ESparrow.Utils.Conditions
{
    [Serializable]
    public abstract class SerializableConditionBase<T> : ICondition<T>
    {
        [SerializeField] private T origin;
        [SerializeField] private EConditionType type;

        protected abstract bool Fit(T origin, T value, EConditionType type);

        public bool Fit(T value)
        {
            return Fit(origin, value, type);
        }
    }
}