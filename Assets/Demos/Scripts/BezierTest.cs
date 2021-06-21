using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ESparrow.Utils.Drawers;
using ESparrow.Utils.Geometry.Bezier;

namespace Demos
{
    [ExecuteAlways]
    [AddComponentMenu("Demos/BezierTest")]
    public class BezierTest : MonoBehaviour
    {
        [SerializeField] private QuadraticBezierCurve curve;

        private void OnDrawGizmos()
        {
            GizmosDrawer.DrawBezierCurvePoints(curve, .05f, .05f, Color.blue, Color.green);

            Gizmos.color = Color.green; 
            GizmosDrawer.DrawBezierCurve(curve);
        }
    }
}
