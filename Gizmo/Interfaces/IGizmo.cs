using ESparrow.Utils.Gizmo.Enums;

namespace ESparrow.Utils.Patterns.Listening.Interfaces
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