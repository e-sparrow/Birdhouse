using System;
using System.Reflection;
using ESparrow.Utils.Extensions;
using UnityEngine;

namespace ESparrow.Utils.Test
{
    [Serializable]
    public class ReflectionTestModule : TestModuleBase
    {
        public override void Test()
        {
            var pureGetMethods = new Func<Type, MethodInfo[]>(GetMethods).AsPure();

            Debug.Log(DiagnosticHelper.MeasureExecutionTicks(() => GetMethods(typeof(Type))) + " - default");

            for (int i = 0; i < 10; i++)
            {
                Debug.Log(DiagnosticHelper.MeasureExecutionTicks(() => pureGetMethods.Invoke(typeof(Type))) + $" - pure {i + 1}");
            }

            MethodInfo[] GetMethods(Type type)
            {
                return type.GetMethods();
            }
        }
    }
}