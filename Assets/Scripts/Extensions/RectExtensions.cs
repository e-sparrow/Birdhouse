using UnityEngine;

namespace ESparrow.Utils.Extensions
{
    public static class RectExtensions
    {
        public static bool ContainsEntirely(this Rect big, Rect small)
        {
            bool leftDownCorner = big.Contains(new Vector2(small.xMin, small.yMin));
            bool leftUpCorner = big.Contains(new Vector2(small.xMin, small.yMax));
            bool rightDownCorner = big.Contains(new Vector2(small.xMax, small.yMin));
            bool rightUpCorner = big.Contains(new Vector2(small.xMax, small.yMax));

            return leftDownCorner && leftUpCorner && rightDownCorner && rightUpCorner;
        }

        public static Vector2 ClampedInRectCenter(this Rect inside, Rect outside)
        {
            float clampedX = Mathf.Clamp(inside.center.x, outside.xMin + inside.size.x / 2, outside.xMax - inside.size.x / 2);
            float clampedY = Mathf.Clamp(inside.center.y, outside.yMin + inside.size.y / 2, outside.yMax - inside.size.y / 2);

            if (inside.size.x > outside.size.x)
            {
                clampedX = outside.center.x;
            }

            if (inside.size.y > outside.size.y)
            {
                clampedY = outside.center.y;
            }

            return new Vector2(clampedX, clampedY);
        }

        public static Vector2 GetRandomRectPoint(this Rect rect)
        {
            var randomX = Random.Range(rect.x, rect.x + rect.width);
            var randomY = Random.Range(rect.y, rect.y + rect.height);

            return new Vector2(randomX, randomY);
        }

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
    }
}
