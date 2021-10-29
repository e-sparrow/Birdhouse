using System.Linq;
using System.Collections.Generic;
using ESparrow.Utils.Drawers.Interfaces;
using UnityEngine;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Mathematics.Ways;

namespace ESparrow.Utils.Drawers
{
    public class GizmosDrawer : DrawerBase
    {
        public GizmosDrawer(Color color)
        {
            Gizmos.color = color;
        }

        public override void DrawLine(Line line)
        {
            Gizmos.DrawLine(line.Start, line.End);
        }
    }
}
