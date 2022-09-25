using System;
using UnityEngine;

namespace Birdhouse.Common.Mathematics.Geometry.Ways
{
    public class JumpWay : WayBase<Vector3>
    {
        public JumpWay(Vector3 start, Vector3 finish, float height) : base(CreateFunc(start, finish, height))
        {
            
        }

        private static Func<float, Vector3> CreateFunc(Vector3 start, Vector3 finish, float height)
        {
            return Interpolate;

            Vector3 Interpolate(float progress)
            {
                var position = Vector2.Lerp(start, finish, progress);

                var currentHeight = Mathf.Lerp(start.y, finish.y, progress);
                var currentJumpHeight = Mathf.Sin(progress * Mathf.PI) * height;

                position.y = currentHeight + currentJumpHeight;

                return position;
            }
        }
    }
}