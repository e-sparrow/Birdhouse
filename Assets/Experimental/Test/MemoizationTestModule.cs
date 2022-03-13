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
            var elapsedDirty = DiagnosticHelper.MeasureExecutionTicks(DoFactorialDefault);
            Debug.Log($"{"[MemoizationTest]".WithColor(Color.cyan).Bold()} Default function: elapsed {elapsedDirty} ticks");
            
            var pureFunction = new Func<int, int>(GetFactorial).AsPure();
            for (int i = 0; i < 3; i++)
            {
                var elapsedPure = DiagnosticHelper.MeasureExecutionTicks(DoFactorialPure);
                Debug.Log($"{"[MemoizationTest]".WithColor(Color.cyan).Bold()} PureFunction Attempt {i + 1}: elapsed {elapsedPure} ticks");

                void DoFactorialPure()
                {
                    var result = pureFunction.Invoke(number);
                    Debug.Log($"{"[MemoizationTest]".WithColor(Color.cyan)} Factorial of {number} is {result}");
                }
            }

            void DoFactorialDefault()
            {
                var result = GetFactorial(number);
                Debug.Log($"{"[MemoizationTest]".WithColor(Color.cyan)} Factorial of {number} is {result}");
            }
        }

        private int GetFactorial(int value)
        {
            return value.Factorial();
        }
    }
}