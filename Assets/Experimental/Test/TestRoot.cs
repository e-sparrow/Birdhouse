using ESparrow.Utils.Drawers;
using ESparrow.Utils.Drawers.Adapters.AsGizmos;
using ESparrow.Utils.Drawers.Interfaces;
using UnityEngine;

namespace ESparrow.Utils.Test
{
    public class TestRoot : MonoBehaviour
    {
        [SerializeField] private ConversionTestModule conversionTestModule;
        [SerializeField] private MemoizationTestModule memoizationTestModule;
        [SerializeField] private ReflectionTestModule reflectionTestModule;
        [SerializeField] private SubstitutionTestModule substitutionTestModule;
        
        [SerializeField] private bool drawTestGizmos;

        private IDrawer _gizmosDrawer = new GizmosDrawer(100);

        [ContextMenu("Test Conversion")]
        private void TestOperators()
        {
            conversionTestModule.Test();    
        }

        [ContextMenu("Test Memoization")]
        private void TestMemoization()
        {
            memoizationTestModule.Test();
        }

        [ContextMenu("Test Reflection")]
        private void TestReflection()
        {
            reflectionTestModule.Test();
        }
        
        [ContextMenu("Test Substitution")]
        private void TestSubstitution()
        {
            substitutionTestModule.Test();
        }

        private void OnDrawGizmos()
        {
            if (!drawTestGizmos) return;

            var rect = new RectToDrawableAdapter(new Rect(new Vector2(), new Vector2(100, 100)));
        }

        private ConversionTestModule ConversionTestModule => conversionTestModule;
        public MemoizationTestModule MemoizationTestModule => memoizationTestModule;
    }
}