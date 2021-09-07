using UnityEngine;

namespace ESparrow.Utils.Mathematics.Ways.Interfaces
{
    public interface IWay
    {
        public Vector3 Start
        {
            get;
        }

        public Vector3 End
        {
            get;
        }

        public Vector3 Evaluate(float t);
    }
}
