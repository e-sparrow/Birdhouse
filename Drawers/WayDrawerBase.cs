using ESparrow.Utils.Drawers.Interfaces;
using ESparrow.Utils.Mathematics.Ways;
using ESparrow.Utils.Mathematics.Ways.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Drawers
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