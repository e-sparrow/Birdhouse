using System;
using Birdhouse.Tools.Conditions.Enums;
using Birdhouse.Tools.Conditions.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Conditions
{
    [Serializable]
    public abstract class SerializableConditionBase<T> 
        : ICondition<T>
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