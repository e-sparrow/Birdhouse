using UnityEngine;

namespace Birdhouse.Common.Mathematics
{
    public static class QuadBezierHelper
    {
        public static Vector3 Evaluate(Vector3 start, Vector3 control, Vector3 end, float t)
        {
            t = Mathf.Clamp01(t);
            var u = 1 - t;
            return u * u * start + 2 * u * t * control + t * t * end;
        }

        public static Vector3 GetTangent(Vector3 start, Vector3 control, Vector3 end, float t)
        {
            t = Mathf.Clamp01(t);
            var u = 1 - t;
            var tangent = 2 * u * (control - start) + 2 * t * (end - control);
            return tangent.normalized;
        }

        public static Vector3[] GeneratePoints(Vector3 start, Vector3 control, Vector3 end, int segments)
        {
            segments = Mathf.Max(1, segments);
            var points = new Vector3[segments + 1];

            for (var i = 0; i <= segments; i++)
            {
                var t = i / (float)segments;
                points[i] = Evaluate(start, control, end, t);
            }

            return points;
        }

        public static float GetLength(Vector3 start, Vector3 control, Vector3 end, int segments = 50)
        {
            var points = GeneratePoints(start, control, end, segments);
            var length = 0f;

            for (var i = 0; i < points.Length - 1; i++)
            {
                length += Vector3.Distance(points[i], points[i + 1]);
            }

            return length;
        }

        public static Vector3 GetPointAtDistance(Vector3 start, Vector3 control, Vector3 end, float distance, int segments = 100)
        {
            var totalLength = GetLength(start, control, end, segments);
            var targetT = distance / totalLength;
            return Evaluate(start, control, end, targetT);
        }

        public static void Split
        (
            Vector3 start, Vector3 control, Vector3 end, float t,
            out Vector3 leftStart, out Vector3 leftControl, out Vector3 leftEnd,
            out Vector3 rightStart, out Vector3 rightControl, out Vector3 rightEnd
        )
        {
            var q0 = Vector3.Lerp(start, control, t);
            var q1 = Vector3.Lerp(control, end, t);
            var r0 = Vector3.Lerp(q0, q1, t);

            leftStart = start;
            leftControl = q0;
            leftEnd = r0;

            rightStart = r0;
            rightControl = q1;
            rightEnd = end;
        }

        public static bool IsLinear(Vector3 start, Vector3 control, Vector3 end, float tolerance = 0.01f)
        {
            var direction = (end - start).normalized;
            var toControl = control - start;
            var perpendicular = toControl - Vector3.Project(toControl, direction);
            return perpendicular.magnitude < tolerance;
        }
    }
}