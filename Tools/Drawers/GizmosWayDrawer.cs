using Birdhouse.Common.Mathematics.Geometry.Ways.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Drawers
{
    public class GizmosWayDrawer : WayDrawerBase
    {
        public GizmosWayDrawer(int steps) : base(steps)
        {
            
        }

        protected override void DrawLine(IWay<Vector3> line, int steps)
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
