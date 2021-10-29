using ESparrow.Utils.Drawers.Interfaces;
using ESparrow.Utils.Extensions;
using ESparrow.Utils.Mathematics.Ways;
using UnityEngine;

namespace ESparrow.Utils.Drawers.Adapters.AsGizmos
{
    public class RectToDrawableAdapter : ToDrawableAdapterBase<Rect>
    {
        public RectToDrawableAdapter(Rect self) : base(self)
        {
            
        }

        public override void Draw(IDrawer drawer)
        {
            var corners = Self.GetCorners();

            drawer.DrawLine(new Line(corners[0], corners[1]));
            drawer.DrawLine(new Line(corners[1], corners[2]));
            drawer.DrawLine(new Line(corners[2], corners[3]));
            drawer.DrawLine(new Line(corners[3], corners[0]));
        }
    }
}