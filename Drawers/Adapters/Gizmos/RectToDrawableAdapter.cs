using ESparrow.Utils.Drawers.Interfaces;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Mathematics.Ways;
using ESparrow.Utils.Tools.Interpolation.Adapters;
using UnityEngine;

namespace ESparrow.Utils.Drawers.Adapters.AsGizmos
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