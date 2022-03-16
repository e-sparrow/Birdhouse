using System;
using ESparrow.Utils.Generic.Spans.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Generic.Spans
{
    [Serializable]
    public class SerializableSpan<T> : ISpan<T>
    {
        [SerializeField] private T min;
        [SerializeField] private T max;

        public T Min => min;
        public T Max => max;
    }
}