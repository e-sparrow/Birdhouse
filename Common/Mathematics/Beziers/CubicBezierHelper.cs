using UnityEngine;

namespace Birdhouse.Common.Mathematics
{
    public static class CubicBezierHelper
    {
        public static Vector3 Evaluate(Vector3 start, Vector3 controlA, Vector3 controlB, Vector3 end, float t)
        {
            t = Mathf.Clamp01(t);
            var u = 1 - t;
            return u * u * u * start +
                   3 * u * u * t * controlA +
                   3 * u * t * t * controlB +
                   t * t * t * end;
        }

        public static Vector3 GetTangent(Vector3 start, Vector3 controlA, Vector3 controlB, Vector3 end, float t)
        {
            t = Mathf.Clamp01(t);
            var u = 1 - t;
            var tangent = 3 * u * u * (controlA - start) +
                          6 * u * t * (controlB - controlA) +
                          3 * t * t * (end - controlB);

            return tangent.normalized;
        }

        public static Vector3 GetAcceleration(Vector3 start, Vector3 controlA, Vector3 controlB, Vector3 end, float t)
        {
            t = Mathf.Clamp01(t);
            var u = 1 - t;
            return 6 * u * (controlB - 2 * controlA + start) +
                   6 * t * (end - 2 * controlB + controlA);
        }

        public static float GetCurvature(Vector3 start, Vector3 controlA, Vector3 controlB, Vector3 end, float t)
        {
            t = Mathf.Clamp01(t);
            var u = 1 - t;

            var first = 3 * u * u * (controlA - start) +
                        6 * u * t * (controlB - controlA) +
                        3 * t * t * (end - controlB);

            var second = 6 * u * (controlB - 2 * controlA + start) +
                         6 * t * (end - 2 * controlB + controlA);

            if (first.magnitude < 0.0001f) return 0f;

            return Vector3.Cross(first, second).magnitude / Mathf.Pow(first.magnitude, 3);
        }

        public static Vector3[] GeneratePoints(Vector3 start, Vector3 controlA, Vector3 controlB, Vector3 end, int segments)
        {
            segments = Mathf.Max(1, segments);
            var points = new Vector3[segments + 1];

            for (var i = 0; i <= segments; i++)
            {
                var t = i / (float)segments;
                points[i] = Evaluate(start, controlA, controlB, end, t);
            }

            return points;
        }

        public static float GetLength(Vector3 start, Vector3 controlA, Vector3 controlB, Vector3 end, int segments = 50)
        {
            var points = GeneratePoints(start, controlA, controlB, end, segments);
            var length = 0f;

            for (var i = 0; i < points.Length - 1; i++)
            {
                length += Vector3.Distance(points[i], points[i + 1]);
            }

            return length;
        }

        public static Vector3 GetPointAtDistance(Vector3 start, Vector3 controlA, Vector3 controlB, Vector3 end, float distance, int segments = 100)
        {
            var totalLength = GetLength(start, controlA, controlB, end, segments);
            var targetT = distance / totalLength;
            return Evaluate(start, controlA, controlB, end, targetT);
        }

        public static float GetTAtDistance(Vector3 start, Vector3 controlA, Vector3 controlB, Vector3 end, float distance, int segments = 100)
        {
            var totalLength = GetLength(start, controlA, controlB, end, segments);
            return Mathf.Clamp01(distance / totalLength);
        }

        public static void Split
        (
            Vector3 start, Vector3 controlA, Vector3 controlB, Vector3 end, float t,
            out Vector3 leftStart, out Vector3 leftControlA, out Vector3 leftControlB, out Vector3 leftEnd,
            out Vector3 rightStart, out Vector3 rightControlA, out Vector3 rightControlB, out Vector3 rightEnd
        )
        {
            var q0 = Vector3.Lerp(start, controlA, t);
            var q1 = Vector3.Lerp(controlA, controlB, t);
            var q2 = Vector3.Lerp(controlB, end, t);

            var r0 = Vector3.Lerp(q0, q1, t);
            var r1 = Vector3.Lerp(q1, q2, t);

            var s0 = Vector3.Lerp(r0, r1, t);

            leftStart = start;
            leftControlA = q0;
            leftControlB = r0;
            leftEnd = s0;

            rightStart = s0;
            rightControlA = r1;
            rightControlB = q2;
            rightEnd = end;
        }

        public static Bounds GetBounds(Vector3 start, Vector3 controlA, Vector3 controlB, Vector3 end, int segments = 20)
        {
            var points = GeneratePoints(start, controlA, controlB, end, segments);
            var bounds = new Bounds(points[0], Vector3.zero);

            for (var i = 1; i < points.Length; i++)
            {
                bounds.Encapsulate(points[i]);
            }

            return bounds;
        }

        public static Vector3 GetClosestPoint(Vector3 start, Vector3 controlA, Vector3 controlB, Vector3 end, Vector3 target, int iterations = 10)
        {
            var bestT = 0f;
            var bestDistance = float.MaxValue;

            for (var i = 0; i <= 20; i++)
            {
                var t = i / 20f;
                var point = Evaluate(start, controlA, controlB, end, t);
                var distance = Vector3.Distance(point, target);

                if (!(distance < bestDistance)) continue;

                bestDistance = distance;
                bestT = t;
            }

            var step = 0.05f;
            for (var i = 0; i < iterations; i++)
            {
                var tMin = Mathf.Max(0, bestT - step);
                var tMax = Mathf.Min(1, bestT + step);

                for (var t = tMin; t <= tMax; t += step / 2f)
                {
                    var point = Evaluate(start, controlA, controlB, end, t);
                    var distance = Vector3.Distance(point, target);

                    if (!(distance < bestDistance)) continue;

                    bestDistance = distance;
                    bestT = t;
                }

                step *= 0.5f;
            }

            return Evaluate(start, controlA, controlB, end, bestT);
        }
    }
}