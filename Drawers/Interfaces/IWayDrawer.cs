using ESparrow.Utils.Mathematics.Ways;
using ESparrow.Utils.Mathematics.Ways.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Drawers.Interfaces
{
    public interface IWayDrawer
    {
        void DrawLine(IWay<Vector3> line);
    }
}
