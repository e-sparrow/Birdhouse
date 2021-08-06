using UnityEngine;

namespace ESparrow.Utils.Tools.Interpolation.Interfaces
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
