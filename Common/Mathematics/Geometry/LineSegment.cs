using UnityEngine;

namespace Birdhouse.Common.Mathematics.Geometry
{
    public class Line
    {
        public float a;
        public float b;
        public float c;

        public Line()
        {

        }

        public Line(float a, float b, float c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }

    public static class LineSegment
    {
        public static bool AreCrossing(Vector2 from1, Vector2 to1, Vector2 from2, Vector2 to2, out Vector2 crossPoint)
        {
            float v1 = CrossProduct(to2 - from2, from1 - from2);
            float v2 = CrossProduct(to2 - from2, to1 - from2);
            float v3 = CrossProduct(to1 - from1, from2 - from1);
            float v4 = CrossProduct(to1 - from1, to2 - from1);

            crossPoint = Vector2.zero;
            if (v1 * v2 < 0 && v3 * v4 < 0)
            {
                var line1 = LineEquation(from1, to1);
                var line2 = LineEquation(from2, to2);

                crossPoint = CrossingPoint(line1, line2);

                return true;
            }

            return false;
        }

        private static float CrossProduct(Vector2 vector1, Vector2 vector2)
        {
            return CrossProduct(vector1.x, vector1.y, vector2.x, vector2.y);
        }

        private static float CrossProduct(float x1, float y1, float x2, float b2)
        {
            return x1 * b2 - x2 * y1;
        }

        private static Line LineEquation(Vector2 vector1, Vector2 vector2)
        {
            float yDifference = vector2.y - vector1.y;
            float xDifference = vector2.x - vector1.x;
            float differenceProduct = -vector1.x * (yDifference) + vector1.y * (xDifference);

            return new Line(yDifference, -xDifference, differenceProduct);
        }

        private static Vector2 CrossingPoint(Line line1, Line line2)
        {
            var point = new Vector2();

            float abProduct = line1.a * line2.b - line1.b * line2.a;
            float bcProduct = -line1.c * line2.b + line1.b * line2.c;
            float acProduct = -line1.a * line2.c + line1.c * line2.a;

            point.x = bcProduct / abProduct;
            point.y = acProduct / abProduct;

            return point;
        }
    }
}
