using ESparrow.Utils.Extensions;
using ESparrow.Utils.Geometry.Bezier;
using UnityEngine;

namespace ESparrow.Utils.Drawers
{
    public static class GizmosDrawer
    {
        public static void DrawRect(Rect rect)
        {
            var corners = rect.GetCorners();

            Gizmos.DrawLine(corners[0], corners[1]);
            Gizmos.DrawLine(corners[1], corners[2]);
            Gizmos.DrawLine(corners[2], corners[3]);
            Gizmos.DrawLine(corners[3], corners[0]);
        }

        public static void DrawBezierCurve(BezierCurve curve, float step = 0.025f)
        {
            for (float progress = 0; progress < 1; progress += step)
            {
                if (progress == 0) continue;

                var from = curve.GetPoint(progress - step);
                var to = curve.GetPoint(progress);
                Gizmos.DrawLine(from, to);
            }
        }

        public static void DrawBezierCurvePoints
        (
            BezierCurve curve, 
            float pointsRadius, 
            float guidesRadius, 
            Color pointsColor, 
            Color guidesColor
        )
        {
            Gizmos.color = pointsColor;
            Gizmos.DrawSphere(curve.Start, pointsRadius);
            Gizmos.DrawSphere(curve.End, pointsRadius);

            Gizmos.color = guidesColor;
            foreach (var guide in curve.Guides)
            {
                Gizmos.DrawSphere(guide, guidesRadius);
            }
        }
    }
}
