using ESparrow.Utils.Tools.Eases.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Eases.Routine
{
    public class Vector2EaseApplier : StartFinishEaseApplierBase<Vector2>
    {
        public Vector2EaseApplier(Vector2 start, Vector2 finish, IEase ease) : base(start, finish, ease)
        {
            
        }

        protected override Vector2 Lerp(Vector2 start, Vector2 finish, float progress)
        {
            return Vector2.Lerp(start, finish, progress);
        }
    }
}
