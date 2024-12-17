using UnityEngine;

namespace Birdhouse.Common.Mathematics.Rays
{
    public static class RayExtensions
    {
        public static Vector3 GetRayPointAtHeight(this Ray self, float height)
        {
            var distance = self.origin.y - height;
            var result = self.origin + self.direction * distance;
            var ratio = (self.origin.y - result.y) / distance;
            distance /= ratio;
            result = self.origin + self.direction * distance;

            return result;
        }
    }
}