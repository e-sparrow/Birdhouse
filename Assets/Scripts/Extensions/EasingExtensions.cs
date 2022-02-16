using ESparrow.Utils.Tools.Eases;
using ESparrow.Utils.Tools.Eases.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class EasingExtensions
    {
        public static IEaseApplier<Transform> CreateTransformEasingApplier(this Transform self, IEaseApplier<Vector3> positionApplier, IEaseApplier<Quaternion> rotationApplier, IEaseApplier<Vector3> scaleApplier)
        {
            var applier = new FacadeEaseApplier<Transform>(self);
            applier.AddApplier(positionApplier).AddApplier(rotationApplier).AddApplier(scaleApplier);

            return applier;
        }
    }
}
