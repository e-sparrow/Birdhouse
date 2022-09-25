using System;
using Birdhouse.Common.Generic.Spans.Interfaces;
using UnityEngine;

namespace Birdhouse.Common.Generic.Spans
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