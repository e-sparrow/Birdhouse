using System;
using UnityEngine;
using ESparrow.Utils.Mathematics.Ways.Interfaces;

namespace ESparrow.Utils.Mathematics.Ways.Implementations
{
    [Serializable]
    public class Line : IWay
    {
        public Vector3 Start
        {
            get;
            set;
        }

        public Vector3 End
        {
            get;
            set;
        }

        public Vector3 Delta => End - Start;

        public float Length => Delta.magnitude;

        public Vector3 Evaluate(float t)
        {
            return Vector3.Lerp(End, Start, t);
        }
    }
}
