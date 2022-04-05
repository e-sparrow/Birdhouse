using System;
using ESparrow.Utils.Gizmo.Enums;
using ESparrow.Utils.Patterns.Listening.Interfaces;

namespace ESparrow.Utils.Gizmo
{
    public readonly struct Gizmo : IGizmo
    {
        public Gizmo(Action draw, EGizmoDrawType type, Func<bool> active)
        {
            _draw = draw;
            Type = type;
            _active = active;
        }
        
        private readonly Action _draw;
        private readonly Func<bool> _active;

        public void Draw()
        {
            _draw.Invoke();
        }

        public EGizmoDrawType Type
        {
            get;
        }

        public bool IsActive => _active.Invoke();
    }
}