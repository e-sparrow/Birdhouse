using Birdhouse.Common.Extensions;
using Birdhouse.Common.Mathematics.Geometry.Ways;
using Birdhouse.Tools.Drawers.Interfaces;
using Birdhouse.Tools.Interpolation.Adapters;
using UnityEngine;

namespace Birdhouse.Tools.Drawers.Adapters.Gizmos
{
    public class RectToDrawableAdapter : ToDrawableAdapterBase<Rect>
    {
        public RectToDrawableAdapter(Rect self) : base(self)
        {
            
        }

        public override void Draw(IWayDrawer wayDrawer)
        {
            var corners = Self.GetCorners();

            var interpolator = new Vector3ToInterpolatorAdapter();

            wayDrawer.DrawLine(new StraightLine<Vector3>(interpolator, corners[0], corners[1]));
            wayDrawer.DrawLine(new StraightLine<Vector3>(interpolator, corners[1], corners[2]));
            wayDrawer.DrawLine(new StraightLine<Vector3>(interpolator, corners[2], corners[3]));
            wayDrawer.DrawLine(new StraightLine<Vector3>(interpolator, corners[3], corners[0]));
        }
    }
}