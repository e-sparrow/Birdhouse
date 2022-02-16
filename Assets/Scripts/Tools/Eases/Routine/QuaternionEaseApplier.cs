using ESparrow.Utils.Tools.Eases.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Tools.Eases.Routine
{
    public class QuaternionEaseApplier : StartFinishEaseApplierBase<Quaternion>
    {
        public QuaternionEaseApplier(Quaternion start, Quaternion finish, IEase ease) : base(start, finish, ease)
        {
            
        }

        protected override Quaternion Lerp(Quaternion start, Quaternion finish, float progress)
        {
            return Quaternion.Lerp(start, finish, progress);
        }
    }
}