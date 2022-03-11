using UnityEngine;
using ESparrow.Utils.Mathematics.Ways;

namespace ESparrow.Utils.Drawers
{
    public class GizmosDrawer : DrawerBase
    {
        public GizmosDrawer(int steps) : base(steps)
        {
            
        }

        protected override void DrawLine(StraightLine<Vector3> line, int steps)
        {
            for (int i = 0; i < steps; i++)
            {
                var from = (float) i / steps;
                var to = (float) (i + 1) / steps;
                
                Gizmos.DrawLine(line.Evaluate(from), line.Evaluate(to));
            }
        }
    }
}
