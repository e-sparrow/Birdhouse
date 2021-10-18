using UnityEngine;

namespace ESparrow.Utils.Mathematics.Ways.Interfaces
{
    public interface IWay
    {
        /// <summary>
        /// Gets a point on the way by path share in argument.
        /// </summary>
        /// <param name="progress">Path share</param>
        /// <returns></returns>
        public Vector3 Evaluate(float progress);

        /// <summary>
        /// Start of a way.
        /// </summary>
        public Vector3 Start
        {
            get;
        }

        /// <summary>
        /// End of the way.
        /// </summary>
        public Vector3 End
        {
            get;
        }
    }
}
