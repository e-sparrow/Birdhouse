using System;
using Birdhouse.Tools.Gizmo.Enums;
using Birdhouse.Tools.Gizmo.Interfaces;

namespace Birdhouse.Tools.Gizmo
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