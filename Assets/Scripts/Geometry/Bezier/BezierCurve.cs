using UnityEngine;

namespace ESparrow.Utils.Geometry.Bezier
{
    public abstract class BezierCurve
    {
        public abstract Vector3 Start 
        {
            get;
        }

        public abstract Vector3 End
        {
            get;
        }

        public abstract Vector3[] Guides
        {
            get;
        }

        public Vector3 Center => GetPoint(0.5f);

        public abstract Vector3 GetPoint(float t);
    }
}
