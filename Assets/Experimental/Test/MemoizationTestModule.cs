using System;
using ESparrow.Utils.Extensions;
using UnityEngine;

namespace ESparrow.Utils.Test
{
    [Serializable]
    public class MemoizationTestModule : TestModuleBase
    {
        [SerializeField] private int number;
        
        public override void Test()
        {
            var pureFunction = new Func<int, int>(GetFactorial).AsPure();
            for (int i = 0; i < 3; i++)
            {
                var elapsed = DiagnosticHelper.MeasureExecutionTicks(DoFactorial);
                Debug.Log($"{"[MemoizationTest]".WithColor(Color.cyan).Bold()} Attempt {i + 1}: elapsed {elapsed} ticks");

                void DoFactorial()
                {
                    var result = pureFunction.Invoke(number);
                    Debug.Log($"{"[MemoizationTest]".WithColor(Color.cyan)} Factorial of {number} is {result}");
                }
            }
        }

        private int GetFactorial(int value)
        {
            return value.Factorial();
        }
    }
}