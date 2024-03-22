using System;
using Birdhouse.Features.Remapping.Unity.Enums;
using UnityEngine;

namespace Birdhouse.Features.Remapping.Unity
{
    public static class VectorRemappingExtensions
    {
        public static Vector3 Remap(this Vector3 self, EVector3Map map)
        {
            return map switch
            {
                EVector3Map.XYZ => self,
                EVector3Map.XZY => new Vector3(self.x, self.z, self.y),
                EVector3Map.YXZ => new Vector3(self.y, self.x, self.z),
                EVector3Map.YZX => new Vector3(self.y, self.z, self.x),
                EVector3Map.ZXY => new Vector3(self.z, self.x, self.y),
                EVector3Map.ZYX => new Vector3(self.z, self.y, self.x),
                _ => throw new ArgumentException($"Incorrect vector remap parameter: {map.ToString()}")
            };
        }

        public static Vector2 Inverse(this Vector2 self)
        {
            var result = new Vector2(self.y, self.x);
            return result;
        }

        public static Vector3 XZY(this Vector3 self)
        {
            var result = self.Remap(EVector3Map.XZY);
            return result;
        }

        public static Vector3 YXZ(this Vector3 self)
        {
            var result = self.Remap(EVector3Map.YXZ);
            return result;
        }

        public static Vector3 YZX(this Vector3 self)
        {
            var result = self.Remap(EVector3Map.YZX);
            return result;
        }

        public static Vector3 ZXY(this Vector3 self)
        {
            var result = self.Remap(EVector3Map.ZXY);
            return result;
        }

        public static Vector3 ZYX(this Vector3 self)
        {
            var result = self.Remap(EVector3Map.ZYX);
            return result;
        }
    }
}