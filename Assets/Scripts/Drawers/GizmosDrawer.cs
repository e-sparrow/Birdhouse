using UnityEngine;
using ESparrow.Utils.Extensions;

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
    }
}
