using Birdhouse.Common.Mathematics.Geometry.Ways.Interfaces;
using Birdhouse.Tools.Drawers.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Drawers
{
    public abstract class WayDrawerBase : IWayDrawer
    {
        protected WayDrawerBase(int steps)
        {
            _steps = steps;
        }

        private readonly int _steps;

        protected abstract void DrawLine(IWay<Vector3> line, int steps);
 
        public void DrawLine(IWay<Vector3> line)
        {
            DrawLine(line, _steps);
        }
    }
}