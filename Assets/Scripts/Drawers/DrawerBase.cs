using ESparrow.Utils.Mathematics.Ways;
using UnityEditor.U2D.Path;
using UnityEngine;
using IDrawer = ESparrow.Utils.Drawers.Interfaces.IDrawer;

namespace ESparrow.Utils.Drawers
{
    public abstract class DrawerBase : IDrawer
    {
        protected DrawerBase(int steps)
        {
            _steps = steps;
        }

        private readonly int _steps;

        protected abstract void DrawLine(StraightLine<Vector3> line, int steps);
 
        public void DrawLine(StraightLine<Vector3> line)
        {
            DrawLine(line, _steps);
        }
    }
}