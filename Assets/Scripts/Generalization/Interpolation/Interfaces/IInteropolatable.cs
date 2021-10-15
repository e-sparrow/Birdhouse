using UnityEngine;

namespace ESparrow.Utils.Generalization.Interpolation.Interfaces
{
    public interface IInteropolatable<T>
    { 
        /// <summary>
        /// Interpolates between two values by progress variable.
        /// </summary>
        /// <param name="from">Start value</param>
        /// <param name="to">End value</param>
        /// <param name="progress">Progress of interpolation</param>
        void Interpolate(T from, T to, float progress);
        
        /// <summary>
        /// Current value of interpolatable inheritor.
        /// </summary>
        T Value
        {
            get;
            set;
        }
    }
}
