using Birdhouse.Common.Mathematics.Geometry.Ways.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Drawers.Interfaces
{
    public interface IWayDrawer
    {
        void DrawLine(IWay<Vector3> line);
    }
}
