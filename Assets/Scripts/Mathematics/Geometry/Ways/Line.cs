using System;
using UnityEngine;
using ESparrow.Utils.Mathematics.Ways.Interfaces;

namespace ESparrow.Utils.Mathematics.Ways
{
    [Serializable]
    public class Line : ILine
    {
        public Line(Vector3 start, Vector3 end)
        {
            Start = start;
            End = end;
        }

        public Vector3 Evaluate(float progress)
        {
            return Vector3.Lerp(End, Start, progress);
        }
        
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
    }
}
