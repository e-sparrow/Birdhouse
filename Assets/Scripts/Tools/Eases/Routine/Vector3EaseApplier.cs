using ESparrow.Utils.Tools.Eases.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Eases.Routine
{
    public class Vector3EaseApplier : StartFinishEaseApplierBase<Vector3>
    {
        public Vector3EaseApplier(Vector3 start, Vector3 finish, IEase ease) : base(start, finish, ease)
        {
            
        }

        protected override Vector3 Lerp(Vector3 start, Vector3 finish, float progress)
        {
            return Vector3.Lerp(start, finish, progress);
        }
    }
}