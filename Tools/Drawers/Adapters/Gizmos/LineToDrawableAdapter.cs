using Birdhouse.Common.Mathematics.Geometry.Ways;
using Birdhouse.Tools.Drawers.Interfaces;
using UnityEngine;

namespace Birdhouse.Tools.Drawers.Adapters.Gizmos
{
    public class LineToDrawableAdapter : ToDrawableAdapterBase<StraightLine<Vector3>>
    {
        public LineToDrawableAdapter(StraightLine<Vector3> self) : base(self)
        {
            
        }

        public override void Draw(IWayDrawer wayDrawer)
        {
            wayDrawer.DrawLine(Self);
        }
    }
}