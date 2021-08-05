using UnityEngine;

namespace ESparrow.Utils.Interpolation.Interfaces
{
    public interface IInteropolatable<T>
    {
        public T Value
        {
            get;
            set;
        }

        public void Interpolate(T from, T to, float t);
    }
}
