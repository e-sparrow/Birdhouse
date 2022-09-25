using UnityEngine;

namespace Birdhouse.Common.Extensions
{
    public static class RectExtensions
    {
        /// <summary>
        /// Checks is small rect contains in big one.
        /// </summary>
        /// <param name="big">Big rect</param>
        /// <param name="small">Small rect</param>
        /// <returns>True if contains and false otherwise</returns>
        public static bool ContainsEntirely(this Rect big, Rect small)
        {
            bool leftDownCorner = big.Contains(new Vector2(small.xMin, small.yMin));
            bool leftUpCorner = big.Contains(new Vector2(small.xMin, small.yMax));
            bool rightDownCorner = big.Contains(new Vector2(small.xMax, small.yMin));
            bool rightUpCorner = big.Contains(new Vector2(small.xMax, small.yMax));

            return leftDownCorner && leftUpCorner && rightDownCorner && rightUpCorner;
        }

        /// <summary>
        /// Gets the position of inner rect clamped in outer one.
        /// </summary>
        /// <param name="inner">Inner rect</param>
        /// <param name="outer">Outer rect</param>
        /// <returns>Position of clamped inner rect</returns>
        public static Vector2 ClampedInRectCenter(this Rect inner, Rect outer)
        {
            float clampedX = Mathf.Clamp(inner.center.x, outer.xMin + inner.size.x / 2, outer.xMax - inner.size.x / 2);
            float clampedY = Mathf.Clamp(inner.center.y, outer.yMin + inner.size.y / 2, outer.yMax - inner.size.y / 2);

            if (inner.size.x > outer.size.x)
            {
                clampedX = outer.center.x;
            }

            if (inner.size.y > outer.size.y)
            {
                clampedY = outer.center.y;
            }

            return new Vector2(clampedX, clampedY);
        }

        /// <summary>
        /// Gets random rect point.
        /// </summary>
        /// <param name="rect">Self rect</param>
        /// <returns>Random rect point</returns>
        public static Vector2 GetRandomRectPoint(this Rect rect)
        {
            var randomX = Random.Range(rect.x, rect.x + rect.width);
            var randomY = Random.Range(rect.y, rect.y + rect.height);

            return new Vector2(randomX, randomY);
        }

        /// <summary>
        /// Gets corners of rect.
        /// </summary>
        /// <param name="rect">Self rect</param>
        /// <returns>Corners of rect</returns>
        public static Vector2[] GetCorners(this Rect rect)
        {   
            return new Vector2[]
            {
                new Vector2(rect.xMin, rect.yMin),
                new Vector2(rect.xMin, rect.yMax),
                new Vector2(rect.xMax, rect.yMax),
                new Vector2(rect.xMax, rect.yMin)
            };
        }

        /// <summary>
        /// Moves rect position to target position.
        /// </summary>
        /// <param name="rect">Target rect</param>
        /// <param name="position">Target position</param>
        /// <returns>Moved rect</returns>
        public static Rect MoveTo(this Rect rect, Vector2 position)
        {
            return new Rect(position, rect.size);
        }

        /// <summary>
        /// Moves rect position by specified delta.
        /// </summary>
        /// <param name="rect">Target rect</param>
        /// <param name="delta">Delta to move relatively current position</param>
        /// <returns>Moved rect</returns>
        public static Rect MoveBy(this Rect rect, Vector2 delta)
        {
            return rect.MoveTo(rect.position + delta);
        }
    }
}
