using ESparrow.Utils.Mathematics.Ways;

namespace ESparrow.Utils.Drawers.Interfaces
{
    public interface IDrawer
    {
        void Draw(IDrawable drawable);

        void DrawLine(Line line);
    }
}
