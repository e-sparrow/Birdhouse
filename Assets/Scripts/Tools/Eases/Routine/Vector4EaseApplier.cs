using ESparrow.Utils.Tools.Eases.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Eases.Routine
{
    public class Vector4EaseApplier : StartFinishEaseApplierBase<Vector4>
    {
        public Vector4EaseApplier(Vector4 start, Vector4 finish, IEase ease) : base(start, finish, ease)
        {
            
        }

        protected override Vector4 Lerp(Vector4 start, Vector4 finish, float progress)
        {
            return Vector4.Lerp(start, finish, progress);
        }
    }
}