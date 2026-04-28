using UnityEngine;

namespace Birdhouse.Common.Mathematics
{
    public static class VectorExtensions
    {
        public static Vector2 GetDominantAxis(this Vector2 self) 
            => Mathf.Abs(self.x) > Mathf.Abs(self.y) ? new Vector2(self.x, 0f)
                : Mathf.Abs(self.x) < Mathf.Abs(self.y) ? new Vector2(0f, self.y)
                : Vector2.zero;
        
        public static Vector3 GetDominantAxis(this Vector3 self) 
            => Mathf.Abs(self.x) > Mathf.Abs(self.y) && Mathf.Abs(self.x) > Mathf.Abs(self.z) ? new Vector3(self.x, 0f, 0f)
             : Mathf.Abs(self.y) > Mathf.Abs(self.x) && Mathf.Abs(self.y) > Mathf.Abs(self.z) ? new Vector3(0f, self.y, 0f)
             : Mathf.Abs(self.z) > Mathf.Abs(self.x) && Mathf.Abs(self.z) > Mathf.Abs(self.y) ? new Vector3(0f, 0f, self.z)
             : Vector3.zero;

        public static Vector2 GetDominantDirection(this Vector2 self) => self == Vector2.zero ? self : GetDominantAxis(self).normalized;
        public static Vector3 GetDominantDirection(this Vector3 self) => self == Vector3.zero ? self : GetDominantAxis(self).normalized;
    }
}