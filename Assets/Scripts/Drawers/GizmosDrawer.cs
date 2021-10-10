using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Mathematics.Ways;

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

        public static void DrawLine(Line line)
        {
            Gizmos.DrawLine(line.Start, line.End);
        }

        public static void DrawBrokenLine(BrokenLine line, bool close = false)
        {
            var points = new List<Vector3>(line.Points);
            for (int i = 1; i < points.Count; i++)
            {
                Gizmos.DrawLine(points[i - 1], points[i]);
            }

            if (close)
            {
                Gizmos.DrawLine(points.Last(), points.First());
            }
        }
    }
}
