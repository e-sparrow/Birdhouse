using Birdhouse.Tools.Gizmo.Enums;

namespace Birdhouse.Tools.Gizmo.Interfaces
{
    public interface IGizmo
    {
        void Draw();
        
        EGizmoDrawType Type
        {
            get;
        }

        bool IsActive
        {
            get;
        }
    }
}