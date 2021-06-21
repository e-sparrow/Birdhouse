using System;
using System.Linq;
using UnityEngine;
using ESparrow.Utils.Extensions;

namespace ESparrow.Utils.Geometry.Bezier
{
    [Serializable]
    public class QuadraticBezierCurve : BezierCurve
    {
        [SerializeField] public Vector3 start; // Начальная точка.
        [SerializeField] public Vector3 end; // Конечная точка.

        [SerializeField] public Vector3 guide; // Направляющая.

        public override Vector3 Start => start;
        public override Vector3 End => end;

        public override Vector3[] Guides => guide.AsSingleCollection().ToArray();

        public QuadraticBezierCurve()
        {

        }

        public QuadraticBezierCurve(Vector3 start, Vector3 end)
        {
            this.start = start;
            this.end = end;

            guide = Vector3.Lerp(start, end, 0.5f);
        }

        public QuadraticBezierCurve(Vector3 start, Vector3 end, Vector3 guide)
        {
            this.start = start;
            this.end = end;
            this.guide = guide;
        }

        public override Vector3 GetPoint(float t)
        {
            return Mathf.Pow((1 - t), 2) * start + (1 - t) * t * guide + t * t * end;
        }
    }
}
