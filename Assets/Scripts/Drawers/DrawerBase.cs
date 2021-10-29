using ESparrow.Utils.Drawers.Interfaces;
using ESparrow.Utils.Mathematics.Ways;

namespace ESparrow.Utils.Drawers
{
    public abstract class DrawerBase : IDrawer
    {
        public abstract void DrawLine(Line line);

        public void Draw(IDrawable drawable)
        {
            drawable.Draw(this);
        }
    }
}