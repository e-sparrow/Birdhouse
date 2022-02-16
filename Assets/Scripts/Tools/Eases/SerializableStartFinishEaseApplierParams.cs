using System;
using ESparrow.Utils.Tools.Eases.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Eases
{
    [Serializable]
    public struct SerializableStartFinishEaseApplierParams<T> : IStartFinishEaseApplierParams<T>
    {
        [SerializeField] private T start;
        [SerializeField] private T finish;
        [SerializeField] private AnimationCurve easeCurve;

        public T Start => start;
        public T Finish => finish;
        public IEase Ease => new Ease(easeCurve);
    }
}