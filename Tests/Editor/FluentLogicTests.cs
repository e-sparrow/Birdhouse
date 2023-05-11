using System.Collections.Generic;
using System.Linq;
using Birdhouse.Common.Helpers;
using Birdhouse.Features.FluentLogics;
using NUnit.Framework;
using Debug = UnityEngine.Debug;

namespace Birdhouse.Tests.Editor
{
    public class FluentLogicTests
    {
        [Test]
        public void TestFluentLogic()
        {
            ESizeResult result = ESizeResult.None;
            var list = new List<int>();
            
            CheckTooMuch();
            CheckTooFew();
            CheckOkay();

            void CheckTooMuch()
            {
                list.Clear();
                list.AddRange(Enumerable.Repeat(0, 11));
                
                CheckFor(ESizeResult.TooMuch);
            }

            void CheckTooFew()
            {
                list.Clear();
                list.Add(0);
                
                CheckFor(ESizeResult.TooFew);
            }

            void CheckOkay()
            {
                list.Clear();
                list.AddRange(Enumerable.Repeat(0, 5));
                
                CheckFor(ESizeResult.Okay);
            }

            void CheckFor(ESizeResult expectedResult)
            {
                var normalTime = DiagnosticHelper.MeasureExecutionTime(ExecuteNormal);
                Assert.IsTrue(result == expectedResult);
                
                Debug.Log($"Execution time with normal conditional constructions is {normalTime.TotalMilliseconds} ms");
                
                var fluentTime = DiagnosticHelper.MeasureExecutionTime(Execute);
                Assert.IsTrue(result == expectedResult);
                
                Debug.Log($"Execution time with fluent conditional constructions is {fluentTime.TotalMilliseconds} ms");
            }

            void ExecuteNormal()
            {
                if (list.Count > 10)
                {
                    NotifyTooMuch();
                }
                else if (list.Count < 5)
                {
                    NotifyTooFew();
                }
                else
                {
                    NotifyOkay();
                }
            }

            void Execute()
            {
                FluentLogic.If(() => list.Count > 10).So(NotifyTooMuch)
                    .ElseIf(() => list.Count < 5).So(NotifyTooFew)
                    .Else().So(NotifyOkay);
            }

            void NotifyTooMuch()
            {
                result = ESizeResult.TooMuch;
                Debug.Log($"It's too much values in list");
            }

            void NotifyTooFew()
            {
                result = ESizeResult.TooFew;
                Debug.Log("It's too few values in list");
            }

            void NotifyOkay()
            {
                result = ESizeResult.Okay;
                Debug.Log($"Nice, no fault");
            }
        }

        [Test]
        public void TestGenericFluentLogic()
        {
            var list = new List<int>();
            
            CheckTooMuch();
            CheckTooFew();
            CheckOkay();

            void CheckTooMuch()
            {
                list.Clear();
                list.AddRange(Enumerable.Repeat(0, 11));
                
                CheckFor(ESizeResult.TooMuch);
            }

            void CheckTooFew()
            {
                list.Clear();
                list.Add(0);
                
                CheckFor(ESizeResult.TooFew);
            }

            void CheckOkay()
            {
                list.Clear();
                list.AddRange(Enumerable.Repeat(0, 5));
                
                CheckFor(ESizeResult.Okay);
            }

            void CheckFor(ESizeResult expectedResult)
            {
                var result = FluentLogic<ESizeResult>
                    .If(() => list.Count > 10).SoReturn(() => ESizeResult.TooMuch)
                    .ElseIf(() => list.Count < 5).SoReturn(() => ESizeResult.TooFew)
                    .Else().SoReturn(() => ESizeResult.Okay);

                Assert.IsTrue(result == expectedResult);
            }
        }

        private enum ESizeResult
        {
            None,
            TooMuch,
            TooFew,
            Okay
        }
    }
}