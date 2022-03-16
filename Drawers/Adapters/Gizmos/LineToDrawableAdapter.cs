using ESparrow.Utils.Drawers.Interfaces;
using ESparrow.Utils.Mathematics.Ways;
using UnityEngine;

namespace ESparrow.Utils.Drawers.Adapters.AsGizmos
{
    public class LineToDrawableAdapter : ToDrawableAdapterBase<StraightLine<Vector3>>
    {
        public LineToDrawableAdapter(StraightLine<Vector3> self) : base(self)
        {
            
        }

        public override void Draw(IDrawer drawer)
        {
            drawer.DrawLine(Self);
        }
    }
}