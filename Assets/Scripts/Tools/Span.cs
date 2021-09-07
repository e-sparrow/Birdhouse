using System;
using UnityEngine;

namespace ESparrow.Utils.Tools
{
    [Serializable]
    public struct Span<T> where T : IEquatable<T>
    {
        [SerializeField] private T min;
        [SerializeField] private T max;

        public T Min
        {
            get => min;
            set => min = value;
        }

        public T Max
        {
            get => max;
            set => max = value;
        }

        public Span(T min, T max)
        {
            this.min = min;
            this.max = max;
        }
    }
}
