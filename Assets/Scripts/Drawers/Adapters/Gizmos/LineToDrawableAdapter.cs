using ESparrow.Utils.Drawers.Interfaces;
using ESparrow.Utils.Mathematics.Ways;
using UnityEngine;

namespace ESparrow.Utils.Drawers.Adapters.AsGizmos
{
    public class LineToDrawableAdapter : ToDrawableAdapterBase<Line>
    {
        public LineToDrawableAdapter(Line self) : base(self)
        {
            
        }

        public override void Draw(IDrawer drawer)
        {
            drawer.DrawLine(Self);
        }
    }
}