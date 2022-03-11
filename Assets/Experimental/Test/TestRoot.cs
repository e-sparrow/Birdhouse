using System;
using ESparrow.Utils.Drawers;
using ESparrow.Utils.Drawers.Adapters.AsGizmos;
using ESparrow.Utils.Drawers.Interfaces;
using ESparrow.Utils.Helpers;
using ESparrow.Utils.Reflection.Operators;
using UnityEngine;

namespace ESparrow.Utils.Experimental
{
    public class TestRoot : MonoBehaviour
    {
        [SerializeField] private ConversionTestModule conversionTestModule;
        
        [SerializeField] private bool drawTestGizmos;

        private IDrawer _gizmosDrawer = new GizmosDrawer(100);

        [ContextMenu("Test Operators")]
        private void TestOperators()
        {
            var operatorTest = new OperatorTest();
            var type = operatorTest.GetType();
            var infos =  ReflectionHelper.OperatorHelper.GetAllOperatorInfos(type);
        }

        private void OnDrawGizmos()
        {
            if (!drawTestGizmos) return;

            var rect = new RectToDrawableAdapter(new Rect(new Vector2(), new Vector2(100, 100)));
        }
    }
}